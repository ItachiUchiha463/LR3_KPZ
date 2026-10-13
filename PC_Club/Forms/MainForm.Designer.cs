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
            this.components = new System.ComponentModel.Container();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.menuTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuTabClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabCloseOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.tabState = new System.Windows.Forms.TabPage();
            this.gbState = new System.Windows.Forms.GroupBox();
            this.flowState = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStat1 = new System.Windows.Forms.Label();
            this.lblStat2 = new System.Windows.Forms.Label();
            this.lblStat3 = new System.Windows.Forms.Label();
            this.lblStat4 = new System.Windows.Forms.Label();
            this.menuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tabs.SuspendLayout();
            this.menuTab.SuspendLayout();
            this.tabState.SuspendLayout();
            this.gbState.SuspendLayout();
            this.flowState.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1280, 28);
            this.menuMain.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCloseTab,
            this.menuSeparator1,
            this.menuLogout,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(59, 24);
            this.menuFile.Text = "Файл";
            // 
            // menuCloseTab
            // 
            this.menuCloseTab.Name = "menuCloseTab";
            this.menuCloseTab.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.menuCloseTab.Size = new System.Drawing.Size(261, 26);
            this.menuCloseTab.Text = "Закрити вкладку";
            this.menuCloseTab.Click += new System.EventHandler(this.menuCloseTab_Click);
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            this.menuSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(261, 26);
            this.menuLogout.Text = "Змінити користувача";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(261, 26);
            this.menuExit.Text = "Вихід";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusMain
            // 
            this.statusMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser});
            this.statusMain.Location = new System.Drawing.Point(0, 774);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(1280, 26);
            this.statusMain.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(92, 20);
            this.lblUser.Text = "Користувач:";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 28);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tree);
            this.splitMain.Panel1.Controls.Add(this.txtSearch);
            this.splitMain.Panel1.Controls.Add(this.lblSearch);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(4);
            this.splitMain.Panel1MinSize = 160;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tabs);
            this.splitMain.Size = new System.Drawing.Size(1280, 746);
            this.splitMain.SplitterDistance = 250;
            this.splitMain.TabIndex = 1;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.FullRowSelect = true;
            this.tree.HideSelection = false;
            this.tree.Indent = 16;
            this.tree.ItemHeight = 22;
            this.tree.Location = new System.Drawing.Point(4, 48);
            this.tree.Name = "tree";
            this.tree.ShowLines = false;
            this.tree.Size = new System.Drawing.Size(242, 694);
            this.tree.TabIndex = 1;
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            this.tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_KeyDown);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(4, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSearch.Location = new System.Drawing.Point(4, 4);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lblSearch.Size = new System.Drawing.Size(242, 22);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Пошук:";
            // 
            // tabs
            // 
            this.tabs.ContextMenuStrip = this.menuTab;
            this.tabs.Controls.Add(this.tabState);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1026, 746);
            this.tabs.TabIndex = 0;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            this.tabs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabs_MouseUp);
            // 
            // menuTab
            // 
            this.menuTab.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTabClose,
            this.menuTabCloseOthers});
            this.menuTab.Name = "menuTab";
            this.menuTab.Size = new System.Drawing.Size(227, 52);
            this.menuTab.Opening += new System.ComponentModel.CancelEventHandler(this.menuTab_Opening);
            // 
            // menuTabClose
            // 
            this.menuTabClose.Name = "menuTabClose";
            this.menuTabClose.Size = new System.Drawing.Size(226, 24);
            this.menuTabClose.Text = "Закрити вкладку";
            this.menuTabClose.Click += new System.EventHandler(this.menuTabClose_Click);
            // 
            // menuTabCloseOthers
            // 
            this.menuTabCloseOthers.Name = "menuTabCloseOthers";
            this.menuTabCloseOthers.Size = new System.Drawing.Size(226, 24);
            this.menuTabCloseOthers.Text = "Закрити інші вкладки";
            this.menuTabCloseOthers.Click += new System.EventHandler(this.menuTabCloseOthers_Click);
            // 
            // tabState
            // 
            this.tabState.Controls.Add(this.gbState);
            this.tabState.Location = new System.Drawing.Point(4, 25);
            this.tabState.Name = "tabState";
            this.tabState.Padding = new System.Windows.Forms.Padding(8);
            this.tabState.Size = new System.Drawing.Size(1018, 717);
            this.tabState.TabIndex = 0;
            this.tabState.Text = "Стан клубу";
            this.tabState.UseVisualStyleBackColor = true;
            // 
            // gbState
            // 
            this.gbState.Controls.Add(this.flowState);
            this.gbState.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbState.Location = new System.Drawing.Point(8, 8);
            this.gbState.Name = "gbState";
            this.gbState.Size = new System.Drawing.Size(1002, 60);
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
            this.flowState.Location = new System.Drawing.Point(3, 18);
            this.flowState.Name = "flowState";
            this.flowState.Size = new System.Drawing.Size(996, 39);
            this.flowState.TabIndex = 0;
            // 
            // lblStat1
            // 
            this.lblStat1.AutoSize = true;
            this.lblStat1.Location = new System.Drawing.Point(3, 6);
            this.lblStat1.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat1.Name = "lblStat1";
            this.lblStat1.Size = new System.Drawing.Size(0, 16);
            this.lblStat1.TabIndex = 0;
            // 
            // lblStat2
            // 
            this.lblStat2.AutoSize = true;
            this.lblStat2.Location = new System.Drawing.Point(36, 6);
            this.lblStat2.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat2.Name = "lblStat2";
            this.lblStat2.Size = new System.Drawing.Size(0, 16);
            this.lblStat2.TabIndex = 1;
            // 
            // lblStat3
            // 
            this.lblStat3.AutoSize = true;
            this.lblStat3.Location = new System.Drawing.Point(69, 6);
            this.lblStat3.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat3.Name = "lblStat3";
            this.lblStat3.Size = new System.Drawing.Size(0, 16);
            this.lblStat3.TabIndex = 2;
            // 
            // lblStat4
            // 
            this.lblStat4.AutoSize = true;
            this.lblStat4.Location = new System.Drawing.Point(102, 6);
            this.lblStat4.Margin = new System.Windows.Forms.Padding(3, 6, 30, 3);
            this.lblStat4.Name = "lblStat4";
            this.lblStat4.Size = new System.Drawing.Size(0, 16);
            this.lblStat4.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПК клуб";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.menuTab.ResumeLayout(false);
            this.tabState.ResumeLayout(false);
            this.gbState.ResumeLayout(false);
            this.flowState.ResumeLayout(false);
            this.flowState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuCloseTab;
        private System.Windows.Forms.ToolStripSeparator menuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabState;
        private System.Windows.Forms.GroupBox gbState;
        private System.Windows.Forms.FlowLayoutPanel flowState;
        private System.Windows.Forms.Label lblStat1;
        private System.Windows.Forms.Label lblStat2;
        private System.Windows.Forms.Label lblStat3;
        private System.Windows.Forms.Label lblStat4;
        private System.Windows.Forms.ContextMenuStrip menuTab;
        private System.Windows.Forms.ToolStripMenuItem menuTabClose;
        private System.Windows.Forms.ToolStripMenuItem menuTabCloseOthers;
    }
}
