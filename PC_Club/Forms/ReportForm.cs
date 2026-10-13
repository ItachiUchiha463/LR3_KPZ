using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PC_Club.Forms
{
    public partial class ReportForm : Form
    {
        private readonly ReportDef _report;

        public ReportForm(ReportDef report)
        {
            InitializeComponent();
            _report = report;
            Text = report.Title;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = DateTime.Today.AddDays(-_report.DefaultDays);
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            reportViewer.LocalReport.ReportEmbeddedResource = _report.Resource;
            Build();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            Build();
        }

        private void Build()
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            if (from > to)
            {
                MessageBox.Show("Дата «З» не може бути пізніше за дату «По».", Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sources = new List<ReportDataSource>();
            try
            {
                Cursor = Cursors.WaitCursor;
                foreach (var ds in _report.DataSets)
                    sources.Add(new ReportDataSource(ds.Key, Db.GetTable(ds.Value, Db.P("@from", from), Db.P("@to", to))));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Errors.Friendly(ex), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            reportViewer.LocalReport.DataSources.Clear();
            foreach (ReportDataSource source in sources)
                reportViewer.LocalReport.DataSources.Add(source);
            reportViewer.LocalReport.SetParameters(new[]
            {
                new ReportParameter("PeriodFrom", from.ToString("dd.MM.yyyy")),
                new ReportParameter("PeriodTo", to.ToString("dd.MM.yyyy"))
            });
            reportViewer.RefreshReport();
        }
    }
}
