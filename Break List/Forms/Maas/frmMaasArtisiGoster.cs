using System;

namespace Break_List.Forms.Maas
{
    public partial class FrmMaasArtisiGoster : DevExpress.XtraEditors.XtraForm
    {
        public int Rowid { get; set; }
        public FrmMaasArtisiGoster()
        {
            InitializeComponent();
        }

       
        private void frmMaasArtisiGoster_Load(object sender, EventArgs e)
        {
            try
            {
                spMaasartisiniGosterTableAdapter.Fill(livegameDataSet1.spMaasartisiniGoster, Rowid);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}