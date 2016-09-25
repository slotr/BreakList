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

namespace Break_List
{
    public partial class frmPersonel : XtraForm
    {
        public frmPersonel()
        {
            InitializeComponent();           
            resourcesTableAdapter1.Fill(livegameDataSet11.resources);
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
           

        }

        private void btnAddNew_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSource1.AddNew();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Validate();
            bindingSource1.EndEdit();
            resourcesTableAdapter1.Update(livegameDataSet11);
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult result = XtraMessageBox.Show("Bu Kaydı Silmek istediğinizden Emin misiniz?", "Konfirmasyon", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                bindingSource1.RemoveCurrent();
                bindingSource1.EndEdit();
                resourcesTableAdapter1.Update(livegameDataSet11);
            }
            else if (result == DialogResult.No)
            {
               
            }
            
            
        }
    }
}