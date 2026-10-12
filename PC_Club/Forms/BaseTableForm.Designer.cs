namespace PC_Club.Forms
{
    partial class BaseTableForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseTableForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearchField = new System.Windows.Forms.ComboBox();
            this.btnRemoveCond = new System.Windows.Forms.Button();
            this.lstConditions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOp = new System.Windows.Forms.ComboBox();
            this.lblFound = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSortDesc = new System.Windows.Forms.Button();
            this.btnSortAsc = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cbField = new System.Windows.Forms.ComboBox();
            this.menuOps = new System.Windows.Forms.MenuStrip();
            this.операціїНажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.впорядкуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSortAsc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSortDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.panelFields = new System.Windows.Forms.Panel();
            this.panelEditButtons = new System.Windows.Forms.Panel();
            this.btnCancelRecord = new System.Windows.Forms.Button();
            this.btnSaveRecord = new System.Windows.Forms.Button();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.menuOps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelEdit.SuspendLayout();
            this.panelEditButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.cbSearchField);
            this.panelTop.Controls.Add(this.btnRemoveCond);
            this.panelTop.Controls.Add(this.lstConditions);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.cbOp);
            this.panelTop.Controls.Add(this.lblFound);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnReset);
            this.panelTop.Controls.Add(this.btnFind);
            this.panelTop.Controls.Add(this.btnFilter);
            this.panelTop.Controls.Add(this.btnSortDesc);
            this.panelTop.Controls.Add(this.btnSortAsc);
            this.panelTop.Controls.Add(this.txtValue);
            this.panelTop.Controls.Add(this.cbField);
            this.panelTop.Controls.Add(this.menuOps);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1122, 155);
            this.panelTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSearch.Location = new System.Drawing.Point(669, 108);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 22);
            this.txtSearch.TabIndex = 18;
            // 
            // cbSearchField
            // 
            this.cbSearchField.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbSearchField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchField.FormattingEnabled = true;
            this.cbSearchField.Location = new System.Drawing.Point(542, 108);
            this.cbSearchField.Name = "cbSearchField";
            this.cbSearchField.Size = new System.Drawing.Size(121, 24);
            this.cbSearchField.TabIndex = 17;
            // 
            // btnRemoveCond
            // 
            this.btnRemoveCond.Location = new System.Drawing.Point(187, 108);
            this.btnRemoveCond.Name = "btnRemoveCond";
            this.btnRemoveCond.Size = new System.Drawing.Size(131, 37);
            this.btnRemoveCond.TabIndex = 16;
            this.btnRemoveCond.Text = "Видалити умову";
            this.btnRemoveCond.UseVisualStyleBackColor = true;
            this.btnRemoveCond.Click += new System.EventHandler(this.btnRemoveCond_Click);
            // 
            // lstConditions
            // 
            this.lstConditions.FormattingEnabled = true;
            this.lstConditions.ItemHeight = 16;
            this.lstConditions.Location = new System.Drawing.Point(12, 50);
            this.lstConditions.Name = "lstConditions";
            this.lstConditions.Size = new System.Drawing.Size(467, 52);
            this.lstConditions.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Умови фільтра: ";
            // 
            // cbOp
            // 
            this.cbOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOp.FormattingEnabled = true;
            this.cbOp.Items.AddRange(new object[] {
            "містить",
            ">",
            "<",
            "="});
            this.cbOp.Location = new System.Drawing.Point(252, 27);
            this.cbOp.Name = "cbOp";
            this.cbOp.Size = new System.Drawing.Size(121, 24);
            this.cbOp.TabIndex = 13;
            // 
            // lblFound
            // 
            this.lblFound.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFound.AutoSize = true;
            this.lblFound.Location = new System.Drawing.Point(629, 70);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(0, 16);
            this.lblFound.TabIndex = 12;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(950, 50);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 37);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Location = new System.Drawing.Point(950, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 37);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(361, 108);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(123, 37);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Скинути";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFind.Location = new System.Drawing.Point(542, 60);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(81, 37);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Пошук";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(12, 108);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(127, 37);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Додати умову";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSortDesc.Location = new System.Drawing.Point(847, 93);
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(97, 37);
            this.btnSortDesc.TabIndex = 3;
            this.btnSortDesc.Text = "Я-А";
            this.btnSortDesc.UseVisualStyleBackColor = true;
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSortAsc.Location = new System.Drawing.Point(847, 50);
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(97, 37);
            this.btnSortAsc.TabIndex = 2;
            this.btnSortAsc.Text = "А-Я";
            this.btnSortAsc.UseVisualStyleBackColor = true;
            this.btnSortAsc.Click += new System.EventHandler(this.btnSortAsc_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(379, 27);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 22);
            this.txtValue.TabIndex = 1;
            // 
            // cbField
            // 
            this.cbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbField.FormattingEnabled = true;
            this.cbField.Location = new System.Drawing.Point(125, 27);
            this.cbField.Name = "cbField";
            this.cbField.Size = new System.Drawing.Size(121, 24);
            this.cbField.TabIndex = 0;
            // 
            // menuOps
            // 
            this.menuOps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuOps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.операціїНажToolStripMenuItem});
            this.menuOps.Location = new System.Drawing.Point(0, 0);
            this.menuOps.Name = "menuOps";
            this.menuOps.Size = new System.Drawing.Size(1122, 30);
            this.menuOps.TabIndex = 8;
            this.menuOps.Text = "menuStrip1";
            // 
            // операціїНажToolStripMenuItem
            // 
            this.операціїНажToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.впорядкуванняToolStripMenuItem,
            this.menuFilter,
            this.menuFind,
            this.menuReset});
            this.операціїНажToolStripMenuItem.Name = "операціїНажToolStripMenuItem";
            this.операціїНажToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.операціїНажToolStripMenuItem.Text = "Операції з даними";
            // 
            // впорядкуванняToolStripMenuItem
            // 
            this.впорядкуванняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSortAsc,
            this.menuSortDesc});
            this.впорядкуванняToolStripMenuItem.Name = "впорядкуванняToolStripMenuItem";
            this.впорядкуванняToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.впорядкуванняToolStripMenuItem.Text = "Впорядкування";
            // 
            // menuSortAsc
            // 
            this.menuSortAsc.Name = "menuSortAsc";
            this.menuSortAsc.Size = new System.Drawing.Size(117, 26);
            this.menuSortAsc.Text = "А-Я";
            this.menuSortAsc.Click += new System.EventHandler(this.menuSortAsc_Click);
            // 
            // menuSortDesc
            // 
            this.menuSortDesc.Name = "menuSortDesc";
            this.menuSortDesc.Size = new System.Drawing.Size(117, 26);
            this.menuSortDesc.Text = "Я-А";
            this.menuSortDesc.Click += new System.EventHandler(this.menuSortDesc_Click);
            // 
            // menuFilter
            // 
            this.menuFilter.Name = "menuFilter";
            this.menuFilter.Size = new System.Drawing.Size(200, 26);
            this.menuFilter.Text = "Фільтрація";
            this.menuFilter.Click += new System.EventHandler(this.menuFilter_Click);
            // 
            // menuFind
            // 
            this.menuFind.Name = "menuFind";
            this.menuFind.Size = new System.Drawing.Size(200, 26);
            this.menuFind.Text = "Пошук";
            this.menuFind.Click += new System.EventHandler(this.menuFind_Click);
            // 
            // menuReset
            // 
            this.menuReset.Name = "menuReset";
            this.menuReset.Size = new System.Drawing.Size(200, 26);
            this.menuReset.Text = "Скинути";
            this.menuReset.Click += new System.EventHandler(this.menuReset_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 652);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1122, 27);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // dgv
            // 
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.DataSource = this.bindingSource1;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 155);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(792, 475);
            this.dgv.TabIndex = 2;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.panelFields);
            this.panelEdit.Controls.Add(this.panelEditButtons);
            this.panelEdit.Controls.Add(this.lblEditTitle);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEdit.Location = new System.Drawing.Point(792, 155);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(330, 497);
            this.panelEdit.TabIndex = 3;
            // 
            // panelFields
            // 
            this.panelFields.AutoScroll = true;
            this.panelFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFields.Location = new System.Drawing.Point(0, 16);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(330, 426);
            this.panelFields.TabIndex = 1;
            // 
            // panelEditButtons
            // 
            this.panelEditButtons.Controls.Add(this.btnCancelRecord);
            this.panelEditButtons.Controls.Add(this.btnSaveRecord);
            this.panelEditButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEditButtons.Location = new System.Drawing.Point(0, 442);
            this.panelEditButtons.Name = "panelEditButtons";
            this.panelEditButtons.Size = new System.Drawing.Size(330, 55);
            this.panelEditButtons.TabIndex = 2;
            // 
            // btnCancelRecord
            // 
            this.btnCancelRecord.Location = new System.Drawing.Point(204, 16);
            this.btnCancelRecord.Name = "btnCancelRecord";
            this.btnCancelRecord.Size = new System.Drawing.Size(98, 23);
            this.btnCancelRecord.TabIndex = 1;
            this.btnCancelRecord.Text = "Скасувати";
            this.btnCancelRecord.UseVisualStyleBackColor = true;
            this.btnCancelRecord.Click += new System.EventHandler(this.btnCancelRecord_Click);
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.Location = new System.Drawing.Point(28, 16);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(98, 23);
            this.btnSaveRecord.TabIndex = 0;
            this.btnSaveRecord.Text = "Зберегти";
            this.btnSaveRecord.UseVisualStyleBackColor = true;
            this.btnSaveRecord.Click += new System.EventHandler(this.btnSaveRecord_Click);
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.AutoSize = true;
            this.lblEditTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEditTitle.Location = new System.Drawing.Point(0, 0);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(161, 16);
            this.lblEditTitle.TabIndex = 0;
            this.lblEditTitle.Text = "Редагування запису";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.lblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 16);
            // 
            // BaseTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 679);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.panelTop);
            this.Name = "BaseTableForm";
            this.Text = "BaseTableForm";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.menuOps.ResumeLayout(false);
            this.menuOps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.panelEditButtons.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cbField;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnSortDesc;
        private System.Windows.Forms.Button btnSortAsc;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        protected System.Windows.Forms.DataGridView dgv;
        protected System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip menuOps;
        private System.Windows.Forms.ToolStripMenuItem операціїНажToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem впорядкуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSortAsc;
        private System.Windows.Forms.ToolStripMenuItem menuSortDesc;
        private System.Windows.Forms.ToolStripMenuItem menuFilter;
        private System.Windows.Forms.ToolStripMenuItem menuFind;
        private System.Windows.Forms.ToolStripMenuItem menuReset;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.ListBox lstConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOp;
        private System.Windows.Forms.Button btnRemoveCond;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Panel panelFields;
        private System.Windows.Forms.Panel panelEditButtons;
        private System.Windows.Forms.Button btnCancelRecord;
        private System.Windows.Forms.Button btnSaveRecord;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearchField;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
    }
}