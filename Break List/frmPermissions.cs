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
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List
{
    public partial class frmPermissions : DevExpress.XtraEditors.XtraForm
    {
        
        public frmPermissions()
        {
            InitializeComponent();
        }
        customProperties prop = new customProperties();
        void getPErmissions()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                MySqlCommand command = new MySqlCommand("spAlluserPermissions;", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;                
                              
                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = command;
                    {
                        adapter.Fill(dt);
                        userPermissionsGridControl.DataSource = dt;
                    }
                }
                conn.Close();
            }

        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            getPErmissions();
        }
        public int personelID;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            personelID = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "User Id");
            var personel = new frmPersonelDetails
            {
                MdiParent = this.ParentForm,
                _personelID = personelID.ToString()

            };

            personel.Show();
        }
    }
}