using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading.Tasks;

namespace Break_List.Forms.Personel
{
    public partial class frmPersonelDetails : XtraForm
    {
        private const string conString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private readonly MySqlConnection con = new MySqlConnection(conString);
        private MySqlCommand cmd;
        private FileStream fs;
        private BinaryReader br;
        public string _personelID { get; set; }
        public string _kayitID { get; set; }
        public int UniqueID { get; set; }
        public string _departmentName { get; set; }
        public string _pozisyon { get; set; }
        public string _UserID { get; set; }
        public string _UserNameFromMainForm { get; set; }
        public bool hasPermissionToVacations { get; set; }
        public bool hasPermissionsToPersonelEditAdd { get; set; }
        public bool hasPermissionToAddEditTip { get; set; }
        public bool hasPermissionToAddEditmaas { get; set; }
        public frmPersonelDetails()
        {
            InitializeComponent();
        }
        private void checkPermissions()
        {
            var conn = new MySqlConnection(Settings.Default.livegameConnectionString2);
            var command = conn.CreateCommand();
            command.CommandText = string.Format("SELECT * from permissions WHERE UserID ='{0}'", _UserID);
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
                hasPermissionToVacations = Convert.ToBoolean(reader["Vacations"].ToString());
                hasPermissionsToPersonelEditAdd = Convert.ToBoolean(reader["personelEkle"].ToString());
                hasPermissionToAddEditTip = Convert.ToBoolean(reader["MaasArtisi"].ToString());
                hasPermissionToAddEditmaas = Convert.ToBoolean(reader["maasedit"].ToString());
            }
            conn.Close();
        }
        private void frmPersonelDetails_Load(object sender, EventArgs e)
        {
            if (_personelID != null)
            {
                getPersonel();
                calculateVacation();
                getUsedVacations();
                getDepartments();
                getVacations();
                getToplamOffAlacagi();
                checkPermissions();
                labelControl.Text = string.Format("Personel: {0} | Departmanı: {1} | Pozisyonu: {2} | Sicil No: {3} | Kayıt No:{4}", txtNameSurname.Text, _departmentName, _pozisyon, _personelID, _kayitID);
                LockControls(this);

                if (hasPermissionsToPersonelEditAdd == false)
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

                if (hasPermissionToAddEditmaas) {
                    txtMaas.Enabled = true;
                    txtTip.Enabled = true;
                }

                else {
                    tabMaas.PageVisible = false;
                    txtMaas.Enabled = false;
                    txtTip.Enabled = false;
                }
                    windowsUIButtonPanelMain.Buttons["Save"].Properties.Caption = "Edit";
                windowsUIButtonPanelMain.Buttons["Save And New"].Properties.Visible = false;
                windowsUIButtonPanelMain.Buttons["Save And Close"].Properties.Visible = false;
                
            }
            else
            {
                getDepartments();
                tabLayout.Visibility = LayoutVisibility.Never;
                labelControl.Text = "Yeni Personel Kaydı";
            }
        }
        private void addPersonel()
        {
            try
            {
                try
                {
                    if ((txtNameSurname.Text.Length <= 0 ? true : lblFileName.Text.Length <= 0))
                    {
                        MessageBox.Show("Resim Eklenmedi", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        var FileName = lblFileName.Text;
                        byte[] ImageData;
                        fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                        br = new BinaryReader(fs);
                        ImageData = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();

                        cmd = new MySqlCommand("INSERT INTO resources(ResourceID, ResourceName, Image, Department, StartDate, EndDate,  BirthDate, Position, DocumentType, DocumentNo, ValidUntil, WorkPermitStart, WorkPermitEnd, PassportDNNo, SSKNO, IhtiyatNo,  ReasonForLeaving, Adres, Telefon, Active, Maas, TipPuani, Uyruk, sex, email, MedeniHal, Askerlik, Ehliyet, aciltelefon ) VALUES(@ResourceID, @ResourceName, @Image, @Department, @StartDate, @EndDate , @BirthDate, @Position, @DocumentType, @DocumentNo, @ValidUntil, @WorkPermitStart, @WorkPermitEnd, @PassportDNNo, @SSKNO, @IhtiyatNo,  @ReasonForLeaving, @Adres, @Telefon, @Active, @Maas, @TipPuani, @Uyruk, @sex, @email, @MedeniHal, @Askerlik, @Ehliyet, @aciltelefon)", con);
                        cmd.Parameters.Add("@ResourceID"        , MySqlDbType.Int32)                ;
                        cmd.Parameters.Add("@ResourceName"      , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@Image"             , MySqlDbType.Blob)                 ;
                        cmd.Parameters.Add("@Department"        , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@StartDate"         , MySqlDbType.Date)                 ; 
                        cmd.Parameters.Add("@EndDate"           , MySqlDbType.Date)                 ;
                        cmd.Parameters.Add("@BirthDate"         , MySqlDbType.Date)                 ;
                        cmd.Parameters.Add("@Position"          , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@DocumentType"      , MySqlDbType.VarChar, 45)           ;
                        cmd.Parameters.Add("@DocumentNo"        , MySqlDbType.VarChar, 45)           ;
                        cmd.Parameters.Add("@ValidUntil"        , MySqlDbType.Date)                 ;
                        cmd.Parameters.Add("@WorkPermitStart"   , MySqlDbType.Date)                 ;
                        cmd.Parameters.Add("@WorkPermitEnd"     , MySqlDbType.Date)                 ;
                        cmd.Parameters.Add("@PassportDNNo"      , MySqlDbType.VarChar, 45)           ;
                        cmd.Parameters.Add("@SSKNO"             , MySqlDbType.VarChar , 45)          ;
                        cmd.Parameters.Add("@IhtiyatNo"         , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@ReasonForLeaving"  , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@Adres"             , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@Telefon"           , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@Active"            , MySqlDbType.Int32)                ;
                        cmd.Parameters.Add("@Maas"              , MySqlDbType.Decimal)              ;
                        cmd.Parameters.Add("@TipPuani"          , MySqlDbType.Decimal);
                        cmd.Parameters.Add("@Uyruk"             , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@sex"               , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@email"             , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@MedeniHal"         , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@Askerlik"          , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@Ehliyet"           , MySqlDbType.VarChar, 45)          ;
                        cmd.Parameters.Add("@aciltelefon"       , MySqlDbType.VarChar, 45)          ;

                        cmd.Parameters["@ResourceID"      ].Value = txtPersonelId.Text;
                        cmd.Parameters["@ResourceName"    ].Value = txtNameSurname.Text;
                        cmd.Parameters["@Image"           ].Value = ImageData;
                        cmd.Parameters["@Department"      ].Value = cmbDepartment.Text;
                        cmd.Parameters["@StartDate"       ].Value = dtStartDate.EditValue != null ? (object)dtStartDate.DateTime.Date : (object)DBNull.Value;
                        cmd.Parameters["@EndDate"         ].Value = dtEnd.EditValue != null ? (object)dtEnd.DateTime.Date : (object)DBNull.Value;
                        cmd.Parameters["@BirthDate"       ].Value = dtBirthDate.EditValue != null ? (object)dtBirthDate.DateTime.Date : (object)DBNull.Value;
                        cmd.Parameters["@Position"        ].Value = txtPosition.Text;
                        cmd.Parameters["@DocumentType"    ].Value = cmbDocumentType.Text;
                        cmd.Parameters["@DocumentNo"      ].Value = txtDocumentNo.Text;
                        cmd.Parameters["@ValidUntil"      ].Value = txtValidUntil.EditValue != null ? (object)txtValidUntil.DateTime.Date : (object)DBNull.Value;
                        cmd.Parameters["@WorkPermitStart" ].Value = dtIzinBaslangic.EditValue != null ? (object)dtIzinBaslangic.DateTime.Date : (object)DBNull.Value;
                        cmd.Parameters["@WorkPermitEnd"   ].Value = dtIzinBitis.EditValue != null ? (object)dtIzinBitis.DateTime.Date : (object)DBNull.Value;
                        cmd.Parameters["@PassportDNNo"    ].Value = txtPassportNo.Text;
                        cmd.Parameters["@SSKNO"           ].Value = txtSSKNo.Text;
                        cmd.Parameters["@IhtiyatNo"       ].Value = txtIhtiyat.Text;
                        cmd.Parameters["@ReasonForLeaving"].Value = cmbistenayrilma.Text;
                        cmd.Parameters["@Adres"           ].Value = txtAddress.Text;
                        cmd.Parameters["@Telefon"         ].Value = txtTelefon.Text;
                        cmd.Parameters["@Active"          ].Value = Convert.ToInt32(radioGroup1.EditValue.ToString());
                        cmd.Parameters["@Maas"            ].Value = Convert.ToDecimal(txtMaas.Text);
                        cmd.Parameters["@TipPuani"        ].Value = Convert.ToDouble(txtTip.Text);
                        cmd.Parameters["@Uyruk"           ].Value = cmbUyruk.Text;
                        cmd.Parameters["@sex"].Value = cmbCinsiyet.Text;
                        cmd.Parameters["@email"].Value = txtEmail.Text;
                        cmd.Parameters["@MedeniHal"].Value = txtMedeniHali.Text;
                        cmd.Parameters["@Askerlik"].Value = cmbAskerlik.Text;
                        cmd.Parameters["@Ehliyet"].Value = cmbEhliyet.Text;
                        cmd.Parameters["@aciltelefon"].Value = txtAcilTel.Text;
                        con.Open();
                    }
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Personel Added Succesfully");
                    }
                    con.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }




        private void updatePersonel()
        {
            if (lblFileName.Text.Length > 0)
            {
                try
                {
                    var FileName = lblFileName.Text;
                    byte[] ImageData;
                    fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    ImageData = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    using (var conn = new MySqlConnection(conString))
                    {
                        using (var cmd = new MySqlCommand("spUpdatePersonelWithImage;", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        })
                        {
                            cmd.Parameters.Add(new MySqlParameter("_ResourceName", txtNameSurname.Text));
                            cmd.Parameters.Add(new MySqlParameter("_Image", ImageData));
                            cmd.Parameters.Add(new MySqlParameter("_Department", cmbDepartment.Text));
                            cmd.Parameters.Add(new MySqlParameter("_StartDate", dtStartDate.EditValue != null ? (object)dtStartDate.DateTime.Date : (object)DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_EndDate", dtEnd.EditValue != null ? (object)dtEnd.DateTime.Date : (object)DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_BirthDate", dtBirthDate.EditValue != null ? (object)dtBirthDate.DateTime.Date : (object)DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_Position", txtPosition.Text));
                            cmd.Parameters.Add(new MySqlParameter("_DocumentType", cmbDocumentType.Text));
                            cmd.Parameters.Add(new MySqlParameter("_DocumentNo", txtDocumentNo.Text));
                            cmd.Parameters.Add(new MySqlParameter("_ValidUntil", txtValidUntil.EditValue != null ? (object)txtValidUntil.DateTime.Date : (object)DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_WorkPermitStart", dtIzinBaslangic.EditValue != null ? (object)dtIzinBaslangic.DateTime.Date : (object)DBNull.Value));
                            cmd.Parameters.Add(new MySqlParameter("_WorkPermitEnd", dtIzinBitis.EditValue != null ? (object)dtIzinBitis.DateTime.Date : (object)DBNull.Value));
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
                            cmd.Parameters.Add(new MySqlParameter("_uniqueID", UniqueID));
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                   MessageBox.Show("Personel Bilgisi Update edildi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Bir Hata Oluştu.");
                }
                return;
            }
            try
            {
                using (var conn = new MySqlConnection(conString))
                {
                    using (var cmd = new MySqlCommand("spUpdatePersonelWithoutImage;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new MySqlParameter("_ResourceName", txtNameSurname.Text));                        
                        cmd.Parameters.Add(new MySqlParameter("_Department", cmbDepartment.Text));
                        cmd.Parameters.Add(new MySqlParameter("_StartDate", dtStartDate.EditValue != null ? (object)dtStartDate.DateTime.Date : (object)DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_EndDate", dtEnd.EditValue != null ? (object)dtEnd.DateTime.Date : (object)DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_BirthDate", dtBirthDate.EditValue != null ? (object)dtBirthDate.DateTime.Date : (object)DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_Position", txtPosition.Text));
                        cmd.Parameters.Add(new MySqlParameter("_DocumentType", cmbDocumentType.Text));
                        cmd.Parameters.Add(new MySqlParameter("_DocumentNo", txtDocumentNo.Text));
                        cmd.Parameters.Add(new MySqlParameter("_ValidUntil", txtValidUntil.EditValue != null ? (object)txtValidUntil.DateTime.Date : (object)DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_WorkPermitStart", dtIzinBaslangic.EditValue != null ? (object)dtIzinBaslangic.DateTime.Date : (object)DBNull.Value));
                        cmd.Parameters.Add(new MySqlParameter("_WorkPermitEnd", dtIzinBitis.EditValue != null ? (object)dtIzinBitis.DateTime.Date : (object)DBNull.Value));
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
                        cmd.Parameters.Add(new MySqlParameter("_uniqueID", UniqueID));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Bir Hata Oluştu.");
            }
        }
        private void getPersonel()
        {
            using (var mySqlConnection = new MySqlConnection(conString))
            {
                var mySqlCommand = new MySqlCommand("spSinglePersonel;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var str = _personelID;

                mySqlCommand.Parameters.Add(new MySqlParameter("_resourceID", str));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spSinglePersonel");
                UniqueID = Convert.ToInt32(dataSet.Tables["spSinglePersonel"].Rows[0]["UniqueID"].ToString());
                _departmentName = dataSet.Tables["spSinglePersonel"].Rows[0]["Department"].ToString();
                _pozisyon = dataSet.Tables["spSinglePersonel"].Rows[0]["Position"].ToString();
                _kayitID = dataSet.Tables["spSinglePersonel"].Rows[0]["UniqueID"].ToString();
                txtPersonelId.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["ResourceID"].ToString();
                txtNameSurname.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["REsourceName"].ToString();
                cmbDepartment.EditValue = _departmentName;
                txtPosition.Text = _pozisyon;
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
                radioGroup1.SelectedIndex = Convert.ToInt32(dataSet.Tables["spSinglePersonel"].Rows[0]["Active"].ToString());
                txtMaas.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Maas"].ToString();
                txtTip.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["TipPuani"].ToString();
                cmbUyruk.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Uyruk"].ToString();
                cmbCinsiyet.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["sex"].ToString();
                cmbAskerlik.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Askerlik"].ToString();
                txtMedeniHali.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["MedeniHal"].ToString();
                cmbEhliyet.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Ehliyet"].ToString();
                txtAcilTel.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["aciltelefon"].ToString();
                txtEmail.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["email"].ToString();
                var item = (byte[])dataSet.Tables["spSinglePersonel"].Rows[0]["Image"];
                var memoryStream = new MemoryStream(item);
                pictureBox1.Image = Image.FromStream(memoryStream);
                mySqlConnection.Close();
            }
        }

        private void getDepartments()
        {
            using (var cnn = new MySqlConnection(conString))
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

                        foreach (DataRow Row in dt.Rows)
                        {
                            cmbDepartment.Properties.Items.Add(Row["DepartmentName"]);
                        }

                        cmbDepartment.Properties.Sorted = true;

                        cnn.Close();
                    }
                }
            }
        }

        private void bringPositions()
        {
            using (var cnn = new MySqlConnection(conString))
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

                        foreach (DataRow Row in dt.Rows)
                        {
                            txtPosition.Properties.Items.Add(Row["PositionName"]);
                        }

                        txtPosition.Properties.Sorted = true;
                        cnn.Close();
                    }
                }
            }
        }


        private DateTime IseBaslamaTarihi
        {
            get
            {
                return dtStartDate.DateTime;
            }
        }
        private void calculateVacation()
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                var iseBaslamaTarihi = dtStartDate.DateTime;
                var ikincitarih = DateTime.Today;
                var num = DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, ikincitarih);
                var toplamCalismaGunu = Convert.ToInt32(num);



                var firstFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, ikincitarih));
                var secondFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, ikincitarih) - 1825);
                var thirdFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, ikincitarih) - 3650);
                var over15Years = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, ikincitarih) - 5475);


                var dataFirstFiveYears = firstFiveYears * 14 / 365;
                var dataSecondFiveYears = ((firstFiveYears - secondFiveYears) * 14 / 365 + secondFiveYears * 18 / 365);
                var dataThirdFiveYears = ((firstFiveYears - secondFiveYears) * 14 / 365 + (secondFiveYears - thirdFiveYears) * 18 / 365 + thirdFiveYears * 22 / 365);
                var dataOver15Years = ((firstFiveYears - secondFiveYears) * 14 / 365 + (secondFiveYears - thirdFiveYears) * 18 / 365 + (thirdFiveYears - over15Years) * 22 / 365 + over15Years * 25 / 365);





                if (toplamCalismaGunu < 184)
                {
                    lblHak.Text = "0";
                    lbl05.Text = "6 ay altı";
                    lbl510.Text = "0";
                    lbl1015.Text = "0";
                    lbl15ust.Text = "0";
                }

                if (toplamCalismaGunu > 184 && toplamCalismaGunu < 1825)
                {
                    lblHak.Text = dataFirstFiveYears.ToString();

                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";

                    lbl510.Text = "0";
                    lbl1015.Text = "0";
                    lbl15ust.Text = "0";
                }
                if (toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650)
                {
                    lblHak.Text = dataSecondFiveYears.ToString();
                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";
                    lbl510.Text = toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650 ? (secondFiveYears * 18 / 365).ToString() : "90";
                    lbl1015.Text = "0";
                    lbl15ust.Text = "0";
                }
                if (toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475)
                {
                    lblHak.Text = dataThirdFiveYears.ToString();
                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";
                    lbl510.Text = toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650 ? (secondFiveYears * 18 / 365).ToString() : "90";
                    lbl1015.Text = toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475 ? (thirdFiveYears * 22 / 365).ToString() : "110";


                    lbl15ust.Text = "0";
                }
                if (toplamCalismaGunu > 5475)
                {
                    lblHak.Text = dataOver15Years.ToString();
                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";
                    lbl510.Text = toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650 ? (secondFiveYears * 18 / 365).ToString() : "90";
                    lbl1015.Text = toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475 ? (thirdFiveYears * 22 / 365).ToString() : "110";
                    lbl15ust.Text = (over15Years * 25 / 365).ToString();
                }
            }
            else
            {
                var ikincitarih = dtEnd.DateTime;
                var num = DateTimeUtil.DateDiff(DateInterval.Day, IseBaslamaTarihi, ikincitarih);
                var toplamCalismaGunu = Convert.ToInt32(num);



                var firstFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, IseBaslamaTarihi, ikincitarih));
                var secondFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, IseBaslamaTarihi, ikincitarih) - 1825);
                var thirdFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, IseBaslamaTarihi, ikincitarih) - 3650);
                var over15Years = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, IseBaslamaTarihi, ikincitarih) - 5475);


                var dataFirstFiveYears = firstFiveYears * 14 / 365;
                var dataSecondFiveYears = ((firstFiveYears - secondFiveYears) * 14 / 365 + secondFiveYears * 18 / 365);
                var dataThirdFiveYears = ((firstFiveYears - secondFiveYears) * 14 / 365 + (secondFiveYears - thirdFiveYears) * 18 / 365 + thirdFiveYears * 22 / 365);
                var dataOver15Years = ((firstFiveYears - secondFiveYears) * 14 / 365 + (secondFiveYears - thirdFiveYears) * 18 / 365 + (thirdFiveYears - over15Years) * 22 / 365 + over15Years * 25 / 365);





                if (toplamCalismaGunu < 184)
                {
                    lblHak.Text = "0";
                    lbl05.Text = "6 ay altı";
                    lbl510.Text = "0";
                    lbl1015.Text = "0";
                    lbl15ust.Text = "0";
                }

                if (toplamCalismaGunu > 184 && toplamCalismaGunu < 1825)
                {
                    lblHak.Text = dataFirstFiveYears.ToString();

                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";

                    lbl510.Text = "0";
                    lbl1015.Text = "0";
                    lbl15ust.Text = "0";
                }
                if (toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650)
                {
                    lblHak.Text = dataSecondFiveYears.ToString();
                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";
                    lbl510.Text = toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650 ? (secondFiveYears * 18 / 365).ToString() : "90";
                    lbl1015.Text = "0";
                    lbl15ust.Text = "0";
                }
                if (toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475)
                {
                    lblHak.Text = dataThirdFiveYears.ToString();
                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";
                    lbl510.Text = toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650 ? (secondFiveYears * 18 / 365).ToString() : "90";
                    lbl1015.Text = toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475 ? (thirdFiveYears * 22 / 365).ToString() : "110";


                    lbl15ust.Text = "0";
                }
                if (toplamCalismaGunu > 5475)
                {
                    lblHak.Text = dataOver15Years.ToString();
                    lbl05.Text = toplamCalismaGunu < 1825 ? (toplamCalismaGunu * 14 / 365).ToString() : "70";
                    lbl510.Text = toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650 ? (secondFiveYears * 18 / 365).ToString() : "90";
                    lbl1015.Text = toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475 ? (thirdFiveYears * 22 / 365).ToString() : "110";
                    lbl15ust.Text = (over15Years * 25 / 365).ToString();
                }
            }
        }
        private void getVacations()
        {
            using (var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (var mySqlCommand = new MySqlCommand("spSelectVacations;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    var num = Convert.ToInt32(_personelID);
                    mySqlCommand.Parameters.Add(new MySqlParameter("personelID", num));
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
        private void getUsedVacations()
        {
            using (var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var mySqlCommand = new MySqlCommand("spUSedVacations;", mySqlConnection)
                { CommandType = CommandType.StoredProcedure
                };
                var str = _personelID;
                mySqlCommand.Parameters.Add(new MySqlParameter("personelID", str));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spUsedVacations");
                lblKul.Text = dataSet.Tables["spUSedVacations"].Rows[0]["totalVacationUsed"].ToString();
                lblKullanilan.Text = dataSet.Tables["spUSedVacations"].Rows[0]["totalVacationUsed"].ToString();



                if (lblKul.Text == string.Empty)
                {
                    lblKul.Text = "0";
                }


                else
                {
                    var kullanilan = Convert.ToInt32(lblKul.Text);
                    var hakedilen = Convert.ToInt32(lblHak.Text);
                    lblKalan.Text = Convert.ToString(hakedilen - kullanilan);
                }

                mySqlConnection.Close();
            }
        }


        private void getMaas()
        {
            using (var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (var mySqlCommand = new MySqlCommand("spMaasArtislari;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    var num = Convert.ToInt32(_personelID);
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

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    if (_personelID == null)
                    {
                        addPersonel();
                        calculateVacation();
                        getUsedVacations();
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
                    updatePersonel();
                    calculateVacation();
                    getUsedVacations();
                    labelControl.Text = string.Format("Personel: {0} | Departmanı: {1} | Pozisyonu: {2} | Sicil No: {3} | Kayıt No:{4}", txtNameSurname.Text, _departmentName, _pozisyon, _personelID, _kayitID);
                    break;


                case "Save And Close":
                    if (_personelID == null)
                    {
                        addPersonel();
                        Close();
                    }


                    break;
                case "Save And New":
                    if (_personelID == null)
                    {
                        addPersonel();
                        _personelID = null;
                        ClearSpace(this);
                    }

                    else
                    {
                        _personelID = null;
                        ClearSpace(this);
                    }
                    break;
                default:
                    break;
            }
        }

       
      



        public static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var picturebox = c as PictureBox;
                if (textBox != null)
                {
                    (textBox).Text = string.Empty;
                }
                if (comboBox != null)
                {
                    comboBox.SelectedIndex = -1;
                }
                if (picturebox != null)
                {
                    picturebox.Image = null;
                }
                if (c.HasChildren)
                {
                    ClearSpace(c);
                }
            }
        }

        public static void LockControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var radiobox = c as RadioGroup;
                var button = c as SimpleButton;
                if (button != null)
                {
                    button.Enabled = false;
                }
                if (radiobox != null)
                {
                    radiobox.ReadOnly = true;
                }
                if (textBox != null)
                {
                    textBox.ReadOnly = true;
                }
                if (comboBox != null)
                {
                    comboBox.ReadOnly = true;
                }
                if (c.HasChildren)
                {
                    LockControls(c);
                }
            }
        }

        public static void UnlockLockControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var radiobox = c as RadioGroup;
                var button = c as SimpleButton;
                if (button != null)
                {
                    button.Enabled = true;
                }
                if (radiobox != null)
                {
                    radiobox.ReadOnly = false;
                }
                if (textBox != null)
                {
                    textBox.ReadOnly = false;
                }
                if (comboBox != null)
                {
                    comboBox.ReadOnly = false;
                }
                if (c.HasChildren)
                {
                    UnlockLockControls(c);
                }
            }
        }
        public enum DateInterval
        {
            Year,
            Month,
            Weekday,
            Day,
            Hour,
            Minute,
            Second
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
                        year = (long)(date2.Year - date1.Year);
                        break;
                    case DateInterval.Month:
                        year = (long)(date2.Month - date1.Month + 12 * (date2.Year - date1.Year));
                        break;
                    case DateInterval.Weekday:
                        year = Fix(timeSpan.TotalDays) / (long)7;
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

            private static long Fix(double Number)
            {
                var num = (Number < 0 ? (long)Math.Ceiling(Number) : (long)Math.Floor(Number));
                return num;
            }
        }

        

        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog()
                { Filter = "Image files | *.jpg"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
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
            {
                popvacation.ShowPopup(Control.MousePosition);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var frmvacation = new frmNewVacation())
            {
                frmvacation.personelID = _personelID;
                frmvacation.UserName = _UserNameFromMainForm;
                frmvacation.lblKalan.Text = lblKalan.Text;
                frmvacation.personelName = txtNameSurname.Text;
                var dr = frmvacation.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    getVacations();
                    getUsedVacations();
                    calculateVacation();
                    getOffAlacaklari();
                }
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPosition.Properties.Items.Clear();
            bringPositions();
        }



        private void txtNameSurname_KeyUp(object sender, KeyEventArgs e)
        {
            labelControl.Text = "Personel: " + txtNameSurname.Text;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var frmMaasArtisi = new Forms.Maas.frmMaasArtisi())
            {
                frmMaasArtisi.personelID = _personelID;
                frmMaasArtisi.UserName = _UserNameFromMainForm;
                var dr = frmMaasArtisi.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show("Maas Artis Talebi Onaya gonderilmistir.", "Onaya Gonderildi");
                }
            }
        }

        private void salaryGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popMaas.ShowPopup(Control.MousePosition);
            }
        }



        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptMaasArtisi report = new rptMaasArtisi() { RequestParameters = false };
            report.Parameters[0].Value = _personelID;
            new ReportPrintTool(report).ShowPreview();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmHatalar = new Forms.Hatalar.frmHataEkle();
            try
            {
                frmHatalar.personelID = _personelID;

                var dr = frmHatalar.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    getHataListesi();
                }
            }
            finally
            {
                if (frmHatalar != null)
                {
                    frmHatalar.Dispose();
                }
            }
        }

        private void getHataListesi()
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2);
            try
            {
                var mySqlCommand = new MySqlCommand("spLgHata;", mySqlConnection) { CommandType = CommandType.StoredProcedure };
                try
                {
                    var num = Convert.ToInt32(_personelID);
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
                    if (mySqlCommand != null)
                    {
                        mySqlCommand.Dispose();
                    }
                }
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }

        private void hatagridview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            popHata.ShowPopup(Control.MousePosition);
        }

        private void btnOffAlacagi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmAlacaklar = new frmOffAlacagi();
            try
            {
                frmAlacaklar.personelID = _personelID;
                frmAlacaklar.UserName = _UserNameFromMainForm;
                var dr = frmAlacaklar.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    getVacations();
                    getUsedVacations();
                    calculateVacation();
                    getOffAlacaklari();
                    getToplamOffAlacagi();
                }
            }
            finally
            {
                if (frmAlacaklar != null)
                {
                    frmAlacaklar.Dispose();
                }
            }
        }

        private void getOffAlacaklari()
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2);
            try
            {
                var mySqlCommand = new MySqlCommand("spOffAlacaklari;", mySqlConnection) { CommandType = CommandType.StoredProcedure };
                try
                {
                    var num = Convert.ToInt32(_personelID);
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
                    if (mySqlCommand != null)
                    {
                        mySqlCommand.Dispose();
                    }
                }
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }

        private void getOdenenOfflar()
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2);
            try
            {
                using (var mySqlCommand = new MySqlCommand("spOdenenOfflar;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    var num = Convert.ToInt32(_personelID);
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
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }
        private void getToplamOffAlacagi()
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2);
            try
            {
                var mySqlCommand = new MySqlCommand("spOffAlacaklariToplam;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", _personelID));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spOffAlacaklariToplam");
                lblOffalacagi.Text = dataSet.Tables["spOffAlacaklariToplam"].Rows[0]["Toplam Off Alacagi"].ToString();




                if (lblOffalacagi.Text == string.Empty)
                {
                    lblOffalacagi.Text = "0";
                }



                mySqlConnection.Close();
            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }


        private void gridView6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            popOffAlacak.ShowPopup(Control.MousePosition);
        }



        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Equals(tabOffAlacak) && gridOffAlacaklari.DataSource == null)
            {
                getOffAlacaklari();
                getOdenenOfflar();
            }
            if (xtraTabControl1.SelectedTabPage.Equals(tabMaas) && salaryGrid.DataSource == null)
            {
                getMaas();
            }
            if (xtraTabControl1.SelectedTabPage.Equals(tabPerformans) && hatagrid.DataSource == null)
            {
                getHataListesi();
            }
            if (xtraTabControl1.SelectedTabPage.Equals(tabEgitim) && egitimGrid.DataSource == null)
            {
                egitimler();
            }
        }

        private void egitimler()
        {
            var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2);
            try
            {
                using (var mySqlCommand = new MySqlCommand("spSelectEgitimByPersonel;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", _personelID));
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
                if (mySqlConnection != null)
                {
                    mySqlConnection.Dispose();
                }
            }
        }
        private void gridView6_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var Column = e.Column;
            if (Column != gridColumn1)
            {
                return;
            }
            if (MessageBox.Show("Off alacagini geri vereceksiniz.", "Emin misiniz?",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var frmOdemeTarihi = new frmOdemeTarihi();
                try
                {
                    var dr = frmOdemeTarihi.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        var _odemeTarihi = Convert.ToDateTime(frmOdemeTarihi.dateEdit1.EditValue.ToString());
                        var rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                        using (var con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                        {
                            using (var cmd = new MySqlCommand("spOffOde;", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            })
                            {
                                cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                                cmd.Parameters.Add(new MySqlParameter("userName", _UserNameFromMainForm));
                                cmd.Parameters.Add(new MySqlParameter("odemeTarihi", _odemeTarihi));
                                con.Open();
                                cmd.ExecuteNonQuery();
                                using (var mySqlDataAdapter = new MySqlDataAdapter())
                                {
                                    using (var dataTable = new DataTable())
                                    {
                                    }
                                    mySqlDataAdapter.SelectCommand = cmd;
                                }
                                con.Close();
                            }
                            getOffAlacaklari();
                            getToplamOffAlacagi();
                            getOdenenOfflar();
                        }
                    }
                }
                finally
                {
                    if (frmOdemeTarihi != null)
                    {
                        frmOdemeTarihi.Dispose();
                    }
                }
            }
            else
            {
                switch (MessageBox.Show("Off alacagini geri vereceksiniz.", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
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
            var Column = e.Column;

            if (Column != gridColumn6)
            {
                return;
            }
            var rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
            var frmMaasGoster = new Forms.Maas.frmMaasArtisiGoster();
            try
            {
                frmMaasGoster.rowid = rowid;
                frmMaasGoster.Text = txtNameSurname.Text;
                frmMaasGoster.ShowDialog();
            }
            finally
            {
                if (frmMaasGoster != null)
                {
                    frmMaasGoster.Dispose();
                }
            }
        }

        private void dtEnd_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null || e.Value.ToString() != String.Empty)
            {
                return;
            }
            e.Value = null;
        }

        private void cmbDepartment_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption != "add")
            {
                return;
            }
            using (var frmDepartments = new frmDepartments())
            {
                frmDepartments.ShowDialog();
            }
        }

        private void txtPosition_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption != "add")
            {
                return;
            }
            using (var frmPositions = new frmPositions())
            {
                frmPositions.ShowDialog();
            }
        }

        
    }
}
