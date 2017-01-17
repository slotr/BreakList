using System;
using System.Data;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.Envanter
{
    public partial class FrmEnvanter : XtraForm
    {
        public string Department;
        public FrmEnvanter()
        {
            InitializeComponent();
            
        }

       void GetEnvanterTree()
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spEnvanterListesi;", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new MySqlParameter("_departman", Department));                
                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        listGrid.DataSource = dt;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }

        private void frmEnvanter_Load(object sender, EventArgs e)
        {
            GetEnvanterTree();
        }

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column == colparca)
            {
                string parca = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "parca");
                using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    var cmd = new MySqlCommand("spEnvanterListesiDetay;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("_departman", Department));
                    cmd.Parameters.Add(new MySqlParameter("_parca", parca));
                    conn.Open();

                    using (var adapter = new MySqlDataAdapter())
                    {
                        var dt = new DataTable();
                        adapter.SelectCommand = cmd;
                        {
                            adapter.Fill(dt);
                            detayGrid.DataSource = dt;
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}