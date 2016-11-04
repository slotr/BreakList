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
using Break_List.Properties;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.Personel
{
    public partial class frmEgitimler : XtraForm
    {
        public frmEgitimler()
        {
            InitializeComponent();
            getDepartment();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bringNamesbyDepartment();
        }

        void getDepartment()
        {
            var connectionString = Settings.Default.livegameConnectionString2;
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spDepartment";
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow Row in dt.Rows)
                    {

                        comboBoxEdit1.Properties.Items.Add(Row["DepartmentName"]);

                    }

                    comboBoxEdit1.Properties.Sorted = true;

                    cnn.Close();
                }
            }
        }

        void bringNamesbyDepartment()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spLivePersonelbyDepartment;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    string dep = comboBoxEdit1.EditValue.ToString(); ;
                    mySqlCommand.Parameters.Add(new MySqlParameter("_department", dep));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        gridControl2.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridColumn Column = e.Column;
            int rowid;
            string personelName;
            if(Column == gridColumn1)
            {
              rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "personel");
              using (frmEgitimGirisi frmEgitimGirisi = new frmEgitimGirisi())
                {
                    frmEgitimGirisi.personelID = rowid;
                    frmEgitimGirisi.lblPersonel.Text = personelName;
                    DialogResult dr = frmEgitimGirisi.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        
                    }
                    
                    
                }
            }
            if (Column == personel)
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