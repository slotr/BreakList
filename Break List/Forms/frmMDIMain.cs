using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Break_List.Properties;
using MySql.Data.MySqlClient;
using Break_List.Forms.Rotalar;
using Break_List.Forms.Personel;
using Break_List.Forms.Prosedur;
using Break_List.Forms.Raporlar;
using Break_List.Forms.Counts;
using Break_List.Forms.Turnuva;
using Break_List.Class;
using System.Deployment.Application;
using System.Diagnostics;
using System.Reflection;
using Break_List.Forms.Admin;
using Break_List.Forms.BreakList;
using Break_List.Forms.Kasa;
using Break_List.Forms.Maas;
using DevExpress.XtraEditors;

namespace Break_List.Forms
{
    public partial class FrmMdiMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly CustomProperties _prop = new CustomProperties();
        readonly ClsPermissions _p = new ClsPermissions();
        private readonly string _str = Settings.Default.livegameConnectionString2;
        public string UserNameFromLogin { get; set; }

        public FrmMdiMain()
        {
            InitializeComponent();
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            var productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            lblVersion.Text = assemblyVersion + @" " + fileVersion + @" " + productVersion;
        }


        private void frmMDIMain_Load(object sender, EventArgs e)
        {
            rbnOnaylar.Visible = _p.Onay;
            rbnPageKasa.Visible = _p.Kasa;
            ribbonRoster.Visible = _p.Rota;
            rbnAdmin.Visible = _p.Admin;
            ribbonRapor.Visible = _p.Rapor;
            rbnProsedur.Visible = _p.Prosedur;
            btnAddPersonel.Enabled = _p.AddPersonel;
            ribbonPersonel.Visible = _p.Personel;
            ribbonBreak.Visible = _p.BreakList;
            rbnEgitimler.Visible = _p.Egitim;
            rbnCount.Visible = _p.Count;
            rbnDashBoard.Visible = _p.Dashboard;
            rbnEnvanter.Visible = _p.Envanter;
            rbnTurnuvalar.Visible = _p.Turnuva;
            rbnSM.Visible = _p.Slot;
            rbnMasa.Visible = _p.Istatistik;
            backstageViewControl1.Controls.Add(labelControl2);
            labelControl2.Top = 5;
        }

