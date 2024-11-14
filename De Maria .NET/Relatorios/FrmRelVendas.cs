using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_Maria.NET.Relatorios
{
    public partial class FrmRelVendas : Form
    {
        DataTable dt = new DataTable();
        public FrmRelVendas(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void FrmRelVendas_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetVendas", dt));
            this.reportViewer1.RefreshReport();
        }
    }
}
