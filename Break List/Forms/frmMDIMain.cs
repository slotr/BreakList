using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Break_List.Properties;
using MySql.Data.MySqlClient;
using Break_List.Forms.Rotalar;
using Break_List.Forms.Personel;
using Break_List.Forms.Prosedur;

namespace Break_List.Forms
{
    public partial class frmMDIMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string _userNameFromLogin { get; set; }
        private readonly customProperties prop = new customProperties();
        private readonly string str = Settings.Default.livegameConnectionString2;
        private bool haspermissionAppointment { get; set; }
        private bool haspermissionRota { get; set; }
        private bool haspermissionStaff { get; set; }
        private bool haspermissionAdmin { get; set; }
        private bool haspermissionRapor { get; set; }
        private bool hasPermissionAddPersonel { get; set; }
        private bool hasPermissionKasa { get; set; }
        private bool hasPermissionOnay { get; set; }
        
        public frmMDIMain()
        {
            InitializeComponent();
        }


        private void frmMDIMain_Load(object sender, EventArgs e)
        {
            barStaticItem1.Caption = "Last Login: " + DateTime.Now;
            var conn1 = new MySqlConnection(str);
            var command1 = conn1.CreateCommand();
            command1.CommandText = string.Format("SELECT userID, Department, RoleID, FullName from users WHERE UserName ='{0}'", _userNameFromLogin);
            try
            {
                conn1.Open();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("There were an Error", ex1.ToString());
            }
            var reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                prop._userID = reader1["userID"].ToString();
                prop._roleID = reader1["RoleID"].ToString();
                prop._department = reader1["Department"].ToString();
                prop._FullName = reader1["FullName"].ToString();
            }
            conn1.Close();
            department.Caption = "Department: " + prop._department;
            bstuserName.Caption = "User: " + prop._FullName;


            var conn = new MySqlConnection(str);
            var command = conn.CreateCommand();
            command.CommandText = string.Format("SELECT * from permissions WHERE UserID ='{0}'", prop._userID);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There were an Error", ex.ToString());
            }
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                haspermissionAppointment = Convert.ToBoolean(reader["Appointments"].ToString());
                haspermissionRota = Convert.ToBoolean(reader["Roster"].ToString());
                haspermissionAdmin = Convert.ToBoolean(reader["Users"].ToString());
                haspermissionRapor = Convert.ToBoolean(reader["Rapor"].ToString());
                hasPermissionAddPersonel = Convert.ToBoolean(reader["personelEkle"].ToString());
                hasPermissionKasa = Convert.ToBoolean(reader["kasa"].ToString());
                hasPermissionOnay = Convert.ToBoolean(reader["onay"].ToString());
                
            }
            conn.Close();
            if (haspermissionAppointment)
            {
                ribbonBreak.Visible = true;
                frmOperationDate opDate = new frmOperationDate();
                
                try
                {
                    opDate.ShowDialog();
                }
                finally
                {
                    if (opDate != null)
                        opDate.Dispose();
                      
                }
                stOperationDate.Caption = Settings.Default.operationDate.ToString("d");
            }
            else
            {
                ribbonBreak.Visible = false;
                stOperationDate.Caption = Convert.ToString(DateTime.Today);
            }
            
            rbnOnaylar.Visible = hasPermissionOnay ? true : false;
            rbnPageKasa.Visible = hasPermissionKasa ? true : false;
            ribbonRoster.Visible = haspermissionRota ? true : false;
            rbnAdmin.Visible = haspermissionAdmin ? true : false;
            ribbonRapor.Visible = haspermissionRapor ? true : false;
            btnAddPersonel.Enabled = hasPermissionAddPersonel ? true : false;
        }
        private void frmMDIMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            BreakList.frmBreakList breaklist = new BreakList.frmBreakList
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department,
                _operationDate = Convert.ToDateTime(stOperationDate.Caption)
            };

            breaklist.Show();
        }

        private void btnStaffList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var personelList = new frmPersonelList
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department,
                _UserNameFromMainForm = prop._FullName,
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
            var monthlRoster = new frmRoster
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department,
                UserName = prop._FullName
                
            };

            monthlRoster.Show();
        }

        private void btnDepartments_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Departments = new frmDepartments() { MdiParent = this };
            Departments.Show();
        }

        private void btnPositions_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Positions = new frmPositions() { MdiParent = this };
            Positions.Show();
        }

        private void btnPermissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            var Permissions = new frmPermissions() { MdiParent = this };
            Permissions.Show();
        }

        private void btnPrintRota_ItemClick(object sender, ItemClickEventArgs e)
        {
            var printRota = new frmPrintRota() { MdiParent = this };
            printRota.Show();
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var saatler = new Raporlar.frmCcalismaSaatleriByManager() { MdiParent = this };
            saatler.Show();
        }

        private void btnUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var users = new frmUsers())
            {
                users.ShowDialog();
            }
        }

        private void btnIstenAyrilmis_ItemClick(object sender, ItemClickEventArgs e)
        {
            var istenAyrilmispersonelList = new frmIstenAyrilmis()
            {
                MdiParent = this,
                _departmentNameFromMainForm = prop._department,
                _UserNameFromMainForm = prop._FullName,
                _UserID = prop._userID
            };
            istenAyrilmispersonelList.Show();
        }

        private void btnCalismaIzni_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmCalismaIzinleri = new frmCalismaIzinleri() { MdiParent = this };
            frmCalismaIzinleri.Show();
        }

        private void btnTip_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmTip = new Kasa.frmTipListesi() { userName = prop._FullName, MdiParent = this };
            frmTip.Show();
        }

        private void btnOnayaDusenler_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmOnay = new Maas.frmMaasTipOnaylari() { _UserNameFromMainForm = prop._FullName, MdiParent = this };
            frmOnay.Show();
        }

        private void btnPersonelCount_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmCountPersonel = new frmPersonelCount() { MdiParent = this };
            frmCountPersonel.Show();
        }

        private void btnEgitim_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmEgitim = new frmEgitimler() { MdiParent = this };
            frmEgitim.Show();
        }

        private void btnEskiBreak_ItemClick(object sender, ItemClickEventArgs e)
        {
            BreakList.BreakListPrint printBreak = new BreakList.BreakListPrint();
            printBreak.MdiParent = this;
            printBreak.Show();
        }

        private void btnProsedur_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProsedurler prosedur = new frmProsedurler();
            prosedur.MdiParent = this;
            prosedur._departmentNameFromMainForm = prop._department;
            prosedur.Show();
        }

        private void btnYeniProsedur_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProsedurDisplay yeniProsedur = new frmProsedurDisplay();
            yeniProsedur.goster = false;
            yeniProsedur.Show();
        }
    }
}
