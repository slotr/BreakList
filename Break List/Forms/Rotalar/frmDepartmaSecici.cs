using System;
using System.Data;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Rotalar
{
    public partial class FrmDepartmaSecici : DevExpress.XtraEditors.XtraForm
    {
        public FrmDepartmaSecici()
        {
            InitializeComponent();
            GetDepartments();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SecilenDepartman = comboBoxEdit1.Text;
        }
        public string SecilenDepartman { get; set; }
        void GetDepartments() // Yeni Kayit Olusturulurken Aliyor
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

                    foreach (DataRow row in dt.Rows)
                    {

                        comboBoxEdit1.Properties.Items.Add(row["DepartmentName"]);

                    }

                    comboBoxEdit1.Properties.Sorted = true;


                }
            }

        }
    }
}