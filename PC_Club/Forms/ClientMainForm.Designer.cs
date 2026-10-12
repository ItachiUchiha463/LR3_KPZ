namespace PC_Club.Forms
{
    partial class ClientMainForm
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
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.flow_gbAccount = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblSessions = new System.Windows.Forms.Label();
            this.lblSpent = new System.Windows.Forms.Label();
            this.lblDeposited = new System.Windows.Forms.Label();
            this.gbClub = new System.Windows.Forms.GroupBox();
            this.flow_gbClub = new System.Windows.Forms.FlowLayoutPanel();
            this.btnU1 = new System.Windows.Forms.Button();
            this.btnU2 = new System.Windows.Forms.Button();
            this.btnU3 = new System.Windows.Forms.Button();
            this.btnU4 = new System.Windows.Forms.Button();
            this.btnU5 = new System.Windows.Forms.Button();
            this.gbMine = new System.Windows.Forms.GroupBox();
            this.flow_gbMine = new System.Windows.Forms.FlowLayoutPanel();
            this.btnU6 = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.flow_gbAccount.SuspendLayout();
            this.gbClub.SuspendLayout();
            this.flow_gbClub.SuspendLayout();
            this.gbMine.SuspendLayout();
            this.flow_gbMine.SuspendLayout();
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
            this.panelBody.Controls.Add(this.gbMine);
            this.panelBody.Controls.Add(this.gbClub);
            this.panelBody.Controls.Add(this.gbAccount);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 80);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.panelBody.Size = new System.Drawing.Size(1134, 641);
            this.panelBody.TabIndex = 1;
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.flow_gbAccount);
            this.gbAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAccount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbAccount.Location = new System.Drawing.Point(14, 8);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(1106, 86);
            this.gbAccount.TabIndex = 0;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Мій рахунок";
            // 
            // flow_gbAccount
            // 
            this.flow_gbAccount.Controls.Add(this.lblBalance);
            this.flow_gbAccount.Controls.Add(this.lblSessions);
            this.flow_gbAccount.Controls.Add(this.lblSpent);
            this.flow_gbAccount.Controls.Add(this.lblDeposited);
            this.flow_gbAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbAccount.Location = new System.Drawing.Point(3, 21);
            this.flow_gbAccount.Name = "flow_gbAccount";
            this.flow_gbAccount.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbAccount.Size = new System.Drawing.Size(1100, 62);
            this.flow_gbAccount.TabIndex = 0;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblBalance.Location = new System.Drawing.Point(10, 14);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(200, 21);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Баланс: —";
            // 
            // lblSessions
            // 
            this.lblSessions.AutoSize = true;
            this.lblSessions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSessions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblSessions.Location = new System.Drawing.Point(270, 14);
            this.lblSessions.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblSessions.Name = "lblSessions";
            this.lblSessions.Size = new System.Drawing.Size(200, 21);
            this.lblSessions.TabIndex = 1;
            this.lblSessions.Text = "Сесій: —";
            // 
            // lblSpent
            // 
            this.lblSpent.AutoSize = true;
            this.lblSpent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSpent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblSpent.Location = new System.Drawing.Point(530, 14);
            this.lblSpent.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblSpent.Name = "lblSpent";
            this.lblSpent.Size = new System.Drawing.Size(200, 21);
            this.lblSpent.TabIndex = 2;
            this.lblSpent.Text = "Витрачено: —";
            // 
            // lblDeposited
            // 
            this.lblDeposited.AutoSize = true;
            this.lblDeposited.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeposited.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.lblDeposited.Location = new System.Drawing.Point(790, 14);
            this.lblDeposited.Margin = new System.Windows.Forms.Padding(6, 10, 40, 6);
            this.lblDeposited.Name = "lblDeposited";
            this.lblDeposited.Size = new System.Drawing.Size(200, 21);
            this.lblDeposited.TabIndex = 3;
            this.lblDeposited.Text = "Поповнено: —";
            // 
            // gbClub
            // 
            this.gbClub.Controls.Add(this.flow_gbClub);
            this.gbClub.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbClub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbClub.Location = new System.Drawing.Point(14, 94);
            this.gbClub.Name = "gbClub";
            this.gbClub.Size = new System.Drawing.Size(1106, 106);
            this.gbClub.TabIndex = 1;
            this.gbClub.TabStop = false;
            this.gbClub.Text = "Клуб";
            // 
            // flow_gbClub
            // 
            this.flow_gbClub.Controls.Add(this.btnU1);
            this.flow_gbClub.Controls.Add(this.btnU2);
            this.flow_gbClub.Controls.Add(this.btnU3);
            this.flow_gbClub.Controls.Add(this.btnU4);
            this.flow_gbClub.Controls.Add(this.btnU5);
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
            // btnU3
            // 
            this.btnU3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnU3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnU3.FlatAppearance.BorderSize = 0;
            this.btnU3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnU3.ForeColor = System.Drawing.Color.White;
            this.btnU3.Location = new System.Drawing.Point(434, 10);
            this.btnU3.Margin = new System.Windows.Forms.Padding(6);
            this.btnU3.Name = "btnU3";
            this.btnU3.Size = new System.Drawing.Size(200, 56);
            this.btnU3.TabIndex = 2;
            this.btnU3.Tag = "Q:U3";
            this.btnU3.Text = "Каталог ігор";
            this.btnU3.UseVisualStyleBackColor = false;
            this.btnU3.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnU4
            // 
            this.btnU4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnU4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnU4.FlatAppearance.BorderSize = 0;
            this.btnU4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnU4.ForeColor = System.Drawing.Color.White;
            this.btnU4.Location = new System.Drawing.Point(646, 10);
            this.btnU4.Margin = new System.Windows.Forms.Padding(6);
            this.btnU4.Name = "btnU4";
            this.btnU4.Size = new System.Drawing.Size(200, 56);
            this.btnU4.TabIndex = 3;
            this.btnU4.Tag = "Q:U4";
            this.btnU4.Text = "Калькулятор вартості";
            this.btnU4.UseVisualStyleBackColor = false;
            this.btnU4.Click += new System.EventHandler(this.Tile_Click);
            // 
            // btnU5
            // 
            this.btnU5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnU5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnU5.FlatAppearance.BorderSize = 0;
            this.btnU5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnU5.ForeColor = System.Drawing.Color.White;
            this.btnU5.Location = new System.Drawing.Point(858, 10);
            this.btnU5.Margin = new System.Windows.Forms.Padding(6);
            this.btnU5.Name = "btnU5";
            this.btnU5.Size = new System.Drawing.Size(200, 56);
            this.btnU5.TabIndex = 4;
            this.btnU5.Tag = "Q:U5";
            this.btnU5.Text = "Популярні ігри";
            this.btnU5.UseVisualStyleBackColor = false;
            this.btnU5.Click += new System.EventHandler(this.Tile_Click);
            // 
            // gbMine
            // 
            this.gbMine.Controls.Add(this.flow_gbMine);
            this.gbMine.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbMine.Location = new System.Drawing.Point(14, 200);
            this.gbMine.Name = "gbMine";
            this.gbMine.Size = new System.Drawing.Size(1106, 106);
            this.gbMine.TabIndex = 2;
            this.gbMine.TabStop = false;
            this.gbMine.Text = "Мої дані";
            // 
            // flow_gbMine
            // 
            this.flow_gbMine.Controls.Add(this.btnU6);
            this.flow_gbMine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow_gbMine.Location = new System.Drawing.Point(3, 21);
            this.flow_gbMine.Name = "flow_gbMine";
            this.flow_gbMine.Padding = new System.Windows.Forms.Padding(4);
            this.flow_gbMine.Size = new System.Drawing.Size(1100, 82);
            this.flow_gbMine.TabIndex = 0;
            // 
            // btnU6
            // 
            this.btnU6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.btnU6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnU6.FlatAppearance.BorderSize = 0;
            this.btnU6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnU6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnU6.ForeColor = System.Drawing.Color.White;
            this.btnU6.Location = new System.Drawing.Point(10, 10);
            this.btnU6.Margin = new System.Windows.Forms.Padding(6);
            this.btnU6.Name = "btnU6";
            this.btnU6.Size = new System.Drawing.Size(200, 56);
            this.btnU6.TabIndex = 0;
            this.btnU6.Tag = "Q:U6";
            this.btnU6.Text = "Мої сесії";
            this.btnU6.UseVisualStyleBackColor = false;
            this.btnU6.Click += new System.EventHandler(this.Tile_Click);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1134, 721);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ClientMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПК клуб: клієнт";
            this.Activated += new System.EventHandler(this.ClientMainForm_Activated);
            this.Load += new System.EventHandler(this.ClientMainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.gbAccount.ResumeLayout(false);
            this.flow_gbAccount.ResumeLayout(false);
            this.flow_gbAccount.PerformLayout();
            this.gbClub.ResumeLayout(false);
            this.flow_gbClub.ResumeLayout(false);
            this.gbMine.ResumeLayout(false);
            this.flow_gbMine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblClub;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.FlowLayoutPanel flow_gbAccount;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblSessions;
        private System.Windows.Forms.Label lblSpent;
        private System.Windows.Forms.Label lblDeposited;
        private System.Windows.Forms.GroupBox gbClub;
        private System.Windows.Forms.FlowLayoutPanel flow_gbClub;
        private System.Windows.Forms.Button btnU1;
        private System.Windows.Forms.Button btnU2;
        private System.Windows.Forms.Button btnU3;
        private System.Windows.Forms.Button btnU4;
        private System.Windows.Forms.Button btnU5;
        private System.Windows.Forms.GroupBox gbMine;
        private System.Windows.Forms.FlowLayoutPanel flow_gbMine;
        private System.Windows.Forms.Button btnU6;
    }
}