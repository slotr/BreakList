using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Break_List.Properties;
using MySql.Data.MySqlClient;


namespace Break_List
{

    public partial class frmMDIMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string _userNameFromLogin { get; set; }  // Login Formundan geliyor.
        customProperties prop = new customProperties();
        string str = Settings.Default.livegameConnectionString2;
        public frmMDIMain()
        {
            InitializeComponent();
        }
               
        
        private void frmMDIMain_Load(object sender, EventArgs e)
        {
            barStaticItem1.Caption = "Last Login: "+ DateTime.Now.ToString();
            getProperties();
            department.Caption = "Department: " + prop._department;
            bstuserName.Caption = "User: " + prop._FullName;
            frmOperationDate opDate = new frmOperationDate();
            opDate.ShowDialog();
            stOperationDate.Caption = Settings.Default.operationDate.ToString("d");
        }

        void getProperties() //Department , Role ve Full adi aliyor.
        {
            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT Department, RoleID, FullName from users WHERE UserName ='" + _userNameFromLogin + "'";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There were an Error", ex.ToString());
            }
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                prop._roleID = reader["RoleID"].ToString();
                prop._department = reader["Department"].ToString();
                prop._FullName = reader["FullName"].ToString();
                
            }
            conn.Close();
        }
        private void frmMDIMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var breaklist = new frmBreakList
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department // Break List ve diger dormlara gidiyor.

            };
            
            breaklist.Show();
        }

        private void btnStaffList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var personelList = new frmPersonelList
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department
       
            };
            personelList.Show();
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var addpersonel = new frmPersonelDetails
            {
                MdiParent = this,
                
            };

            addpersonel.Show();
        }

        private void btnRoster_ItemClick(object sender, ItemClickEventArgs e)
        {
            var monthlRoster = new frmRoster {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department
            };

            monthlRoster.Show();
        }
    }
}