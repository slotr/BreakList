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
    public partial class frmPersonelList : XtraForm
    {
        public string _departmentNameFromMainForm { get; set; }
        public frmPersonelList()
        {
            InitializeComponent();           
            
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            getNames();

        }

        void getNames()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                MySqlCommand command = new MySqlCommand("spPersonel;", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                string _department = _departmentNameFromMainForm;                
                command.Parameters.Add(new MySqlParameter("DepartmentName", _department));

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = command;
                    {
                        adapter.Fill(dt);
                        resourcesGridControl.DataSource = dt;
                    }
                }
                conn.Close();
            }

        }
        public int personelID;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks > 0)
            {
                personelID = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel ID");
                var personel = new frmPersonelDetails
                {
                    MdiParent = this.ParentForm,                   
                   _personelID = personelID.ToString()

                };

                personel.Show();
            }
        }
    }
}