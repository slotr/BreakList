using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Maas
{
    public partial class FrmMaasTipOnaylari : DevExpress.XtraEditors.XtraForm
    {
        public FrmMaasTipOnaylari()
        {
            InitializeComponent();
        }

        private void frmMaasTipOnaylari_Load(object sender, EventArgs e)
        {
           
            spMaasTipOnayiTableAdapter.Fill(livegameDataSet1.spMaasTipOnayi);


        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }
        public string UserNameFromMainForm { get; set; }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column == gridColumn1)
            {

                var result = MessageBox.Show(@"Maas veya tip artisina onay vereceksiniz.", @"Emin misiniz?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;
                var rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                using (var con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (var cmd = new MySqlCommand("spMaastipOnalya;", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {

                        cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                        cmd.Parameters.Add(new MySqlParameter("userName", UserNameFromMainForm));

                        con.Open();
                        cmd.ExecuteNonQuery();
                        using (var mySqlDataAdapter = new MySqlDataAdapter())
                        {
                            
                            mySqlDataAdapter.SelectCommand = cmd;
                        }
                        con.Close();
                    }
                    spMaasTipOnayiTableAdapter.Fill(livegameDataSet1.spMaasTipOnayi);
                    spMaasTipOnayiGridControl.Refresh();
                }
            }
            else if (column == gridColumn2)
            {

                var result1 = MessageBox.Show(@"Maas veya tip artisina Rededeceksiniz.", @"Emin misiniz?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result1 != DialogResult.Yes) return;
                var rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                using (var con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (var cmd = new MySqlCommand("Delete from maaslar where id=" + rowid, con)
                    {
                        CommandType = CommandType.Text
                    })
                    {

                        cmd.Parameters.Add(new MySqlParameter("rowID", rowid));

                        con.Open();
                        cmd.ExecuteNonQuery();
                        using (var mySqlDataAdapter = new MySqlDataAdapter())
                        {
                            mySqlDataAdapter.SelectCommand = cmd;

                        }
                        con.Close();
                    }
                    spMaasTipOnayiTableAdapter.Fill(livegameDataSet1.spMaasTipOnayi);
                    spMaasTipOnayiGridControl.Refresh();
                }
            }
        }
    }
}
