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

namespace Break_List.Forms.Kasa
{
    public partial class frmAvanslar : DevExpress.XtraEditors.XtraForm
    {
        public frmAvanslar()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            spAvansListesiTableAdapter.Fill(livegameDataSet1.spAvansListesi, Convert.ToDateTime(dateEdit1.EditValue.ToString()), Convert.ToDateTime(dateEdit2.EditValue.ToString()));
            
        }
    }
}