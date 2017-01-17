using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.BreakList
{
    public partial class FrmMasalar : XtraForm
    {
        public FrmMasalar()
        {
            InitializeComponent();
        }

        private void frmMasalar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.tables' table. You can move, or remove it, as needed.
            tablesTableAdapter.Fill(livegameDataSet1.tables);


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Validate();
            tablesBindingSource.EndEdit();
            tableAdapterManager.UpdateAll(livegameDataSet1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show(@"Masa Silinsin mi?", @"Onaylama", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                var view = sender as GridView;
                view?.DeleteRow(view.FocusedRowHandle);
            }
        }
    }
}