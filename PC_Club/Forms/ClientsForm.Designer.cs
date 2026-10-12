namespace PC_Club.Forms
{
    partial class ClientsForm
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
            this.panelLowBalance = new System.Windows.Forms.Panel();
            this.btnAllClients = new System.Windows.Forms.Button();
            this.btnLowBalance = new System.Windows.Forms.Button();
            this.nudLimit = new System.Windows.Forms.NumericUpDown();
            this.lblLimit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelLowBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).BeginInit();
            this.SuspendLayout();
            //
            // panelLowBalance
            //
            this.panelLowBalance.Controls.Add(this.btnAllClients);
            this.panelLowBalance.Controls.Add(this.btnLowBalance);
            this.panelLowBalance.Controls.Add(this.nudLimit);
            this.panelLowBalance.Controls.Add(this.lblLimit);
            this.panelLowBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLowBalance.Location = new System.Drawing.Point(0, 0);
            this.panelLowBalance.Name = "panelLowBalance";
            this.panelLowBalance.Size = new System.Drawing.Size(1122, 40);
            this.panelLowBalance.TabIndex = 10;
            //
            // lblLimit
            //
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(9, 12);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(120, 16);
            this.lblLimit.TabIndex = 0;
            this.lblLimit.Text = "Баланс менше, грн:";
            //
            // nudLimit
            //
            this.nudLimit.DecimalPlaces = 2;
            this.nudLimit.Location = new System.Drawing.Point(140, 9);
            this.nudLimit.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudLimit.Name = "nudLimit";
            this.nudLimit.Size = new System.Drawing.Size(100, 22);
            this.nudLimit.TabIndex = 1;
            this.nudLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimit.Value = new decimal(new int[] { 50, 0, 0, 0 });
            //
            // btnLowBalance
            //
            this.btnLowBalance.Location = new System.Drawing.Point(250, 5);
            this.btnLowBalance.Name = "btnLowBalance";
            this.btnLowBalance.Size = new System.Drawing.Size(110, 30);
            this.btnLowBalance.TabIndex = 2;
            this.btnLowBalance.Text = "Показати";
            this.btnLowBalance.UseVisualStyleBackColor = true;
            this.btnLowBalance.Click += new System.EventHandler(this.btnLowBalance_Click);
            //
            // btnAllClients
            //
            this.btnAllClients.Location = new System.Drawing.Point(366, 5);
            this.btnAllClients.Name = "btnAllClients";
            this.btnAllClients.Size = new System.Drawing.Size(110, 30);
            this.btnAllClients.TabIndex = 3;
            this.btnAllClients.Text = "Усі клієнти";
            this.btnAllClients.UseVisualStyleBackColor = true;
            this.btnAllClients.Click += new System.EventHandler(this.btnAllClients_Click);
            //
            // ClientsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1122, 679);
            this.Controls.Add(this.panelLowBalance);
            this.Name = "ClientsForm";
            this.Text = "Клієнти";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panelLowBalance.ResumeLayout(false);
            this.panelLowBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLowBalance;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.NumericUpDown nudLimit;
        private System.Windows.Forms.Button btnLowBalance;
        private System.Windows.Forms.Button btnAllClients;
    }
}
