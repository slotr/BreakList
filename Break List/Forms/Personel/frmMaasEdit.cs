using System;
using DevExpress.XtraEditors;

namespace Break_List.Forms.Personel
{
    public partial class FrmMaasEdit : XtraForm
    {
        public string UserName{get; set; }
        public string PersonelId { get; set; }
        public FrmMaasEdit()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}