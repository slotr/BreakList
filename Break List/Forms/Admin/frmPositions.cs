using System.Data;
using Break_List.Properties;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Admin
{
    public partial class FrmPositions : XtraForm
    {
        private readonly MySqlConnection _con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand _cmd;
        public FrmPositions()
        {
            InitializeComponent();
            GetDepartments();
           
        }
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

        void InsertPosition()
        {
            _con.Open();
            _cmd = new MySqlCommand("INSERT INTO positions(DepartmentName, PositionName) VALUES(@DepartmentName, @PositionName)", _con);
            _cmd.Parameters.Add("@DepartmentName", MySqlDbType.VarChar, 45);
            _cmd.Parameters.Add("@PositionName", MySqlDbType.VarChar, 45);
            _cmd.Parameters["@DepartmentName"].Value = comboBoxEdit1.EditValue.ToString();
            _cmd.Parameters["@PositionName"].Value = textEdit1.Text;
            _cmd.ExecuteNonQuery();
            _con.Close();
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    InsertPosition();
                    break;
                case "Save And Close":
                    InsertPosition();
                    Close();
                    break;
                case "Save And New":
                    InsertPosition();
                    txtPosition.Text = "";
                    break;
            }
        }

        private void comboBoxEdit1_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Plus)
            {
                FrmDepartments departments = new FrmDepartments {MdiParent = this};
                departments.Show();
            }
            
        }
    }
}