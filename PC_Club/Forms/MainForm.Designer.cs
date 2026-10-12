namespace PC_Club.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.довідникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.залиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компютериToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жанриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ігриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тарифиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ігриНаПКToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.людиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клієнтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.працівникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.операціїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сесіїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поповненняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnSwitchUser = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnSessions = new System.Windows.Forms.Button();
            this.btnDeposits = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnHalls = new System.Windows.Forms.Button();
            this.btnComputers = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnTariffs = new System.Windows.Forms.Button();
            this.btnGenres = new System.Windows.Forms.Button();
            this.btnComputerGames = new System.Windows.Forms.Button();
            this.запитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.довідникиToolStripMenuItem,
            this.людиToolStripMenuItem,
            this.операціїToolStripMenuItem,
            this.вихідToolStripMenuItem,
            this.запитиToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(964, 28);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // довідникиToolStripMenuItem
            // 
            this.довідникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.залиToolStripMenuItem,
            this.компютериToolStripMenuItem,
            this.жанриToolStripMenuItem,
            this.ігриToolStripMenuItem,
            this.тарифиToolStripMenuItem,
            this.ігриНаПКToolStripMenuItem});
            this.довідникиToolStripMenuItem.Name = "довідникиToolStripMenuItem";
            this.довідникиToolStripMenuItem.Size = new System.Drawing.Size(96, 26);
            this.довідникиToolStripMenuItem.Text = "Довідники";
            // 
            // залиToolStripMenuItem
            // 
            this.залиToolStripMenuItem.Name = "залиToolStripMenuItem";
            this.залиToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.залиToolStripMenuItem.Text = "Зали";
            this.залиToolStripMenuItem.Click += new System.EventHandler(this.залиToolStripMenuItem_Click);
            // 
            // компютериToolStripMenuItem
            // 
            this.компютериToolStripMenuItem.Name = "компютериToolStripMenuItem";
            this.компютериToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.компютериToolStripMenuItem.Text = "Комп\'ютери";
            this.компютериToolStripMenuItem.Click += new System.EventHandler(this.компютериToolStripMenuItem_Click);
            // 
            // жанриToolStripMenuItem
            // 
            this.жанриToolStripMenuItem.Name = "жанриToolStripMenuItem";
            this.жанриToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.жанриToolStripMenuItem.Text = "Жанри";
            this.жанриToolStripMenuItem.Click += new System.EventHandler(this.жанриToolStripMenuItem_Click);
            // 
            // ігриToolStripMenuItem
            // 
            this.ігриToolStripMenuItem.Name = "ігриToolStripMenuItem";
            this.ігриToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.ігриToolStripMenuItem.Text = "Ігри";
            this.ігриToolStripMenuItem.Click += new System.EventHandler(this.ігриToolStripMenuItem_Click);
            // 
            // тарифиToolStripMenuItem
            // 
            this.тарифиToolStripMenuItem.Name = "тарифиToolStripMenuItem";
            this.тарифиToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.тарифиToolStripMenuItem.Text = "Тарифи";
            this.тарифиToolStripMenuItem.Click += new System.EventHandler(this.тарифиToolStripMenuItem_Click);
            // 
            // ігриНаПКToolStripMenuItem
            // 
            this.ігриНаПКToolStripMenuItem.Name = "ігриНаПКToolStripMenuItem";
            this.ігриНаПКToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.ігриНаПКToolStripMenuItem.Text = "Ігри на ПК";
            this.ігриНаПКToolStripMenuItem.Click += new System.EventHandler(this.ігриНаПКToolStripMenuItem_Click);
            // 
            // людиToolStripMenuItem
            // 
            this.людиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клієнтиToolStripMenuItem,
            this.працівникиToolStripMenuItem});
            this.людиToolStripMenuItem.Name = "людиToolStripMenuItem";
            this.людиToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
            this.людиToolStripMenuItem.Text = "Люди";
            // 
            // клієнтиToolStripMenuItem
            // 
            this.клієнтиToolStripMenuItem.Name = "клієнтиToolStripMenuItem";
            this.клієнтиToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.клієнтиToolStripMenuItem.Text = "Клієнти";
            this.клієнтиToolStripMenuItem.Click += new System.EventHandler(this.клієнтиToolStripMenuItem_Click);
            // 
            // працівникиToolStripMenuItem
            // 
            this.працівникиToolStripMenuItem.Name = "працівникиToolStripMenuItem";
            this.працівникиToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.працівникиToolStripMenuItem.Text = "Працівники";
            this.працівникиToolStripMenuItem.Click += new System.EventHandler(this.працівникиToolStripMenuItem_Click);
            // 
            // операціїToolStripMenuItem
            // 
            this.операціїToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сесіїToolStripMenuItem,
            this.поповненняToolStripMenuItem});
            this.операціїToolStripMenuItem.Name = "операціїToolStripMenuItem";
            this.операціїToolStripMenuItem.Size = new System.Drawing.Size(85, 26);
            this.операціїToolStripMenuItem.Text = "Операції";
            // 
            // сесіїToolStripMenuItem
            // 
            this.сесіїToolStripMenuItem.Name = "сесіїToolStripMenuItem";
            this.сесіїToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.сесіїToolStripMenuItem.Text = "Сесії";
            this.сесіїToolStripMenuItem.Click += new System.EventHandler(this.сесіїToolStripMenuItem_Click);
            // 
            // поповненняToolStripMenuItem
            // 
            this.поповненняToolStripMenuItem.Name = "поповненняToolStripMenuItem";
            this.поповненняToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.поповненняToolStripMenuItem.Text = "Поповнення";
            this.поповненняToolStripMenuItem.Click += new System.EventHandler(this.поповненняToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(60, 26);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.panelHeader.Controls.Add(this.btnSwitchUser);
            this.panelHeader.Controls.Add(this.lblRole);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 28);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(964, 82);
            this.panelHeader.TabIndex = 1;
            // 
            // btnSwitchUser
            // 
            this.btnSwitchUser.Location = new System.Drawing.Point(832, 24);
            this.btnSwitchUser.Name = "btnSwitchUser";
            this.btnSwitchUser.Size = new System.Drawing.Size(120, 46);
            this.btnSwitchUser.TabIndex = 2;
            this.btnSwitchUser.Text = "Змінити користувача";
            this.btnSwitchUser.UseVisualStyleBackColor = true;
            this.btnSwitchUser.Click += new System.EventHandler(this.btnSwitchUser_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRole.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRole.Location = new System.Drawing.Point(905, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(59, 20);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "label1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(193, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ПК КЛУБ";
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClients.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClients.Location = new System.Drawing.Point(152, 154);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(199, 70);
            this.btnClients.TabIndex = 2;
            this.btnClients.Tag = "ClientsForm";
            this.btnClients.Text = "Клієнти";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnSessions
            // 
            this.btnSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnSessions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSessions.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSessions.Location = new System.Drawing.Point(357, 154);
            this.btnSessions.Name = "btnSessions";
            this.btnSessions.Size = new System.Drawing.Size(199, 70);
            this.btnSessions.TabIndex = 3;
            this.btnSessions.Tag = "SessionsForm";
            this.btnSessions.Text = "Сесії";
            this.btnSessions.UseVisualStyleBackColor = false;
            this.btnSessions.Click += new System.EventHandler(this.btnSessions_Click);
            // 
            // btnDeposits
            // 
            this.btnDeposits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnDeposits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeposits.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeposits.Location = new System.Drawing.Point(562, 154);
            this.btnDeposits.Name = "btnDeposits";
            this.btnDeposits.Size = new System.Drawing.Size(199, 70);
            this.btnDeposits.TabIndex = 4;
            this.btnDeposits.Tag = "DepositsForm";
            this.btnDeposits.Text = "Поповнення";
            this.btnDeposits.UseVisualStyleBackColor = false;
            this.btnDeposits.Click += new System.EventHandler(this.btnDeposits_Click);
            // 
            // btnGames
            // 
            this.btnGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGames.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGames.Location = new System.Drawing.Point(562, 230);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(199, 70);
            this.btnGames.TabIndex = 5;
            this.btnGames.Tag = "GamesForm";
            this.btnGames.Text = "Ігри";
            this.btnGames.UseVisualStyleBackColor = false;
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
            // 
            // btnHalls
            // 
            this.btnHalls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnHalls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHalls.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHalls.Location = new System.Drawing.Point(357, 230);
            this.btnHalls.Name = "btnHalls";
            this.btnHalls.Size = new System.Drawing.Size(199, 70);
            this.btnHalls.TabIndex = 6;
            this.btnHalls.Tag = "HallsForm";
            this.btnHalls.Text = "Зали";
            this.btnHalls.UseVisualStyleBackColor = false;
            this.btnHalls.Click += new System.EventHandler(this.btnHalls_Click);
            // 
            // btnComputers
            // 
            this.btnComputers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnComputers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnComputers.ForeColor = System.Drawing.SystemColors.Control;
            this.btnComputers.Location = new System.Drawing.Point(152, 230);
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Size = new System.Drawing.Size(199, 70);
            this.btnComputers.TabIndex = 7;
            this.btnComputers.Tag = "ComputersForm";
            this.btnComputers.Text = "Комп\'ютери";
            this.btnComputers.UseVisualStyleBackColor = false;
            this.btnComputers.Click += new System.EventHandler(this.btnComputers_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmployees.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEmployees.Location = new System.Drawing.Point(562, 306);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(199, 70);
            this.btnEmployees.TabIndex = 8;
            this.btnEmployees.Tag = "EmployeeForm";
            this.btnEmployees.Text = "Працівники";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnTariffs
            // 
            this.btnTariffs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnTariffs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTariffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTariffs.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTariffs.Location = new System.Drawing.Point(357, 306);
            this.btnTariffs.Name = "btnTariffs";
            this.btnTariffs.Size = new System.Drawing.Size(199, 70);
            this.btnTariffs.TabIndex = 9;
            this.btnTariffs.Tag = "TariffsForm";
            this.btnTariffs.Text = "Тарифи";
            this.btnTariffs.UseVisualStyleBackColor = false;
            this.btnTariffs.Click += new System.EventHandler(this.btnTariffs_Click);
            // 
            // btnGenres
            // 
            this.btnGenres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnGenres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenres.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGenres.Location = new System.Drawing.Point(152, 306);
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.Size = new System.Drawing.Size(199, 70);
            this.btnGenres.TabIndex = 10;
            this.btnGenres.Tag = "GenresForm";
            this.btnGenres.Text = "Жанри";
            this.btnGenres.UseVisualStyleBackColor = false;
            this.btnGenres.Click += new System.EventHandler(this.btnGenres_Click);
            // 
            // btnComputerGames
            // 
            this.btnComputerGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnComputerGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputerGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnComputerGames.ForeColor = System.Drawing.SystemColors.Control;
            this.btnComputerGames.Location = new System.Drawing.Point(357, 382);
            this.btnComputerGames.Name = "btnComputerGames";
            this.btnComputerGames.Size = new System.Drawing.Size(199, 70);
            this.btnComputerGames.TabIndex = 11;
            this.btnComputerGames.Tag = "ComputerGamesForm";
            this.btnComputerGames.Text = "Ігри на ПК";
            this.btnComputerGames.UseVisualStyleBackColor = false;
            this.btnComputerGames.Click += new System.EventHandler(this.btnComputerGames_Click);
            // 
            // запитиToolStripMenuItem
            // 
            this.запитиToolStripMenuItem.Name = "запитиToolStripMenuItem";
            this.запитиToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.запитиToolStripMenuItem.Text = "Запити";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 456);
            this.Controls.Add(this.btnComputerGames);
            this.Controls.Add(this.btnGenres);
            this.Controls.Add(this.btnTariffs);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnComputers);
            this.Controls.Add(this.btnHalls);
            this.Controls.Add(this.btnGames);
            this.Controls.Add(this.btnDeposits);
            this.Controls.Add(this.btnSessions);
            this.Controls.Add(this.btnClients);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПК клуб";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem довідникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem залиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компютериToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жанриToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ігриToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тарифиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem людиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клієнтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem працівникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem операціїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сесіїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поповненняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnSessions;
        private System.Windows.Forms.Button btnDeposits;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnHalls;
        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnTariffs;
        private System.Windows.Forms.Button btnGenres;
        private System.Windows.Forms.ToolStripMenuItem ігриНаПКToolStripMenuItem;
        private System.Windows.Forms.Button btnComputerGames;
        private System.Windows.Forms.Button btnSwitchUser;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ToolStripMenuItem запитиToolStripMenuItem;
    }
}