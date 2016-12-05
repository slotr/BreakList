using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Break_List.Properties;
using MySql.Data.MySqlClient;
using Break_List.Forms.Rotalar;
using Break_List.Forms.Personel;
using Break_List.Forms.Prosedur;
using Break_List.Forms.Raporlar;
using Break_List.Class;

namespace Break_List.Forms
{
    public partial class FrmMdiMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly customProperties _prop = new customProperties();
        readonly clsPermissions _p = new clsPermissions();
        private readonly string _str = Settings.Default.livegameConnectionString2;
        public string UserNameFromLogin { get; set; }

        public FrmMdiMain()
        {
            InitializeComponent();
        }


        private void frmMDIMain_Load(object sender, EventArgs e)
        {
            rbnOnaylar.Visible = _p.onay;
            rbnPageKasa.Visible = _p.kasa;
            ribbonRoster.Visible = _p.rota;
            rbnAdmin.Visible = _p.admin;
            ribbonRapor.Visible = _p.rapor;
            rbnProsedur.Visible = _p.prosedur;
            btnAddPersonel.Enabled = _p.addPersonel;
            ribbonPersonel.Visible = _p.personel;
            ribbonBreak.Visible = _p.breakList;
            rbnEgitimler.Visible = _p.egitim;
            backstageViewControl1.Controls.Add(labelControl2);
            labelControl2.Top = 5;
        }

        private void frmMDIMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            BreakList.FrmBreakList breaklist = new BreakList.FrmBreakList
            {
                MdiParent = this,
                DepartmentNameFromMainForm = _prop._department,
                OperationDate = Settings.Default.operationDate
            };

