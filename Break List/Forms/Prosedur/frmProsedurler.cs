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
using System.IO;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Break_List.Properties;

namespace Break_List.Forms.Prosedur
{
    public partial class frmProsedurler : DevExpress.XtraEditors.XtraForm
    {
        public frmProsedurler()
        {
            InitializeComponent();
        }

        private void frmProsedurler_Load(object sender, EventArgs e)
        {
            getProcedures();

        }
        public string _departmentNameFromMainForm { get; set; }
        void getProcedures()
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
            var Column = e.Column;
            if (Column == colGoruntule)
            {
                int rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "No");

                frmProsedurDisplay display = new frmProsedurDisplay();
                display.rowid = rowid;
                display.goster = true;
                display.Show();

               
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
        
    }
}