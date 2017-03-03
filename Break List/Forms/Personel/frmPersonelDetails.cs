using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Break_List.Forms.Admin;
using Break_List.Forms.Hatalar;
using Break_List.Forms.Maas;
using Break_List.Forms.Vacations;
using Break_List.Reports;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using MySql.Data.MySqlClient;
using Break_List.Class;

namespace Break_List.Forms.Personel
{
    public partial class FrmPersonelDetails : XtraForm
    {
        public enum DateInterval
        {
            Year,
            Month,
            Weekday,
            Day,
            Hour,
            Minute
        }

        

        private readonly MySqlConnection _con = DbConnection.Con;
        private BinaryReader _br;
        private MySqlCommand _cmd;
        private FileStream _fs;

        public FrmPersonelDetails()
        {
            InitializeComponent();
        }

        public string PersonelId { private get; set; }
        private string KayitId { get; set; }
        private int UniqueId { get; set; }
        private string DepartmentName { get; set; }
        private string Pozisyon { get; set; }
        public string UserId { private get; set; }
        public string UserNameFromMainForm { private get; set; }
        private bool HasPermissionToVacations { get; set; }
        private bool HasPermissionsToPersonelEditAdd { get; set; }
        private bool HasPermissionToAddEditTip { get; set; }
        private bool HasPermissionToAddEditmaas { get; set; }
        public string PersonelName { private get; set; }


        

        private void CheckPermissions()
        {
            var conn = DbConnection.Con;
            var command = conn.CreateCommand();
            command.CommandText = $"SELECT * from permissions WHERE UserID ='{UserId}'";
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
                HasPermissionToVacations = Convert.ToBoolean(reader["Vacations"].ToString());
                HasPermissionsToPersonelEditAdd = Convert.ToBoolean(reader["personelEkle"].ToString());
                HasPermissionToAddEditTip = Convert.ToBoolean(reader["MaasArtisi"].ToString());
                HasPermissionToAddEditmaas = Convert.ToBoolean(reader["maasedit"].ToString());
            }
            conn.Close();
        }

        private void frmPersonelDetails_Load(object sender, EventArgs e)
        {
            if (PersonelId != null)
            {
                GetPersonel();
                GetUsedVacations();
                GetDepartments();
                GetVacations();
                GetToplamOffAlacagi();
                CheckPermissions();
                labelControl.Text =
                    $@"Personel: {txtNameSurname.Text} | Departmanı: {DepartmentName} | Pozisyonu: {Pozisyon} | Sicil No: {PersonelId} | Kayıt No:{KayitId}";
                LockControls(this);

                if (HasPermissionsToPersonelEditAdd == false)
                {
                    windowsUIButtonPanelMain.Visible = false;
                    btnAddVacation.Enabled = false;
                    btnMaasArtisi.Enabled = false;
                }

                else
                {
                    windowsUIButtonPanelMain.Visible = true;
                    btnAddVacation.Enabled = true;
                    btnMaasArtisi.Enabled = true;
                }

                if (HasPermissionToAddEditmaas)
                {
                    txtMaas.Enabled = true;
                    txtTip.Enabled = true;
                }

                else
                {
                    tabMaas.PageVisible = false;
                    txtMaas.Enabled = false;
                    txtTip.Enabled = false;
                }
                windowsUIButtonPanelMain.Buttons["Save"].Properties.Caption = "Edit";
                windowsUIButtonPanelMain.Buttons["Save And New"].Properties.Visible = false;
                windowsUIButtonPanelMain.Buttons["Save And Close"].Properties.Visible = true;
            }
            else
            {
                GetDepartments();
                tabLayout.Visibility = LayoutVisibility.Never;
                labelControl.Text = @"Yeni Personel Kaydı";
            }
           
        }

