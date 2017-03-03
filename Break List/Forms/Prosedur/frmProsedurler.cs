using System;
using System.Data;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.Prosedur
{
    public partial class FrmProsedurler : DevExpress.XtraEditors.XtraForm
    {
        public FrmProsedurler()
        {
            InitializeComponent();
        }

        private void frmProsedurler_Load(object sender, EventArgs e)
        {
            GetProcedures();

        }
        public string DepartmentNameFromMainForm { get; set; }

        private void GetProcedures()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("spProcedure;", conn) { CommandType = CommandType.StoredProcedure };
                //string _department = _departmentNameFromMainForm;               
                //cmd.Parameters.Add(new MySqlParameter("DepartmentName", _department));

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;
                    }
                }
                conn.Close();
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column == colGoruntule)
            {
                int rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "No");

                var display = new FrmProsedurDisplay
                {
                    Rowid = rowid.ToString(),
                    Goster = true
                };
                display.Show();

               
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
        
    }
}