            breaklist.Show();
        }

        private void btnStaffList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var personelList = new frmPersonelList
            {
                MdiParent = this,
                _departmentNameFromMainForm = _prop._department,
                _UserNameFromMainForm = _prop._FullName,
                _UserID = _prop._userID
            };
            personelList.Show();
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var addpersonel = new FrmPersonelDetails
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
                _departmentNameFromMainForm = _prop._department,
                UserName = _prop._FullName
            };

            monthlRoster.Show();
        }

        private void btnDepartments_ItemClick(object sender, ItemClickEventArgs e)
        {
            var departments = new frmDepartments() {MdiParent = this};
            departments.Show();
        }

        private void btnPositions_ItemClick(object sender, ItemClickEventArgs e)
        {
            var positions = new frmPositions() {MdiParent = this};
            positions.Show();
        }

        private void btnPermissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            var permissions = new frmPermissions() {MdiParent = this};
            permissions.Show();
        }

        private void btnPrintRota_ItemClick(object sender, ItemClickEventArgs e)
        {
            var printRota = new frmPrintRota() {MdiParent = this};
            printRota.Show();
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var saatler = new frmCcalismaSaatleriByManager() {MdiParent = this};
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
                _departmentNameFromMainForm = _prop._department,
                _UserNameFromMainForm = _prop._FullName,
                _UserID = _prop._userID
            };
            istenAyrilmispersonelList.Show();
        }

        private void btnCalismaIzni_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmCalismaIzinleri = new frmCalismaIzinleri() {MdiParent = this};
            frmCalismaIzinleri.Show();
        }

        private void btnTip_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmTip = new Kasa.frmTipListesi() {userName = _prop._FullName, MdiParent = this};
            frmTip.Show();
        }

        private void btnOnayaDusenler_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmOnay = new Maas.frmMaasTipOnaylari() {_UserNameFromMainForm = _prop._FullName, MdiParent = this};
            frmOnay.Show();
        }

        private void btnPersonelCount_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmCountPersonel = new frmPersonelCount() {MdiParent = this};
            frmCountPersonel.Show();
        }

        private void btnEgitim_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmEgitim = new frmEgitimler() {MdiParent = this};
            frmEgitim.Show();
        }

        private void btnEskiBreak_ItemClick(object sender, ItemClickEventArgs e)
        {
            BreakList.BreakListPrint printBreak = new BreakList.BreakListPrint {MdiParent = this};
            printBreak.Show();
        }

        private void btnProsedur_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProsedurler prosedur = new frmProsedurler
            {
                MdiParent = this,
                _departmentNameFromMainForm = _prop._department
            };
            prosedur.Show();
        }

        private void btnYeniProsedur_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProsedurDisplay yeniProsedur = new frmProsedurDisplay {goster = false};
            yeniProsedur.Show();
        }

        private void btnGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRotaGruplar gruplar = new frmRotaGruplar {_departmentNameFromMainForm = _prop._department};
            gruplar.ShowDialog();
        }

        private void btnDetayliRapor_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBreakMusteri detay = new frmBreakMusteri {MdiParent = this};
            detay.Show();
        }


        private void frmMDIMain_Shown(object sender, EventArgs e)
        {
            var conn1 = new MySqlConnection(_str);
            var command1 = conn1.CreateCommand();
            command1.CommandText =
                $"SELECT userID, Department, RoleID, FullName from users WHERE UserName ='{UserNameFromLogin}'";
            try
            {
                conn1.Open();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(@"There were an Error", ex1.ToString());
            }
            var reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                _prop._userID = reader1["userID"].ToString();
                _prop._roleID = reader1["RoleID"].ToString();
                _prop._department = reader1["Department"].ToString();
                _prop._FullName = reader1["FullName"].ToString();
            }
            conn1.Close();
            conn1.Dispose();
            // department.Caption = "Department: " + prop._department;
            //bstuserName.Caption = "User: " + prop._FullName;


            var conn = new MySqlConnection(_str);
            var command = conn.CreateCommand();
            command.CommandText = $"SELECT * from permissions WHERE UserID ='{_prop._userID}'";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There were an Error", ex.ToString());
            }
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                _p.breakList = Convert.ToBoolean(reader["Appointments"].ToString());
                _p.rota = Convert.ToBoolean(reader["Roster"].ToString());
                _p.admin = Convert.ToBoolean(reader["Users"].ToString());
                _p.addPersonel = Convert.ToBoolean(reader["personelEkle"].ToString());
                _p.kasa = Convert.ToBoolean(reader["kasa"].ToString());
                _p.onay = Convert.ToBoolean(reader["onay"].ToString());
                _p.rapor = Convert.ToBoolean(reader["rapor"].ToString());
                _p.prosedur = Convert.ToBoolean(reader["prosedur"].ToString());
                _p.personel = Convert.ToBoolean(reader["resources"].ToString());
                _p.egitim = Convert.ToBoolean(reader["egitim"].ToString());
            }
            conn.Close();
            if (_p.breakList)
            {
                frmOperationDate opDate = new frmOperationDate();

                try
                {
                    opDate.ShowDialog();
                }
                finally
                {
                    opDate.Dispose();
                }
                //stOperationDate.Caption = Settings.Default.operationDate.ToString("d");
                lblOperasyonTarihi.Caption = @"Çalışılan gün: " + Settings.Default.operationDate.ToString("d");
                lblDepartman.Caption = @"Department: " + _prop._department;
                lblUserName.Caption = @"User: " + _prop._FullName;
            }
            rbnOnaylar.Visible = _p.onay;
            rbnPageKasa.Visible = _p.kasa;
            ribbonRoster.Visible = _p.rota;
            rbnAdmin.Visible = _p.admin;
            ribbonRapor.Visible = _p.rapor;
            rbnProsedur.Visible = _p.prosedur;
            btnAddPersonel.Enabled = _p.addPersonel;
            ribbonPersonel.Visible = _p.personel;
            ribbonBreak.Visible = _p.breakList;
            rbnEgitimler.Visible = _p.egitim;
        }


        private void recentButtonItem1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.RecentItemEventArgs e)
        {
            frmOperationDate changeOperationDate = new frmOperationDate {simpleButton1 = {Text = @"Değiştir"}};
            var dr = changeOperationDate.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //stOperationDate.Caption = Settings.Default.operationDate.ToString("d");
                lblOperasyonTarihi.Caption = @"Çlışılan gün: " + Settings.Default.operationDate.ToString("d");
                MessageBox.Show(@"Operasyon Tarihi Değiştirildi", @"Bir Hata Oluştu.");
            }
        }


        private void backstageViewButtonItem1_ItemClick(object sender,
            DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Application.Restart();
        }

        private void backstageViewControl1_SizeChanged(object sender, EventArgs e)
        {
            labelControl2.Left = backstageViewClientControl1.Location.X +
                                 (backstageViewClientControl1.Width - labelControl2.Width);
        }

        private void backstageViewButtonItem3_ItemClick(object sender,
            DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Application.Exit();
        }
    }
}