using System;

namespace Break_List.Forms.Slot
{
    public partial class FrmAllRates : DevExpress.XtraEditors.XtraForm
    {
        public FrmAllRates()
        {
            InitializeComponent();
        }

        private void tblratesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblratesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.livegameDataSet1);

        }

        private void FrmAllRates_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.tblrates' table. You can move, or remove it, as needed.
            this.tblratesTableAdapter.Fill(this.livegameDataSet1.tblrates);

        }
    }
}