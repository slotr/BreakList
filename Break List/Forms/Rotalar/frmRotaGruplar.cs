using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.Rotalar
{
    public partial class FrmRotaGruplar : DevExpress.XtraEditors.XtraForm
    {
        public FrmRotaGruplar()
        {
            InitializeComponent();
        }
        public string DepartmentNameFromMainForm { get; set; }
        private void frmRotaGruplar_Load(object sender, EventArgs e)
        {
            GetGroup();
        }
        void GetGroup()
        {
            using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("spRotagrup;", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", DepartmentNameFromMainForm));

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
            if (column == colDeg)
            {
                int rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "ResourceID");
                using (var frmGroupDegistir = new FrmGroupDegistir())
                {
                    frmGroupDegistir.RowId = rowid.ToString();
                    
                    var dr = frmGroupDegistir.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        GetGroup();
                    }
                }

            }
        }
    }
}