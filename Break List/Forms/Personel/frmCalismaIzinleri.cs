using System;

namespace Break_List.Forms.Personel
{
    public partial class FrmCalismaIzinleri : DevExpress.XtraEditors.XtraForm
    {
        public FrmCalismaIzinleri()
        {
            InitializeComponent();
        }

        private void frmCalismaIzinleri_Load(object sender, EventArgs e)
        {
            
            spCalismaIzinTakibiTableAdapter.Fill(livegameDataSet1.spCalismaIzinTakibi);
            schedulerControl1.Start = DateTime.Today;
        }
    }
    
}