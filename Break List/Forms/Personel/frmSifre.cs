using System;
using System.Windows.Forms;

namespace Break_List.Forms.Personel
{
    public partial class FrmSifre : DevExpress.XtraEditors.XtraForm
    {
        public FrmSifre()
        {
            InitializeComponent();
        }
        string _sifre = "135642";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == _sifre) {
                simpleButton1.DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show(@"Personel Bilgisi Update edildi");
                simpleButton1.DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}