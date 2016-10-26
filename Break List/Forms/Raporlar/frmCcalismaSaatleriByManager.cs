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

namespace Break_List
{
    public partial class frmCcalismaSaatleriByManager : DevExpress.XtraEditors.XtraForm
    {
        public frmCcalismaSaatleriByManager()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void frmCcalismaSaatleriByManager_Load(object sender, EventArgs e)
        {
            getDepartments();
        }
        private void getTimes()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spCalismaSaatleriAll;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    
                    mySqlCommand.Parameters.Add(new MySqlParameter("StartDate", dateEdit1.EditValue));
                    mySqlCommand.Parameters.Add(new MySqlParameter("EndDate", dateEdit2.EditValue));
                    mySqlCommand.Parameters.Add(new MySqlParameter("DepartmentName", comboBoxEdit1.EditValue));
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
        void getDepartments() // Yeni Kayit Olusturulurken Aliyor
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


                }
            }

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTimes();
        }
    }
}