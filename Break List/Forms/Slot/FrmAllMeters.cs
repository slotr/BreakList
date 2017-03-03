using System;
using DevExpress.XtraEditors;

namespace Break_List.Forms.Slot
{
    public partial class FrmAllMeters : XtraForm
    {
        public FrmAllMeters()
        {
            InitializeComponent();
        }

        private void tblslotresultsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblslotresultsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.livegameDataSet1);

        }

        private void FrmAllMeters_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.tblslotresults' table. You can move, or remove it, as needed.
            this.tblslotresultsTableAdapter.Fill(this.livegameDataSet1.tblslotresults);

        }
    }
}