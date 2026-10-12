using System;
using PC_Club.PCClubDataSetTableAdapters;

namespace PC_Club.Forms
{
    public partial class EmployeeForm : BaseTableForm
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            var ds = new PCClubDataSet();
            var adapter = new EmployeeTableAdapter();
            adapter.Fill(ds.Employee);
            Bind(ds.Employee, () => adapter.Update(ds.Employee));

            HideInEditor("user_id");
            dgv.Columns["user_id"].Visible = false;
        }
    }
}