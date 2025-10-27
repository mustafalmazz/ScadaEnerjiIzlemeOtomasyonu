namespace ScadaEnerjiIzlemeOtomasyonu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblSonGuncelleme = new System.Windows.Forms.Label();
            this.panelBaglanti = new System.Windows.Forms.Panel();
            this.lblBaglantiBaslik = new System.Windows.Forms.Label();
            this.lblComPort = new System.Windows.Forms.Label();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.lblBaglantiDurum = new System.Windows.Forms.Label();
            this.panelVeriler = new System.Windows.Forms.Panel();
            this.lblVerilerBaslik = new System.Windows.Forms.Label();
            this.lblRuzgarBaslik = new System.Windows.Forms.Label();
            this.lblRuzgarHizi = new System.Windows.Forms.Label();
            this.progressRuzgar = new System.Windows.Forms.ProgressBar();
            this.lblGuvenlikBaslik = new System.Windows.Forms.Label();
            this.lblGuvenlik = new System.Windows.Forms.Label();
            this.progressGuvenlik = new System.Windows.Forms.ProgressBar();
            this.lblGucBaslik = new System.Windows.Forms.Label();
            this.lblAnlikGuc = new System.Windows.Forms.Label();
            this.progressGuc = new System.Windows.Forms.ProgressBar();
            this.panelIstatistik = new System.Windows.Forms.Panel();
            this.lblIstatistikBaslik = new System.Windows.Forms.Label();
            this.lblToplamEnerjiBaslik = new System.Windows.Forms.Label();
            this.lblToplamEnerji = new System.Windows.Forms.Label();
            this.lblCalismaZamaniBaslik = new System.Windows.Forms.Label();
            this.lblCalismaZamani = new System.Windows.Forms.Label();
            this.lblVerimlilikBaslik = new System.Windows.Forms.Label();
            this.lblVerimlilik = new System.Windows.Forms.Label();
            this.lblDurumBaslik = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.panelGrafik = new System.Windows.Forms.Panel();
            this.lblGrafikBaslik = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.lblLogBaslik = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.panelKontrol = new System.Windows.Forms.Panel();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.btnRaporAl = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelBaglanti.SuspendLayout();
            this.panelVeriler.SuspendLayout();
            this.panelIstatistik.SuspendLayout();
            this.panelGrafik.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelKontrol.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Controls.Add(this.lblSonGuncelleme);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1400, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(20, 15);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(626, 45);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "SCADA ENERJİ İZLEME OTOMASYONU";
            // 
            // lblSonGuncelleme
            // 
            this.lblSonGuncelleme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonGuncelleme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSonGuncelleme.ForeColor = System.Drawing.Color.White;
            this.lblSonGuncelleme.Location = new System.Drawing.Point(1100, 30);
            this.lblSonGuncelleme.Name = "lblSonGuncelleme";
            this.lblSonGuncelleme.Size = new System.Drawing.Size(280, 25);
            this.lblSonGuncelleme.TabIndex = 1;
            this.lblSonGuncelleme.Text = "Son Güncelleme: --:--:--";
            this.lblSonGuncelleme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelBaglanti
            // 
            this.panelBaglanti.BackColor = System.Drawing.Color.White;
            this.panelBaglanti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBaglanti.Controls.Add(this.lblBaglantiBaslik);
            this.panelBaglanti.Controls.Add(this.lblComPort);
            this.panelBaglanti.Controls.Add(this.cmbComPort);
            this.panelBaglanti.Controls.Add(this.lblBaudRate);
            this.panelBaglanti.Controls.Add(this.cmbBaudRate);
            this.panelBaglanti.Controls.Add(this.btnBaglan);
            this.panelBaglanti.Controls.Add(this.lblBaglantiDurum);
            this.panelBaglanti.Location = new System.Drawing.Point(20, 100);
            this.panelBaglanti.Name = "panelBaglanti";
            this.panelBaglanti.Size = new System.Drawing.Size(320, 280);
            this.panelBaglanti.TabIndex = 1;
            // 
            // lblBaglantiBaslik
            // 
            this.lblBaglantiBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblBaglantiBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaglantiBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaglantiBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaglantiBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaglantiBaslik.Name = "lblBaglantiBaslik";
            this.lblBaglantiBaslik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblBaglantiBaslik.Size = new System.Drawing.Size(318, 45);
            this.lblBaglantiBaslik.TabIndex = 0;
            this.lblBaglantiBaslik.Text = "BAĞLANTI AYARLARI";
            this.lblBaglantiBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblComPort.Location = new System.Drawing.Point(20, 65);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(82, 20);
            this.lblComPort.TabIndex = 1;
            this.lblComPort.Text = "COM Port:";
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(130, 63);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(160, 25);
            this.cmbComPort.TabIndex = 2;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaudRate.Location = new System.Drawing.Point(20, 105);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(85, 20);
            this.lblBaudRate.TabIndex = 3;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(130, 103);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(160, 25);
            this.cmbBaudRate.TabIndex = 4;
            // 
            // btnBaglan
            // 
            this.btnBaglan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnBaglan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaglan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaglan.ForeColor = System.Drawing.Color.White;
            this.btnBaglan.Location = new System.Drawing.Point(24, 150);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(266, 45);
            this.btnBaglan.TabIndex = 5;
            this.btnBaglan.Text = "BAĞLAN";
            this.btnBaglan.UseVisualStyleBackColor = false;
            this.btnBaglan.Click += new System.EventHandler(this.BtnBaglan_Click);
            // 
            // lblBaglantiDurum
            // 
            this.lblBaglantiDurum.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaglantiDurum.ForeColor = System.Drawing.Color.Red;
            this.lblBaglantiDurum.Location = new System.Drawing.Point(24, 215);
            this.lblBaglantiDurum.Name = "lblBaglantiDurum";
            this.lblBaglantiDurum.Size = new System.Drawing.Size(266, 40);
            this.lblBaglantiDurum.TabIndex = 6;
            this.lblBaglantiDurum.Text = "BAĞLI DEĞİL";
            this.lblBaglantiDurum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelVeriler
            // 
            this.panelVeriler.BackColor = System.Drawing.Color.White;
            this.panelVeriler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVeriler.Controls.Add(this.lblVerilerBaslik);
            this.panelVeriler.Controls.Add(this.lblRuzgarBaslik);
            this.panelVeriler.Controls.Add(this.lblRuzgarHizi);
            this.panelVeriler.Controls.Add(this.progressRuzgar);
            this.panelVeriler.Controls.Add(this.lblGuvenlikBaslik);
            this.panelVeriler.Controls.Add(this.lblGuvenlik);
            this.panelVeriler.Controls.Add(this.progressGuvenlik);
            this.panelVeriler.Controls.Add(this.lblGucBaslik);
            this.panelVeriler.Controls.Add(this.lblAnlikGuc);
            this.panelVeriler.Controls.Add(this.progressGuc);
            this.panelVeriler.Location = new System.Drawing.Point(360, 100);
            this.panelVeriler.Name = "panelVeriler";
            this.panelVeriler.Size = new System.Drawing.Size(420, 280);
            this.panelVeriler.TabIndex = 2;
            // 
            // lblVerilerBaslik
            // 
            this.lblVerilerBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblVerilerBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVerilerBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerilerBaslik.ForeColor = System.Drawing.Color.White;
            this.lblVerilerBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblVerilerBaslik.Name = "lblVerilerBaslik";
            this.lblVerilerBaslik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblVerilerBaslik.Size = new System.Drawing.Size(418, 45);
            this.lblVerilerBaslik.TabIndex = 0;
            this.lblVerilerBaslik.Text = "ANLIK VERİLER";
            this.lblVerilerBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRuzgarBaslik
            // 
            this.lblRuzgarBaslik.AutoSize = true;
            this.lblRuzgarBaslik.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRuzgarBaslik.Location = new System.Drawing.Point(20, 60);
            this.lblRuzgarBaslik.Name = "lblRuzgarBaslik";
            this.lblRuzgarBaslik.Size = new System.Drawing.Size(96, 20);
            this.lblRuzgarBaslik.TabIndex = 1;
            this.lblRuzgarBaslik.Text = "Rüzgar Hızı:";
            // 
            // lblRuzgarHizi
            // 
            this.lblRuzgarHizi.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRuzgarHizi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblRuzgarHizi.Location = new System.Drawing.Point(230, 55);
            this.lblRuzgarHizi.Name = "lblRuzgarHizi";
            this.lblRuzgarHizi.Size = new System.Drawing.Size(170, 30);
            this.lblRuzgarHizi.TabIndex = 2;
            this.lblRuzgarHizi.Text = "0.00 m/s";
            this.lblRuzgarHizi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressRuzgar
            // 
            this.progressRuzgar.Location = new System.Drawing.Point(24, 90);
            this.progressRuzgar.Name = "progressRuzgar";
            this.progressRuzgar.Size = new System.Drawing.Size(376, 23);
            this.progressRuzgar.TabIndex = 3;
            // 
            // lblGuvenlikBaslik
            // 
            this.lblGuvenlikBaslik.AutoSize = true;
            this.lblGuvenlikBaslik.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGuvenlikBaslik.Location = new System.Drawing.Point(20, 130);
            this.lblGuvenlikBaslik.Name = "lblGuvenlikBaslik";
            this.lblGuvenlikBaslik.Size = new System.Drawing.Size(124, 20);
            this.lblGuvenlikBaslik.TabIndex = 4;
            this.lblGuvenlikBaslik.Text = "Güvenlik Oranı:";
            // 
            // lblGuvenlik
            // 
            this.lblGuvenlik.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGuvenlik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblGuvenlik.Location = new System.Drawing.Point(230, 125);
            this.lblGuvenlik.Name = "lblGuvenlik";
            this.lblGuvenlik.Size = new System.Drawing.Size(170, 30);
            this.lblGuvenlik.TabIndex = 5;
            this.lblGuvenlik.Text = "0.0 %";
            this.lblGuvenlik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressGuvenlik
            // 
            this.progressGuvenlik.Location = new System.Drawing.Point(24, 160);
            this.progressGuvenlik.Name = "progressGuvenlik";
            this.progressGuvenlik.Size = new System.Drawing.Size(376, 23);
            this.progressGuvenlik.TabIndex = 6;
            // 
            // lblGucBaslik
            // 
            this.lblGucBaslik.AutoSize = true;
            this.lblGucBaslik.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGucBaslik.Location = new System.Drawing.Point(20, 200);
            this.lblGucBaslik.Name = "lblGucBaslik";
            this.lblGucBaslik.Size = new System.Drawing.Size(86, 20);
            this.lblGucBaslik.TabIndex = 7;
            this.lblGucBaslik.Text = "Anlık Güç:";
            // 
            // lblAnlikGuc
            // 
            this.lblAnlikGuc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnlikGuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblAnlikGuc.Location = new System.Drawing.Point(230, 195);
            this.lblAnlikGuc.Name = "lblAnlikGuc";
            this.lblAnlikGuc.Size = new System.Drawing.Size(170, 30);
            this.lblAnlikGuc.TabIndex = 8;
            this.lblAnlikGuc.Text = "0.00 kW";
            this.lblAnlikGuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressGuc
            // 
            this.progressGuc.Location = new System.Drawing.Point(24, 230);
            this.progressGuc.Name = "progressGuc";
            this.progressGuc.Size = new System.Drawing.Size(376, 23);
            this.progressGuc.TabIndex = 9;
            // 
            // panelIstatistik
            // 
            this.panelIstatistik.BackColor = System.Drawing.Color.White;
            this.panelIstatistik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIstatistik.Controls.Add(this.lblIstatistikBaslik);
            this.panelIstatistik.Controls.Add(this.lblToplamEnerjiBaslik);
            this.panelIstatistik.Controls.Add(this.lblToplamEnerji);
            this.panelIstatistik.Controls.Add(this.lblCalismaZamaniBaslik);
            this.panelIstatistik.Controls.Add(this.lblCalismaZamani);
            this.panelIstatistik.Controls.Add(this.lblVerimlilikBaslik);
            this.panelIstatistik.Controls.Add(this.lblVerimlilik);
            this.panelIstatistik.Controls.Add(this.lblDurumBaslik);
            this.panelIstatistik.Controls.Add(this.lblDurum);
            this.panelIstatistik.Location = new System.Drawing.Point(800, 100);
            this.panelIstatistik.Name = "panelIstatistik";
            this.panelIstatistik.Size = new System.Drawing.Size(580, 280);
            this.panelIstatistik.TabIndex = 3;
            // 
            // lblIstatistikBaslik
            // 
            this.lblIstatistikBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblIstatistikBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIstatistikBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIstatistikBaslik.ForeColor = System.Drawing.Color.White;
            this.lblIstatistikBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblIstatistikBaslik.Name = "lblIstatistikBaslik";
            this.lblIstatistikBaslik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblIstatistikBaslik.Size = new System.Drawing.Size(578, 45);
            this.lblIstatistikBaslik.TabIndex = 0;
            this.lblIstatistikBaslik.Text = "İSTATİSTİKLER";
            this.lblIstatistikBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToplamEnerjiBaslik
            // 
            this.lblToplamEnerjiBaslik.AutoSize = true;
            this.lblToplamEnerjiBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamEnerjiBaslik.Location = new System.Drawing.Point(20, 65);
            this.lblToplamEnerjiBaslik.Name = "lblToplamEnerjiBaslik";
            this.lblToplamEnerjiBaslik.Size = new System.Drawing.Size(118, 21);
            this.lblToplamEnerjiBaslik.TabIndex = 1;
            this.lblToplamEnerjiBaslik.Text = "Toplam Enerji:";
            // 
            // lblToplamEnerji
            // 
            this.lblToplamEnerji.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamEnerji.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblToplamEnerji.Location = new System.Drawing.Point(320, 60);
            this.lblToplamEnerji.Name = "lblToplamEnerji";
            this.lblToplamEnerji.Size = new System.Drawing.Size(240, 32);
            this.lblToplamEnerji.TabIndex = 2;
            this.lblToplamEnerji.Text = "0.000 kWh";
            this.lblToplamEnerji.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCalismaZamaniBaslik
            // 
            this.lblCalismaZamaniBaslik.AutoSize = true;
            this.lblCalismaZamaniBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCalismaZamaniBaslik.Location = new System.Drawing.Point(20, 115);
            this.lblCalismaZamaniBaslik.Name = "lblCalismaZamaniBaslik";
            this.lblCalismaZamaniBaslik.Size = new System.Drawing.Size(135, 21);
            this.lblCalismaZamaniBaslik.TabIndex = 3;
            this.lblCalismaZamaniBaslik.Text = "Çalışma Zamanı:";
            // 
            // lblCalismaZamani
            // 
            this.lblCalismaZamani.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCalismaZamani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblCalismaZamani.Location = new System.Drawing.Point(320, 110);
            this.lblCalismaZamani.Name = "lblCalismaZamani";
            this.lblCalismaZamani.Size = new System.Drawing.Size(240, 32);
            this.lblCalismaZamani.TabIndex = 4;
            this.lblCalismaZamani.Text = "00:00:00";
            this.lblCalismaZamani.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVerimlilikBaslik
            // 
            this.lblVerimlilikBaslik.AutoSize = true;
            this.lblVerimlilikBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerimlilikBaslik.Location = new System.Drawing.Point(20, 165);
            this.lblVerimlilikBaslik.Name = "lblVerimlilikBaslik";
            this.lblVerimlilikBaslik.Size = new System.Drawing.Size(88, 21);
            this.lblVerimlilikBaslik.TabIndex = 5;
            this.lblVerimlilikBaslik.Text = "Verimlilik:";
            // 
            // lblVerimlilik
            // 
            this.lblVerimlilik.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerimlilik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblVerimlilik.Location = new System.Drawing.Point(320, 160);
            this.lblVerimlilik.Name = "lblVerimlilik";
            this.lblVerimlilik.Size = new System.Drawing.Size(240, 32);
            this.lblVerimlilik.TabIndex = 6;
            this.lblVerimlilik.Text = "0.0 %";
            this.lblVerimlilik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDurumBaslik
            // 
            this.lblDurumBaslik.AutoSize = true;
            this.lblDurumBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurumBaslik.Location = new System.Drawing.Point(20, 215);
            this.lblDurumBaslik.Name = "lblDurumBaslik";
            this.lblDurumBaslik.Size = new System.Drawing.Size(116, 21);
            this.lblDurumBaslik.TabIndex = 7;
            this.lblDurumBaslik.Text = "Sistem Durum:";
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.ForeColor = System.Drawing.Color.Green;
            this.lblDurum.Location = new System.Drawing.Point(320, 210);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(240, 32);
            this.lblDurum.TabIndex = 8;
            this.lblDurum.Text = "Bekleniyor";
            this.lblDurum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelGrafik
            // 
            this.panelGrafik.BackColor = System.Drawing.Color.White;
            this.panelGrafik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrafik.Controls.Add(this.lblGrafikBaslik);
            this.panelGrafik.Location = new System.Drawing.Point(20, 400);
            this.panelGrafik.Name = "panelGrafik";
            this.panelGrafik.Size = new System.Drawing.Size(900, 320);
            this.panelGrafik.TabIndex = 4;
            this.panelGrafik.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGrafik_Paint);
            // 
            // lblGrafikBaslik
            // 
            this.lblGrafikBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblGrafikBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGrafikBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGrafikBaslik.ForeColor = System.Drawing.Color.White;
            this.lblGrafikBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblGrafikBaslik.Name = "lblGrafikBaslik";
            this.lblGrafikBaslik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblGrafikBaslik.Size = new System.Drawing.Size(898, 45);
            this.lblGrafikBaslik.TabIndex = 0;
            this.lblGrafikBaslik.Text = "GERÇEK ZAMANLI GRAFİK";
            this.lblGrafikBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLog
            // 
            this.panelLog.BackColor = System.Drawing.Color.White;
            this.panelLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLog.Controls.Add(this.lblLogBaslik);
            this.panelLog.Controls.Add(this.listBoxLog);
            this.panelLog.Location = new System.Drawing.Point(940, 400);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(440, 320);
            this.panelLog.TabIndex = 5;
            // 
            // lblLogBaslik
            // 
            this.lblLogBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblLogBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLogBaslik.ForeColor = System.Drawing.Color.White;
            this.lblLogBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblLogBaslik.Name = "lblLogBaslik";
            this.lblLogBaslik.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblLogBaslik.Size = new System.Drawing.Size(438, 45);
            this.lblLogBaslik.TabIndex = 0;
            this.lblLogBaslik.Text = "SİSTEM KAYITLARI";
            this.lblLogBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 14;
            this.listBoxLog.Location = new System.Drawing.Point(10, 55);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(418, 256);
            this.listBoxLog.TabIndex = 1;
            // 
            // panelKontrol
            // 
            this.panelKontrol.BackColor = System.Drawing.Color.White;
            this.panelKontrol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKontrol.Controls.Add(this.btnSifirla);
            this.panelKontrol.Controls.Add(this.btnRaporAl);
            this.panelKontrol.Location = new System.Drawing.Point(20, 740);
            this.panelKontrol.Name = "panelKontrol";
            this.panelKontrol.Size = new System.Drawing.Size(1360, 80);
            this.panelKontrol.TabIndex = 6;
            // 
            // btnSifirla
            // 
            this.btnSifirla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSifirla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSifirla.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifirla.ForeColor = System.Drawing.Color.Black;
            this.btnSifirla.Location = new System.Drawing.Point(20, 15);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(200, 50);
            this.btnSifirla.TabIndex = 0;
            this.btnSifirla.Text = "VERİLERİ SIFIRLA";
            this.btnSifirla.UseVisualStyleBackColor = false;
            this.btnSifirla.Click += new System.EventHandler(this.BtnSifirla_Click);
            // 
            // btnRaporAl
            // 
            this.btnRaporAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRaporAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporAl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporAl.ForeColor = System.Drawing.Color.White;
            this.btnRaporAl.Location = new System.Drawing.Point(1140, 15);
            this.btnRaporAl.Name = "btnRaporAl";
            this.btnRaporAl.Size = new System.Drawing.Size(200, 50);
            this.btnRaporAl.TabIndex = 1;
            this.btnRaporAl.Text = "RAPOR AL";
            this.btnRaporAl.UseVisualStyleBackColor = false;
            this.btnRaporAl.Click += new System.EventHandler(this.BtnRaporAl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1400, 840);
            this.Controls.Add(this.panelKontrol);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelGrafik);
            this.Controls.Add(this.panelIstatistik);
            this.Controls.Add(this.panelVeriler);
            this.Controls.Add(this.panelBaglanti);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCADA Enerji İzleme Otomasyonu - Rüzgar Gülü Sistemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBaglanti.ResumeLayout(false);
            this.panelBaglanti.PerformLayout();
            this.panelVeriler.ResumeLayout(false);
            this.panelVeriler.PerformLayout();
            this.panelIstatistik.ResumeLayout(false);
            this.panelIstatistik.PerformLayout();
            this.panelGrafik.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelKontrol.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblSonGuncelleme;
        private System.Windows.Forms.Panel panelBaglanti;
        private System.Windows.Forms.Label lblBaglantiBaslik;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Button btnBaglan;
        private System.Windows.Forms.Label lblBaglantiDurum;
        private System.Windows.Forms.Panel panelVeriler;
        private System.Windows.Forms.Label lblVerilerBaslik;
        private System.Windows.Forms.Label lblRuzgarBaslik;
        private System.Windows.Forms.Label lblRuzgarHizi;
        private System.Windows.Forms.ProgressBar progressRuzgar;
        private System.Windows.Forms.Label lblGuvenlikBaslik;
        private System.Windows.Forms.Label lblGuvenlik;
        private System.Windows.Forms.ProgressBar progressGuvenlik;
        private System.Windows.Forms.Label lblGucBaslik;
        private System.Windows.Forms.Label lblAnlikGuc;
        private System.Windows.Forms.ProgressBar progressGuc;
        private System.Windows.Forms.Panel panelIstatistik;
        private System.Windows.Forms.Label lblIstatistikBaslik;
        private System.Windows.Forms.Label lblToplamEnerjiBaslik;
        private System.Windows.Forms.Label lblToplamEnerji;
        private System.Windows.Forms.Label lblCalismaZamaniBaslik;
        private System.Windows.Forms.Label lblCalismaZamani;
        private System.Windows.Forms.Label lblVerimlilikBaslik;
        private System.Windows.Forms.Label lblVerimlilik;
        private System.Windows.Forms.Label lblDurumBaslik;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Panel panelGrafik;
        private System.Windows.Forms.Label lblGrafikBaslik;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Label lblLogBaslik;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Panel panelKontrol;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.Button btnRaporAl;
    }
}