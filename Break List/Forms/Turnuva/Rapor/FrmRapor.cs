using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Break_List.Forms.Turnuva.Rapor
{
    public partial class FrmRapor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.tblturnuva_katilimci' table. You can move, or remove it, as needed.
            this.tblturnuva_katilimciTableAdapter.Fill(this.livegameDataSet1.tblturnuva_katilimci);

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            pivotGridControl1.ShowRibbonPrintPreview();}
    }
}