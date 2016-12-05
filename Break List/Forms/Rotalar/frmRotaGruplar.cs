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
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.Rotalar
{
    public partial class frmRotaGruplar : DevExpress.XtraEditors.XtraForm
    {
        public frmRotaGruplar()
        {
            InitializeComponent();
        }
        public string _departmentNameFromMainForm { get; set; }
        private void frmRotaGruplar_Load(object sender, EventArgs e)
        {
            getGroup();
        }
        void getGroup()
        {
            using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("spRotagrup;", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", _departmentNameFromMainForm));

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
            if (Column == colDeg)
            {
                int rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "ResourceID");
                using (var frmGroupDegistir = new frmGroupDegistir())
                {
                    frmGroupDegistir.rowID = rowid.ToString();
                    
                    var dr = frmGroupDegistir.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        getGroup();
                    }
                }

            }
        }
    }
}