using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Linq; // Random.NextDouble için

namespace ScadaEnerjiIzlemeOtomasyonu
{
    public partial class Form1 : Form
    {
        // --- SİSTEM DEĞİŞKENLERİ ---
        private Timer dataUpdateTimer;
        private SerialPort serialPort;
        private bool sistemAktif = false;

        // --- TEST VERİSİ İÇİN YENİ DEĞİŞKENLER ---
        private DateTime sonGercekVeriZamani = DateTime.MinValue;
        private const int TEST_VERISI_BEKLEME_SANIYE = 5;
        private Random random = new Random();
        // --- TEST VERİSİ İÇİN YENİ DEĞİŞKENLER SONU ---

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

        // --- GERÇEKÇİ PANEL MAX DEĞERLERİ (300W Panel Örneği) ---
        private const double MAX_GUNES = 1200.0; // W/m²
        private const double MAX_VOLT = 40.0; // Panel Açık Devre Voltajı (Voc) için üst sınır V
        private const double MAX_AKIM = 10.0; // Panel Kısa Devre Akımı (Isc) için üst sınır A
        private const double PANEL_ALANI = 2.0; // 1 Panel yaklaşık 2m2

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

                        // Bağlantı açıldığında son veri zamanını sıfırla
                        sonGercekVeriZamani = DateTime.Now;

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

                            // Gerçek veri alındığında zamanı güncelle
                            sonGercekVeriZamani = DateTime.Now;
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

        // --- TEST VERİSİ ÜRETEN METOD (Gerçekçi Panel Değerlerine Göre Güncellendi) ---
        private void GenerateTestData()
        {
            // Güneş (200 - 1000 W/m² arasında rastgele)
            sonGelenGunes = 200 + random.NextDouble() * 800;

            // Voltaj (Panel MPPT Voltajı civarında: 28V - 38V arasında rastgele)
            sonGelenVolt = 28 + random.NextDouble() * 10;

            // Akım (Panel MPPT Akımı civarında: 3A - 9A arasında rastgele)
            sonGelenAkim = 3 + random.NextDouble() * 6;
        }
        // --- TEST VERİSİ ÜRETEN METOD SONU ---

