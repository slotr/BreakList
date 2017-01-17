using System;

namespace Break_List.Reports
{
    public partial class RptMaasArtisi : DevExpress.XtraReports.UI.XtraReport
    {
        public RptMaasArtisi()
        {
            InitializeComponent();
        }

        private void rptMaasArtisi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            spPrintPersonelMaaslariTableAdapter1.Fill(livegameDataSet11.spPrintPersonelMaaslari, Convert.ToString(Parameters["parameter1"].Value));
        }
    }
}
