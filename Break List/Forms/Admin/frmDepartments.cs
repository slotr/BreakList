using Break_List.Properties;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Admin
{
    public partial class FrmDepartments : XtraForm
    {
        private readonly MySqlConnection _con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand _cmd;
        public FrmDepartments()
        {
            InitializeComponent();

        }

        void InsertDepartment()
        {
                         _con.Open();
                        _cmd = new MySqlCommand("INSERT INTO departments(DepartmentName) VALUES(@DepartmentName)", _con);
                        _cmd.Parameters.Add("@DepartmentName", MySqlDbType.VarChar, 45);
                        _cmd.Parameters["@DepartmentName"].Value = txtDepartment.Text;
                        _cmd.ExecuteNonQuery();
                        _con.Close();
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {switch (e.Button.Properties.Caption)
            {
                case "Save":
                    InsertDepartment();
                    break;
                case "Save And Close":
                    InsertDepartment();
                    Close();
                    break;
                case "Save And New":
                    InsertDepartment();
                    txtDepartment.Text = "";
                    break;
            }
        }
    }                
}
  