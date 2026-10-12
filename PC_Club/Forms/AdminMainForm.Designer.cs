namespace PC_Club.Forms
{
    partial class AdminMainForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblClub = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelBody = new System.Windows.Forms.Panel();
            this.gbTotals = new System.Windows.Forms.GroupBox();
            this.flow_gbTotals = new System.Windows.Forms.FlowLayoutPanel();
            this.lblToday = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblPlaying = new System.Windows.Forms.Label();
            this.lblClients = new System.Windows.Forms.Label();
            this.gbReports = new System.Windows.Forms.GroupBox();
            this.flow_gbReports = new System.Windows.Forms.FlowLayoutPanel();
            this.btnA1 = new System.Windows.Forms.Button();
            this.btnA2 = new System.Windows.Forms.Button();
            this.btnA3 = new System.Windows.Forms.Button();
            this.btnA4 = new System.Windows.Forms.Button();
            this.btnA5 = new System.Windows.Forms.Button();
            this.btnA6 = new System.Windows.Forms.Button();
            this.btnA7 = new System.Windows.Forms.Button();
            this.gbManage = new System.Windows.Forms.GroupBox();
            this.flow_gbManage = new System.Windows.Forms.FlowLayoutPanel();
            this.btnA8 = new System.Windows.Forms.Button();
            this.btnA9 = new System.Windows.Forms.Button();
            this.btnM6 = new System.Windows.Forms.Button();
            this.btnM7 = new System.Windows.Forms.Button();
            this.gbShift = new System.Windows.Forms.GroupBox();
            this.flow_gbShift = new System.Windows.Forms.FlowLayoutPanel();
            this.btnM1 = new System.Windows.Forms.Button();
            this.btnM2 = new System.Windows.Forms.Button();
            this.btnM3 = new System.Windows.Forms.Button();
            this.btnM4 = new System.Windows.Forms.Button();
            this.btnM5 = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.flow_gbData = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnSessions = new System.Windows.Forms.Button();
            this.btnDeposits = new System.Windows.Forms.Button();
            this.btnHalls = new System.Windows.Forms.Button();
            this.btnComputers = new System.Windows.Forms.Button();
            this.btnGenres = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnTariffs = new System.Windows.Forms.Button();
            this.btnComputerGames = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.gbTotals.SuspendLayout();
            this.flow_gbTotals.SuspendLayout();
            this.gbReports.SuspendLayout();
            this.flow_gbReports.SuspendLayout();
            this.gbManage.SuspendLayout();
            this.flow_gbManage.SuspendLayout();
            this.gbShift.SuspendLayout();
            this.flow_gbShift.SuspendLayout();
            this.gbData.SuspendLayout();
            this.flow_gbData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Controls.Add(this.lblUser);
            this.panelHeader.Controls.Add(this.lblClub);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1134, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblClub
            // 
            this.lblClub.AutoSize = true;
            this.lblClub.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblClub.ForeColor = System.Drawing.Color.White;
            this.lblClub.Location = new System.Drawing.Point(18, 6);
            this.lblClub.Name = "lblClub";
            this.lblClub.Size = new System.Drawing.Size(150, 37);
            this.lblClub.TabIndex = 0;
            this.lblClub.Text = "ПК КЛУБ";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(22, 48);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(160, 20);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Користувач · Роль";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnLogout.Location = new System.Drawing.Point(1004, 22);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 36);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Вийти";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelBody
            // 
            this.panelBody.AutoScroll = true;
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.panelBody.Controls.Add(this.gbData);
            this.panelBody.Controls.Add(this.gbShift);
            this.panelBody.Controls.Add(this.gbManage);
            this.panelBody.Controls.Add(this.gbReports);
            this.panelBody.Controls.Add(this.gbTotals);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 80);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.panelBody.Size = new System.Drawing.Size(1134, 641);
            this.panelBody.TabIndex = 1;
            // 
            // gbTotals
            // 
            this.gbTotals.Controls.Add(this.flow_gbTotals);
            this.gbTotals.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTotals.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbTotals.Location = new System.Drawing.Point(14, 8);
            this.gbTotals.Name = "gbTotals";
            this.gbTotals.Size = new System.Drawing.Size(1106, 86);
            this.gbTotals.TabIndex = 0;
            this.gbTotals.TabStop = false;
            this.gbTotals.Text = "Підсумки";
            // 
            // flow_gbTotals
            // 
            this.flow_gbTotals.Controls.Add(this.lblToday);
            this.flow_gbTotals.Controls.Add(this.lblMonth);
            this.flow_gbTotals.Controls.Add(this.lblPlaying);
            this.flow_gbTotals.Controls.Add(this.lblClients);
            this.flow_gbTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbTotals.Location = new System.Drawing.Point(3, 21);
            this.flow_gbTotals.Name = "flow_gbTotals";
            this.flow_gbTotals.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbTotals.Size = new System.Drawing.Size(1100, 62);
            this.flow_gbTotals.TabIndex = 0;
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblToday.Location = new System.Drawing.Point(10, 14);
            this.lblToday.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(200, 21);
            this.lblToday.TabIndex = 0;
            this.lblToday.Text = "Виручка сьогодні: —";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblMonth.Location = new System.Drawing.Point(270, 14);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(200, 21);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "За 30 днів: —";
            // 
            // lblPlaying
            // 
            this.lblPlaying.AutoSize = true;
            this.lblPlaying.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPlaying.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblPlaying.Location = new System.Drawing.Point(530, 14);
            this.lblPlaying.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblPlaying.Name = "lblPlaying";
            this.lblPlaying.Size = new System.Drawing.Size(200, 21);
            this.lblPlaying.TabIndex = 2;
            this.lblPlaying.Text = "Зараз грає: —";
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblClients.Location = new System.Drawing.Point(790, 14);
            this.lblClients.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(200, 21);
            this.lblClients.TabIndex = 3;
            this.lblClients.Text = "Клієнтів: —";
            // 
            // gbReports
            // 
            this.gbReports.Controls.Add(this.flow_gbReports);
            this.gbReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbReports.Location = new System.Drawing.Point(14, 94);
            this.gbReports.Name = "gbReports";
            this.gbReports.Size = new System.Drawing.Size(1106, 174);
            this.gbReports.TabIndex = 1;
            this.gbReports.TabStop = false;
            this.gbReports.Text = "Звіти";
            // 
            // flow_gbReports
            // 
            this.flow_gbReports.Controls.Add(this.btnA1);
            this.flow_gbReports.Controls.Add(this.btnA2);
            this.flow_gbReports.Controls.Add(this.btnA3);
            this.flow_gbReports.Controls.Add(this.btnA4);
            this.flow_gbReports.Controls.Add(this.btnA5);
            this.flow_gbReports.Controls.Add(this.btnA6);
            this.flow_gbReports.Controls.Add(this.btnA7);
            this.flow_gbReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbReports.Location = new System.Drawing.Point(3, 21);
            this.flow_gbReports.Name = "flow_gbReports";
            this.flow_gbReports.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbReports.Size = new System.Drawing.Size(1100, 150);
            this.flow_gbReports.TabIndex = 0;
            // 
            // btnA1
            // 
            this.btnA1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA1.FlatAppearance.BorderSize = 0;
            this.btnA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA1.ForeColor = System.Drawing.Color.White;
            this.btnA1.Location = new System.Drawing.Point(10, 10);
            this.btnA1.Margin = new System.Windows.Forms.Padding(6);
            this.btnA1.Name = "btnA1";
            this.btnA1.Size = new System.Drawing.Size(200, 56);
            this.btnA1.TabIndex = 0;
            this.btnA1.Tag = "Q:A1";
            this.btnA1.Text = "Виручка по днях";
            this.btnA1.UseVisualStyleBackColor = false;
            this.btnA1.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnA2
            // 
            this.btnA2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA2.FlatAppearance.BorderSize = 0;
            this.btnA2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA2.ForeColor = System.Drawing.Color.White;
            this.btnA2.Location = new System.Drawing.Point(222, 10);
            this.btnA2.Margin = new System.Windows.Forms.Padding(6);
            this.btnA2.Name = "btnA2";
            this.btnA2.Size = new System.Drawing.Size(200, 56);
            this.btnA2.TabIndex = 1;
            this.btnA2.Tag = "Q:A2";
            this.btnA2.Text = "Виручка по залах";
            this.btnA2.UseVisualStyleBackColor = false;
            this.btnA2.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnA3
            // 
            this.btnA3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA3.FlatAppearance.BorderSize = 0;
            this.btnA3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA3.ForeColor = System.Drawing.Color.White;
            this.btnA3.Location = new System.Drawing.Point(434, 10);
            this.btnA3.Margin = new System.Windows.Forms.Padding(6);
            this.btnA3.Name = "btnA3";
            this.btnA3.Size = new System.Drawing.Size(200, 56);
            this.btnA3.TabIndex = 2;
            this.btnA3.Tag = "Q:A3";
            this.btnA3.Text = "Завантаженість ПК";
            this.btnA3.UseVisualStyleBackColor = false;
            this.btnA3.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnA4
            // 
            this.btnA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA4.FlatAppearance.BorderSize = 0;
            this.btnA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA4.ForeColor = System.Drawing.Color.White;
            this.btnA4.Location = new System.Drawing.Point(646, 10);
            this.btnA4.Margin = new System.Windows.Forms.Padding(6);
            this.btnA4.Name = "btnA4";
            this.btnA4.Size = new System.Drawing.Size(200, 56);
            this.btnA4.TabIndex = 3;
            this.btnA4.Tag = "Q:A4";
            this.btnA4.Text = "Найкращі клієнти";
            this.btnA4.UseVisualStyleBackColor = false;
            this.btnA4.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnA5
            // 
            this.btnA5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA5.FlatAppearance.BorderSize = 0;
            this.btnA5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA5.ForeColor = System.Drawing.Color.White;
            this.btnA5.Location = new System.Drawing.Point(858, 10);
            this.btnA5.Margin = new System.Windows.Forms.Padding(6);
            this.btnA5.Name = "btnA5";
            this.btnA5.Size = new System.Drawing.Size(200, 56);
            this.btnA5.TabIndex = 4;
            this.btnA5.Tag = "Q:A5";
            this.btnA5.Text = "Робота працівників";
            this.btnA5.UseVisualStyleBackColor = false;
            this.btnA5.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnA6
            // 
            this.btnA6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA6.FlatAppearance.BorderSize = 0;
            this.btnA6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA6.ForeColor = System.Drawing.Color.White;
            this.btnA6.Location = new System.Drawing.Point(10, 78);
            this.btnA6.Margin = new System.Windows.Forms.Padding(6);
            this.btnA6.Name = "btnA6";
            this.btnA6.Size = new System.Drawing.Size(200, 56);
            this.btnA6.TabIndex = 5;
            this.btnA6.Tag = "Q:A6";
            this.btnA6.Text = "Ігри, яких бракує";
            this.btnA6.UseVisualStyleBackColor = false;
            this.btnA6.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnA7
            // 
            this.btnA7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA7.FlatAppearance.BorderSize = 0;
            this.btnA7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA7.ForeColor = System.Drawing.Color.White;
            this.btnA7.Location = new System.Drawing.Point(222, 78);
            this.btnA7.Margin = new System.Windows.Forms.Padding(6);
            this.btnA7.Name = "btnA7";
            this.btnA7.Size = new System.Drawing.Size(200, 56);
            this.btnA7.TabIndex = 6;
            this.btnA7.Tag = "Q:A7";
            this.btnA7.Text = "Виручка по днях тижня";
            this.btnA7.UseVisualStyleBackColor = false;
            this.btnA7.Click += new System.EventHandler(this.Tile_Click);
            // 
            // gbManage
            // 
            this.gbManage.Controls.Add(this.flow_gbManage);
            this.gbManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbManage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbManage.Location = new System.Drawing.Point(14, 268);
            this.gbManage.Name = "gbManage";
            this.gbManage.Size = new System.Drawing.Size(1106, 106);
            this.gbManage.TabIndex = 2;
            this.gbManage.TabStop = false;
            this.gbManage.Text = "Керування";
            // 
            // flow_gbManage
            // 
            this.flow_gbManage.Controls.Add(this.btnA8);
            this.flow_gbManage.Controls.Add(this.btnA9);
            this.flow_gbManage.Controls.Add(this.btnM6);
            this.flow_gbManage.Controls.Add(this.btnM7);
            this.flow_gbManage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbManage.Location = new System.Drawing.Point(3, 21);
            this.flow_gbManage.Name = "flow_gbManage";
            this.flow_gbManage.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbManage.Size = new System.Drawing.Size(1100, 82);
            this.flow_gbManage.TabIndex = 0;
            // 
            // btnA8
            // 
            this.btnA8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA8.FlatAppearance.BorderSize = 0;
            this.btnA8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA8.ForeColor = System.Drawing.Color.White;
            this.btnA8.Location = new System.Drawing.Point(10, 10);
            this.btnA8.Margin = new System.Windows.Forms.Padding(6);
            this.btnA8.Name = "btnA8";
            this.btnA8.Size = new System.Drawing.Size(200, 56);
            this.btnA8.TabIndex = 0;
            this.btnA8.Tag = "Q:A8";
            this.btnA8.Text = "Змінити ціни залів";
            this.btnA8.UseVisualStyleBackColor = false;
            this.btnA8.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnA9
            // 
            this.btnA9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnA9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnA9.FlatAppearance.BorderSize = 0;
            this.btnA9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnA9.ForeColor = System.Drawing.Color.White;
            this.btnA9.Location = new System.Drawing.Point(222, 10);
            this.btnA9.Margin = new System.Windows.Forms.Padding(6);
            this.btnA9.Name = "btnA9";
            this.btnA9.Size = new System.Drawing.Size(200, 56);
            this.btnA9.TabIndex = 1;
            this.btnA9.Tag = "Q:A9";
            this.btnA9.Text = "Видалити неактивних";
            this.btnA9.UseVisualStyleBackColor = false;
            this.btnA9.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnM6
            // 
            this.btnM6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM6.FlatAppearance.BorderSize = 0;
            this.btnM6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM6.ForeColor = System.Drawing.Color.White;
            this.btnM6.Location = new System.Drawing.Point(434, 10);
            this.btnM6.Margin = new System.Windows.Forms.Padding(6);
            this.btnM6.Name = "btnM6";
            this.btnM6.Size = new System.Drawing.Size(200, 56);
            this.btnM6.TabIndex = 2;
            this.btnM6.Tag = "Q:M6";
            this.btnM6.Text = "Статус комп'ютера";
            this.btnM6.UseVisualStyleBackColor = false;
            this.btnM6.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnM7
            // 
            this.btnM7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM7.FlatAppearance.BorderSize = 0;
            this.btnM7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM7.ForeColor = System.Drawing.Color.White;
            this.btnM7.Location = new System.Drawing.Point(646, 10);
            this.btnM7.Margin = new System.Windows.Forms.Padding(6);
            this.btnM7.Name = "btnM7";
            this.btnM7.Size = new System.Drawing.Size(200, 56);
            this.btnM7.TabIndex = 3;
            this.btnM7.Tag = "Q:M7";
            this.btnM7.Text = "Реєстрація клієнта";
            this.btnM7.UseVisualStyleBackColor = false;
            this.btnM7.Click += new System.EventHandler(this.Tile_Click);
            // 
            // gbShift
            // 
            this.gbShift.Controls.Add(this.flow_gbShift);
            this.gbShift.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbShift.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbShift.Location = new System.Drawing.Point(14, 374);
            this.gbShift.Name = "gbShift";
            this.gbShift.Size = new System.Drawing.Size(1106, 106);
            this.gbShift.TabIndex = 3;
            this.gbShift.TabStop = false;
            this.gbShift.Text = "Робота зміни";
            // 
            // flow_gbShift
            // 
            this.flow_gbShift.Controls.Add(this.btnM1);
            this.flow_gbShift.Controls.Add(this.btnM2);
            this.flow_gbShift.Controls.Add(this.btnM3);
            this.flow_gbShift.Controls.Add(this.btnM4);
            this.flow_gbShift.Controls.Add(this.btnM5);
            this.flow_gbShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbShift.Location = new System.Drawing.Point(3, 21);
            this.flow_gbShift.Name = "flow_gbShift";
            this.flow_gbShift.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbShift.Size = new System.Drawing.Size(1100, 82);
            this.flow_gbShift.TabIndex = 0;
            // 
            // btnM1
            // 
            this.btnM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM1.FlatAppearance.BorderSize = 0;
            this.btnM1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM1.ForeColor = System.Drawing.Color.White;
            this.btnM1.Location = new System.Drawing.Point(10, 10);
            this.btnM1.Margin = new System.Windows.Forms.Padding(6);
            this.btnM1.Name = "btnM1";
            this.btnM1.Size = new System.Drawing.Size(200, 56);
            this.btnM1.TabIndex = 0;
            this.btnM1.Tag = "Q:M1";
            this.btnM1.Text = "Хто зараз грає";
            this.btnM1.UseVisualStyleBackColor = false;
            this.btnM1.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnM2
            // 
            this.btnM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM2.FlatAppearance.BorderSize = 0;
            this.btnM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM2.ForeColor = System.Drawing.Color.White;
            this.btnM2.Location = new System.Drawing.Point(222, 10);
            this.btnM2.Margin = new System.Windows.Forms.Padding(6);
            this.btnM2.Name = "btnM2";
            this.btnM2.Size = new System.Drawing.Size(200, 56);
            this.btnM2.TabIndex = 1;
            this.btnM2.Tag = "Q:M2";
            this.btnM2.Text = "Пошук клієнта";
            this.btnM2.UseVisualStyleBackColor = false;
            this.btnM2.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnM3
            // 
            this.btnM3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM3.FlatAppearance.BorderSize = 0;
            this.btnM3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM3.ForeColor = System.Drawing.Color.White;
            this.btnM3.Location = new System.Drawing.Point(434, 10);
            this.btnM3.Margin = new System.Windows.Forms.Padding(6);
            this.btnM3.Name = "btnM3";
            this.btnM3.Size = new System.Drawing.Size(200, 56);
            this.btnM3.TabIndex = 2;
            this.btnM3.Tag = "Q:M3";
            this.btnM3.Text = "Низький баланс";
            this.btnM3.UseVisualStyleBackColor = false;
            this.btnM3.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnM4
            // 
            this.btnM4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM4.FlatAppearance.BorderSize = 0;
            this.btnM4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM4.ForeColor = System.Drawing.Color.White;
            this.btnM4.Location = new System.Drawing.Point(646, 10);
            this.btnM4.Margin = new System.Windows.Forms.Padding(6);
            this.btnM4.Name = "btnM4";
            this.btnM4.Size = new System.Drawing.Size(200, 56);
            this.btnM4.TabIndex = 3;
            this.btnM4.Tag = "Q:M4";
            this.btnM4.Text = "Рух коштів клієнта";
            this.btnM4.UseVisualStyleBackColor = false;
            this.btnM4.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnM5
            // 
            this.btnM5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM5.FlatAppearance.BorderSize = 0;
            this.btnM5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM5.ForeColor = System.Drawing.Color.White;
            this.btnM5.Location = new System.Drawing.Point(858, 10);
            this.btnM5.Margin = new System.Windows.Forms.Padding(6);
            this.btnM5.Name = "btnM5";
            this.btnM5.Size = new System.Drawing.Size(200, 56);
            this.btnM5.TabIndex = 4;
            this.btnM5.Tag = "Q:M5";
            this.btnM5.Text = "Поповнення за період";
            this.btnM5.UseVisualStyleBackColor = false;
            this.btnM5.Click += new System.EventHandler(this.Tile_Click);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.flow_gbData);
            this.gbData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbData.Location = new System.Drawing.Point(14, 480);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(1106, 174);
            this.gbData.TabIndex = 4;
            this.gbData.TabStop = false;
            this.gbData.Text = "Дані";
            // 
            // flow_gbData
            // 
            this.flow_gbData.Controls.Add(this.btnClients);
            this.flow_gbData.Controls.Add(this.btnEmployees);
            this.flow_gbData.Controls.Add(this.btnSessions);
            this.flow_gbData.Controls.Add(this.btnDeposits);
            this.flow_gbData.Controls.Add(this.btnHalls);
            this.flow_gbData.Controls.Add(this.btnComputers);
            this.flow_gbData.Controls.Add(this.btnGenres);
            this.flow_gbData.Controls.Add(this.btnGames);
            this.flow_gbData.Controls.Add(this.btnTariffs);
            this.flow_gbData.Controls.Add(this.btnComputerGames);
            this.flow_gbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbData.Location = new System.Drawing.Point(3, 21);
            this.flow_gbData.Name = "flow_gbData";
            this.flow_gbData.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbData.Size = new System.Drawing.Size(1100, 150);
            this.flow_gbData.TabIndex = 0;
            // 
            // btnClients
            // 
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Location = new System.Drawing.Point(10, 10);
            this.btnClients.Margin = new System.Windows.Forms.Padding(6);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(200, 56);
            this.btnClients.TabIndex = 0;
            this.btnClients.Tag = "F:ClientsForm";
            this.btnClients.Text = "Клієнти";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Location = new System.Drawing.Point(222, 10);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(6);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(200, 56);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Tag = "F:EmployeeForm";
            this.btnEmployees.Text = "Працівники";
            this.btnEmployees.UseVisualStyleBackColor = false;
            this.btnEmployees.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnSessions
            // 
            this.btnSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnSessions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSessions.FlatAppearance.BorderSize = 0;
            this.btnSessions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSessions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSessions.ForeColor = System.Drawing.Color.White;
            this.btnSessions.Location = new System.Drawing.Point(434, 10);
            this.btnSessions.Margin = new System.Windows.Forms.Padding(6);
            this.btnSessions.Name = "btnSessions";
            this.btnSessions.Size = new System.Drawing.Size(200, 56);
            this.btnSessions.TabIndex = 2;
            this.btnSessions.Tag = "F:SessionsForm";
            this.btnSessions.Text = "Сесії";
            this.btnSessions.UseVisualStyleBackColor = false;
            this.btnSessions.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnDeposits
            // 
            this.btnDeposits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnDeposits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeposits.FlatAppearance.BorderSize = 0;
            this.btnDeposits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposits.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeposits.ForeColor = System.Drawing.Color.White;
            this.btnDeposits.Location = new System.Drawing.Point(646, 10);
            this.btnDeposits.Margin = new System.Windows.Forms.Padding(6);
            this.btnDeposits.Name = "btnDeposits";
            this.btnDeposits.Size = new System.Drawing.Size(200, 56);
            this.btnDeposits.TabIndex = 3;
            this.btnDeposits.Tag = "F:DepositsForm";
            this.btnDeposits.Text = "Поповнення";
            this.btnDeposits.UseVisualStyleBackColor = false;
            this.btnDeposits.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnHalls
            // 
            this.btnHalls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnHalls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHalls.FlatAppearance.BorderSize = 0;
            this.btnHalls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHalls.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHalls.ForeColor = System.Drawing.Color.White;
            this.btnHalls.Location = new System.Drawing.Point(858, 10);
            this.btnHalls.Margin = new System.Windows.Forms.Padding(6);
            this.btnHalls.Name = "btnHalls";
            this.btnHalls.Size = new System.Drawing.Size(200, 56);
            this.btnHalls.TabIndex = 4;
            this.btnHalls.Tag = "F:HallsForm";
            this.btnHalls.Text = "Зали";
            this.btnHalls.UseVisualStyleBackColor = false;
            this.btnHalls.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnComputers
            // 
            this.btnComputers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnComputers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComputers.FlatAppearance.BorderSize = 0;
            this.btnComputers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnComputers.ForeColor = System.Drawing.Color.White;
            this.btnComputers.Location = new System.Drawing.Point(10, 78);
            this.btnComputers.Margin = new System.Windows.Forms.Padding(6);
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Size = new System.Drawing.Size(200, 56);
            this.btnComputers.TabIndex = 5;
            this.btnComputers.Tag = "F:ComputersForm";
            this.btnComputers.Text = "Комп'ютери";
            this.btnComputers.UseVisualStyleBackColor = false;
            this.btnComputers.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnGenres
            // 
            this.btnGenres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnGenres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenres.FlatAppearance.BorderSize = 0;
            this.btnGenres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenres.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenres.ForeColor = System.Drawing.Color.White;
            this.btnGenres.Location = new System.Drawing.Point(222, 78);
            this.btnGenres.Margin = new System.Windows.Forms.Padding(6);
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.Size = new System.Drawing.Size(200, 56);
            this.btnGenres.TabIndex = 6;
            this.btnGenres.Tag = "F:GenresForm";
            this.btnGenres.Text = "Жанри";
            this.btnGenres.UseVisualStyleBackColor = false;
            this.btnGenres.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnGames
            // 
            this.btnGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGames.FlatAppearance.BorderSize = 0;
            this.btnGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGames.ForeColor = System.Drawing.Color.White;
            this.btnGames.Location = new System.Drawing.Point(434, 78);
            this.btnGames.Margin = new System.Windows.Forms.Padding(6);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(200, 56);
            this.btnGames.TabIndex = 7;
            this.btnGames.Tag = "F:GamesForm";
            this.btnGames.Text = "Ігри";
            this.btnGames.UseVisualStyleBackColor = false;
            this.btnGames.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnTariffs
            // 
            this.btnTariffs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnTariffs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTariffs.FlatAppearance.BorderSize = 0;
            this.btnTariffs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTariffs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTariffs.ForeColor = System.Drawing.Color.White;
            this.btnTariffs.Location = new System.Drawing.Point(646, 78);
            this.btnTariffs.Margin = new System.Windows.Forms.Padding(6);
            this.btnTariffs.Name = "btnTariffs";
            this.btnTariffs.Size = new System.Drawing.Size(200, 56);
            this.btnTariffs.TabIndex = 8;
            this.btnTariffs.Tag = "F:TariffsForm";
            this.btnTariffs.Text = "Тарифи";
            this.btnTariffs.UseVisualStyleBackColor = false;
            this.btnTariffs.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnComputerGames
            // 
            this.btnComputerGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnComputerGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComputerGames.FlatAppearance.BorderSize = 0;
            this.btnComputerGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputerGames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnComputerGames.ForeColor = System.Drawing.Color.White;
            this.btnComputerGames.Location = new System.Drawing.Point(858, 78);
            this.btnComputerGames.Margin = new System.Windows.Forms.Padding(6);
            this.btnComputerGames.Name = "btnComputerGames";
            this.btnComputerGames.Size = new System.Drawing.Size(200, 56);
            this.btnComputerGames.TabIndex = 9;
            this.btnComputerGames.Tag = "F:ComputerGamesForm";
            this.btnComputerGames.Text = "Ігри на ПК";
            this.btnComputerGames.UseVisualStyleBackColor = false;
            this.btnComputerGames.Click += new System.EventHandler(this.Tile_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1134, 721);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПК клуб: адміністратор";
            this.Activated += new System.EventHandler(this.AdminMainForm_Activated);
            this.Load += new System.EventHandler(this.AdminMainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.gbTotals.ResumeLayout(false);
            this.flow_gbTotals.ResumeLayout(false);
            this.flow_gbTotals.PerformLayout();
            this.gbReports.ResumeLayout(false);
            this.flow_gbReports.ResumeLayout(false);
            this.gbManage.ResumeLayout(false);
            this.flow_gbManage.ResumeLayout(false);
            this.gbShift.ResumeLayout(false);
            this.flow_gbShift.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            this.flow_gbData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblClub;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.GroupBox gbTotals;
        private System.Windows.Forms.FlowLayoutPanel flow_gbTotals;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblPlaying;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.GroupBox gbReports;
        private System.Windows.Forms.FlowLayoutPanel flow_gbReports;
        private System.Windows.Forms.Button btnA1;
        private System.Windows.Forms.Button btnA2;
        private System.Windows.Forms.Button btnA3;
        private System.Windows.Forms.Button btnA4;
        private System.Windows.Forms.Button btnA5;
        private System.Windows.Forms.Button btnA6;
        private System.Windows.Forms.Button btnA7;
        private System.Windows.Forms.GroupBox gbManage;
        private System.Windows.Forms.FlowLayoutPanel flow_gbManage;
        private System.Windows.Forms.Button btnA8;
        private System.Windows.Forms.Button btnA9;
        private System.Windows.Forms.Button btnM6;
        private System.Windows.Forms.Button btnM7;
        private System.Windows.Forms.GroupBox gbShift;
        private System.Windows.Forms.FlowLayoutPanel flow_gbShift;
        private System.Windows.Forms.Button btnM1;
        private System.Windows.Forms.Button btnM2;
        private System.Windows.Forms.Button btnM3;
        private System.Windows.Forms.Button btnM4;
        private System.Windows.Forms.Button btnM5;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.FlowLayoutPanel flow_gbData;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnSessions;
        private System.Windows.Forms.Button btnDeposits;
        private System.Windows.Forms.Button btnHalls;
        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Button btnGenres;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnTariffs;
        private System.Windows.Forms.Button btnComputerGames;
    }
}