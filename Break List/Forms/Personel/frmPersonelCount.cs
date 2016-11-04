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
    public partial class frmPersonelCount : DevExpress.XtraEditors.XtraForm
    {
        public frmPersonelCount()
        {
            InitializeComponent();
        }

        

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            
            spCountPersonelTableAdapter.Fill(livegameDataSet1.spCountPersonel,
               Convert.ToDateTime(dateEdit1.EditValue.ToString()), Convert.ToDateTime(dateEdit2.EditValue.ToString()));
        }
    }
}