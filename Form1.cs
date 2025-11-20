using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

namespace ScadaEnerjiIzlemeOtomasyonu
{
    public partial class Form1 : Form
    {
        // --- SİSTEM DEĞİŞKENLERİ ---
        private Timer dataUpdateTimer;
        private SerialPort serialPort;
        private bool sistemAktif = false;

        // --- VERİ DEPOLARI (HAVUZ) ---
        private Queue<double> ruzgarHiziData = new Queue<double>(); // MAVİ (Güneş)
        private Queue<double> guvenlikData = new Queue<double>();   // YEŞİL (Voltaj)
        private Queue<double> enerjiUretimiData = new Queue<double>(); // KIRMIZI (Akım)

        // Anlık son gelen değerler
        private double sonGelenGunes = 0;
        private double sonGelenVolt = 0;
        private double sonGelenAkim = 0;

        // --- İSTATİSTİKLER VE AYARLAR ---
        private const int MAX_DATA_POINTS = 50; // Grafikte kaç nokta olsun
        private double toplamEnerji = 0;
        private int calismaZamani = 0;

        // Gelen veri tamponu
        private string gelenVeriTamponu = "";

        public Form1()
        {
            InitializeComponent();
            InitializeSystem();
        }

        private void InitializeSystem()
        {
            // Timer: 1 Saniyede 1 Kere çalışır
            dataUpdateTimer = new Timer();
            dataUpdateTimer.Interval = 1000;
            dataUpdateTimer.Tick += DataUpdateTimer_Tick;

            lblRuzgarBaslik.Text = "Güneş Işınımı:";
            lblGuvenlikBaslik.Text = "Panel Voltajı:";
            lblGucBaslik.Text = "Panel Akımı:";

            // Port Ayarları
            string[] ports = SerialPort.GetPortNames();
            cmbComPort.Items.AddRange(ports);
            if (cmbComPort.Items.Count > 0) cmbComPort.SelectedIndex = 0;

            cmbBaudRate.Items.AddRange(new object[] { "9600", "19200" });
            cmbBaudRate.SelectedIndex = 0;

            UpdateSystemStatus(false);
            lblSonGuncelleme.Text = "Son Güncelleme: --:--:--";
            CheckForIllegalCrossThreadCalls = false;
        }

        // --- BAĞLANTIYI AÇ/KAPA ---
        private void BtnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!sistemAktif)
                {
                    if (cmbComPort.SelectedItem != null)
                    {
                        serialPort = new SerialPort();
                        serialPort.PortName = cmbComPort.SelectedItem.ToString();
                        serialPort.BaudRate = 9600;
                        serialPort.DataReceived += SerialPort_DataReceived;
                        serialPort.Open();

                        dataUpdateTimer.Start();
                        sistemAktif = true;
                        UpdateSystemStatus(true);
                        LogMesaj($"Bağlantı sağlandı: {serialPort.PortName}", Color.Green);
                    }
                }
                else
                {
                    dataUpdateTimer.Stop();
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        serialPort.Close();
                        serialPort.Dispose();
                    }
                    sistemAktif = false;
                    UpdateSystemStatus(false);
                    LogMesaj("Sistem durduruldu.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // --- VERİ OKUMA ---
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen) return;

                string hamVeri = serialPort.ReadExisting();
                gelenVeriTamponu += hamVeri;