        private void frmMDIMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
           
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FrmBreakList))
                {
                    form.Activate();
                    return;
                }
            }
            
           
            Form breakList = new FrmBreakList
            {

                MdiParent = this,
                DepartmentNameFromMainForm = _prop.Department,
                OperationDate = Settings.Default.operationDate,
                UserFullName = _prop.FullName
            };
            breakList.Show();
        }

        private void btnStaffList_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FrmPersonelList))
                {
                    form.Activate();
                    return;
                }
            }
            Form personelList = new FrmPersonelList
            {
                MdiParent = this,
                DepartmentNameFromMainForm = _prop.Department,
                UserNameFromMainForm = _prop.FullName,
                UserId = _prop.UserId
            };
            personelList.Show();
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FrmPersonelDetails))
                {
                    form.Activate();
                    return;
                }
            }
            Form addpersonel = new FrmPersonelDetails
            {
                MdiParent = this,
            };

            addpersonel.Show();
        }

        public string SecilenDep { get; set; } // Eger management ise

        private void btnRoster_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_prop.Department == "Management")
            {
                using (var form = new FrmDepartmaSecici())
                {
                    var dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        SecilenDep = form.SecilenDepartman;
                        var monthlRoster = new FrmRoster
                        {
                            MdiParent = this,
                            DepartmentNameFromMainForm = SecilenDep,
                            UserName = _prop.FullName
                        };

                        monthlRoster.Show();
                    }
                }
            }
            else
            {
                var monthlRoster = new FrmRoster
                {
                    MdiParent = this,
                    DepartmentNameFromMainForm = _prop.Department,
                    UserName = _prop.FullName
                };

                monthlRoster.Show();
            }
        }

        private void btnDepartments_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FrmDepartments))
                {
                    form.Activate();
                    return;
                }
            }
            Form departments = new FrmDepartments {MdiParent = this};
            departments.Show();
        }

        private void btnPositions_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FrmPositions))
                {
                    form.Activate();
                    return;
                }
            }
            Form positions = new FrmPositions { MdiParent = this};
            positions.Show();
        }

        private void btnPermissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FrmPermissions))
                {
                    form.Activate();
                    return;
                }
            }
            Form permissions = new FrmPermissions {MdiParent = this};
            permissions.Show();
        }

        private void btnPrintRota_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(FrmPrintRota)) continue;
                form.Activate();
                return;
            }
            Form printRota = new FrmPrintRota {MdiParent = this};
            printRota.Show();
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(FrmCcalismaSaatleriByManager)) continue;
                form.Activate();
                return;
            }
            Form saatler = new FrmCcalismaSaatleriByManager {MdiParent = this};
            saatler.Show();
        }

        private void btnUsers_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var users = new FrmUsers())
            {
                users.ShowDialog();
            }
        }

        private void btnIstenAyrilmis_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(FrmIstenAyrilmis)) continue;
                form.Activate();
                return;
            }
            Form istenAyrilmispersonelList = new FrmIstenAyrilmis
            {
                MdiParent = this,
                DepartmentNameFromMainForm = _prop.Department,
                UserNameFromMainForm = _prop.FullName,
                UserId = _prop.UserId
            };
            istenAyrilmispersonelList.Show();
        }

        private void btnCalismaIzni_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(FrmCalismaIzinleri)) continue;
                form.Activate();
                return;
            }
            Form frmCalismaIzinleri = new FrmCalismaIzinleri {MdiParent = this};
            frmCalismaIzinleri.Show();
        }

        private void btnTip_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(FrmTipListesi)) continue;
                form.Activate();
                return;
            }
            Form frmTip = new FrmTipListesi() {UserName = _prop.FullName, MdiParent = this};
            frmTip.Show();
        }

        private void btnOnayaDusenler_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() != typeof(FrmMaasTipOnaylari)) continue;
                form.Activate();
                return;
            }
            Form frmOnay = new FrmMaasTipOnaylari() {UserNameFromMainForm = _prop.FullName, MdiParent = this};
            frmOnay.Show();
        }

        private void btnPersonelCount_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmCountPersonel = new FrmPersonelCount() {MdiParent = this};
            frmCountPersonel.Show();
        }

        private void btnEgitim_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmEgitim = new FrmEgitimler() {MdiParent = this};
            frmEgitim.Show();
        }

        private void btnEskiBreak_ItemClick(object sender, ItemClickEventArgs e)
        {
            var printBreak = new BreakListPrint {MdiParent = this};
            printBreak.Show();
        }

        private void btnProsedur_ItemClick(object sender, ItemClickEventArgs e)
        {
            var prosedur = new FrmProsedurler
            {
                MdiParent = this,
                DepartmentNameFromMainForm = _prop.Department
            };
            prosedur.Show();
        }

        private void btnYeniProsedur_ItemClick(object sender, ItemClickEventArgs e)
        {
            var yeniProsedur = new FrmProsedurDisplay {Goster = false};
            yeniProsedur.Show();
        }

        private void btnGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRotaGruplar gruplar = new FrmRotaGruplar {DepartmentNameFromMainForm = _prop.Department};
            gruplar.ShowDialog();
        }

        private void btnDetayliRapor_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBreakMusteri detay = new FrmBreakMusteri {MdiParent = this};
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
                _prop.UserId = reader1["userID"].ToString();
                _prop.RoleId = reader1["RoleID"].ToString();
                _prop.Department = reader1["Department"].ToString();
                _prop.FullName = reader1["FullName"].ToString();
            }
            conn1.Close();
            conn1.Dispose();

            var conn = new MySqlConnection(_str);
            var command = conn.CreateCommand();
            command.CommandText = $"SELECT * from permissions WHERE UserID ='{_prop.UserId}'";
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
                _p.BreakList = Convert.ToBoolean(reader["Appointments"].ToString());
                _p.Rota = Convert.ToBoolean(reader["Roster"].ToString());
                _p.Admin = Convert.ToBoolean(reader["Users"].ToString());
                _p.AddPersonel = Convert.ToBoolean(reader["personelEkle"].ToString());
                _p.Kasa = Convert.ToBoolean(reader["kasa"].ToString());
                _p.Onay = Convert.ToBoolean(reader["onay"].ToString());
                _p.Rapor = Convert.ToBoolean(reader["rapor"].ToString());
                _p.Prosedur = Convert.ToBoolean(reader["prosedur"].ToString());
                _p.Personel = Convert.ToBoolean(reader["resources"].ToString());
                _p.Egitim = Convert.ToBoolean(reader["egitim"].ToString());
                _p.Count = Convert.ToBoolean(reader["count"].ToString());
                _p.Dashboard = Convert.ToBoolean(reader["dashboard"].ToString());
                _p.Envanter = Convert.ToBoolean(reader["envanter"].ToString());
                _p.Turnuva = Convert.ToBoolean(reader["turnuva"].ToString());
                _p.Slot = Convert.ToBoolean(reader["slot"].ToString());
                _p.Istatistik = Convert.ToBoolean(reader["istatistik"].ToString());
            }
            conn.Close();
            if (_p.BreakList)
            {
                var opDate = new FrmOperationDate();

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
                lblDepartman.Caption = @"Department: " + _prop.Department;
                lblUserName.Caption = @"User: " + _prop.FullName;
            }
           
            rbnOnaylar.Visible = _p.Onay;
            rbnPageKasa.Visible = _p.Kasa;
            ribbonRoster.Visible = _p.Rota;
            rbnAdmin.Visible = _p.Admin;
            ribbonRapor.Visible = _p.Rapor;
            rbnProsedur.Visible = _p.Prosedur;
            btnAddPersonel.Enabled = _p.AddPersonel;
            ribbonPersonel.Visible = _p.Personel;
            ribbonBreak.Visible = _p.BreakList;
            rbnEgitimler.Visible = _p.Egitim;
            rbnCount.Visible = _p.Count;
            rbnDashBoard.Visible = _p.Dashboard;
            rbnEnvanter.Visible = _p.Envanter;
            rbnTurnuvalar.Visible = _p.Turnuva;
            rbnSM.Visible = _p.Slot;
            rbnMasa.Visible = _p.Istatistik;
        }


        private void recentButtonItem1_ItemClick(object sender, DevExpress.XtraBars.Ribbon.RecentItemEventArgs e)
        {
            FrmOperationDate changeOperationDate = new FrmOperationDate {simpleButton1 = {Text = @"Değiştir"}};
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

        private void backstageViewButtonItem4_ItemClick(object sender,
            DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            InstallUpdateSyncWithInfo();
        }

        private static void InstallUpdateSyncWithInfo()
        {
            if (!ApplicationDeployment.IsNetworkDeployed) return;
            var ad = ApplicationDeployment.CurrentDeployment;

            UpdateCheckInfo info;
            try
            {
                info = ad.CheckForDetailedUpdate();
            }
            catch (DeploymentDownloadException dde)
            {
                MessageBox.Show(
                    @"The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " +
                    dde.Message);
                return;
            }
            catch (InvalidDeploymentException ide)
            {
                MessageBox.Show(
                    @"Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " +
                    ide.Message);
                return;
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show(
                    @"This application cannot be updated. It is likely not a ClickOnce application. Error: " +
                    ioe.Message);
                return;
            }

            if (info.UpdateAvailable)
            {
                Boolean doUpdate = true;

                if (!info.IsUpdateRequired)
                {
                    DialogResult dr =
                        MessageBox.Show(@"An update is available. Would you like to update the application now?",
                            @"Update Available", MessageBoxButtons.OKCancel);
                    if (DialogResult.OK != dr)
                    {
                        doUpdate = false;
                    }
                }
                else
                {
                    // Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show(@"This application has detected a mandatory update from your current " +
                                    @"version to version " + info.MinimumRequiredVersion +
                                    @". The application will now install the update and restart.",
                        @"Update Available", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                if (doUpdate)
                {
                    try
                    {
                        ad.Update();
                        MessageBox.Show(@"The application has been upgraded, and will now restart.");
                        Application.Restart();
                    }
                    catch (DeploymentDownloadException dde)
                    {
                        MessageBox.Show(
                            @"Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " +
                            dde);
                    }
                }
            }
        }

        private void btnCount_ItemClick(object sender, ItemClickEventArgs e)
        {
            var count = new FrmTableCount {MdiParent = this};
            count.Show();
        }

        private void btnEnvanter_ItemClick(object sender, ItemClickEventArgs e)
        {
            Envanter.FrmEnvanter envanter = new Envanter.FrmEnvanter {Department = _prop.Department};
            envanter.Text = envanter.Department + @" Envanteri";
            envanter.MdiParent = this;
            envanter.Show();
        }

        private void btnTeknikListe_ItemClick(object sender, ItemClickEventArgs e)
        {
            var teknik = new Teknik.FrmTeknikTakip {Department = _prop.Department, User = _prop.FullName };
            teknik.Text = teknik.Department + @" Görev Takibi";
            teknik.MdiParent = this;
            teknik.Show();
        }

        private void btnDashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dashboard = new DashBoard.FrmDashBoard {MdiParent = this};
            dashboard.Show();
        }

        private void btnLGturnuva_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTurnuva lgTurnuva = new FrmTurnuva {MdiParent = this};
            lgTurnuva.Show();
        }

        private void btnPrintTip_ItemClick(object sender, ItemClickEventArgs e)
        {
            var count = new FrmCountChooser {Tip = true};
            count.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var count = new FrmCountChooser {Tip = false};
            count.ShowDialog();
        }

        private void btnMasaBazlı_ItemClick(object sender, ItemClickEventArgs e)
        {
            var topTables = new TopPlayers.FrmTables {MdiParent = this};
            topTables.Show();
        }

        private void btnPlayerStats_ItemClick(object sender, ItemClickEventArgs e)
        {
            var topPlayers = new TopPlayers.FrmPlayers {MdiParent = this};
            topPlayers.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var slotDaily = new TopPlayers.FrmSlots {MdiParent = this};
            slotDaily.Show();
        }

        private void btnAnaliz_ItemClick(object sender, ItemClickEventArgs e)
        {
            var slotPerformans = new TopPlayers.FrmSlotRapor { MdiParent = this };
            slotPerformans.Show();
        }

        private void btnsifre_ItemClick(object sender, DevExpress.XtraBars.Ribbon.RecentItemEventArgs e)
        {
            var password = new FrmChangePassword {UserName = _prop.FullName};
            password.ShowDialog();
                

        }
    }
}