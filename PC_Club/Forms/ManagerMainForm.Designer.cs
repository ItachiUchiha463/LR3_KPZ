namespace PC_Club.Forms
{
    partial class ManagerMainForm
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
            this.gbNow = new System.Windows.Forms.GroupBox();
            this.flow_gbNow = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPlaying = new System.Windows.Forms.Label();
            this.lblFree = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.lblTodayDeposits = new System.Windows.Forms.Label();
            this.gbShift = new System.Windows.Forms.GroupBox();
            this.flow_gbShift = new System.Windows.Forms.FlowLayoutPanel();
            this.btnM1 = new System.Windows.Forms.Button();
            this.btnM2 = new System.Windows.Forms.Button();
            this.btnM3 = new System.Windows.Forms.Button();
            this.btnM4 = new System.Windows.Forms.Button();
            this.btnM5 = new System.Windows.Forms.Button();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.flow_gbActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnM7 = new System.Windows.Forms.Button();
            this.btnM6 = new System.Windows.Forms.Button();
            this.gbClub = new System.Windows.Forms.GroupBox();
            this.flow_gbClub = new System.Windows.Forms.FlowLayoutPanel();
            this.btnU1 = new System.Windows.Forms.Button();
            this.btnU2 = new System.Windows.Forms.Button();
            this.btnU4 = new System.Windows.Forms.Button();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.flow_gbData = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnSessions = new System.Windows.Forms.Button();
            this.btnDeposits = new System.Windows.Forms.Button();
            this.btnComputers = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnComputerGames = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.gbNow.SuspendLayout();
            this.flow_gbNow.SuspendLayout();
            this.gbShift.SuspendLayout();
            this.flow_gbShift.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.flow_gbActions.SuspendLayout();
            this.gbClub.SuspendLayout();
            this.flow_gbClub.SuspendLayout();
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
            this.panelBody.Controls.Add(this.gbClub);
            this.panelBody.Controls.Add(this.gbActions);
            this.panelBody.Controls.Add(this.gbShift);
            this.panelBody.Controls.Add(this.gbNow);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 80);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.panelBody.Size = new System.Drawing.Size(1134, 641);
            this.panelBody.TabIndex = 1;
            // 
            // gbNow
            // 
            this.gbNow.Controls.Add(this.flow_gbNow);
            this.gbNow.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbNow.Location = new System.Drawing.Point(14, 8);
            this.gbNow.Name = "gbNow";
            this.gbNow.Size = new System.Drawing.Size(1106, 86);
            this.gbNow.TabIndex = 0;
            this.gbNow.TabStop = false;
            this.gbNow.Text = "Зараз у клубі";
            // 
            // flow_gbNow
            // 
            this.flow_gbNow.Controls.Add(this.lblPlaying);
            this.flow_gbNow.Controls.Add(this.lblFree);
            this.flow_gbNow.Controls.Add(this.lblLow);
            this.flow_gbNow.Controls.Add(this.lblTodayDeposits);
            this.flow_gbNow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbNow.Location = new System.Drawing.Point(3, 21);
            this.flow_gbNow.Name = "flow_gbNow";
            this.flow_gbNow.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbNow.Size = new System.Drawing.Size(1100, 62);
            this.flow_gbNow.TabIndex = 0;
            // 
            // lblPlaying
            // 
            this.lblPlaying.AutoSize = true;
            this.lblPlaying.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPlaying.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblPlaying.Location = new System.Drawing.Point(10, 14);
            this.lblPlaying.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblPlaying.Name = "lblPlaying";
            this.lblPlaying.Size = new System.Drawing.Size(200, 21);
            this.lblPlaying.TabIndex = 0;
            this.lblPlaying.Text = "Зараз грає: —";
            // 
            // lblFree
            // 
            this.lblFree.AutoSize = true;
            this.lblFree.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblFree.Location = new System.Drawing.Point(270, 14);
            this.lblFree.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(200, 21);
            this.lblFree.TabIndex = 1;
            this.lblFree.Text = "Вільних ПК: —";
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblLow.Location = new System.Drawing.Point(530, 14);
            this.lblLow.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(200, 21);
            this.lblLow.TabIndex = 2;
            this.lblLow.Text = "Не вистачає балансу: —";
            // 
            // lblTodayDeposits
            // 
            this.lblTodayDeposits.AutoSize = true;
            this.lblTodayDeposits.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTodayDeposits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblTodayDeposits.Location = new System.Drawing.Point(790, 14);
            this.lblTodayDeposits.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblTodayDeposits.Name = "lblTodayDeposits";
            this.lblTodayDeposits.Size = new System.Drawing.Size(200, 21);
            this.lblTodayDeposits.TabIndex = 3;
            this.lblTodayDeposits.Text = "Поповнення сьогодні: —";
            // 
            // gbShift
            // 
            this.gbShift.Controls.Add(this.flow_gbShift);
            this.gbShift.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbShift.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbShift.Location = new System.Drawing.Point(14, 94);
            this.gbShift.Name = "gbShift";
            this.gbShift.Size = new System.Drawing.Size(1106, 106);
            this.gbShift.TabIndex = 1;
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
            // gbActions
            // 
            this.gbActions.Controls.Add(this.flow_gbActions);
            this.gbActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbActions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbActions.Location = new System.Drawing.Point(14, 200);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(1106, 106);
            this.gbActions.TabIndex = 2;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Операції";
            // 
            // flow_gbActions
            // 
            this.flow_gbActions.Controls.Add(this.btnM7);
            this.flow_gbActions.Controls.Add(this.btnM6);
            this.flow_gbActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbActions.Location = new System.Drawing.Point(3, 21);
            this.flow_gbActions.Name = "flow_gbActions";
            this.flow_gbActions.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbActions.Size = new System.Drawing.Size(1100, 82);
            this.flow_gbActions.TabIndex = 0;
            // 
            // btnM7
            // 
            this.btnM7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM7.FlatAppearance.BorderSize = 0;
            this.btnM7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM7.ForeColor = System.Drawing.Color.White;
            this.btnM7.Location = new System.Drawing.Point(10, 10);
            this.btnM7.Margin = new System.Windows.Forms.Padding(6);
            this.btnM7.Name = "btnM7";
            this.btnM7.Size = new System.Drawing.Size(200, 56);
            this.btnM7.TabIndex = 0;
            this.btnM7.Tag = "Q:M7";
            this.btnM7.Text = "Реєстрація клієнта";
            this.btnM7.UseVisualStyleBackColor = false;
            this.btnM7.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnM6
            // 
            this.btnM6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnM6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnM6.FlatAppearance.BorderSize = 0;
            this.btnM6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnM6.ForeColor = System.Drawing.Color.White;
            this.btnM6.Location = new System.Drawing.Point(222, 10);
            this.btnM6.Margin = new System.Windows.Forms.Padding(6);
            this.btnM6.Name = "btnM6";
            this.btnM6.Size = new System.Drawing.Size(200, 56);
            this.btnM6.TabIndex = 1;
            this.btnM6.Tag = "Q:M6";
            this.btnM6.Text = "Статус комп'ютера";
            this.btnM6.UseVisualStyleBackColor = false;
            this.btnM6.Click += new System.EventHandler(this.Tile_Click);
            // 
            // gbClub
            // 
            this.gbClub.Controls.Add(this.flow_gbClub);
            this.gbClub.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbClub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbClub.Location = new System.Drawing.Point(14, 306);
            this.gbClub.Name = "gbClub";
            this.gbClub.Size = new System.Drawing.Size(1106, 106);
            this.gbClub.TabIndex = 3;
            this.gbClub.TabStop = false;
            this.gbClub.Text = "Клуб";
            // 
            // flow_gbClub
            // 
            this.flow_gbClub.Controls.Add(this.btnU1);
            this.flow_gbClub.Controls.Add(this.btnU2);
            this.flow_gbClub.Controls.Add(this.btnU4);
            this.flow_gbClub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbClub.Location = new System.Drawing.Point(3, 21);
            this.flow_gbClub.Name = "flow_gbClub";
            this.flow_gbClub.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbClub.Size = new System.Drawing.Size(1100, 82);
            this.flow_gbClub.TabIndex = 0;
            // 
            // btnU1
            // 
            this.btnU1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnU1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnU1.FlatAppearance.BorderSize = 0;
            this.btnU1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnU1.ForeColor = System.Drawing.Color.White;
            this.btnU1.Location = new System.Drawing.Point(10, 10);
            this.btnU1.Margin = new System.Windows.Forms.Padding(6);
            this.btnU1.Name = "btnU1";
            this.btnU1.Size = new System.Drawing.Size(200, 56);
            this.btnU1.TabIndex = 0;
            this.btnU1.Tag = "Q:U1";
            this.btnU1.Text = "Вільні комп'ютери";
            this.btnU1.UseVisualStyleBackColor = false;
            this.btnU1.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnU2
            // 
            this.btnU2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnU2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnU2.FlatAppearance.BorderSize = 0;
            this.btnU2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnU2.ForeColor = System.Drawing.Color.White;
            this.btnU2.Location = new System.Drawing.Point(222, 10);
            this.btnU2.Margin = new System.Windows.Forms.Padding(6);
            this.btnU2.Name = "btnU2";
            this.btnU2.Size = new System.Drawing.Size(200, 56);
            this.btnU2.TabIndex = 1;
            this.btnU2.Tag = "Q:U2";
            this.btnU2.Text = "Де пограти в гру";
            this.btnU2.UseVisualStyleBackColor = false;
            this.btnU2.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnU4
            // 
            this.btnU4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnU4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnU4.FlatAppearance.BorderSize = 0;
            this.btnU4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnU4.ForeColor = System.Drawing.Color.White;
            this.btnU4.Location = new System.Drawing.Point(434, 10);
            this.btnU4.Margin = new System.Windows.Forms.Padding(6);
            this.btnU4.Name = "btnU4";
            this.btnU4.Size = new System.Drawing.Size(200, 56);
            this.btnU4.TabIndex = 2;
            this.btnU4.Tag = "Q:U4";
            this.btnU4.Text = "Калькулятор вартості";
            this.btnU4.UseVisualStyleBackColor = false;
            this.btnU4.Click += new System.EventHandler(this.Tile_Click);
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.flow_gbData);
            this.gbData.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbData.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbData.Location = new System.Drawing.Point(14, 412);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(1106, 174);
            this.gbData.TabIndex = 4;
            this.gbData.TabStop = false;
            this.gbData.Text = "Дані";
            // 
            // flow_gbData
            // 
            this.flow_gbData.Controls.Add(this.btnClients);
            this.flow_gbData.Controls.Add(this.btnSessions);
            this.flow_gbData.Controls.Add(this.btnDeposits);
            this.flow_gbData.Controls.Add(this.btnComputers);
            this.flow_gbData.Controls.Add(this.btnGames);
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
            // btnSessions
            // 
            this.btnSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnSessions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSessions.FlatAppearance.BorderSize = 0;
            this.btnSessions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSessions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSessions.ForeColor = System.Drawing.Color.White;
            this.btnSessions.Location = new System.Drawing.Point(222, 10);
            this.btnSessions.Margin = new System.Windows.Forms.Padding(6);
            this.btnSessions.Name = "btnSessions";
            this.btnSessions.Size = new System.Drawing.Size(200, 56);
            this.btnSessions.TabIndex = 1;
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
            this.btnDeposits.Location = new System.Drawing.Point(434, 10);
            this.btnDeposits.Margin = new System.Windows.Forms.Padding(6);
            this.btnDeposits.Name = "btnDeposits";
            this.btnDeposits.Size = new System.Drawing.Size(200, 56);
            this.btnDeposits.TabIndex = 2;
            this.btnDeposits.Tag = "F:DepositsForm";
            this.btnDeposits.Text = "Поповнення";
            this.btnDeposits.UseVisualStyleBackColor = false;
            this.btnDeposits.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnComputers
            // 
            this.btnComputers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnComputers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComputers.FlatAppearance.BorderSize = 0;
            this.btnComputers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnComputers.ForeColor = System.Drawing.Color.White;
            this.btnComputers.Location = new System.Drawing.Point(646, 10);
            this.btnComputers.Margin = new System.Windows.Forms.Padding(6);
            this.btnComputers.Name = "btnComputers";
            this.btnComputers.Size = new System.Drawing.Size(200, 56);
            this.btnComputers.TabIndex = 3;
            this.btnComputers.Tag = "F:ComputersForm";
            this.btnComputers.Text = "Комп'ютери";
            this.btnComputers.UseVisualStyleBackColor = false;
            this.btnComputers.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnGames
            // 
            this.btnGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGames.FlatAppearance.BorderSize = 0;
            this.btnGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGames.ForeColor = System.Drawing.Color.White;
            this.btnGames.Location = new System.Drawing.Point(858, 10);
            this.btnGames.Margin = new System.Windows.Forms.Padding(6);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(200, 56);
            this.btnGames.TabIndex = 4;
            this.btnGames.Tag = "F:GamesForm";
            this.btnGames.Text = "Ігри";
            this.btnGames.UseVisualStyleBackColor = false;
            this.btnGames.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnComputerGames
            // 
            this.btnComputerGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnComputerGames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComputerGames.FlatAppearance.BorderSize = 0;
            this.btnComputerGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputerGames.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnComputerGames.ForeColor = System.Drawing.Color.White;
            this.btnComputerGames.Location = new System.Drawing.Point(10, 78);
            this.btnComputerGames.Margin = new System.Windows.Forms.Padding(6);
            this.btnComputerGames.Name = "btnComputerGames";
            this.btnComputerGames.Size = new System.Drawing.Size(200, 56);
            this.btnComputerGames.TabIndex = 5;
            this.btnComputerGames.Tag = "F:ComputerGamesForm";
            this.btnComputerGames.Text = "Ігри на ПК";
            this.btnComputerGames.UseVisualStyleBackColor = false;
            this.btnComputerGames.Click += new System.EventHandler(this.Tile_Click);
            // 
            // ManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1134, 721);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ManagerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПК клуб: менеджер";
            this.Activated += new System.EventHandler(this.ManagerMainForm_Activated);
            this.Load += new System.EventHandler(this.ManagerMainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.gbNow.ResumeLayout(false);
            this.flow_gbNow.ResumeLayout(false);
            this.flow_gbNow.PerformLayout();
            this.gbShift.ResumeLayout(false);
            this.flow_gbShift.ResumeLayout(false);
            this.gbActions.ResumeLayout(false);
            this.flow_gbActions.ResumeLayout(false);
            this.gbClub.ResumeLayout(false);
            this.flow_gbClub.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbNow;
        private System.Windows.Forms.FlowLayoutPanel flow_gbNow;
        private System.Windows.Forms.Label lblPlaying;
        private System.Windows.Forms.Label lblFree;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.Label lblTodayDeposits;
        private System.Windows.Forms.GroupBox gbShift;
        private System.Windows.Forms.FlowLayoutPanel flow_gbShift;
        private System.Windows.Forms.Button btnM1;
        private System.Windows.Forms.Button btnM2;
        private System.Windows.Forms.Button btnM3;
        private System.Windows.Forms.Button btnM4;
        private System.Windows.Forms.Button btnM5;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.FlowLayoutPanel flow_gbActions;
        private System.Windows.Forms.Button btnM7;
        private System.Windows.Forms.Button btnM6;
        private System.Windows.Forms.GroupBox gbClub;
        private System.Windows.Forms.FlowLayoutPanel flow_gbClub;
        private System.Windows.Forms.Button btnU1;
        private System.Windows.Forms.Button btnU2;
        private System.Windows.Forms.Button btnU4;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.FlowLayoutPanel flow_gbData;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnSessions;
        private System.Windows.Forms.Button btnDeposits;
        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnComputerGames;
    }
}