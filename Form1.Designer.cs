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
            this.btnRaporAl = new System.Windows.Forms.Button();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.lblSonGuncelleme = new System.Windows.Forms.Label();
            this.panelSol = new System.Windows.Forms.Panel();
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
            this.lblToplamSureBaslik = new System.Windows.Forms.Label();
            this.lblToplamSure = new System.Windows.Forms.Label();
            this.lblToplamEnerjiVerilerBaslik = new System.Windows.Forms.Label();
            this.lblToplamEnerjiVeriler = new System.Windows.Forms.Label();
            this.lblVerimlilikVerilerBaslik = new System.Windows.Forms.Label();
            this.lblVerimlilikVeriler = new System.Windows.Forms.Label();
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
            this.panelSag = new System.Windows.Forms.Panel();
            this.panelGrafik = new System.Windows.Forms.Panel();
            this.lblGrafikBaslik = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.lblLogBaslik = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.panelHeader.SuspendLayout();
            this.panelSol.SuspendLayout();
            this.panelBaglanti.SuspendLayout();
            this.panelVeriler.SuspendLayout();
            this.panelIstatistik.SuspendLayout();
            this.panelSag.SuspendLayout();
            this.panelGrafik.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.btnRaporAl);
            this.panelHeader.Controls.Add(this.btnSifirla);
            this.panelHeader.Controls.Add(this.lblBaslik);
            this.panelHeader.Controls.Add(this.lblSonGuncelleme);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1867, 74);
            this.panelHeader.TabIndex = 0;
            // 
            // btnRaporAl
            // 
            this.btnRaporAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRaporAl.BackColor = System.Drawing.Color.White;
            this.btnRaporAl.FlatAppearance.BorderSize = 0;
            this.btnRaporAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporAl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporAl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRaporAl.Location = new System.Drawing.Point(1653, 18);
            this.btnRaporAl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRaporAl.Name = "btnRaporAl";
            this.btnRaporAl.Size = new System.Drawing.Size(187, 39);
            this.btnRaporAl.TabIndex = 1;
            this.btnRaporAl.Text = "📊 RAPOR AL";
            this.btnRaporAl.UseVisualStyleBackColor = false;
            this.btnRaporAl.Click += new System.EventHandler(this.BtnRaporAl_Click);
            // 
            // btnSifirla
            // 
            this.btnSifirla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSifirla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSifirla.FlatAppearance.BorderSize = 0;
            this.btnSifirla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSifirla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifirla.ForeColor = System.Drawing.Color.Black;
            this.btnSifirla.Location = new System.Drawing.Point(1427, 18);
            this.btnSifirla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(213, 39);
            this.btnSifirla.TabIndex = 0;
            this.btnSifirla.Text = "🔄 VERİLERİ SIFIRLA";
            this.btnSifirla.UseVisualStyleBackColor = false;
            this.btnSifirla.Click += new System.EventHandler(this.BtnSifirla_Click);
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(20, 18);
            this.lblBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(609, 41);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "⚡ SCADA ENERJİ İZLEME OTOMASYONU";
            // 
            // lblSonGuncelleme
            // 
            this.lblSonGuncelleme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSonGuncelleme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSonGuncelleme.ForeColor = System.Drawing.Color.White;
            this.lblSonGuncelleme.Location = new System.Drawing.Point(1000, 27);
            this.lblSonGuncelleme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSonGuncelleme.Name = "lblSonGuncelleme";
            this.lblSonGuncelleme.Size = new System.Drawing.Size(400, 25);
            this.lblSonGuncelleme.TabIndex = 1;
            this.lblSonGuncelleme.Text = "🕒 Son Güncelleme: --:--:--";
            this.lblSonGuncelleme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelSol
            // 
            this.panelSol.Controls.Add(this.panelBaglanti);
            this.panelSol.Controls.Add(this.panelVeriler);
            this.panelSol.Controls.Add(this.panelIstatistik);
            this.panelSol.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSol.Location = new System.Drawing.Point(0, 74);
            this.panelSol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSol.Name = "panelSol";
            this.panelSol.Padding = new System.Windows.Forms.Padding(13, 12, 7, 12);
            this.panelSol.Size = new System.Drawing.Size(453, 972);
            this.panelSol.TabIndex = 1;
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
            this.panelBaglanti.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBaglanti.Location = new System.Drawing.Point(13, 462);
            this.panelBaglanti.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBaglanti.Name = "panelBaglanti";
            this.panelBaglanti.Size = new System.Drawing.Size(433, 240);
            this.panelBaglanti.TabIndex = 0;
            // 
            // lblBaglantiBaslik
            // 
            this.lblBaglantiBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblBaglantiBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaglantiBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaglantiBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaglantiBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaglantiBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaglantiBaslik.Name = "lblBaglantiBaslik";
            this.lblBaglantiBaslik.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblBaglantiBaslik.Size = new System.Drawing.Size(431, 37);
            this.lblBaglantiBaslik.TabIndex = 0;
            this.lblBaglantiBaslik.Text = "🔌 BAĞLANTI";
            this.lblBaglantiBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblComPort.Location = new System.Drawing.Point(16, 52);
            this.lblComPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(38, 20);
            this.lblComPort.TabIndex = 1;
            this.lblComPort.Text = "Port:";
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(113, 48);
            this.cmbComPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(299, 28);
            this.cmbComPort.TabIndex = 2;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaudRate.Location = new System.Drawing.Point(16, 89);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(46, 20);
            this.lblBaudRate.TabIndex = 3;
            this.lblBaudRate.Text = "Baud:";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(113, 85);
            this.cmbBaudRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(299, 28);
            this.cmbBaudRate.TabIndex = 4;
            // 
            // btnBaglan
            // 
            this.btnBaglan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnBaglan.FlatAppearance.BorderSize = 0;
            this.btnBaglan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaglan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaglan.ForeColor = System.Drawing.Color.White;
            this.btnBaglan.Location = new System.Drawing.Point(20, 129);
            this.btnBaglan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(393, 43);
            this.btnBaglan.TabIndex = 5;
            this.btnBaglan.Text = "BAĞLAN";
            this.btnBaglan.UseVisualStyleBackColor = false;
            this.btnBaglan.Click += new System.EventHandler(this.BtnBaglan_Click);
            // 
            // lblBaglantiDurum
            // 
            this.lblBaglantiDurum.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaglantiDurum.ForeColor = System.Drawing.Color.Red;
            this.lblBaglantiDurum.Location = new System.Drawing.Point(20, 185);
            this.lblBaglantiDurum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaglantiDurum.Name = "lblBaglantiDurum";
            this.lblBaglantiDurum.Size = new System.Drawing.Size(393, 37);
            this.lblBaglantiDurum.TabIndex = 6;
            this.lblBaglantiDurum.Text = "● BAĞLI DEĞİL";
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
            this.panelVeriler.Controls.Add(this.lblToplamSureBaslik);
            this.panelVeriler.Controls.Add(this.lblToplamSure);
            this.panelVeriler.Controls.Add(this.lblToplamEnerjiVerilerBaslik);
            this.panelVeriler.Controls.Add(this.lblToplamEnerjiVeriler);
            this.panelVeriler.Controls.Add(this.lblVerimlilikVerilerBaslik);
            this.panelVeriler.Controls.Add(this.lblVerimlilikVeriler);
            this.panelVeriler.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVeriler.Location = new System.Drawing.Point(13, 12);
            this.panelVeriler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelVeriler.Name = "panelVeriler";
            this.panelVeriler.Size = new System.Drawing.Size(433, 450);
            this.panelVeriler.TabIndex = 1;
            // 
            // lblVerilerBaslik
            // 
            this.lblVerilerBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblVerilerBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVerilerBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerilerBaslik.ForeColor = System.Drawing.Color.White;
            this.lblVerilerBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblVerilerBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerilerBaslik.Name = "lblVerilerBaslik";
            this.lblVerilerBaslik.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblVerilerBaslik.Size = new System.Drawing.Size(431, 37);
            this.lblVerilerBaslik.TabIndex = 0;
            this.lblVerilerBaslik.Text = "📊 ANLIK VERİLER";
            this.lblVerilerBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRuzgarBaslik
            // 
            this.lblRuzgarBaslik.AutoSize = true;
            this.lblRuzgarBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRuzgarBaslik.Location = new System.Drawing.Point(16, 49);
            this.lblRuzgarBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRuzgarBaslik.Name = "lblRuzgarBaslik";
            this.lblRuzgarBaslik.Size = new System.Drawing.Size(114, 20);
            this.lblRuzgarBaslik.TabIndex = 1;
            this.lblRuzgarBaslik.Text = "🌬️ Rüzgar Hızı";
            // 
            // lblRuzgarHizi
            // 
            this.lblRuzgarHizi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRuzgarHizi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblRuzgarHizi.Location = new System.Drawing.Point(253, 46);
            this.lblRuzgarHizi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRuzgarHizi.Name = "lblRuzgarHizi";
            this.lblRuzgarHizi.Size = new System.Drawing.Size(160, 27);
            this.lblRuzgarHizi.TabIndex = 2;
            this.lblRuzgarHizi.Text = "0.00 m/s";
            this.lblRuzgarHizi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressRuzgar
            // 
            this.progressRuzgar.Location = new System.Drawing.Point(20, 76);
            this.progressRuzgar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressRuzgar.Name = "progressRuzgar";
            this.progressRuzgar.Size = new System.Drawing.Size(393, 15);
            this.progressRuzgar.TabIndex = 3;
            // 
            // lblGuvenlikBaslik
            // 
            this.lblGuvenlikBaslik.AutoSize = true;
            this.lblGuvenlikBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGuvenlikBaslik.Location = new System.Drawing.Point(16, 111);
            this.lblGuvenlikBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuvenlikBaslik.Name = "lblGuvenlikBaslik";
            this.lblGuvenlikBaslik.Size = new System.Drawing.Size(133, 20);
            this.lblGuvenlikBaslik.TabIndex = 4;
            this.lblGuvenlikBaslik.Text = "🛡️ Güvenlik Oranı";
            // 
            // lblGuvenlik
            // 
            this.lblGuvenlik.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGuvenlik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblGuvenlik.Location = new System.Drawing.Point(253, 107);
            this.lblGuvenlik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuvenlik.Name = "lblGuvenlik";
            this.lblGuvenlik.Size = new System.Drawing.Size(160, 27);
            this.lblGuvenlik.TabIndex = 5;
            this.lblGuvenlik.Text = "0.0 %";
            this.lblGuvenlik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressGuvenlik
            // 
            this.progressGuvenlik.Location = new System.Drawing.Point(20, 138);
            this.progressGuvenlik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressGuvenlik.Name = "progressGuvenlik";
            this.progressGuvenlik.Size = new System.Drawing.Size(393, 15);
            this.progressGuvenlik.TabIndex = 6;
            // 
            // lblGucBaslik
            // 
            this.lblGucBaslik.AutoSize = true;
            this.lblGucBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGucBaslik.Location = new System.Drawing.Point(16, 172);
            this.lblGucBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGucBaslik.Name = "lblGucBaslik";
            this.lblGucBaslik.Size = new System.Drawing.Size(101, 20);
            this.lblGucBaslik.TabIndex = 7;
            this.lblGucBaslik.Text = "⚡ Anlık Güç";
            // 
            // lblAnlikGuc
            // 
            this.lblAnlikGuc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnlikGuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblAnlikGuc.Location = new System.Drawing.Point(253, 169);
            this.lblAnlikGuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnlikGuc.Name = "lblAnlikGuc";
            this.lblAnlikGuc.Size = new System.Drawing.Size(160, 27);
            this.lblAnlikGuc.TabIndex = 8;
            this.lblAnlikGuc.Text = "0.00 kW";
            this.lblAnlikGuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressGuc
            // 
            this.progressGuc.Location = new System.Drawing.Point(20, 199);
            this.progressGuc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressGuc.Name = "progressGuc";
            this.progressGuc.Size = new System.Drawing.Size(393, 15);
            this.progressGuc.TabIndex = 9;
            // 
            // lblToplamSureBaslik
            // 
            this.lblToplamSureBaslik.AutoSize = true;
            this.lblToplamSureBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamSureBaslik.Location = new System.Drawing.Point(16, 240);
            this.lblToplamSureBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamSureBaslik.Name = "lblToplamSureBaslik";
            this.lblToplamSureBaslik.Size = new System.Drawing.Size(105, 20);
            this.lblToplamSureBaslik.TabIndex = 10;
            this.lblToplamSureBaslik.Text = "⏱️ Toplam Süre";
            // 
            // lblToplamSure
            // 
            this.lblToplamSure.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamSure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblToplamSure.Location = new System.Drawing.Point(253, 237);
            this.lblToplamSure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamSure.Name = "lblToplamSure";
            this.lblToplamSure.Size = new System.Drawing.Size(160, 27);
            this.lblToplamSure.TabIndex = 11;
            this.lblToplamSure.Text = "00:00:00";
            this.lblToplamSure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToplamEnerjiVerilerBaslik
            // 
            this.lblToplamEnerjiVerilerBaslik.AutoSize = true;
            this.lblToplamEnerjiVerilerBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamEnerjiVerilerBaslik.Location = new System.Drawing.Point(16, 300);
            this.lblToplamEnerjiVerilerBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamEnerjiVerilerBaslik.Name = "lblToplamEnerjiVerilerBaslik";
            this.lblToplamEnerjiVerilerBaslik.Size = new System.Drawing.Size(125, 20);
            this.lblToplamEnerjiVerilerBaslik.TabIndex = 12;
            this.lblToplamEnerjiVerilerBaslik.Text = "🔋 Toplam Enerji";
            // 
            // lblToplamEnerjiVeriler
            // 
            this.lblToplamEnerjiVeriler.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamEnerjiVeriler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblToplamEnerjiVeriler.Location = new System.Drawing.Point(253, 297);
            this.lblToplamEnerjiVeriler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamEnerjiVeriler.Name = "lblToplamEnerjiVeriler";
            this.lblToplamEnerjiVeriler.Size = new System.Drawing.Size(160, 27);
            this.lblToplamEnerjiVeriler.TabIndex = 13;
            this.lblToplamEnerjiVeriler.Text = "0.000 kWh";
            this.lblToplamEnerjiVeriler.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVerimlilikVerilerBaslik
            // 
            this.lblVerimlilikVerilerBaslik.AutoSize = true;
            this.lblVerimlilikVerilerBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerimlilikVerilerBaslik.Location = new System.Drawing.Point(16, 360);
            this.lblVerimlilikVerilerBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerimlilikVerilerBaslik.Name = "lblVerimlilikVerilerBaslik";
            this.lblVerimlilikVerilerBaslik.Size = new System.Drawing.Size(96, 20);
            this.lblVerimlilikVerilerBaslik.TabIndex = 14;
            this.lblVerimlilikVerilerBaslik.Text = "📊 Verimlilik";
            // 
            // lblVerimlilikVeriler
            // 
            this.lblVerimlilikVeriler.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerimlilikVeriler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblVerimlilikVeriler.Location = new System.Drawing.Point(253, 357);
            this.lblVerimlilikVeriler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerimlilikVeriler.Name = "lblVerimlilikVeriler";
            this.lblVerimlilikVeriler.Size = new System.Drawing.Size(160, 27);
            this.lblVerimlilikVeriler.TabIndex = 15;
            this.lblVerimlilikVeriler.Text = "0.0 %";
            this.lblVerimlilikVeriler.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.panelIstatistik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIstatistik.Location = new System.Drawing.Point(13, 12);
            this.panelIstatistik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelIstatistik.Name = "panelIstatistik";
            this.panelIstatistik.Size = new System.Drawing.Size(433, 948);
            this.panelIstatistik.TabIndex = 2;
            // 
            // lblIstatistikBaslik
            // 
            this.lblIstatistikBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblIstatistikBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIstatistikBaslik.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIstatistikBaslik.ForeColor = System.Drawing.Color.White;
            this.lblIstatistikBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblIstatistikBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIstatistikBaslik.Name = "lblIstatistikBaslik";
            this.lblIstatistikBaslik.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblIstatistikBaslik.Size = new System.Drawing.Size(431, 37);
            this.lblIstatistikBaslik.TabIndex = 0;
            this.lblIstatistikBaslik.Text = "📈 İSTATİSTİKLER";
            this.lblIstatistikBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToplamEnerjiBaslik
            // 
            this.lblToplamEnerjiBaslik.AutoSize = true;
            this.lblToplamEnerjiBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamEnerjiBaslik.Location = new System.Drawing.Point(16, 55);
            this.lblToplamEnerjiBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamEnerjiBaslik.Name = "lblToplamEnerjiBaslik";
            this.lblToplamEnerjiBaslik.Size = new System.Drawing.Size(108, 20);
            this.lblToplamEnerjiBaslik.TabIndex = 1;
            this.lblToplamEnerjiBaslik.Text = "Toplam Enerji:";
            // 
            // lblToplamEnerji
            // 
            this.lblToplamEnerji.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplamEnerji.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblToplamEnerji.Location = new System.Drawing.Point(16, 80);
            this.lblToplamEnerji.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToplamEnerji.Name = "lblToplamEnerji";
            this.lblToplamEnerji.Size = new System.Drawing.Size(397, 34);
            this.lblToplamEnerji.TabIndex = 2;
            this.lblToplamEnerji.Text = "0.000 kWh";
            this.lblToplamEnerji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCalismaZamaniBaslik
            // 
            this.lblCalismaZamaniBaslik.AutoSize = true;
            this.lblCalismaZamaniBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCalismaZamaniBaslik.Location = new System.Drawing.Point(16, 135);
            this.lblCalismaZamaniBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalismaZamaniBaslik.Name = "lblCalismaZamaniBaslik";
            this.lblCalismaZamaniBaslik.Size = new System.Drawing.Size(123, 20);
            this.lblCalismaZamaniBaslik.TabIndex = 3;
            this.lblCalismaZamaniBaslik.Text = "Çalışma Zamanı:";
            // 
            // lblCalismaZamani
            // 
            this.lblCalismaZamani.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCalismaZamani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblCalismaZamani.Location = new System.Drawing.Point(16, 160);
            this.lblCalismaZamani.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalismaZamani.Name = "lblCalismaZamani";
            this.lblCalismaZamani.Size = new System.Drawing.Size(397, 34);
            this.lblCalismaZamani.TabIndex = 4;
            this.lblCalismaZamani.Text = "00:00:00";
            this.lblCalismaZamani.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVerimlilikBaslik
            // 
            this.lblVerimlilikBaslik.AutoSize = true;
            this.lblVerimlilikBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerimlilikBaslik.Location = new System.Drawing.Point(16, 215);
            this.lblVerimlilikBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerimlilikBaslik.Name = "lblVerimlilikBaslik";
            this.lblVerimlilikBaslik.Size = new System.Drawing.Size(79, 20);
            this.lblVerimlilikBaslik.TabIndex = 5;
            this.lblVerimlilikBaslik.Text = "Verimlilik:";
            // 
            // lblVerimlilik
            // 
            this.lblVerimlilik.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVerimlilik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblVerimlilik.Location = new System.Drawing.Point(16, 240);
            this.lblVerimlilik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerimlilik.Name = "lblVerimlilik";
            this.lblVerimlilik.Size = new System.Drawing.Size(397, 34);
            this.lblVerimlilik.TabIndex = 6;
            this.lblVerimlilik.Text = "0.0 %";
            this.lblVerimlilik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDurumBaslik
            // 
            this.lblDurumBaslik.AutoSize = true;
            this.lblDurumBaslik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurumBaslik.Location = new System.Drawing.Point(16, 295);
            this.lblDurumBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDurumBaslik.Name = "lblDurumBaslik";
            this.lblDurumBaslik.Size = new System.Drawing.Size(113, 20);
            this.lblDurumBaslik.TabIndex = 7;
            this.lblDurumBaslik.Text = "Sistem Durum:";
            // 
            // lblDurum
            // 
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.ForeColor = System.Drawing.Color.Green;
            this.lblDurum.Location = new System.Drawing.Point(16, 320);
            this.lblDurum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(397, 34);
            this.lblDurum.TabIndex = 8;
            this.lblDurum.Text = "🟢 Bekleniyor";
            this.lblDurum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSag
            // 
            this.panelSag.Controls.Add(this.panelGrafik);
            this.panelSag.Controls.Add(this.panelLog);
            this.panelSag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSag.Location = new System.Drawing.Point(453, 74);
            this.panelSag.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSag.Name = "panelSag";
            this.panelSag.Padding = new System.Windows.Forms.Padding(7, 12, 13, 12);
            this.panelSag.Size = new System.Drawing.Size(1414, 972);
            this.panelSag.TabIndex = 2;
            // 
            // panelGrafik
            // 
            this.panelGrafik.BackColor = System.Drawing.Color.White;
            this.panelGrafik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrafik.Controls.Add(this.lblGrafikBaslik);
            this.panelGrafik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrafik.Location = new System.Drawing.Point(7, 12);
            this.panelGrafik.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelGrafik.Name = "panelGrafik";
            this.panelGrafik.Size = new System.Drawing.Size(1021, 948);
            this.panelGrafik.TabIndex = 0;
            this.panelGrafik.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGrafik_Paint);
            // 
            // lblGrafikBaslik
            // 
            this.lblGrafikBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblGrafikBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGrafikBaslik.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGrafikBaslik.ForeColor = System.Drawing.Color.White;
            this.lblGrafikBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblGrafikBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrafikBaslik.Name = "lblGrafikBaslik";
            this.lblGrafikBaslik.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblGrafikBaslik.Size = new System.Drawing.Size(1019, 49);
            this.lblGrafikBaslik.TabIndex = 0;
            this.lblGrafikBaslik.Text = "📈 GERÇEK ZAMANLI GRAFİK";
            this.lblGrafikBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLog
            // 
            this.panelLog.BackColor = System.Drawing.Color.White;
            this.panelLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLog.Controls.Add(this.lblLogBaslik);
            this.panelLog.Controls.Add(this.listBoxLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLog.Location = new System.Drawing.Point(1028, 12);
            this.panelLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(373, 948);
            this.panelLog.TabIndex = 1;
            // 
            // lblLogBaslik
            // 
            this.lblLogBaslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblLogBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogBaslik.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLogBaslik.ForeColor = System.Drawing.Color.White;
            this.lblLogBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblLogBaslik.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogBaslik.Name = "lblLogBaslik";
            this.lblLogBaslik.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblLogBaslik.Size = new System.Drawing.Size(371, 49);
            this.lblLogBaslik.TabIndex = 0;
            this.lblLogBaslik.Text = "📋 SİSTEM KAYITLARI";
            this.lblLogBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 15;
            this.listBoxLog.Location = new System.Drawing.Point(11, 59);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(348, 859);
            this.listBoxLog.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1867, 1046);
            this.Controls.Add(this.panelSag);
            this.Controls.Add(this.panelSol);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1882, 1028);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "⚡ SCADA Enerji İzleme Otomasyonu - Rüzgar Gülü Sistemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSol.ResumeLayout(false);
            this.panelBaglanti.ResumeLayout(false);
            this.panelBaglanti.PerformLayout();
            this.panelVeriler.ResumeLayout(false);
            this.panelVeriler.PerformLayout();
            this.panelIstatistik.ResumeLayout(false);
            this.panelIstatistik.PerformLayout();
            this.panelSag.ResumeLayout(false);
            this.panelGrafik.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Label lblSonGuncelleme;
        private System.Windows.Forms.Panel panelSol;
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
        private System.Windows.Forms.Label lblToplamSureBaslik;
        private System.Windows.Forms.Label lblToplamSure;
        private System.Windows.Forms.Label lblToplamEnerjiVerilerBaslik;
        private System.Windows.Forms.Label lblToplamEnerjiVeriler;
        private System.Windows.Forms.Label lblVerimlilikVerilerBaslik;
        private System.Windows.Forms.Label lblVerimlilikVeriler;
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
        private System.Windows.Forms.Panel panelSag;
        private System.Windows.Forms.Panel panelGrafik;
        private System.Windows.Forms.Label lblGrafikBaslik;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Label lblLogBaslik;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.Button btnRaporAl;
    }
}