using System;

namespace Break_List.Forms.Personel
{
    public partial class FrmPersonelCount : DevExpress.XtraEditors.XtraForm
    {
        public FrmPersonelCount()
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