        // --- ZAMANLAYICI TİK ---
        private void DataUpdateTimer_Tick(object sender, EventArgs e)
        {
            calismaZamani++;
            TimeSpan ts = TimeSpan.FromSeconds(calismaZamani);
            lblCalismaZamani.Text = $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";

            // --- TEST VERİSİ KONTROLÜ VE ÜRETİMİ ---
            if (sistemAktif)
            {
                // Son gerçek verinin üzerinden 5 saniyeden fazla zaman geçtiyse
                if ((DateTime.Now - sonGercekVeriZamani).TotalSeconds > TEST_VERISI_BEKLEME_SANIYE)
                {
                    GenerateTestData();
                    // Log mesajını tekrar kontrol etmeye gerek yok, GenerateTestData'dan sonra UpdateUI çağrılıyor.
                    LogMesaj("UYARI: Gerçek veri gelmiyor! Test verisi kullanılıyor.", Color.Purple);
                }
                else
                {
                    // Log mesajını tekrar kontrol et ve gerçek veriyi logla
                    // Sadece veri geldiğinde loglanması daha mantıklı (ParseData'da yapılıyor), burayı log spam'ini azaltmak için pasif bırakıyoruz
                    // LogMesaj("Gerçek veri geliyor.", Color.Black); 
                }
            }
            // --- TEST VERİSİ KONTROLÜ VE ÜRETİMİ SONU ---

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
            else if (guc < 50) // 300W panel için 50W altı düşük üretim sayılabilir.
            {
                durum = "UYARI: Düşük Üretim";
                renk = Color.Orange;
            }
            else if (verimlilik < 10)
            {
                durum = "Düşük Verimlilik";
                renk = Color.Orange;
            }
            else if (verimlilik >= 15) // Tipik panel verimliliği %15-20 arası
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
            double voltajGoster = sonGelenVolt;
            lblGuvenlik.Text = $"{voltajGoster:F2} V";

            // Bar doluluğu: MAX_VOLT üzerinden hesaplıyoruz.
            int voltBar = (int)((voltajGoster / MAX_VOLT) * 100);
            progressGuvenlik.Value = Math.Min(Math.Max(voltBar, 0), 100);

            // --- AKIM GÖSTERİMİ ---
            double akimGoster = sonGelenAkim;
            lblAnlikGuc.Text = $"{akimGoster:F2} A";

            // Bar doluluğu: MAX_AKIM üzerinden hesaplıyoruz. 
            int akimBar = (int)((akimGoster / MAX_AKIM) * 100);
            progressGuc.Value = Math.Min(Math.Max(akimBar, 0), 100);

            // --- GÜNEŞ GÖSTERİMİ ---
            lblRuzgarHizi.Text = $"{sonGelenGunes:F0} W/m²";
            // MAX_GUNES üzerinden hesaplıyoruz.
            int gunesBar = (int)((sonGelenGunes / MAX_GUNES) * 100);
            progressRuzgar.Value = Math.Min(Math.Max(gunesBar, 0), 100);

            // Verimlilik Hesaplama
            double panelAlani = PANEL_ALANI;
            double uretilenGuc = Math.Abs(voltajGoster * akimGoster); // Watt
            double gelenIsınimGucu = sonGelenGunes * panelAlani; // Watt

            double verimlilik = 0;
            if (gelenIsınimGucu > 100)
            {
                verimlilik = (uretilenGuc / gelenIsınimGucu) * 100;
            }
            if (verimlilik > 100) verimlilik = 99.9; // Hata veya simülasyon aşırı değerleri

            lblVerimlilik.Text = $"{verimlilik:F1} %";
            lblVerimlilik.ForeColor = verimlilik > 15 ? Color.Green :
                                     verimlilik > 10 ? Color.Orange : Color.Red;

            // İstatistik
            toplamEnerji += uretilenGuc / 3600000; // kWh (1 saniyede üretilen enerji)
            lblToplamEnerji.Text = $"{toplamEnerji:F4} kWh";
            lblSonGuncelleme.Text = $"Veri: {DateTime.Now:HH:mm:ss}";

            UpdateSystemDurum(verimlilik, uretilenGuc);

            // Log Kaydı (Detaylı loglama için)
            // LogMesaj($"G:{sonGelenGunes:F0} V:{voltajGoster:F1} A:{akimGoster:F1}", Color.Black);

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

        // --- GRAFİK ÇİZİM ALANI (Eksen Değerleri Güncellendi) ---
        private void PanelGrafik_Paint(object sender, PaintEventArgs e)
        {
            // 

            if (ruzgarHiziData.Count < 2) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int w = panelGrafik.Width;
            int h = panelGrafik.Height;

            // Başlık alanı için boşluk (lblGrafikBaslik 40px)
            int topMargin = 50;
            int bottomMargin = 50;
            int leftMargin = 60;
            int rightMargin = 80;

            int chartWidth = w - leftMargin - rightMargin;
            int chartHeight = h - topMargin - bottomMargin;

            // === ARKA PLAN ===
            g.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)),
                leftMargin, topMargin, chartWidth, chartHeight);

            // === EKSEN ÇİZGİLERİ ===
            Pen axisPen = new Pen(Color.FromArgb(80, 80, 80), 2);
            // Sol dikey eksen
            g.DrawLine(axisPen, leftMargin, topMargin, leftMargin, topMargin + chartHeight);
            // Alt yatay eksen
            g.DrawLine(axisPen, leftMargin, topMargin + chartHeight,
                leftMargin + chartWidth, topMargin + chartHeight);

            // === IZGARA VE Y EKSENİ DEĞERLERİ ===
            Pen gridPen = new Pen(Color.FromArgb(220, 220, 220), 1);
            gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Font labelFont = new Font("Segoe UI", 8, FontStyle.Regular);
            Brush labelBrush = new SolidBrush(Color.FromArgb(80, 80, 80));

            // Sol Y ekseni (Güneş değerleri W/m²) (Max 1200)
            string[] yGunesLabels = { "1200", "1000", "800", "600", "400", "200", "0" };
            for (int i = 0; i < yGunesLabels.Length; i++)
            {
                float y = topMargin + (chartHeight / (yGunesLabels.Length - 1f)) * i;
                g.DrawLine(gridPen, leftMargin, y, leftMargin + chartWidth, y);

                // Güneş değerleri (W/m²) - MAVİ
                g.DrawString(yGunesLabels[i], labelFont, Brushes.Blue, 5, y - 8);
            }

