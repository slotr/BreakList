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
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Maas
{
    public partial class frmMaasTipOnaylari : DevExpress.XtraEditors.XtraForm
    {
        public frmMaasTipOnaylari()
        {
            InitializeComponent();
        }

        private void frmMaasTipOnaylari_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.spMaasTipOnayi' table. You can move, or remove it, as needed.
            this.spMaasTipOnayiTableAdapter.Fill(this.livegameDataSet1.spMaasTipOnayi);


        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }
        public string _UserNameFromMainForm { get; set; }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn Column = e.Column;
            if (Column == gridColumn1)
            {

                DialogResult result = MessageBox.Show("Maas veya tip artisina onay vereceksiniz.", "Emin misiniz?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int rowid;
                    rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                    using (MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("spMaastipOnalya;", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {

                            cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                            cmd.Parameters.Add(new MySqlParameter("userName", _UserNameFromMainForm));

                            con.Open();
                            cmd.ExecuteNonQuery();
                            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                            {
                                DataTable dataTable = new DataTable();
                                mySqlDataAdapter.SelectCommand = cmd;

                            }
                            con.Close();
                        }
                        this.spMaasTipOnayiTableAdapter.Fill(this.livegameDataSet1.spMaasTipOnayi);
                        spMaasTipOnayiGridControl.Refresh();
                    }
                }
               
            }
            else if (Column == gridColumn2)
            {

                DialogResult result1 = MessageBox.Show("Maas veya tip artisina Rededeceksiniz.", "Emin misiniz?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result1 == DialogResult.Yes)
                {
                    int rowid;
                    rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                    using (MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Delete from maaslar where id=" + rowid, con)
                        {
                            CommandType = CommandType.Text
                        })
                        {

                            cmd.Parameters.Add(new MySqlParameter("rowID", rowid));

                            con.Open();
                            cmd.ExecuteNonQuery();
                            using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                            {
                                DataTable dataTable = new DataTable();
                                mySqlDataAdapter.SelectCommand = cmd;

                            }
                            con.Close();
                        }
                        this.spMaasTipOnayiTableAdapter.Fill(this.livegameDataSet1.spMaasTipOnayi);
                        spMaasTipOnayiGridControl.Refresh();
                    }
                }


            }
        }
    }
}
