using System;
using System.Data;
using System.Windows.Forms;
using Break_List.Class;
using DevExpress.XtraEditors;
using Break_List.Properties;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.Personel
{
    public partial class FrmEgitimler : XtraForm
    {
        public FrmEgitimler()
        {
            InitializeComponent();
            GetDepartment();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BringNamesbyDepartment();
        }

        private void GetDepartment()
        {
            
            using (var con = DbConnection.Con)
            using (var cmd = con.CreateCommand())
            {
                con.Open();
                cmd.CommandText = "spDepartment";
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        comboBoxEdit1.Properties.Items.Add(row["DepartmentName"]);

                    }

                    comboBoxEdit1.Properties.Sorted = true;

                    con.Close();
                }
            }
        }

        private void BringNamesbyDepartment()
        {
            using (var con = DbConnection.Con)
            {
                using (var mySqlCommand = new MySqlCommand("spLivePersonelbyDepartment;", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    string dep = comboBoxEdit1.EditValue.ToString(); 
                    mySqlCommand.Parameters.Add(new MySqlParameter("_department", dep));
                    con.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        gridControl2.DataSource = dataTable;
                    }
                    con.Close();
                }
            }
        }

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridColumn column = e.Column;
            int rowid;
            if(column == gridColumn1)
            {
              rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                var personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "personel");
              using (FrmEgitimGirisi frmEgitimGirisi = new FrmEgitimGirisi())
                {
                    frmEgitimGirisi.PersonelId = rowid;
                    frmEgitimGirisi.lblPersonel.Text = personelName;
                    DialogResult dr = frmEgitimGirisi.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        
                    }
                    
                    
                }
            }
            if (column == personel)
            {
                rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand("spSelectEgitimByPersonel;", mySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        
                        mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", rowid));
                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();
                        using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                        {
                            DataTable dataTable = new DataTable();
                            mySqlDataAdapter.SelectCommand = mySqlCommand;
                            mySqlDataAdapter.Fill(dataTable);
                            gridControl1.DataSource = dataTable;
                        }
                        mySqlConnection.Close();
                    }
                }
            }
        }
    }
}