            // Sağ taraf Y ekseni (Voltaj ve Akım için)
            // Akım (A) için etiketler (Max 10A)
            string[] akimLabels = { "10 A", "8 A", "6 A", "4 A", "2 A", "0 A" };
            for (int i = 0; i < akimLabels.Length; i++)
            {
                float y = topMargin + (chartHeight / (akimLabels.Length - 1f)) * i;
                g.DrawString(akimLabels[i], labelFont, Brushes.Red,
                    leftMargin + chartWidth + 5, y - 8);
            }

            // Voltaj (V) için etiketler (Max 40V)
            string[] voltLabels = { "40 V", "35 V", "30 V", "25 V", "20 V", "15 V", "10 V", "5 V", "0 V" };
            // Grafiğin sol tarafına orantısal olarak yerleştirilebilir, ancak karışıklığı önlemek için genellikle tek bir sağ eksen kullanılır.
            // Bu örnekte Voltaj ve Akım için MAX_VOLT ve MAX_AKIM değerleri farklı olsa da, çizim yardımcısı kendi max değerini kullanacaktır.
            // Grafikte Akım için sağ ekseni kullanıp, Voltaj için etiketleri başka bir yere koymak ya da tek bir normalize eksen kullanmak daha iyi olur.
            // Şimdilik sadece Akım etiketlerini sağa koyalım, Voltaj için sol Güneş eksenini kullanıp normalizasyon yapalım (veya daha basiti Akım ve Voltajı ayrı ayrı normalize edelim.)
            // İkinci bir sağ eksen etiketini Akım için, ilkini Voltaj için yapalım:

            // Voltaj (V) için etiketler (Max 40V) - YEŞİL
            string[] voltLabelsG = { "40 V", "30 V", "20 V", "10 V", "0 V" };
            for (int i = 0; i < voltLabelsG.Length; i++)
            {
                float y = topMargin + (chartHeight / (voltLabelsG.Length - 1f)) * i;
                g.DrawString(voltLabelsG[i], labelFont, Brushes.Green,
                    leftMargin + chartWidth + 5, y - 8);
            }


            // === X EKSENİ (ZAMAN) ===
            Font timeFont = new Font("Segoe UI", 7, FontStyle.Regular);
            int timeStep = MAX_DATA_POINTS / 5;
            for (int i = 0; i <= 5; i++)
            {
                float x = leftMargin + (chartWidth / 5f) * i;
                int saniyeOnce = (5 - i) * 10;
                g.DrawString($"-{saniyeOnce}s", timeFont, labelBrush, x - 15, topMargin + chartHeight + 5);
            }

            // === VERİ ÇİZGİLERİ (MAX değerleri değiştirildi) ===
            // MAVİ: Güneş Işınımı (0-MAX_GUNES W/m²)
            DrawDataLineWithAxis(g, ruzgarHiziData.ToArray(), Color.Blue,
                leftMargin, topMargin, chartWidth, chartHeight, MAX_GUNES, 3);

            // YEŞİL: Voltaj (0-MAX_VOLT V)
            DrawDataLineWithAxis(g, guvenlikData.ToArray(), Color.Green,
                leftMargin, topMargin, chartWidth, chartHeight, MAX_VOLT, 3);

            // KIRMIZI: Akım (0-MAX_AKIM A)
            DrawDataLineWithAxis(g, enerjiUretimiData.ToArray(), Color.Red,
                leftMargin, topMargin, chartWidth, chartHeight, MAX_AKIM, 3);

            // === LEJANT (SAĞ ÜST) ===
            int legendX = leftMargin + chartWidth - 200;
            int legendY = topMargin + 10;
            int legendWidth = 185;
            int legendHeight = 95;

            g.FillRectangle(new SolidBrush(Color.FromArgb(240, Color.White)),
                legendX, legendY, legendWidth, legendHeight);
            g.DrawRectangle(new Pen(Color.FromArgb(150, 150, 150), 1),
                legendX, legendY, legendWidth, legendHeight);

            Font legendFont = new Font("Segoe UI", 9, FontStyle.Bold);
            int lineY = legendY + 15;

            // Güneş
            g.DrawLine(new Pen(Color.Blue, 4), legendX + 10, lineY, legendX + 35, lineY);
            g.DrawString($"☀️ Güneş: {sonGelenGunes:F0} W/m²", legendFont, Brushes.Black, legendX + 40, lineY - 8);

