using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Break_List.Forms.Maas
{
    public partial class frmMaasArtisiGoster : DevExpress.XtraEditors.XtraForm
    {
        public int rowid { get; set; }
        public frmMaasArtisiGoster()
        {
            InitializeComponent();
        }

       
        private void frmMaasArtisiGoster_Load(object sender, EventArgs e)
        {
            try
            {
                spMaasartisiniGosterTableAdapter.Fill(livegameDataSet1.spMaasartisiniGoster, rowid);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}