        private void AddPersonel()
        {
            try
            {
                try
                {
                    if ((txtNameSurname.Text.Length <= 0) || (lblFileName.Text.Length <= 0))
                    {
                        MessageBox.Show(@"Resim Eklenmedi", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        var fileName = lblFileName.Text;
                        _fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        _br = new BinaryReader(_fs);
                        var imageData = _br.ReadBytes((int) _fs.Length);
                        _br.Close();
                        _fs.Close();

                        _cmd =
                            new MySqlCommand(
                                "INSERT INTO resources(ResourceID, ResourceName, Image, Department, StartDate, EndDate,  BirthDate, Position, DocumentType, DocumentNo, ValidUntil, WorkPermitStart, WorkPermitEnd, PassportDNNo, SSKNO, IhtiyatNo,  ReasonForLeaving, Adres, Telefon, Active, Maas, TipPuani, Uyruk, sex, email, MedeniHal, Askerlik, Ehliyet, aciltelefon ) VALUES(@ResourceID, @ResourceName, @Image, @Department, @StartDate, @EndDate , @BirthDate, @Position, @DocumentType, @DocumentNo, @ValidUntil, @WorkPermitStart, @WorkPermitEnd, @PassportDNNo, @SSKNO, @IhtiyatNo,  @ReasonForLeaving, @Adres, @Telefon, @Active, @Maas, @TipPuani, @Uyruk, @sex, @email, @MedeniHal, @Askerlik, @Ehliyet, @aciltelefon)",
                                _con);
                        _cmd.Parameters.Add("@ResourceID", MySqlDbType.Int32);
                        _cmd.Parameters.Add("@ResourceName", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@Image", MySqlDbType.Blob);
                        _cmd.Parameters.Add("@Department", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@StartDate", MySqlDbType.Date);
                        _cmd.Parameters.Add("@EndDate", MySqlDbType.Date);
                        _cmd.Parameters.Add("@BirthDate", MySqlDbType.Date);
                        _cmd.Parameters.Add("@Position", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@DocumentType", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@DocumentNo", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@ValidUntil", MySqlDbType.Date);
                        _cmd.Parameters.Add("@WorkPermitStart", MySqlDbType.Date);
                        _cmd.Parameters.Add("@WorkPermitEnd", MySqlDbType.Date);
                        _cmd.Parameters.Add("@PassportDNNo", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@SSKNO", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@IhtiyatNo", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@ReasonForLeaving", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@Adres", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@Telefon", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@Active", MySqlDbType.Int32);
                        _cmd.Parameters.Add("@Maas", MySqlDbType.Decimal);
                        _cmd.Parameters.Add("@TipPuani", MySqlDbType.Decimal);
                        _cmd.Parameters.Add("@Uyruk", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@sex", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@email", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@MedeniHal", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@Askerlik", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@Ehliyet", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@aciltelefon", MySqlDbType.VarChar, 45);

                        _cmd.Parameters["@ResourceID"].Value = txtPersonelId.Text;
                        _cmd.Parameters["@ResourceName"].Value = txtNameSurname.Text;
                        _cmd.Parameters["@Image"].Value = imageData;
                        _cmd.Parameters["@Department"].Value = cmbDepartment.Text;
                        _cmd.Parameters["@StartDate"].Value = dtStartDate.EditValue != null
                            ? dtStartDate.DateTime.Date
                            : (object) DBNull.Value;
                        _cmd.Parameters["@EndDate"].Value = dtEnd.EditValue != null
                            ? dtEnd.DateTime.Date
                            : (object) DBNull.Value;
                        _cmd.Parameters["@BirthDate"].Value = dtBirthDate.EditValue != null
                            ? dtBirthDate.DateTime.Date
                            : (object) DBNull.Value;
                        _cmd.Parameters["@Position"].Value = txtPosition.Text;
                        _cmd.Parameters["@DocumentType"].Value = cmbDocumentType.Text;
                        _cmd.Parameters["@DocumentNo"].Value = txtDocumentNo.Text;
                        _cmd.Parameters["@ValidUntil"].Value = txtValidUntil.EditValue != null
                            ? txtValidUntil.DateTime.Date
                            : (object) DBNull.Value;
                        _cmd.Parameters["@WorkPermitStart"].Value = dtIzinBaslangic.EditValue != null
                            ? dtIzinBaslangic.DateTime.Date
                            : (object) DBNull.Value;
                        _cmd.Parameters["@WorkPermitEnd"].Value = dtIzinBitis.EditValue != null
                            ? dtIzinBitis.DateTime.Date
                            : (object) DBNull.Value;
                        _cmd.Parameters["@PassportDNNo"].Value = txtPassportNo.Text;
                        _cmd.Parameters["@SSKNO"].Value = txtSSKNo.Text;
                        _cmd.Parameters["@IhtiyatNo"].Value = txtIhtiyat.Text;
                        _cmd.Parameters["@ReasonForLeaving"].Value = cmbistenayrilma.Text;
                        _cmd.Parameters["@Adres"].Value = txtAddress.Text;
                        _cmd.Parameters["@Telefon"].Value = txtTelefon.Text;
                        _cmd.Parameters["@Active"].Value = Convert.ToInt32(radioGroup1.EditValue.ToString());
                        _cmd.Parameters["@Maas"].Value = Convert.ToDecimal(txtMaas.Text);
                        _cmd.Parameters["@TipPuani"].Value = Convert.ToDouble(txtTip.Text);
                        _cmd.Parameters["@Uyruk"].Value = cmbUyruk.Text;
                        _cmd.Parameters["@sex"].Value = cmbCinsiyet.Text;
                        _cmd.Parameters["@email"].Value = txtEmail.Text;
                        _cmd.Parameters["@MedeniHal"].Value = txtMedeniHali.Text;
                        _cmd.Parameters["@Askerlik"].Value = cmbAskerlik.Text;
                        _cmd.Parameters["@Ehliyet"].Value = cmbEhliyet.Text;
                        _cmd.Parameters["@aciltelefon"].Value = txtAcilTel.Text;
                        _con.Open();
                    }
                    if (_cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show(@"Personel Bilgisi Update edildi");
                    _con.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                if (_con.State == ConnectionState.Open)
                    _con.Close();
            }
        }


        private void UpdatePersonel()
        {
            if (lblFileName.Text.Length > 0)
            {
                try
                {
                    var fileName = lblFileName.Text;
                    _fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    _br = new BinaryReader(_fs);
                    var imageData = _br.ReadBytes((int) _fs.Length);
                    _br.Close();
                    _fs.Close();

                    using (var conn = DbConnection.Con)
                    {
                        using (var cmd = new MySqlCommand("spPersonel_UpdateWithImage;", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.Add(new MySqlParameter("_ResourceName", txtNameSurname.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Image", imageData));
                            cmd.Parameters.Add(new MySqlParameter("_Department", cmbDepartment.Text));
                            cmd.Parameters.Add(new MySqlParameter("_StartDate",
                                dtStartDate.EditValue != null ? dtStartDate.DateTime.Date : (object) DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_EndDate",
                                dtEnd.EditValue != null ? dtEnd.DateTime.Date : (object) DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_BirthDate",
                                dtBirthDate.EditValue != null ? dtBirthDate.DateTime.Date : (object) DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_Position", txtPosition.Text));
                            cmd.Parameters.Add(new MySqlParameter("_DocumentType", cmbDocumentType.Text));
                            cmd.Parameters.Add(new MySqlParameter("_DocumentNo", txtDocumentNo.Text));
                            cmd.Parameters.Add(new MySqlParameter("_ValidUntil",
                                txtValidUntil.EditValue != null ? txtValidUntil.DateTime.Date : (object) DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_WorkPermitStart",
                                dtIzinBaslangic.EditValue != null
                                    ? dtIzinBaslangic.DateTime.Date
                                    : (object) DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_WorkPermitEnd",
                                dtIzinBitis.EditValue != null ? dtIzinBitis.DateTime.Date : (object) DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_PassportDNNo", txtPassportNo.Text));
                            cmd.Parameters.Add(new MySqlParameter("_SSKNO", txtSSKNo.Text));
                            cmd.Parameters.Add(new MySqlParameter("_IhtiyatNo", txtIhtiyat.Text));
                            cmd.Parameters.Add(new MySqlParameter("_ReasonForLeaving", cmbistenayrilma.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Adres", txtAddress.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Telefon", txtTelefon.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Active", radioGroup1.EditValue.ToString()));
                            cmd.Parameters.Add(new MySqlParameter("_Maas", txtMaas.Text));
                            cmd.Parameters.Add(new MySqlParameter("_TipPuani", txtTip.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Uyruk", cmbUyruk.Text));
                            cmd.Parameters.Add(new MySqlParameter("_sex", cmbCinsiyet.Text));cmd.Parameters.Add(new MySqlParameter("_email", txtEmail.Text));
                            cmd.Parameters.Add(new MySqlParameter("_MedeniHal", txtMedeniHali.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Askerlik", cmbAskerlik.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Ehliyet", cmbEhliyet.Text));
                            cmd.Parameters.Add(new MySqlParameter("_aciltelefon", txtAcilTel.Text));
                            cmd.Parameters.Add(new MySqlParameter("_uniqueID", UniqueId));
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    MessageBox.Show(@"Personel Bilgisi Update edildi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), @"Bir Hata Oluştu.");
                }
                return;
            }
            try
            {
                using (var conn = DbConnection.Con)
                {
                    using (var cmd = new MySqlCommand("spPersonel_UpdateWithoutImage;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new MySqlParameter("_ResourceName", txtNameSurname.Text));
                        cmd.Parameters.Add(new MySqlParameter("_Department", cmbDepartment.Text));
                        cmd.Parameters.Add(new MySqlParameter("_StartDate",
                            dtStartDate.EditValue != null ? dtStartDate.DateTime.Date : (object) DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_EndDate",
                            dtEnd.EditValue != null ? dtEnd.DateTime.Date : (object) DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_BirthDate",
                            dtBirthDate.EditValue != null ? dtBirthDate.DateTime.Date : (object) DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_Position", txtPosition.Text));
                        cmd.Parameters.Add(new MySqlParameter("_DocumentType", cmbDocumentType.Text));
                        cmd.Parameters.Add(new MySqlParameter("_DocumentNo", txtDocumentNo.Text));
                        cmd.Parameters.Add(new MySqlParameter("_ValidUntil",
                            txtValidUntil.EditValue != null ? txtValidUntil.DateTime.Date : (object) DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_WorkPermitStart",
                            dtIzinBaslangic.EditValue != null ? dtIzinBaslangic.DateTime.Date : (object) DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_WorkPermitEnd",
                            dtIzinBitis.EditValue != null ? dtIzinBitis.DateTime.Date : (object) DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_PassportDNNo", txtPassportNo.Text));
                        cmd.Parameters.Add(new MySqlParameter("_SSKNO", txtSSKNo.Text));
                        cmd.Parameters.Add(new MySqlParameter("_IhtiyatNo", txtIhtiyat.Text));
                        cmd.Parameters.Add(new MySqlParameter("_ReasonForLeaving", cmbistenayrilma.Text));
                        cmd.Parameters.Add(new MySqlParameter("_Adres", txtAddress.Text));
                        cmd.Parameters.Add(new MySqlParameter("_Telefon", txtTelefon.Text));
                        cmd.Parameters.Add(new MySqlParameter("_Active", radioGroup1.EditValue.ToString()));
                        cmd.Parameters.Add(new MySqlParameter("_Maas", txtMaas.Text));
                        cmd.Parameters.Add(new MySqlParameter("_TipPuani", txtTip.Text));
                        cmd.Parameters.Add(new MySqlParameter("_Uyruk", cmbUyruk.Text));
                        cmd.Parameters.Add(new MySqlParameter("_sex", cmbCinsiyet.Text));
                        cmd.Parameters.Add(new MySqlParameter("_email", txtEmail.Text));
                        cmd.Parameters.Add(new MySqlParameter("_MedeniHal", txtMedeniHali.Text));
                        cmd.Parameters.Add(new MySqlParameter("_Askerlik", cmbAskerlik.Text));
                        cmd.Parameters.Add(new MySqlParameter("_Ehliyet", cmbEhliyet.Text));
                        cmd.Parameters.Add(new MySqlParameter("_aciltelefon", txtAcilTel.Text));
                        cmd.Parameters.Add(new MySqlParameter("_uniqueID", UniqueId));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Bir Hata Oluştu.");
            }
        }

        private void GetPersonel()
        {
            using (var mySqlConnection = DbConnection.Con)
            {
                var mySqlCommand = new MySqlCommand("spSinglePersonel;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var str = PersonelId;

                mySqlCommand.Parameters.Add(new MySqlParameter("_resourceID", str));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spSinglePersonel");
                UniqueId = Convert.ToInt32(dataSet.Tables["spSinglePersonel"].Rows[0]["UniqueID"].ToString());
                DepartmentName = dataSet.Tables["spSinglePersonel"].Rows[0]["Department"].ToString();
                Pozisyon = dataSet.Tables["spSinglePersonel"].Rows[0]["Position"].ToString();
                KayitId = dataSet.Tables["spSinglePersonel"].Rows[0]["UniqueID"].ToString();
                txtPersonelId.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["ResourceID"].ToString();
                txtNameSurname.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["REsourceName"].ToString();
                cmbDepartment.EditValue = DepartmentName;
                txtPosition.Text = Pozisyon;
                dtStartDate.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["StartDate"].ToString();
                dtEnd.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["EndDate"].ToString();
                dtBirthDate.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["BirthDate"].ToString();
                cmbDocumentType.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["DocumentType"].ToString();
                cmbistenayrilma.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["ReasonForLeaving"].ToString();
                txtDocumentNo.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["DocumentNo"].ToString();
                txtValidUntil.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["ValidUntil"].ToString();
                dtIzinBaslangic.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["WorkPermitStart"].ToString();
                dtIzinBitis.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["WorkPermitEnd"].ToString();
                txtPassportNo.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["PassportDNNo"].ToString();
                txtSSKNo.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["SSKNO"].ToString();
                txtIhtiyat.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["IhtiyatNo"].ToString();
                txtAddress.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Adres"].ToString();
                txtTelefon.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Telefon"].ToString();
                radioGroup1.SelectedIndex =
                    Convert.ToInt32(dataSet.Tables["spSinglePersonel"].Rows[0]["Active"].ToString());
                txtMaas.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Maas"].ToString();
                txtTip.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["TipPuani"].ToString();
                cmbUyruk.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Uyruk"].ToString();
                cmbCinsiyet.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["sex"].ToString();
                cmbAskerlik.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Askerlik"].ToString();
                txtMedeniHali.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["MedeniHal"].ToString();
                cmbEhliyet.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Ehliyet"].ToString();
                txtAcilTel.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["aciltelefon"].ToString();
                txtEmail.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["email"].ToString();
                var item = (byte[]) dataSet.Tables["spSinglePersonel"].Rows[0]["Image"];
                var memoryStream = new MemoryStream(item);
                pictureBox1.Image = Image.FromStream(memoryStream);
                mySqlConnection.Close();
            }
        }

        private void GetDepartments()
        {
            using (var cnn = DbConnection.Con)
            {
                using (var cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandText = "spDepartment";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var dt = new DataTable();
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                            cmbDepartment.Properties.Items.Add(row["DepartmentName"]);

                        cmbDepartment.Properties.Sorted = true;

                        cnn.Close();
                    }
                }
            }
        }

        private void BringPositions()
        {
            using (var cnn = DbConnection.Con)
            {
                using (var cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandText = "spBringPositions";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@DepartmentName", MySqlDbType.VarChar, 45);
                    cmd.Parameters["@DepartmentName"].Value = cmbDepartment.EditValue.ToString();
                    var dt = new DataTable();
                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                            txtPosition.Properties.Items.Add(row["PositionName"]);

                        txtPosition.Properties.Sorted = true;
                        cnn.Close();
                    }
                }
            }
        }

        

        private void GetVacations() // Vacatıon grid
        {
            using (var mySqlConnection = DbConnection.Con)
            {
                using (var mySqlCommand = new MySqlCommand("spizinlerPersonel;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    var num = Convert.ToInt32(PersonelId);
                    mySqlCommand.Parameters.Add(new MySqlParameter("p_resourceid", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        vacationgrid.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }

        private void GetUsedVacations()
        {
            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("sp_Personel_vacation;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_resourceid", PersonelId));
                conn.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    if (dbr.HasRows)
                    {
                        lblHak.Text = dbr["Izin Hakki"].ToString();
                        lblKul.Text = dbr["Kullanilan"].ToString();
                        var kullanilan = Convert.ToInt32(lblKul.Text);
                        var hakedilen = Convert.ToInt32(lblHak.Text);
                        lblKalan.Text = Convert.ToString(hakedilen - kullanilan);
                        lblKullanilan.Text = lblKul.Text;
                        lbl05.Text = dbr["Ilk 5 yil"].ToString();
                        lbl510.Text = dbr["2. 5 yil"].ToString();
                        lbl1015.Text = dbr["3. 5 yil"].ToString();
                        lbl15ust.Text = dbr["15 yil ustu"].ToString();
                    }
                    else
                    {
                        lblKul.Text = @"0";
                    }
                }
                conn.Close();
            }}

      

        private void GetMaas()
        {
            using (var mySqlConnection = DbConnection.Con)
            {
                using (var mySqlCommand = new MySqlCommand("spMaasArtislari;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    var num = Convert.ToInt32(PersonelId);
                    mySqlCommand.Parameters.Add(new MySqlParameter("personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        salaryGrid.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    if (PersonelId == null)
                    {
                        AddPersonel();
                        GetUsedVacations();
                        tabLayout.Visibility = LayoutVisibility.Always;
                        windowsUIButtonPanelMain.Buttons["Save"].Properties.Caption = "Edit";
                        windowsUIButtonPanelMain.Buttons["Save And Close"].Properties.Visible = false;
                        windowsUIButtonPanelMain.Buttons["Save And New"].Properties.Visible = false;
                    }


                    break;
                case "Edit":
                    UnlockLockControls(this);
                    windowsUIButtonPanelMain.Buttons["Edit"].Properties.Caption = "Save Changes";
                    break;

                case "Save Changes":
                    LockControls(this);
                    windowsUIButtonPanelMain.Buttons["Save Changes"].Properties.Caption = "Edit";
                    UpdatePersonel();
                   
                    GetUsedVacations();
                    labelControl.Text =
                        $@"Personel: {txtNameSurname.Text} | Departmanı: {DepartmentName} | Pozisyonu: {Pozisyon} | Sicil No: {PersonelId} | Kayıt No:{KayitId}";
                    break;


                case "Save And Close":
                    if (PersonelId == null)
                    {
                        AddPersonel();
                        Close();
                    }
                    else
                    {
                        UpdatePersonel();
                        Close();
                    }


                    break;
                case "Save And New":
                    if (PersonelId == null)
                    {
                        AddPersonel();
                        PersonelId = null;
                        ClearSpace(this);
                    }

                    else
                    {
                        PersonelId = null;
                        ClearSpace(this);
                    }
                    break;
            }
        }


        private static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var picturebox = c as PictureBox;
                if (textBox != null)
                    textBox.Text = string.Empty;
                if (comboBox != null)
                    comboBox.SelectedIndex = -1;
                if (picturebox != null)
                    picturebox.Image = null;
                if (c.HasChildren)
                    ClearSpace(c);
            }
        }

        private static void LockControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var radiobox = c as RadioGroup;
                var button = c as SimpleButton;
                if (button != null)
                    button.Enabled = false;
                if (radiobox != null)
                    radiobox.ReadOnly = true;
                if (textBox != null)
                    textBox.ReadOnly = true;
                if (comboBox != null)
                    comboBox.ReadOnly = true;
                if (c.HasChildren)
                    LockControls(c);
            }
        }

        private static void UnlockLockControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var radiobox = c as RadioGroup;
                var button = c as SimpleButton;
                if (button != null)
                    button.Enabled = true;
                if (radiobox != null)
                    radiobox.ReadOnly = false;
                if (textBox != null)
                    textBox.ReadOnly = false;
                if (comboBox != null)
                    comboBox.ReadOnly = false;
                if (c.HasChildren)
                    UnlockLockControls(c);
            }
        }


        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter = @"Image files | *.jpg"
                };
                switch (openFileDialog.ShowDialog())
                {
                    case DialogResult.OK:
                        lblFileName.Text = openFileDialog.FileName;
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                        break;
                    case DialogResult.None:
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popvacation.ShowPopup(MousePosition);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frmvacation = new FrmAddVacation())
            {
                frmvacation.PersonelId= PersonelId;
                frmvacation.KalanIzin = lblKalan.Text;
                frmvacation.PersonelName = txtNameSurname.Text;
                var dr = frmvacation.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    GetVacations();
                    GetUsedVacations();
                    GetOffAlacaklari();
                }
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPosition.Properties.Items.Clear();
            BringPositions();
        }


        private void txtNameSurname_KeyUp(object sender, KeyEventArgs e)
        {
            labelControl.Text = @"Personel: " + txtNameSurname.Text;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var frmMaasArtisi = new FrmMaasArtisi())
            {
                frmMaasArtisi.PersonelId = PersonelId;
                frmMaasArtisi.UserName = UserNameFromMainForm;
                frmMaasArtisi.PersonelName = PersonelName;
                var dr = frmMaasArtisi.ShowDialog();
                if (dr == DialogResult.OK)
                    MessageBox.Show(@"Maas Artis Talebi Onaya gonderilmistir.", @"Bir Hata Oluştu.");
            }
        }

        private void salaryGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popMaas.ShowPopup(MousePosition);
        }


        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = new RptMaasArtisi {RequestParameters = false};
            report.Parameters[0].Value = PersonelId;
            new ReportPrintTool(report).ShowPreview();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmHatalar = new FrmHataEkle();
            try
            {
                frmHatalar.PersonelId = PersonelId;

                var dr = frmHatalar.ShowDialog();
                if (dr == DialogResult.OK)
                    GetHataListesi();
            }
            finally
            {
                frmHatalar.Dispose();
            }
        }

        private void GetHataListesi()
        {
            var mySqlConnection = DbConnection.Con;
            try
            {
                var mySqlCommand = new MySqlCommand("spLgHata;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                try
                {
                    var num = Convert.ToInt32(PersonelId);
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        hatagrid.DataSource = dataTable;
                        hatagridview.OptionsView.ShowPreview = true;
                        hatagridview.PreviewFieldName = "Aciklama";
                    }
                    mySqlConnection.Close();
                }
                finally
                {
                    mySqlCommand.Dispose();
                }
            }
            finally
            {
                mySqlConnection.Dispose();
            }
        }

        private void hatagridview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            popHata.ShowPopup(MousePosition);
        }

        private void btnOffAlacagi_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmAlacaklar = new FrmOffAlacagi();
            try
            {
                frmAlacaklar.PersonelId = PersonelId;
                frmAlacaklar.UserName = UserNameFromMainForm;
                var dr = frmAlacaklar.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    GetVacations();
                    GetUsedVacations();
                    GetOffAlacaklari();
                    GetToplamOffAlacagi();
                }
            }
            finally
            {
                frmAlacaklar.Dispose();
            }
        }

        private void GetOffAlacaklari()
        {
            var mySqlConnection = DbConnection.Con;
            try
            {
                var mySqlCommand = new MySqlCommand("spOffAlacaklari;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                try
                {
                    var num = Convert.ToInt32(PersonelId);
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        gridOffAlacaklari.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
                finally
                {
                    mySqlCommand.Dispose();
                }
            }
            finally
            {
                mySqlConnection.Dispose();
            }
        }

        private void GetOdenenOfflar()
        {
            var mySqlConnection = DbConnection.Con;
            try
            {
                using (var mySqlCommand = new MySqlCommand("spOdenenOfflar;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    var num = Convert.ToInt32(PersonelId);
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        gridOdenenIzinler.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
            finally
            {
                mySqlConnection.Dispose();
            }
        }

        private void GetToplamOffAlacagi()
        {
            var mySqlConnection = DbConnection.Con;
            try
            {
                var mySqlCommand = new MySqlCommand("spOffAlacaklariToplam;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", PersonelId));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spOffAlacaklariToplam");
                lblOffalacagi.Text = dataSet.Tables["spOffAlacaklariToplam"].Rows[0]["Toplam Off Alacagi"].ToString();


                if (lblOffalacagi.Text == string.Empty)
                    lblOffalacagi.Text = @"0";


                mySqlConnection.Close();
            }
            finally
            {
                mySqlConnection.Dispose();
            }
        }


        private void gridView6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            popOffAlacak.ShowPopup(MousePosition);
        }


        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Equals(tabOffAlacak) && (gridOffAlacaklari.DataSource == null))
            {
                GetOffAlacaklari();
                GetOdenenOfflar();
            }
            if (xtraTabControl1.SelectedTabPage.Equals(tabMaas) && (salaryGrid.DataSource == null))
                GetMaas();
            if (xtraTabControl1.SelectedTabPage.Equals(tabPerformans) && (hatagrid.DataSource == null))
                GetHataListesi();
            if (xtraTabControl1.SelectedTabPage.Equals(tabEgitim) && (egitimGrid.DataSource == null))
                Egitimler();
            if (xtraTabControl1.SelectedTabPage.Equals(tabUyari) && (warningsGrid.DataSource == null))
                Uyarilar();
        }

        private void Uyarilar()
        {
            var mySqlConnection = DbConnection.Con;
            try
            {
                using (var mySqlCommand = new MySqlCommand("spPersonelWarnings;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", PersonelId));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        warningsGrid.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
            finally
            {
                mySqlConnection.Dispose();
            }
        }

        private void Egitimler()
        {
            var mySqlConnection = DbConnection.Con;
            try
            {
                using (var mySqlCommand = new MySqlCommand("spSelectEgitimByPersonel;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", PersonelId));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        egitimGrid.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
            finally
            {
                mySqlConnection.Dispose();
            }
        }

        private void gridView6_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column != gridColumn1)
                return;
            if (MessageBox.Show(@"Off alacagini geri vereceksiniz.", @"Emin misiniz?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var frmOdemeTarihi = new FrmOdemeTarihi();
                try
                {
                    var dr = frmOdemeTarihi.ShowDialog();
                    // ReSharper disable once InvertIf
                    if (dr == DialogResult.OK)
                    {
                        var odemeTarihi = Convert.ToDateTime(frmOdemeTarihi.dateEdit1.EditValue.ToString());
                        var rowid = (int) ((GridView) sender).GetRowCellValue(e.RowHandle, "id");
                        using (var con = DbConnection.Con)
                        {
                            using (var cmd = new MySqlCommand("spOffOde;", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            })
                            {
                                cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                                cmd.Parameters.Add(new MySqlParameter("userName", UserNameFromMainForm));
                                cmd.Parameters.Add(new MySqlParameter("odemeTarihi", odemeTarihi));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                using (var mySqlDataAdapter = new MySqlDataAdapter())
                                {
                                    mySqlDataAdapter.SelectCommand = cmd;
                                }
                                con.Close();
                            }
                            GetOffAlacaklari();
                            GetToplamOffAlacagi();
                            GetOdenenOfflar();
                        }
                    }
                }
                finally
                {
                    frmOdemeTarihi.Dispose();
                }
            }
            else
            {
                switch (
                    MessageBox.Show(@"Off alacagini geri vereceksiniz.", @"Emin misiniz?", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning))
                {
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.None:
                        break;
                    case DialogResult.OK:
                        break;
                    case DialogResult.Abort:
                        break;
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Ignore:
                        break;
                    case DialogResult.Yes:
                        break;
                }
            }
        }

        private void salaryGridview_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;

            if (column != gridColumn6)
                return;
            var rowid = (int) ((GridView) sender).GetRowCellValue(e.RowHandle, "id");
            var frmMaasGoster = new FrmMaasArtisiGoster();
            try
            {
                frmMaasGoster.Rowid = rowid;
                frmMaasGoster.Text = txtNameSurname.Text;
                frmMaasGoster.ShowDialog();
            }
            finally
            {
                frmMaasGoster.Dispose();
            }
        }

        private void dtEnd_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if ((e.Value == null) || (e.Value.ToString() != string.Empty))
                return;
            e.Value = null;
        }

        private void cmbDepartment_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Caption != "add")
                return;
            using (var frmDepartments = new FrmDepartments())
            {
                frmDepartments.ShowDialog();
            }
        }

        private void txtPosition_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Caption != "add")
                return;
            using (var frmPositions = new FrmPositions())
            {
                frmPositions.ShowDialog();
            }
        }

        public static class DateTimeUtil
        {
            public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
            {
                long year;
                var timeSpan = date2 - date1;
                switch (interval)
                {
                    case DateInterval.Year:
                        year = date2.Year - date1.Year;
                        break;
                    case DateInterval.Month:
                        year = date2.Month - date1.Month + 12*(date2.Year - date1.Year);
                        break;
                    case DateInterval.Weekday:
                        year = Fix(timeSpan.TotalDays)/7;
                        break;
                    case DateInterval.Day:
                        year = Fix(timeSpan.TotalDays);
                        break;
                    case DateInterval.Hour:
                        year = Fix(timeSpan.TotalHours);
                        break;
                    case DateInterval.Minute:
                        year = Fix(timeSpan.TotalMinutes);
                        break;
                    default:
                        year = Fix(timeSpan.TotalSeconds);
                        break;
                }
                return year;
            }

            private static long Fix(double number)
            {
                var num = number < 0 ? (long) Math.Ceiling(number) : (long) Math.Floor(number);
                return num;
            }
        }

        private void FrmPersonelDetails_Shown(object sender, EventArgs e)
        {
            if (DepartmentName != "Live Game")
            {
                tabPerformans.PageVisible = false;
            }
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e) // Uyari Ekle
        {
            var uyariekle = new frmUyari()
            {
                PersonelID = PersonelId
            };
            var dr = uyariekle.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Uyarilar();
            }

        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e) // Uyari Sil
        {
            MessageBox.Show(@"Bu Bolum icin yetkiniz yok.", @"Ooooooooppppppsss");
        }

        private void warningsGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            popUyari.ShowPopup(MousePosition);
        }
    }
}