            // Voltaj
            lineY += 30;
            g.DrawLine(new Pen(Color.Green, 4), legendX + 10, lineY, legendX + 35, lineY);
            g.DrawString($"⚡ Voltaj: {sonGelenVolt:F1} V", legendFont, Brushes.Black, legendX + 40, lineY - 8);

            // Akım
            lineY += 30;
            g.DrawLine(new Pen(Color.Red, 4), legendX + 10, lineY, legendX + 35, lineY);
            g.DrawString($"🔌 Akım: {sonGelenAkim:F1} A", legendFont, Brushes.Black, legendX + 40, lineY - 8);

            // === EKSEN ETİKETLERİ ===
            Font axisLabelFont = new Font("Segoe UI", 10, FontStyle.Bold);

            // Y ekseni etiketi (sol)
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // Sol dikey yazı (90 derece döndürülmüş)
            g.TranslateTransform(15, topMargin + chartHeight / 2);
            g.RotateTransform(-90);
            g.DrawString("Güneş Işınımı (W/m²)", axisLabelFont, Brushes.Blue, 0, 0, sf);
            g.ResetTransform();

            // Sağ dikey yazı (90 derece döndürülmüş)
            g.TranslateTransform(leftMargin + chartWidth + 70, topMargin + chartHeight / 2);
            g.RotateTransform(90);
            g.DrawString("Voltaj (V) / Akım (A)", axisLabelFont, Brushes.DarkGreen, 0, 0, sf);
            g.ResetTransform();

            // X ekseni etiketi
            g.DrawString("Zaman (saniye)", axisLabelFont, labelBrush,
                leftMargin + chartWidth / 2 - 60, topMargin + chartHeight + 30);
        }

        // Yeni çizim yardımcısı - Eksen ve margin'ler ile
        private void DrawDataLineWithAxis(Graphics g, double[] data, Color color, int left, int top, int width, int height, double maxVal, int lineWidth)
        {
            if (data.Length < 2) return;
            Pen p = new Pen(color, lineWidth);
            float xStep = (float)width / (MAX_DATA_POINTS - 1);

            for (int i = 0; i < data.Length - 1; i++)
            {
                // Veriyi kendi tavan değerine (maxVal) göre oranla
                // Güneş ve Voltaj/Akım kendi maksimum değerleriyle normalize edilmeli
                float y1 = top + height - (float)(Math.Min(data[i], maxVal) / maxVal * height * 0.95f);
                float y2 = top + height - (float)(Math.Min(data[i + 1], maxVal) / maxVal * height * 0.95f);

                float x1 = left + i * xStep;
                float x2 = left + (i + 1) * xStep;

                g.DrawLine(p, x1, y1, x2, y2);
            }
        }

        // --- LOG VE YARDIMCILAR ---
        private void LogMesaj(string msj, Color renk)
        {
            if (listBoxLog.InvokeRequired) { this.Invoke((MethodInvoker)delegate { LogMesaj(msj, renk); }); return; }

            // Eğer son mesaj aynıysa (gerçek veri/test verisi durumu) tekrar eklemesin
            if (listBoxLog.Items.Count > 0)
            {
                string sonItem = listBoxLog.Items[0].ToString();
                if (msj.Contains("Test verisi kullanılıyor.") && sonItem.Contains("Test verisi kullanılıyor."))
                    return;
                if (msj.Contains("Gerçek veri geliyor.") && sonItem.Contains("Gerçek veri geliyor."))
                    return;
            }

            listBoxLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {msj}");
            if (listBoxLog.Items.Count > 50) listBoxLog.Items.RemoveAt(listBoxLog.Items.Count - 1);
        }

        private void UpdateSystemStatus(bool aktif)
        {
            btnBaglan.Text = aktif ? "Bağlantıyı Kes" : "Bağlan";
            btnBaglan.BackColor = aktif ? Color.Red : Color.Green;
            cmbComPort.Enabled = !aktif;
            if (!aktif) { lblBaglantiDurum.Text = "BAĞLI DEĞİL"; lblBaglantiDurum.ForeColor = Color.Red; }
            else { lblBaglantiDurum.Text = "BAĞLI"; lblBaglantiDurum.ForeColor = Color.Green; } // Bağlı durumu eklendi
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