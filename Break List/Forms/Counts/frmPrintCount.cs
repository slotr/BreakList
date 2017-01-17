using System;
using DevExpress.XtraEditors;

namespace Break_List.Forms.Counts
{
    public partial class FrmPrintCount : XtraForm
    {
        public DateTime Tarih;
        public FrmPrintCount()
        {
            InitializeComponent();
        }
        public bool Tip;
        private void frmPrintCount_Load(object sender, EventArgs e)
        {
            if(Tip)
            {
                RptTip report = new RptTip();
                report.Parameters["parameter1"].Value = Tarih;
                report.Parameters["parameter1"].Visible = false;
                documentViewer1.DocumentSource = report;
                report.CreateDocument(true);
            }
            else
            {
                RptCount report = new RptCount();
                report.Parameters["parameter1"].Value = Tarih;
                report.Parameters["parameter1"].Visible = false;
                documentViewer1.DocumentSource = report;
                report.CreateDocument(true);
            }
            
        }
    }
}