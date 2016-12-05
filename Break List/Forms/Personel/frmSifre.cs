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

namespace Break_List.Forms.Personel
{
    public partial class frmSifre : DevExpress.XtraEditors.XtraForm
    {
        public frmSifre()
        {
            InitializeComponent();
        }
        string sifre = "135642";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == sifre) {
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