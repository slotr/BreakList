using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Break_List.Forms
{
    public partial class FrmOperationDate : XtraForm
    {
        public FrmOperationDate()
        {
            InitializeComponent();
        }

        private void frmOperationDate_Load(object sender, EventArgs e)
        {
            
        }
         DateTime EndDate { get; set; }
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.operationDate = Convert.ToDateTime(dateEdit1.EditValue.ToString());
            Properties.Settings.Default.StartDate = Convert.ToDateTime(dateEdit1.EditValue.ToString());            
            EndDate = Convert.ToDateTime(dateEdit1.EditValue.ToString());
            dateEdit2.EditValue = EndDate.AddHours(26);
            Properties.Settings.Default.Save();
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit2.EditValue != null)
            {
                Properties.Settings.Default.EndDate = Convert.ToDateTime(dateEdit2.EditValue.ToString());
                Properties.Settings.Default.Save();
                simpleButton1.Visible = true;
            }
        }

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateEdit1.EditValue == null)
            {
                MessageBox.Show(@"Shift Başlangıç tarihi ayarlanmadı", @"Bir Hata Oluştu.");
            }
            else
            {
                Close();
            }
            
        }
    }
}