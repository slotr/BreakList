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

namespace Break_List.Forms
{
    public partial class frmPermissions : DevExpress.XtraEditors.XtraForm
    {
        public frmPermissions()
        {
            InitializeComponent();
            this.repositoryItemCheckEdit1.ValueChecked = Convert.ToByte(1);
            this.repositoryItemCheckEdit1.ValueUnchecked = Convert.ToByte(0);
        }

        private void permissionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           

        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.permissions' table. You can move, or remove it, as needed.
            this.permissionsTableAdapter.Fill(this.livegameDataSet1.permissions);


        }



        private void permissionsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            
            string caption = "Kullanici haklari yenilenecek";
            string message = "Kullanıcı haklarını değiştirmek istedişinizden emin misiniz? ";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                this.Validate();
                this.permissionsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.livegameDataSet1);

            }
            else
            {
                permissionsBindingSource.CancelEdit();
                this.permissionsTableAdapter.Fill(this.livegameDataSet1.permissions);
            }
        }

        private void repositoryItemCheckEdit1_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            string val = "";

            if (e.Value != null)
            {
                val = e.Value.ToString();
            }

            if (val.Equals("1"))
            {
                e.CheckState = CheckState.Checked;
            }
            else
            {
                e.CheckState = CheckState.Unchecked;
            }

            e.Handled = true;
        }
    }
}