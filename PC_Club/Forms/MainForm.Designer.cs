namespace PC_Club.Forms
{
    partial class MainForm
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.gbState = new System.Windows.Forms.GroupBox();
            this.flowState = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStat1 = new System.Windows.Forms.Label();
            this.lblStat2 = new System.Windows.Forms.Label();
            this.lblStat3 = new System.Windows.Forms.Label();
            this.lblStat4 = new System.Windows.Forms.Label();
            this.gbShift = new System.Windows.Forms.GroupBox();
            this.flowShift = new System.Windows.Forms.FlowLayoutPanel();
            this.btnM1 = new System.Windows.Forms.Button();
            this.btnM4 = new System.Windows.Forms.Button();
            this.btnM5 = new System.Windows.Forms.Button();
            this.btnM7 = new System.Windows.Forms.Button();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.flowAdmin = new System.Windows.Forms.FlowLayoutPanel();
            this.btnA1 = new System.Windows.Forms.Button();
            this.btnA2 = new System.Windows.Forms.Button();
            this.btnA3 = new System.Windows.Forms.Button();
            this.btnA4 = new System.Windows.Forms.Button();
            this.btnA5 = new System.Windows.Forms.Button();
            this.btnA7 = new System.Windows.Forms.Button();
            this.btnA8 = new System.Windows.Forms.Button();
            this.btnA9 = new System.Windows.Forms.Button();
            this.gbClub = new System.Windows.Forms.GroupBox();
            this.flowClub = new System.Windows.Forms.FlowLayoutPanel();
            this.btnU1 = new System.Windows.Forms.Button();
            this.btnU2 = new System.Windows.Forms.Button();
            this.btnU3 = new System.Windows.Forms.Button();
            this.btnU4 = new System.Windows.Forms.Button();
            this.btnU5 = new System.Windows.Forms.Button();
            this.btnU6 = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.flowData = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnSessions = new System.Windows.Forms.Button();
            this.btnDeposits = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnHalls = new System.Windows.Forms.Button();
            this.btnComputers = new System.Windows.Forms.Button();
            this.btnGenres = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnTariffs = new System.Windows.Forms.Button();
            this.btnComputerGames = new System.Windows.Forms.Button();
            this.menuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.gbState.SuspendLayout();
            this.flowState.SuspendLayout();
            this.gbShift.SuspendLayout();
            this.flowShift.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.flowAdmin.SuspendLayout();
            this.gbClub.SuspendLayout();
            this.flowClub.SuspendLayout();
            this.gbData.SuspendLayout();
            this.flowData.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 28);
            this.menuMain.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout,
            this.menuSeparator,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 24);
            this.menuFile.Text = "Файл";
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(250, 26);
            this.menuLogout.Text = "Змінити користувача";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(247, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(250, 26);
            this.menuExit.Text = "Вихід";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusMain
            // 
            this.statusMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser});
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(800, 26);
            this.statusMain.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 20);
            this.lblUser.Text = "Користувач:";
            // 
            // panelBody
            // 
            this.panelBody.AutoScroll = true;
            this.panelBody.Controls.Add(this.gbData);
            this.panelBody.Controls.Add(this.gbClub);
            this.panelBody.Controls.Add(this.gbAdmin);
            this.panelBody.Controls.Add(this.gbShift);
            this.panelBody.Controls.Add(this.gbState);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(8);
            this.panelBody.TabIndex = 1;
            // 
            // gbState
            // 
            this.gbState.Controls.Add(this.flowState);
            this.gbState.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbState.Name = "gbState";
            this.gbState.Size = new System.Drawing.Size(760, 56);
            this.gbState.TabIndex = 0;
            this.gbState.TabStop = false;
            this.gbState.Text = "Стан клубу";
            // 
            // flowState
            // 
            this.flowState.Controls.Add(this.lblStat1);
            this.flowState.Controls.Add(this.lblStat2);
            this.flowState.Controls.Add(this.lblStat3);
            this.flowState.Controls.Add(this.lblStat4);
            this.flowState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowState.Name = "flowState";
            this.flowState.TabIndex = 0;
            // 
            // lblStat1
            // 
            this.lblStat1.AutoSize = true;
            this.lblStat1.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat1.Name = "lblStat1";
            this.lblStat1.TabIndex = 0;
            // 
            // lblStat2
            // 
            this.lblStat2.AutoSize = true;
            this.lblStat2.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat2.Name = "lblStat2";
            this.lblStat2.TabIndex = 1;
            // 
            // lblStat3
            // 
            this.lblStat3.AutoSize = true;
            this.lblStat3.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat3.Name = "lblStat3";
            this.lblStat3.TabIndex = 2;
            // 
            // lblStat4
            // 
            this.lblStat4.AutoSize = true;
            this.lblStat4.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat4.Name = "lblStat4";
            this.lblStat4.TabIndex = 3;
            // 
            // gbShift
            // 
            this.gbShift.Controls.Add(this.flowShift);
            this.gbShift.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbShift.Name = "gbShift";
            this.gbShift.Size = new System.Drawing.Size(760, 70);
            this.gbShift.TabIndex = 1;
            this.gbShift.TabStop = false;
            this.gbShift.Text = "Робота зміни";
            // 
            // flowShift
            // 
            this.flowShift.Controls.Add(this.btnM1);
            this.flowShift.Controls.Add(this.btnM4);
            this.flowShift.Controls.Add(this.btnM5);
            this.flowShift.Controls.Add(this.btnM7);
            this.flowShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowShift.Name = "flowShift";
            this.flowShift.TabIndex = 0;
            // 
            // btnM1
            // 
            this.btnM1.Name = "btnM1";
            this.btnM1.Size = new System.Drawing.Size(180, 32);
            this.btnM1.TabIndex = 0;
            this.btnM1.Tag = "Q:M1";
            this.btnM1.Text = "Хто зараз грає";
            this.btnM1.UseVisualStyleBackColor = true;
            this.btnM1.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnM4
            // 
            this.btnM4.Name = "btnM4";
            this.btnM4.Size = new System.Drawing.Size(180, 32);
            this.btnM4.TabIndex = 1;
            this.btnM4.Tag = "Q:M4";
            this.btnM4.Text = "Рух коштів клієнта";
            this.btnM4.UseVisualStyleBackColor = true;
            this.btnM4.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnM5
            // 
            this.btnM5.Name = "btnM5";
            this.btnM5.Size = new System.Drawing.Size(180, 32);
            this.btnM5.TabIndex = 2;
            this.btnM5.Tag = "Q:M5";
            this.btnM5.Text = "Поповнення за період";
            this.btnM5.UseVisualStyleBackColor = true;
            this.btnM5.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnM7
            // 
            this.btnM7.Name = "btnM7";
            this.btnM7.Size = new System.Drawing.Size(180, 32);
            this.btnM7.TabIndex = 3;
            this.btnM7.Tag = "Q:M7";
            this.btnM7.Text = "Реєстрація клієнта";
            this.btnM7.UseVisualStyleBackColor = true;
            this.btnM7.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.flowAdmin);
            this.gbAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(760, 108);
            this.gbAdmin.TabIndex = 2;
            this.gbAdmin.TabStop = false;
            this.gbAdmin.Text = "Адміністрування";
            // 
            // flowAdmin
            // 
            this.flowAdmin.Controls.Add(this.btnA1);
            this.flowAdmin.Controls.Add(this.btnA2);
            this.flowAdmin.Controls.Add(this.btnA3);
            this.flowAdmin.Controls.Add(this.btnA4);
            this.flowAdmin.Controls.Add(this.btnA5);
            this.flowAdmin.Controls.Add(this.btnA7);
            this.flowAdmin.Controls.Add(this.btnA8);
            this.flowAdmin.Controls.Add(this.btnA9);
            this.flowAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowAdmin.Name = "flowAdmin";
            this.flowAdmin.TabIndex = 0;
            // 
            // btnA1
            // 
            this.btnA1.Name = "btnA1";
            this.btnA1.Size = new System.Drawing.Size(180, 32);
            this.btnA1.TabIndex = 0;
            this.btnA1.Tag = "Q:A1";
            this.btnA1.Text = "Виручка по днях";
            this.btnA1.UseVisualStyleBackColor = true;
            this.btnA1.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnA2
            // 
            this.btnA2.Name = "btnA2";
            this.btnA2.Size = new System.Drawing.Size(180, 32);
            this.btnA2.TabIndex = 1;
            this.btnA2.Tag = "Q:A2";
            this.btnA2.Text = "Виручка по залах";
            this.btnA2.UseVisualStyleBackColor = true;
            this.btnA2.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnA3
            // 
            this.btnA3.Name = "btnA3";
            this.btnA3.Size = new System.Drawing.Size(180, 32);
            this.btnA3.TabIndex = 2;
            this.btnA3.Tag = "Q:A3";
            this.btnA3.Text = "Завантаженість ПК";
            this.btnA3.UseVisualStyleBackColor = true;
            this.btnA3.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnA4
            // 
            this.btnA4.Name = "btnA4";
            this.btnA4.Size = new System.Drawing.Size(180, 32);
            this.btnA4.TabIndex = 3;
            this.btnA4.Tag = "Q:A4";
            this.btnA4.Text = "Найкращі клієнти";
            this.btnA4.UseVisualStyleBackColor = true;
            this.btnA4.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnA5
            // 
            this.btnA5.Name = "btnA5";
            this.btnA5.Size = new System.Drawing.Size(180, 32);
            this.btnA5.TabIndex = 4;
            this.btnA5.Tag = "Q:A5";
            this.btnA5.Text = "Робота працівників";
            this.btnA5.UseVisualStyleBackColor = true;
            this.btnA5.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnA7
            // 
            this.btnA7.Name = "btnA7";
            this.btnA7.Size = new System.Drawing.Size(180, 32);
            this.btnA7.TabIndex = 5;
            this.btnA7.Tag = "Q:A7";
            this.btnA7.Text = "Виручка по днях тижня";
            this.btnA7.UseVisualStyleBackColor = true;
            this.btnA7.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnA8
            // 
            this.btnA8.Name = "btnA8";
            this.btnA8.Size = new System.Drawing.Size(180, 32);
            this.btnA8.TabIndex = 6;
            this.btnA8.Tag = "Q:A8";
            this.btnA8.Text = "Змінити ціни залів";
            this.btnA8.UseVisualStyleBackColor = true;
            this.btnA8.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnA9
            // 
            this.btnA9.Name = "btnA9";
            this.btnA9.Size = new System.Drawing.Size(180, 32);
            this.btnA9.TabIndex = 7;
            this.btnA9.Tag = "Q:A9";
            this.btnA9.Text = "Неактивні клієнти";
            this.btnA9.UseVisualStyleBackColor = true;
            this.btnA9.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // gbClub
            // 
            this.gbClub.Controls.Add(this.flowClub);
            this.gbClub.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbClub.Name = "gbClub";
            this.gbClub.Size = new System.Drawing.Size(760, 108);
            this.gbClub.TabIndex = 3;
            this.gbClub.TabStop = false;
            this.gbClub.Text = "Клуб";
            // 
            // flowClub
            // 
            this.flowClub.Controls.Add(this.btnU1);
            this.flowClub.Controls.Add(this.btnU2);
            this.flowClub.Controls.Add(this.btnU3);
            this.flowClub.Controls.Add(this.btnU4);
            this.flowClub.Controls.Add(this.btnU5);
            this.flowClub.Controls.Add(this.btnU6);
            this.flowClub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowClub.Name = "flowClub";
            this.flowClub.TabIndex = 0;
            // 
            // btnU1
            // 
            this.btnU1.Name = "btnU1";
            this.btnU1.Size = new System.Drawing.Size(180, 32);
            this.btnU1.TabIndex = 0;
            this.btnU1.Tag = "Q:U1";
            this.btnU1.Text = "Вільні комп'ютери";
            this.btnU1.UseVisualStyleBackColor = true;
            this.btnU1.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnU2
            // 
            this.btnU2.Name = "btnU2";
            this.btnU2.Size = new System.Drawing.Size(180, 32);
            this.btnU2.TabIndex = 1;
            this.btnU2.Tag = "Q:U2";
            this.btnU2.Text = "Де пограти в гру";
            this.btnU2.UseVisualStyleBackColor = true;
            this.btnU2.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnU3
            // 
            this.btnU3.Name = "btnU3";
            this.btnU3.Size = new System.Drawing.Size(180, 32);
            this.btnU3.TabIndex = 2;
            this.btnU3.Tag = "Q:U3";
            this.btnU3.Text = "Каталог ігор";
            this.btnU3.UseVisualStyleBackColor = true;
            this.btnU3.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnU4
            // 
            this.btnU4.Name = "btnU4";
            this.btnU4.Size = new System.Drawing.Size(180, 32);
            this.btnU4.TabIndex = 3;
            this.btnU4.Tag = "Q:U4";
            this.btnU4.Text = "Калькулятор вартості";
            this.btnU4.UseVisualStyleBackColor = true;
            this.btnU4.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnU5
            // 
            this.btnU5.Name = "btnU5";
            this.btnU5.Size = new System.Drawing.Size(180, 32);
            this.btnU5.TabIndex = 4;
            this.btnU5.Tag = "Q:U5";
            this.btnU5.Text = "Популярні ігри";
            this.btnU5.UseVisualStyleBackColor = true;
            this.btnU5.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnU6
            // 
            this.btnU6.Name = "btnU6";
            this.btnU6.Size = new System.Drawing.Size(180, 32);
            this.btnU6.TabIndex = 5;
            this.btnU6.Tag = "Q:U6";
            this.btnU6.Text = "Мої сесії";
            this.btnU6.UseVisualStyleBackColor = true;
            this.btnU6.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.flowData);
            this.gbData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(760, 146);
            this.gbData.TabIndex = 4;
            this.gbData.TabStop = false;
            this.gbData.Text = "Дані";
            // 
            // flowData
            // 
            this.flowData.Controls.Add(this.btnClients);
            this.flowData.Controls.Add(this.btnSessions);
            this.flowData.Controls.Add(this.btnDeposits);
            this.flowData.Controls.Add(this.btnEmployees);
            this.flowData.Controls.Add(this.btnHalls);
            this.flowData.Controls.Add(this.btnComputers);
            this.flowData.Controls.Add(this.btnGenres);
            this.flowData.Controls.Add(this.btnGames);
            this.flowData.Controls.Add(this.btnTariffs);
            this.flowData.Controls.Add(this.btnComputerGames);
            this.flowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowData.Name = "flowData";
            this.flowData.TabIndex = 0;
            // 
            // btnClients
            // 
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(180, 32);
            this.btnClients.TabIndex = 0;
            this.btnClients.Tag = "F:ClientsForm";
            this.btnClients.Text = "Клієнти";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnSessions
            // 
            this.btnSessions.Name = "btnSessions";
            this.btnSessions.Size = new System.Drawing.Size(180, 32);
            this.btnSessions.TabIndex = 1;
            this.btnSessions.Tag = "F:SessionsForm";
            this.btnSessions.Text = "Сесії";
            this.btnSessions.UseVisualStyleBackColor = true;
            this.btnSessions.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnDeposits
            // 
            this.btnDeposits.Name = "btnDeposits";
            this.btnDeposits.Size = new System.Drawing.Size(180, 32);
            this.btnDeposits.TabIndex = 2;
            this.btnDeposits.Tag = "F:DepositsForm";
            this.btnDeposits.Text = "Поповнення";
            this.btnDeposits.UseVisualStyleBackColor = true;
            this.btnDeposits.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(180, 32);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Tag = "F:EmployeeForm";
            this.btnEmployees.Text = "Працівники";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnHalls
            // 
            this.btnHalls.Name = "btnHalls";
            this.btnHalls.Size = new System.Drawing.Size(180, 32);
            this.btnHalls.TabIndex = 4;
            this.btnHalls.Tag = "F:HallsForm";
            this.btnHalls.Text = "Зали";
            this.btnHalls.UseVisualStyleBackColor = true;
            this.btnHalls.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnComputers
            // 
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Size = new System.Drawing.Size(180, 32);
            this.btnComputers.TabIndex = 5;
            this.btnComputers.Tag = "F:ComputersForm";
            this.btnComputers.Text = "Комп'ютери";
            this.btnComputers.UseVisualStyleBackColor = true;
            this.btnComputers.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnGenres
            // 
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.Size = new System.Drawing.Size(180, 32);
            this.btnGenres.TabIndex = 6;
            this.btnGenres.Tag = "F:GenresForm";
            this.btnGenres.Text = "Жанри";
            this.btnGenres.UseVisualStyleBackColor = true;
            this.btnGenres.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnGames
            // 
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(180, 32);
            this.btnGames.TabIndex = 7;
            this.btnGames.Tag = "F:GamesForm";
            this.btnGames.Text = "Ігри";
            this.btnGames.UseVisualStyleBackColor = true;
            this.btnGames.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnTariffs
            // 
            this.btnTariffs.Name = "btnTariffs";
            this.btnTariffs.Size = new System.Drawing.Size(180, 32);
            this.btnTariffs.TabIndex = 8;
            this.btnTariffs.Tag = "F:TariffsForm";
            this.btnTariffs.Text = "Тарифи";
            this.btnTariffs.UseVisualStyleBackColor = true;
            this.btnTariffs.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // btnComputerGames
            // 
            this.btnComputerGames.Name = "btnComputerGames";
            this.btnComputerGames.Size = new System.Drawing.Size(180, 32);
            this.btnComputerGames.TabIndex = 9;
            this.btnComputerGames.Tag = "F:ComputerGamesForm";
            this.btnComputerGames.Text = "Ігри на ПК";
            this.btnComputerGames.UseVisualStyleBackColor = true;
            this.btnComputerGames.Click += new System.EventHandler(this.OpenByTag_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПК клуб";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.gbState.ResumeLayout(false);
            this.flowState.ResumeLayout(false);
            this.flowState.PerformLayout();
            this.gbShift.ResumeLayout(false);
            this.flowShift.ResumeLayout(false);
            this.gbAdmin.ResumeLayout(false);
            this.flowAdmin.ResumeLayout(false);
            this.gbClub.ResumeLayout(false);
            this.flowClub.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            this.flowData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.GroupBox gbState;
        private System.Windows.Forms.FlowLayoutPanel flowState;
        private System.Windows.Forms.Label lblStat1;
        private System.Windows.Forms.Label lblStat2;
        private System.Windows.Forms.Label lblStat3;
        private System.Windows.Forms.Label lblStat4;
        private System.Windows.Forms.GroupBox gbShift;
        private System.Windows.Forms.FlowLayoutPanel flowShift;
        private System.Windows.Forms.Button btnM1;
        private System.Windows.Forms.Button btnM4;
        private System.Windows.Forms.Button btnM5;
        private System.Windows.Forms.Button btnM7;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.FlowLayoutPanel flowAdmin;
        private System.Windows.Forms.Button btnA1;
        private System.Windows.Forms.Button btnA2;
        private System.Windows.Forms.Button btnA3;
        private System.Windows.Forms.Button btnA4;
        private System.Windows.Forms.Button btnA5;
        private System.Windows.Forms.Button btnA7;
        private System.Windows.Forms.Button btnA8;
        private System.Windows.Forms.Button btnA9;
        private System.Windows.Forms.GroupBox gbClub;
        private System.Windows.Forms.FlowLayoutPanel flowClub;
        private System.Windows.Forms.Button btnU1;
        private System.Windows.Forms.Button btnU2;
        private System.Windows.Forms.Button btnU3;
        private System.Windows.Forms.Button btnU4;
        private System.Windows.Forms.Button btnU5;
        private System.Windows.Forms.Button btnU6;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.FlowLayoutPanel flowData;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnSessions;
        private System.Windows.Forms.Button btnDeposits;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnHalls;
        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Button btnGenres;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnTariffs;
        private System.Windows.Forms.Button btnComputerGames;
    }
}
