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
        Boolean haspermissionAppointment { get; set; }
        Boolean haspermissionRota { get; set; }
        Boolean haspermissionStaff { get; set; }
        Boolean haspermissionAdmin { get; set; }
        Boolean haspermissionRapor { get; set; }
        Boolean hasPermissionAddPersonel { get; set; }
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
            
            
            checkPermissions();
            if (haspermissionAppointment == true)
            {
                ribbonBreak.Visible = true;
                frmOperationDate opDate = new frmOperationDate();
                opDate.ShowDialog();
                stOperationDate.Caption = Settings.Default.operationDate.ToString("d");
            }

            else
            {
                ribbonBreak.Visible = false;
            }
            if (haspermissionRota == true)
            {
                ribbonRoster.Visible = true;
                
            }

            else
            {
                ribbonRoster.Visible = false;
            }
            if (haspermissionAdmin == true)
            {
                rbnAdmin.Visible = true;

            }

            else
            {
                rbnAdmin.Visible = false;
            }
            if (haspermissionRapor == true)
            {
                ribbonRapor.Visible = true;

            }

            else
            {
                ribbonRapor.Visible = false;
            }
            if (hasPermissionAddPersonel == true)
            {
                btnAddPersonel.Enabled = true;
            }
            else
            {
                btnAddPersonel.Enabled = false;
            }
        }

        void getProperties() //Department , Role ve Full adi aliyor.
        {
            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT userID, Department, RoleID, FullName from users WHERE UserName ='" + _userNameFromLogin + "'";
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
                prop._userID = reader["userID"].ToString();
                prop._roleID = reader["RoleID"].ToString();
                prop._department = reader["Department"].ToString();
                prop._FullName = reader["FullName"].ToString();
                
            }
            conn.Close();
        }

        void checkPermissions() //Department , Role ve Full adi aliyor.
        {
            MySqlConnection conn = new MySqlConnection(str);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * from permissions WHERE UserID ='" + prop._userID + "'";
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
                haspermissionAppointment = Convert.ToBoolean(reader["Appointments"].ToString());
                haspermissionRota = Convert.ToBoolean(reader["Roster"].ToString());
                haspermissionAdmin = Convert.ToBoolean(reader["Users"].ToString());
                haspermissionRapor = Convert.ToBoolean(reader["Rapor"].ToString());
                hasPermissionAddPersonel = Convert.ToBoolean(reader["personelEkle"].ToString());
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
                _departmentNameFromMainForm = prop._department, // Break List ve diger formlara gidiyor.
                _operationDate = Convert.ToDateTime(stOperationDate.Caption)
            };
            
            breaklist.Show();
        }

        private void btnStaffList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var personelList = new frmPersonelList
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department, // Staff Listesine gonderiliyor
                _UserNameFromMainForm = prop._FullName, // Staff Listesine gonderiliyor
                _UserID = prop._userID
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

        private void btnDepartments_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDepartments Departments = new frmDepartments();
            Departments.MdiParent = this;
            Departments.Show();
        }

        private void btnPositions_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPositions Positions = new frmPositions();
            Positions.MdiParent = this;
            Positions.Show();
        }

        private void btnPermissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.frmPermissions Permissions = new Forms.frmPermissions();
            Permissions.MdiParent = this;
            Permissions.Show();
        }

        private void btnPrintRota_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPrintRota printRota = new frmPrintRota();
            printRota.Show();
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmCcalismaSaatleriByManager saatler = new frmCcalismaSaatleriByManager();
            saatler.MdiParent = this;
            saatler.Show();
        }

        private void btnUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsers users = new frmUsers();
            users.ShowDialog();
        }

        private void btnIstenAyrilmis_ItemClick(object sender, ItemClickEventArgs e)
        {
            var istenAyrilmispersonelList = new frmIstenAyrilmis()
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department, // Staff Listesine gonderiliyor
                _UserNameFromMainForm = prop._FullName, // Staff Listesine gonderiliyor
                _UserID = prop._userID
            };
            istenAyrilmispersonelList.Show();
        }

        private void stOperationDate_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bstuserName_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnCalismaIzni_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Personel.frmCalismaIzinleri frmCalismaIzinleri = new Forms.Personel.frmCalismaIzinleri();
            frmCalismaIzinleri.MdiParent = this;
            frmCalismaIzinleri.Show();
        }

        private void btnTip_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Kasa.frmTipListesi frmTip = new Forms.Kasa.frmTipListesi();
            frmTip.userName = prop._FullName;
            frmTip.MdiParent = this;
            frmTip.Show();
        }

        private void btnOnayaDusenler_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Maas.frmMaasTipOnaylari frmOnay = new Forms.Maas.frmMaasTipOnaylari();
            frmOnay._UserNameFromMainForm = prop._FullName;
            frmOnay.MdiParent = this;
            frmOnay.Show();
        }

        private void btnPersonelCount_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Personel.frmPersonelCount frmCountPersonel = new Forms.Personel.frmPersonelCount();
            frmCountPersonel.MdiParent = this;
            frmCountPersonel.Show();
        }

        private void btnEgitim_ItemClick(object sender, ItemClickEventArgs e)
        {
            Forms.Personel.frmEgitimler frmEgitim = new Forms.Personel.frmEgitimler();
            frmEgitim.MdiParent = this;
            frmEgitim.Show();
        }
    }
}