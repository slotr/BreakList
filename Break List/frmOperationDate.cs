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
using Break_List;

namespace Break_List
{
    public partial class frmOperationDate : DevExpress.XtraEditors.XtraForm
    {
        public frmOperationDate()
        {
            InitializeComponent();
        }

        private void frmOperationDate_Load(object sender, EventArgs e)
        {
            dateNavigator1.EditValue = Properties.Settings.Default.operationDate;
        }

        private void dateNavigator1_EditValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.operationDate = Convert.ToDateTime(dateNavigator1.EditValue);
            Properties.Settings.Default.Save();
            //Close();
        }
    }
}