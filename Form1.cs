using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace ScadaEnerjiIzlemeOtomasyonu
{
    public partial class Form1 : Form
    {
        // Simulink bağlantısı için değişkenler
        private Timer dataUpdateTimer;
        private SerialPort serialPort;
        private Random random; // Simulasyon için

        // Veri saklama
        private Queue<double> ruzgarHiziData = new Queue<double>();
        private Queue<double> guvenlikData = new Queue<double>();
        private Queue<double> enerjiUretimiData = new Queue<double>();
        private Queue<DateTime> zamanData = new Queue<DateTime>();

        private const int MAX_DATA_POINTS = 50;

        // Toplam değerler
        private double toplamEnerji = 0;
        private int calismaZamani = 0;
        private bool sistemAktif = false;

        public Form1()
        {
            InitializeComponent();
            InitializeSystem();
        }

        private void InitializeSystem()
        {
            // Timer başlat
            dataUpdateTimer = new Timer();
            dataUpdateTimer.Interval = 1000; // 1 saniye
            dataUpdateTimer.Tick += DataUpdateTimer_Tick;

            random = new Random();

            // Combobox'ları doldur
            cmbComPort.Items.AddRange(SerialPort.GetPortNames());
            if (cmbComPort.Items.Count > 0)
                cmbComPort.SelectedIndex = 0;

            cmbBaudRate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            cmbBaudRate.SelectedIndex = 0;

            // Başlangıç durumu
            UpdateSystemStatus(false);
            lblSonGuncelleme.Text = "Son Güncelleme: --:--:--";
        }

        private void BtnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!sistemAktif)
                {
                    // Bağlantı kur
                    if (cmbComPort.SelectedItem != null)
                    {
                        serialPort = new SerialPort();
                        serialPort.PortName = cmbComPort.SelectedItem.ToString();
                        serialPort.BaudRate = int.Parse(cmbBaudRate.SelectedItem.ToString());
                        serialPort.DataReceived += SerialPort_DataReceived;

                        // Gerçek bağlantı için uncomment edin
                        // serialPort.Open();

                        dataUpdateTimer.Start();
                        sistemAktif = true;
                        UpdateSystemStatus(true);

                        LogMesaj("Sistem başlatıldı.", Color.Green);
                        MessageBox.Show("SCADA sistemi başarıyla başlatıldı!", "Bağlantı Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Bağlantıyı kes
                    dataUpdateTimer.Stop();
                    if (serialPort != null && serialPort.IsOpen)
                        serialPort.Close();

                    sistemAktif = false;
                    UpdateSystemStatus(false);
                    LogMesaj("Sistem durduruldu.", Color.Red);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMesaj($"HATA: {ex.Message}", Color.Red);
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                // Simulink'ten gelen veriyi parse et
                ProcessSimulinkData(data);
            }
            catch (Exception ex)
            {
                LogMesaj($"Veri okuma hatası: {ex.Message}", Color.Red);
            }
        }

        private void DataUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Simulasyon verileri (Gerçek Simulink bağlantısında bu kısım değişecek)
            double ruzgarHizi = 5 + random.NextDouble() * 15; // 5-20 m/s
            double guvenlik = 80 + random.NextDouble() * 20; // 80-100%
            double enerjiUretimi = CalculateEnerji(ruzgarHizi); // kW

            UpdateData(ruzgarHizi, guvenlik, enerjiUretimi);
        }

        private double CalculateEnerji(double ruzgarHizi)
        {
            // Basit güç hesaplama: P = 0.5 * ρ * A * V³ * η
            // ρ = hava yoğunluğu (1.225 kg/m³)
            // A = rotor alanı (varsayılan 100 m²)
            // V = rüzgar hızı
            // η = verimlilik (0.35)

            if (ruzgarHizi < 3) return 0; // Cut-in speed
            if (ruzgarHizi > 25) return 0; // Cut-out speed

            double guc = 0.5 * 1.225 * 100 * Math.Pow(ruzgarHizi, 3) * 0.35 / 1000; // kW
            return Math.Min(guc, 500); // Max 500 kW
        }

        private void ProcessSimulinkData(string data)
        {
            // Simulink'ten gelen veriyi parse et
            // Format: "RUZGAR:15.5;UC:230.5;AKIM:12.3;GUVENLIK:95"
            try
            {
                string[] parts = data.Split(';');
                double ruzgarHizi = 0, guvenlik = 0, enerjiUretimi = 0;

                foreach (string part in parts)
                {
                    string[] keyValue = part.Split(':');
                    if (keyValue.Length == 2)
                    {
                        switch (keyValue[0].ToUpper())
                        {
                            case "RUZGAR":
                                ruzgarHizi = double.Parse(keyValue[1]);
                                break;
                            case "GUVENLIK":
                                guvenlik = double.Parse(keyValue[1]);
                                break;
                            case "GUC":
                                enerjiUretimi = double.Parse(keyValue[1]);
                                break;
                        }
                    }
                }

                this.Invoke((MethodInvoker)delegate {
                    UpdateData(ruzgarHizi, guvenlik, enerjiUretimi);
                });
            }
            catch (Exception ex)
            {
                LogMesaj($"Veri parse hatası: {ex.Message}", Color.Red);
            }
        }

        private void UpdateData(double ruzgarHizi, double guvenlik, double enerjiUretimi)
        {
            // Verileri güncelle
            lblRuzgarHizi.Text = $"{ruzgarHizi:F2} m/s";
            lblGuvenlik.Text = $"{guvenlik:F1} %";
            lblAnlikGuc.Text = $"{enerjiUretimi:F2} kW";

            // Progress bar'ları güncelle
            progressRuzgar.Value = (int)Math.Min(ruzgarHizi * 4, 100);
            progressGuvenlik.Value = (int)guvenlik;
            progressGuc.Value = (int)Math.Min((enerjiUretimi / 5), 100);

            // Toplam enerji hesapla (kWh)
            toplamEnerji += (enerjiUretimi / 3600); // saniye bazında
            lblToplamEnerji.Text = $"{toplamEnerji:F3} kWh";

            // Çalışma zamanı
            calismaZamani++;
            TimeSpan ts = TimeSpan.FromSeconds(calismaZamani);
            lblCalismaZamani.Text = $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";

            // Verimlilik hesapla
            double verimlilik = (ruzgarHizi > 0) ? (enerjiUretimi / (ruzgarHizi * 10)) * 100 : 0;
            lblVerimlilik.Text = $"{verimlilik:F1} %";

            // Durum güncellemesi
            string durum = "Normal";
            Color durumRenk = Color.Green;

            if (ruzgarHizi < 3)
            {
                durum = "Düşük Rüzgar";
                durumRenk = Color.Orange;
            }
            else if (ruzgarHizi > 20)
            {
                durum = "Yüksek Rüzgar - Dikkat!";
                durumRenk = Color.Red;
            }
            else if (guvenlik < 90)
            {
                durum = "Güvenlik Uyarısı";
                durumRenk = Color.Orange;
            }

            lblDurum.Text = durum;
            lblDurum.ForeColor = durumRenk;

            // Son güncelleme zamanı
            lblSonGuncelleme.Text = $"Son Güncelleme: {DateTime.Now:HH:mm:ss}";

            // Grafik verilerini ekle
            AddChartData(ruzgarHizi, guvenlik, enerjiUretimi);
            UpdateChart();

            // Alarm kontrolü
            CheckAlarms(ruzgarHizi, guvenlik, enerjiUretimi);
        }

        private void AddChartData(double ruzgar, double guvenlik, double enerji)
        {
            ruzgarHiziData.Enqueue(ruzgar);
            guvenlikData.Enqueue(guvenlik);
            enerjiUretimiData.Enqueue(enerji);
            zamanData.Enqueue(DateTime.Now);

            // Maksimum veri sayısını kontrol et
            while (ruzgarHiziData.Count > MAX_DATA_POINTS)
            {
                ruzgarHiziData.Dequeue();
                guvenlikData.Dequeue();
                enerjiUretimiData.Dequeue();
                zamanData.Dequeue();
            }
        }

        private void UpdateChart()
        {
            // Chart güncelleme (basit çizim)
            // Not: Daha gelişmiş grafik için Chart kontrolü kullanılabilir
            panelGrafik.Invalidate();
        }

        private void PanelGrafik_Paint(object sender, PaintEventArgs e)
        {
            if (ruzgarHiziData.Count < 2) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int width = panelGrafik.Width;
            int height = panelGrafik.Height;

            // Arka plan
            g.Clear(Color.FromArgb(240, 240, 240));

            // Grid çiz
            Pen gridPen = new Pen(Color.LightGray, 1);
            for (int i = 0; i < 5; i++)
            {
                int y = height * i / 5;
                g.DrawLine(gridPen, 0, y, width, y);
            }

            // Veri çiz
            DrawDataLine(g, ruzgarHiziData.ToArray(), Color.Blue, width, height, 25);
            DrawDataLine(g, guvenlikData.ToArray(), Color.Green, width, height, 100);
            DrawDataLine(g, enerjiUretimiData.ToArray(), Color.Red, width, height, 500);

            // Efsane
            g.DrawString("Mavi: Rüzgar Hızı | Yeşil: Güvenlik | Kırmızı: Güç",
                new Font("Arial", 8), Brushes.Black, 10, 10);
        }

        private void DrawDataLine(Graphics g, double[] data, Color color, int width, int height, double maxValue)
        {
            if (data.Length < 2) return;

            Pen pen = new Pen(color, 2);
            float xStep = (float)width / (MAX_DATA_POINTS - 1);

            for (int i = 0; i < data.Length - 1; i++)
            {
                float x1 = i * xStep;
                float y1 = height - (float)(data[i] / maxValue * height * 0.9) - height * 0.05f;
                float x2 = (i + 1) * xStep;
                float y2 = height - (float)(data[i + 1] / maxValue * height * 0.9) - height * 0.05f;

                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void CheckAlarms(double ruzgar, double guvenlik, double enerji)
        {
            if (ruzgar > 20)
            {
                LogMesaj("ALARM: Rüzgar hızı kritik seviyede!", Color.Red);
            }

            if (guvenlik < 85)
            {
                LogMesaj("UYARI: Güvenlik seviyesi düşük!", Color.Orange);
            }

            if (enerji < 10 && ruzgar > 5)
            {
                LogMesaj("UYARI: Enerji üretimi beklenenden düşük!", Color.Orange);
            }
        }

        private void LogMesaj(string mesaj, Color renk)
        {
            if (listBoxLog.InvokeRequired)
            {
                listBoxLog.Invoke((MethodInvoker)delegate {
                    LogMesaj(mesaj, renk);
                });
                return;
            }

            string zaman = DateTime.Now.ToString("HH:mm:ss");
            listBoxLog.Items.Insert(0, $"[{zaman}] {mesaj}");

            if (listBoxLog.Items.Count > 100)
                listBoxLog.Items.RemoveAt(listBoxLog.Items.Count - 1);
        }

        private void UpdateSystemStatus(bool aktif)
        {
            if (aktif)
            {
                btnBaglan.Text = "Bağlantıyı Kes";
                btnBaglan.BackColor = Color.FromArgb(220, 53, 69);
                lblBaglantiDurum.Text = "BAĞLI";
                lblBaglantiDurum.ForeColor = Color.Green;
                cmbComPort.Enabled = false;
                cmbBaudRate.Enabled = false;
            }
            else
            {
                btnBaglan.Text = "Bağlan";
                btnBaglan.BackColor = Color.FromArgb(40, 167, 69);
                lblBaglantiDurum.Text = "BAĞLI DEĞİL";
                lblBaglantiDurum.ForeColor = Color.Red;
                cmbComPort.Enabled = true;
                cmbBaudRate.Enabled = true;
            }
        }

        private void BtnSifirla_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Tüm verileri sıfırlamak istediğinizden emin misiniz?",
                "Sıfırlama Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                toplamEnerji = 0;
                calismaZamani = 0;
                ruzgarHiziData.Clear();
                guvenlikData.Clear();
                enerjiUretimiData.Clear();
                zamanData.Clear();
                listBoxLog.Items.Clear();

                lblToplamEnerji.Text = "0.000 kWh";
                lblCalismaZamani.Text = "00:00:00";
                panelGrafik.Invalidate();

                LogMesaj("Veriler sıfırlandı.", Color.Blue);
            }
        }

        private void BtnRaporAl_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Dosyası|*.txt|CSV Dosyası|*.csv";
                saveDialog.Title = "Raporu Kaydet";
                saveDialog.FileName = $"SCADA_Rapor_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                    {
                        sw.WriteLine("========================================");
                        sw.WriteLine("SCADA ENERJİ İZLEME SİSTEMİ RAPORU");
                        sw.WriteLine("========================================");
                        sw.WriteLine($"Rapor Tarihi: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        sw.WriteLine($"Toplam Enerji: {lblToplamEnerji.Text}");
                        sw.WriteLine($"Çalışma Süresi: {lblCalismaZamani.Text}");
                        sw.WriteLine($"Son Rüzgar Hızı: {lblRuzgarHizi.Text}");
                        sw.WriteLine($"Son Güvenlik: {lblGuvenlik.Text}");
                        sw.WriteLine($"Son Anlık Güç: {lblAnlikGuc.Text}");
                        sw.WriteLine($"Verimlilik: {lblVerimlilik.Text}");
                        sw.WriteLine($"Durum: {lblDurum.Text}");
                        sw.WriteLine("\n========================================");
                        sw.WriteLine("LOG KAYITLARI");
                        sw.WriteLine("========================================");

                        foreach (var item in listBoxLog.Items)
                        {
                            sw.WriteLine(item.ToString());
                        }
                    }

                    MessageBox.Show("Rapor başarıyla kaydedildi!", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogMesaj("Rapor oluşturuldu: " + saveDialog.FileName, Color.Green);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rapor oluşturma hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sistemAktif)
            {
                DialogResult result = MessageBox.Show(
                    "Sistem hala çalışıyor. Çıkmak istediğinizden emin misiniz?",
                    "Çıkış Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                dataUpdateTimer.Stop();
                if (serialPort != null && serialPort.IsOpen)
                    serialPort.Close();
            }
        }
    }
}