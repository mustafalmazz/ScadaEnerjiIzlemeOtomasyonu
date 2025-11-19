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
        // Grafik çizimi için verileri burada biriktireceğiz
        private Queue<double> ruzgarHiziData = new Queue<double>(); // MAVİ (Güneş)
        private Queue<double> guvenlikData = new Queue<double>();   // YEŞİL (Voltaj)
        private Queue<double> enerjiUretimiData = new Queue<double>(); // KIRMIZI (Akım)

        // Anlık son gelen değerler (Ekranda göstermek için)
        private double sonGelenGunes = 0;
        private double sonGelenVolt = 0;
        private double sonGelenAkim = 0;

        // --- İSTATİSTİKLER VE AYARLAR ---
        private const int MAX_DATA_POINTS = 50; // Grafikte kaç nokta olsun
        private double toplamEnerji = 0;
        private int calismaZamani = 0;

        // Gelen veri tamponu (Kesik paketleri birleştirmek için)
        private string gelenVeriTamponu = "";

        public Form1()
        {
            InitializeComponent();
            InitializeSystem();
        }

        private void InitializeSystem()
        {
            // Timer: Artık ekranı güncellemekten sorumlu (1 Saniyede 1 Kere)
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

                        dataUpdateTimer.Start(); // Saat işlemeye başlasın
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

        // --- VERİ OKUMA (ARKA PLAN - ÇOK HIZLI) ---
        // Burası sadece veriyi alır ve değişkenlere kaydeder. Ekranı ellemez.
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen) return;

                string hamVeri = serialPort.ReadExisting();
                gelenVeriTamponu += hamVeri;

                // Satır sonu (\n) gelince işle
                if (gelenVeriTamponu.Contains("\n"))
                {
                    string[] satirlar = gelenVeriTamponu.Split('\n');

                    // Son parça yarım kalmış olabilir, onu sakla
                    gelenVeriTamponu = satirlar[satirlar.Length - 1];

                    // Tamamlanmış satırları işle
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

        // --- VERİYİ AYIKLA VE HAFIZAYA AT ---
        private void ParseData(string data)
        {
            try
            {
                // Gelen: GUNES:1000.0;VOLT:230.7;AKIM:12.5
                string[] parts = data.Split(';');
                foreach (string part in parts)
                {
                    string[] kv = part.Split(':');
                    if (kv.Length == 2)
                    {
                        string valStr = kv[1].Replace(',', '.');
                        if (double.TryParse(valStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double val))
                        {
                            // Sadece değişkenleri güncelliyoruz
                            switch (kv[0].ToUpper().Trim())
                            {
                                case "GUNES": sonGelenGunes = val; break;
                                case "VOLT": sonGelenVolt = val; break;
                                case "AKIM": sonGelenAkim = val; break;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        // --- EKRAN GÜNCELLEME (SANİYEDE 1 KERE) ---
        private void DataUpdateTimer_Tick(object sender, EventArgs e)
        {
            // 1. Saati İlerlet
            calismaZamani++;
            TimeSpan ts = TimeSpan.FromSeconds(calismaZamani);
            lblCalismaZamani.Text = $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";

            // 2. Arayüzü Güncelle (O anki son değerlerle)
            UpdateUI();
        }

        private void UpdateUI()
        {
            // --- TEST MODU İÇİN (SİNÜS DALGALARI) ---
            // Grafikte sinüsleri görmek için çarpanları kaldırdık.
            // Normal moda dönünce buradaki çarpanları tekrar ekleyebilirsin.

            // Güneş
            lblRuzgarHizi.Text = $"{sonGelenGunes:F0} W/m²";
            progressRuzgar.Value = (int)Math.Min(Math.Max(sonGelenGunes / 10, 0), 100);

            // Voltaj
            lblGuvenlik.Text = $"{sonGelenVolt:F2} V";
            // Sinüs dalgası (-1 ile 1) barı doldursun diye: (Değer * 50) + 50
            progressGuvenlik.Value = (int)Math.Min(Math.Max((sonGelenVolt * 50) + 50, 0), 100);

            // Akım
            lblAnlikGuc.Text = $"{sonGelenAkim:F2} A";
            progressGuc.Value = (int)Math.Min(Math.Max((sonGelenAkim * 50) + 50, 0), 100);

            // İstatistik
            toplamEnerji += (Math.Abs(sonGelenVolt) * Math.Abs(sonGelenAkim)) / 3600;
            lblToplamEnerji.Text = $"{toplamEnerji:F6} kWh";

            lblSonGuncelleme.Text = $"Veri: {DateTime.Now:HH:mm:ss}";
            lblBaglantiDurum.Text = "VERİ AKIYOR (TEST)";
            lblBaglantiDurum.ForeColor = Color.Green;

            // Log (Saniyede 1 kere yazar, kasmaz)
            LogMesaj($"Anlık: G:{sonGelenGunes:F0} V:{sonGelenVolt:F2} A:{sonGelenAkim:F2}", Color.Black);

            // Grafik Verisi Ekle (Sinüsler üst üste binmesin diye kaydırıyoruz)
            AddChartData(sonGelenGunes, (sonGelenVolt * 100) + 200, (sonGelenAkim * 100) + 500);
            UpdateChart();
        }

        // --- GRAFİK İŞLEMLERİ ---
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

        private void PanelGrafik_Paint(object sender, PaintEventArgs e)
        {
            if (ruzgarHiziData.Count < 2) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.WhiteSmoke);
            int w = panelGrafik.Width, h = panelGrafik.Height;

            // Çizim Tavanı 1500 (Sinüsler rahat görünsün diye)
            DrawDataLine(g, ruzgarHiziData.ToArray(), Color.Blue, w, h, 1500);
            DrawDataLine(g, guvenlikData.ToArray(), Color.Green, w, h, 1500);
            DrawDataLine(g, enerjiUretimiData.ToArray(), Color.Red, w, h, 1500);
        }

        private void DrawDataLine(Graphics g, double[] data, Color color, int w, int h, double maxVal)
        {
            if (data.Length < 2) return;
            Pen p = new Pen(color, 2);
            float xStep = (float)w / (MAX_DATA_POINTS - 1);
            for (int i = 0; i < data.Length - 1; i++)
            {
                float y1 = h - (float)(Math.Min(data[i], maxVal) / maxVal * h * 0.9f);
                float y2 = h - (float)(Math.Min(data[i + 1], maxVal) / maxVal * h * 0.9f);
                g.DrawLine(p, i * xStep, y1, (i + 1) * xStep, y2);
            }
        }

        // --- YARDIMCI METOTLAR ---
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
        private void BtnRaporAl_Click(object sender, EventArgs e) { }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) { if (serialPort != null && serialPort.IsOpen) serialPort.Close(); }
    }
}