                if (gelenVeriTamponu.Contains("\n"))
                {
                    string[] satirlar = gelenVeriTamponu.Split('\n');
                    gelenVeriTamponu = satirlar[satirlar.Length - 1];

                    for (int i = 0; i < satirlar.Length - 1; i++)
                    {
                        string temizSatir = satirlar[i].Trim();
                        if (!string.IsNullOrEmpty(temizSatir))
                        {
                            ParseData(temizSatir);
                        }
                    }
                }
            }
            catch { }
        }

        // --- VERİYİ AYIKLA ---
        private void ParseData(string data)
        {
            try
            {
                // Simulink formatı: GUNES:1000.0;VOLT:230.7;AKIM:12.5
                // Noktalı virgül veya boşluk ayrımına karşı önlem
                string[] parts = data.Contains(";") ? data.Split(';') : data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts)
                {
                    string[] kv = part.Split(':');
                    if (kv.Length == 2)
                    {
                        string valStr = kv[1].Replace(',', '.'); // Virgülü noktaya çevir
                        if (double.TryParse(valStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double val))
                        {
                            switch (kv[0].ToUpper().Trim())
                            {
                                case "G":
                                case "GUNES": sonGelenGunes = val; break;
                                case "V":
                                case "VOLT": sonGelenVolt = val; break;
                                case "A":
                                case "AKIM": sonGelenAkim = val; break;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        // --- ZAMANLAYICI TİK ---
        private void DataUpdateTimer_Tick(object sender, EventArgs e)
        {
            calismaZamani++;
            TimeSpan ts = TimeSpan.FromSeconds(calismaZamani);
            lblCalismaZamani.Text = $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";
            UpdateUI();
        }

        private void UpdateSystemDurum(double verimlilik, double guc)
        {
            string durum = "Bekleniyor";
            Color renk = Color.Gray;

            if (!sistemAktif)
            {
                durum = "BAĞLI DEĞİL";
                renk = Color.Red;
            }
            else if (guc < 1)
            {
                durum = "UYARI: Düşük Üretim";
                renk = Color.Orange;
            }
            else if (verimlilik < 10)
            {
                durum = "Düşük Verimlilik";
                renk = Color.Orange;
            }
            else if (verimlilik >= 15)
            {
                durum = "Optimal Çalışıyor ✓";
                renk = Color.Green;
            }
            else
            {
                durum = "Normal Çalışıyor";
                renk = Color.DarkGreen;
            }

            lblDurum.Text = durum;
            lblDurum.ForeColor = renk;
        }

        // --- ARAYÜZ GÜNCELLEME ---
        private void UpdateUI()
        {
            // Eksi değer kontrolü (0'a sabitle)
            if (sonGelenGunes < 0) sonGelenGunes = 0;
            if (sonGelenVolt < 0) sonGelenVolt = 0;
            if (sonGelenAkim < 0) sonGelenAkim = 0;

            // --- VOLTAJ GÖSTERİMİ ---
            // Gerçek değeri yazdırıyoruz (Örn: 230.7 V)
            double voltajGoster = sonGelenVolt;
            lblGuvenlik.Text = $"{voltajGoster:F2} V";

            // Bar doluluğu: 280V üzerinden hesaplıyoruz ki 230V gelince bar %80 dolsun.
            int voltBar = (int)((voltajGoster / 280.0) * 100);
            progressGuvenlik.Value = Math.Min(Math.Max(voltBar, 0), 100);

            // --- AKIM GÖSTERİMİ ---
            double akimGoster = sonGelenAkim;
            lblAnlikGuc.Text = $"{akimGoster:F2} A";

            // Bar doluluğu: 20A üzerinden hesaplıyoruz. 
            // (Simulink'teki tek panel için 10-15A arası tepe değerdir).
            int akimBar = (int)((akimGoster / 20.0) * 100);
            progressGuc.Value = Math.Min(Math.Max(akimBar, 0), 100);

            // --- GÜNEŞ GÖSTERİMİ ---
            lblRuzgarHizi.Text = $"{sonGelenGunes:F0} W/m²";
            // 1200 üzerinden hesaplıyoruz ki 1000 gelince bar %83 dolsun.
            int gunesBar = (int)((sonGelenGunes / 1200.0) * 100);
            progressRuzgar.Value = Math.Min(Math.Max(gunesBar, 0), 100);

            // Verimlilik Hesaplama
            double panelAlani = 2.0; // 1 Panel yaklaşık 2m2
            double uretilenGuc = Math.Abs(voltajGoster * akimGoster); // Watt
            double gelenIsınimGucu = sonGelenGunes * panelAlani; // Watt

            double verimlilik = 0;
            if (gelenIsınimGucu > 100)
            {
                verimlilik = (uretilenGuc / gelenIsınimGucu) * 100;
            }
            if (verimlilik > 100) verimlilik = 99.9;

            lblVerimlilik.Text = $"{verimlilik:F1} %";
            lblVerimlilik.ForeColor = verimlilik > 15 ? Color.Green :
                                      verimlilik > 10 ? Color.Orange : Color.Red;

            // İstatistik
            toplamEnerji += uretilenGuc / 3600000; // kWh
            lblToplamEnerji.Text = $"{toplamEnerji:F4} kWh";
            lblSonGuncelleme.Text = $"Veri: {DateTime.Now:HH:mm:ss}";

            UpdateSystemDurum(verimlilik, uretilenGuc);

            // Log Kaydı
            LogMesaj($"G:{sonGelenGunes:F0} V:{voltajGoster:F1} A:{akimGoster:F1}", Color.Black);

            // Grafiğe Ekle
            AddChartData(sonGelenGunes, voltajGoster, akimGoster);
            UpdateChart();
        }

        // --- GRAFİK VERİ EKLEME ---
        private void AddChartData(double v1, double v2, double v3)
        {
            ruzgarHiziData.Enqueue(v1);
            guvenlikData.Enqueue(v2);
            enerjiUretimiData.Enqueue(v3);

            while (ruzgarHiziData.Count > MAX_DATA_POINTS)
            {
                ruzgarHiziData.Dequeue(); guvenlikData.Dequeue(); enerjiUretimiData.Dequeue();
            }
        }

        private void UpdateChart() { panelGrafik.Invalidate(); }

        // --- GRAFİK ÇİZİM ALANI ---
        private void PanelGrafik_Paint(object sender, PaintEventArgs e)
        {
            if (ruzgarHiziData.Count < 2) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.WhiteSmoke);
            int w = panelGrafik.Width, h = panelGrafik.Height;

            // Izgara Çizimi
            Pen gridPen = new Pen(Color.LightGray, 1);
            Font gridFont = new Font("Arial", 7, FontStyle.Regular);
            Brush textBrush = new SolidBrush(Color.DarkGray);

            // Dikey Izgara
            for (int i = 0; i <= 10; i++)
            {
                float x = (w / 10f) * i;
                g.DrawLine(gridPen, x, 0, x, h);
            }

            // Yatay Izgara
            for (int i = 0; i <= 8; i++)
            {
                float y = (h / 8f) * i;
                g.DrawLine(gridPen, 0, y, w, y);
                if (i % 2 == 0)
                {
                    int percent = 100 - (i * 100 / 8);
                    g.DrawString($"{percent}%", gridFont, textBrush, 2, y - 8);
                }
            }

            // --- GRAFİK ÇİZGİLERİ VE GÖRSEL ÖLÇEKLENDİRME ---
            // Simulink şemasındaki değerleri grafikte YAN YANA göstermek için özel tavan (Max) değerleri:

            // MAVİ (Güneş): 1000 değeri için 1200 tavan. (Grafiğin üstünde)
            DrawDataLine(g, ruzgarHiziData.ToArray(), Color.Blue, w, h, 1200);

            // YEŞİL (Voltaj): 230V değeri için 280 tavan. (Bu sayede 230V, 1000 Güneş ile aynı hizada durur)
            DrawDataLine(g, guvenlikData.ToArray(), Color.Green, w, h, 80);

            // KIRMIZI (Akım): Şemadaki panel için 20A tavan. (Akım geldiğinde o da yukarı fırlar)
            DrawDataLine(g, enerjiUretimiData.ToArray(), Color.Red, w, h, 100);


            // --- LEJANT (BİLGİ KUTUSU) ---
            int legendX = w - 150;
            int legendY = 75;
            g.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.White)), legendX - 5, legendY - 5, 145, 70);
            g.DrawRectangle(new Pen(Color.Gray), legendX - 5, legendY - 5, 145, 70);

            g.DrawLine(new Pen(Color.Blue, 3), legendX, legendY + 5, legendX + 20, legendY + 5);
            g.DrawString("Güneş (0-1200)", gridFont, Brushes.Black, legendX + 25, legendY);

            g.DrawLine(new Pen(Color.Green, 3), legendX, legendY + 25, legendX + 20, legendY + 25);
            g.DrawString("Voltaj (0-280)", gridFont, Brushes.Black, legendX + 25, legendY + 20);

            g.DrawLine(new Pen(Color.Red, 3), legendX, legendY + 45, legendX + 20, legendY + 45);
            g.DrawString("Akım (0-20)", gridFont, Brushes.Black, legendX + 25, legendY + 40);
        }

        // Çizim Yardımcısı
        private void DrawDataLine(Graphics g, double[] data, Color color, int w, int h, double maxVal)
        {
            if (data.Length < 2) return;
            Pen p = new Pen(color, 2);
            float xStep = (float)w / (MAX_DATA_POINTS - 1);
            for (int i = 0; i < data.Length - 1; i++)
            {
                // Veriyi kendi tavan değerine (maxVal) göre oranla
                float y1 = h - (float)(Math.Min(data[i], maxVal) / maxVal * h * 0.9f);
                float y2 = h - (float)(Math.Min(data[i + 1], maxVal) / maxVal * h * 0.9f);
                g.DrawLine(p, i * xStep, y1, (i + 1) * xStep, y2);
            }
        }

        // --- LOG VE YARDIMCILAR ---
        private void LogMesaj(string msj, Color renk)
        {
            if (listBoxLog.InvokeRequired) { this.Invoke((MethodInvoker)delegate { LogMesaj(msj, renk); }); return; }
            listBoxLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {msj}");
            if (listBoxLog.Items.Count > 50) listBoxLog.Items.RemoveAt(listBoxLog.Items.Count - 1);
        }

        private void UpdateSystemStatus(bool aktif)
        {
            btnBaglan.Text = aktif ? "Bağlantıyı Kes" : "Bağlan";
            btnBaglan.BackColor = aktif ? Color.Red : Color.Green;
            cmbComPort.Enabled = !aktif;
            if (!aktif) { lblBaglantiDurum.Text = "BAĞLI DEĞİL"; lblBaglantiDurum.ForeColor = Color.Red; }
        }

        private void CheckAlarms(double r, double g, double e) { }

        private void BtnSifirla_Click(object sender, EventArgs e)
        {
            toplamEnerji = 0; calismaZamani = 0; lblToplamEnerji.Text = "0.000 kWh";
        }

        private void BtnRaporAl_Click(object sender, EventArgs e)
        {
            try
            {
                string dosyaAdi = $"SCADA_Rapor_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string tamYol = System.IO.Path.Combine(masaustuYolu, dosyaAdi);

                System.Text.StringBuilder rapor = new System.Text.StringBuilder();
                rapor.AppendLine("SCADA RAPORU");
                rapor.AppendLine($"Tarih: {DateTime.Now}");
                rapor.AppendLine($"Güneş: {lblRuzgarHizi.Text}");
                rapor.AppendLine($"Voltaj: {lblGuvenlik.Text}");
                rapor.AppendLine($"Akım: {lblAnlikGuc.Text}");

                System.IO.File.WriteAllText(tamYol, rapor.ToString(), System.Text.Encoding.UTF8);
                MessageBox.Show("Rapor kaydedildi: " + tamYol);
                LogMesaj("Rapor alındı.", Color.Blue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) { if (serialPort != null && serialPort.IsOpen) serialPort.Close(); }
    }
}