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
        public string personelID { get; set; }
        public string avansTipi { get; set; }
        public Boolean flag { get; set; }
        public string userName { get; set; }
        public frmAvanslar()
        {
            InitializeComponent();
        }

        private void frmAvanslar_Load(object sender, EventArgs e)
        {
            //lblPersonel.Text = avansTipi;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                MessageBox.Show("1");
            }
            else
            {
                MessageBox.Show("2");
            }
        }
    }
}