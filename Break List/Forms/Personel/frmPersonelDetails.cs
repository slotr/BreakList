using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraLayout.Utils;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List
{
    public partial class frmPersonelDetails : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        private FileStream fs;
        private BinaryReader br;
        public string _personelID { get; set; }
        public string _kayitID { get; set; }
        public int UniqueID { get; set; }
        public string _departmentName {get; set;}
        public string _pozisyon { get; set; }
        public string _UserID { get; set; }
        public string _UserNameFromMainForm { get; set; }
        #endregion
        public frmPersonelDetails()
        {
            InitializeComponent();

        }
        #region Personel
        private void addPersonel()
        {
            try
            {
                try
                {
                    if ((txtNameSurname.Text.Length <= 0 ? true : lblFileName.Text.Length <= 0))
                    {
                        MessageBox.Show("Resim Eklenmedi", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        string FileName = lblFileName.Text;
                        byte[] ImageData;
                        fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                        br = new BinaryReader(fs);
                        ImageData = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();                      
                            
                            cmd = new MySqlCommand("INSERT INTO resources(ResourceID, ResourceName, Image, Department, StartDate,  BirthDate, Position, DocumentType, DocumentNo, ValidUntil, WorkPermitStart, WorkPermitEnd, PassportDNNo, SSKNO, IhtiyatNo,  ReasonForLeaving, Adres, Telefon, Active, Maas, TipPuani, Uyruk, sex, email, MedeniHal, Askerlik, Ehliyet, aciltelefon ) VALUES(@ResourceID, @ResourceName, @Image, @Department, @StartDate,  @BirthDate, @Position, @DocumentType, @DocumentNo, @ValidUntil, @WorkPermitStart, @WorkPermitEnd, @PassportDNNo, @SSKNO, @IhtiyatNo,  @ReasonForLeaving, @Adres, @Telefon, @Active, @Maas, @TipPuani, @Uyruk, @sex, @email, @MedeniHal, @Askerlik, @Ehliyet, @aciltelefon)", con);
                            cmd.Parameters.Add("@ResourceID"        , MySqlDbType.Int32)                ;
                            cmd.Parameters.Add("@ResourceName"      , MySqlDbType.VarChar, 45)          ;
                            cmd.Parameters.Add("@Image"             , MySqlDbType.Blob)                 ;
                            cmd.Parameters.Add("@Department"        , MySqlDbType.VarChar, 45)          ;
                            cmd.Parameters.Add("@StartDate"         , MySqlDbType.Date)                 ;
                            //cmd.Parameters.Add("@EndDate"           , MySqlDbType.Date)                 ;
                            cmd.Parameters.Add("@BirthDate"         , MySqlDbType.Date)                 ;
                            cmd.Parameters.Add("@Position"          , MySqlDbType.VarChar, 45)          ;
                            cmd.Parameters.Add("@DocumentType"      , MySqlDbType.VarChar,45)           ;
                            cmd.Parameters.Add("@DocumentNo"        , MySqlDbType.VarChar,45)           ;
                            cmd.Parameters.Add("@ValidUntil"        , MySqlDbType.Date)                 ;
                            cmd.Parameters.Add("@WorkPermitStart"   , MySqlDbType.Date)                 ;
                            cmd.Parameters.Add("@WorkPermitEnd"     , MySqlDbType.Date)                 ;
                            cmd.Parameters.Add("@PassportDNNo"      ,MySqlDbType.VarChar, 45)           ;
                            cmd.Parameters.Add("@SSKNO"             , MySqlDbType.VarChar ,45)          ;
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
                            cmd.Parameters["@StartDate"       ].Value = dtStartDate.EditValue;
                            //cmd.Parameters["@EndDate"         ].Value = dtEndDate.EditValue;
                            cmd.Parameters["@BirthDate"       ].Value = dtBirthDate.EditValue;
                            cmd.Parameters["@Position"        ].Value = txtPosition.Text;
                            cmd.Parameters["@DocumentType"    ].Value = cmbDocumentType.Text;
                            cmd.Parameters["@DocumentNo"      ].Value = cmbDocumentType.Text;
                            cmd.Parameters["@ValidUntil"      ].Value = txtValidUntil.EditValue;
                            cmd.Parameters["@WorkPermitStart" ].Value = dtIzinBaslangic.EditValue;
                            cmd.Parameters["@WorkPermitEnd"   ].Value = dtIzinBitis.EditValue;
                            cmd.Parameters["@PassportDNNo"    ].Value = txtPassportNo.Text;
                            cmd.Parameters["@SSKNO"           ].Value = txtSSKNo.Text;
                            cmd.Parameters["@IhtiyatNo"       ].Value = txtIhtiyat.Text;
                            //cmd.Parameters["@ReasonForLeaving"].Value = txtistencikis.Text;
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

            try
            {
                cmd = new MySqlCommand("UPDATE resources SET ResourceName = @ResourceName,  Department = @Department, StartDate = @StartDate, BirthDate =@BirthDate, Position=@Position, DocumentType = @DocumentType, DocumentNo = @DocumentNo, ValidUntil = @ValidUntil, WorkPermitStart = @WorkPermitStart, WorkPermitEnd = @WorkPermitEnd, PassportDNNo = @PassportDNNo, SSKNO = @SSKNO, IhtiyatNo = @IhtiyatNo,  ReasonForLeaving = @ReasonForLeaving, Adres = @Adres, Telefon = @Telefon, Active = @Active, Maas=@Maas, TipPuani=@TipPuani ,Uyruk=@Uyruk, sex=@sex, email=@email, MedeniHal=@MedeniHal, Askerlik=@Askerlik, Ehliyet=@Ehliyet, aciltelefon=@aciltelefon WHERE UniqueID= @UniqueID", con);

                cmd.Parameters.Add("@ResourceName", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Department", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@StartDate", MySqlDbType.Date);
                //cmd.Parameters.Add("@EndDate", MySqlDbType.Date);
                cmd.Parameters.Add("@BirthDate", MySqlDbType.Date);
                cmd.Parameters.Add("@Position", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@DocumentType", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@DocumentNo", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@ValidUntil", MySqlDbType.Date);
                cmd.Parameters.Add("@WorkPermitStart", MySqlDbType.Date);
                cmd.Parameters.Add("@WorkPermitEnd", MySqlDbType.Date);
                cmd.Parameters.Add("@PassportDNNo", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@SSKNO", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@IhtiyatNo", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@ReasonForLeaving", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Adres", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Telefon", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Active", MySqlDbType.Int32);
                cmd.Parameters.Add("@Maas", MySqlDbType.Decimal);
                cmd.Parameters.Add("@TipPuani", MySqlDbType.Double);
                cmd.Parameters.Add("@Uyruk", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@sex", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 45);                
                cmd.Parameters.Add("@MedeniHal", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Askerlik", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Ehliyet", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@aciltelefon", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@UniqueID", MySqlDbType.Int32);

                cmd.Parameters["@ResourceName"].Value = txtNameSurname.Text;
                cmd.Parameters["@Department"].Value = cmbDepartment.Text;
                cmd.Parameters["@StartDate"].Value = Convert.ToDateTime(dtStartDate.EditValue);
                //cmd.Parameters["@EndDate"].Value = Convert.ToDateTime(dtEndDate.EditValue);
                cmd.Parameters["@BirthDate"].Value = Convert.ToDateTime(dtBirthDate.EditValue);
                cmd.Parameters["@Position"].Value = txtPosition.Text;
                cmd.Parameters["@DocumentType"].Value = cmbDocumentType.Text;
                cmd.Parameters["@DocumentNo"].Value = cmbDocumentType.Text;
                cmd.Parameters["@ValidUntil"].Value = Convert.ToDateTime(txtValidUntil.EditValue);
                cmd.Parameters["@WorkPermitStart"].Value = Convert.ToDateTime(dtIzinBaslangic.EditValue);
                cmd.Parameters["@WorkPermitEnd"].Value = Convert.ToDateTime(dtIzinBitis.EditValue);
                cmd.Parameters["@PassportDNNo"].Value = txtPassportNo.Text;
                cmd.Parameters["@SSKNO"].Value = txtSSKNo.Text;
                cmd.Parameters["@IhtiyatNo"].Value = txtIhtiyat.Text;
                //cmd.Parameters["@ReasonForLeaving"].Value = txtistencikis.Text;
                cmd.Parameters["@Adres"].Value = txtAddress.Text;
                cmd.Parameters["@Telefon"].Value = txtTelefon.Text;
                cmd.Parameters["@Active"].Value = Convert.ToInt32(radioGroup1.EditValue.ToString());
                cmd.Parameters["@Maas"].Value = Convert.ToDecimal(txtMaas.Text);
                cmd.Parameters["@TipPuani"].Value = Convert.ToDecimal(txtTip.Text);
                cmd.Parameters["@Uyruk"].Value = cmbUyruk.Text;
                cmd.Parameters["@sex"].Value = cmbCinsiyet.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@MedeniHal"].Value = txtMedeniHali.Text;
                cmd.Parameters["@Askerlik"].Value = cmbAskerlik.Text;
                cmd.Parameters["@Ehliyet"].Value = cmbEhliyet.Text;
                cmd.Parameters["@aciltelefon"].Value = txtAcilTel.Text;
                cmd.Parameters["@UniqueID"].Value = UniqueID;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Bir Hata Oluştu.");
            } 

                        

        }
        void getPersonel()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand mySqlCommand = new MySqlCommand("spSinglePersonel;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                string str = this._personelID;
                
                mySqlCommand.Parameters.Add(new MySqlParameter("_resourceID", str));
                mySqlConnection.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
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
                //dtEndDate.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["EndDate"].ToString();
                dtBirthDate.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["BirthDate"].ToString();
                cmbDocumentType.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["DocumentType"].ToString();                
                //txtistencikis.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["ReasonForLeaving"].ToString();
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
                byte[] item = (byte[])dataSet.Tables["spSinglePersonel"].Rows[0]["Image"];
                MemoryStream memoryStream = new MemoryStream(item);
                pictureBox1.Image = Image.FromStream(memoryStream);
                Text = txtNameSurname.Text + " " + UniqueID.ToString();
                mySqlConnection.Close();
            }
        }

        void getDepartments() // Yeni Kayit Olusturulurken Aliyor
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

                    foreach (DataRow Row in dt.Rows)
                    {

                        cmbDepartment.Properties.Items.Add(Row["DepartmentName"]);
                        
                    }

                   cmbDepartment.Properties.Sorted = true;

                    cnn.Close();
                }
            }
           
        }

        void bringPositions() // Yeni Kayit Olusturulurken Departmana gore Aliyor
        {

            var connectionString = Settings.Default.livegameConnectionString2;
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spBringPositions";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DepartmentName", MySqlDbType.VarChar, 45);
                cmd.Parameters["@DepartmentName"].Value = cmbDepartment.EditValue.ToString();
                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
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
        #endregion
        #region Vacations
        private void calculateVacation()
        {
            DateTime iseBaslamaTarihi = dtStartDate.DateTime;
            long num = DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, DateTime.Today);
            int toplamCalismaGunu = Convert.ToInt32(num);



            int firstFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, DateTime.Today));
            int secondFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, DateTime.Today) - 1825);
            int thirdFiveYears = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, DateTime.Today) - 3650);
            int over15Years = Convert.ToInt32(DateTimeUtil.DateDiff(DateInterval.Day, iseBaslamaTarihi, DateTime.Today) - 5475);


            int dataFirstFiveYears = firstFiveYears * 14 / 365;
            int dataSecondFiveYears = ((firstFiveYears - secondFiveYears) * 14 / 365 + secondFiveYears * 18 / 365);
            int dataThirdFiveYears = ((firstFiveYears - secondFiveYears) * 14 / 365 + (secondFiveYears - thirdFiveYears) * 18 / 365 + thirdFiveYears * 22 / 365);
            int dataOver15Years = ((firstFiveYears - secondFiveYears) * 14 / 365 + (secondFiveYears - thirdFiveYears) * 18 / 365 + (thirdFiveYears - over15Years) * 22 / 365 + over15Years * 25 / 365);

            
           
            

            if (toplamCalismaGunu < 184)
            {
                lblHak.Text = "0";
                lbl05.Text = "6 ay altı";
                lbl510.Text = "0";
                lbl1015.Text = "0";
                lbl15ust.Text = "0";
            }

            if (toplamCalismaGunu >184 && toplamCalismaGunu <1825)
            {
                
                lblHak.Text = dataFirstFiveYears.ToString();

                if (toplamCalismaGunu < 1825)
                {
                    lbl05.Text = (toplamCalismaGunu * 14 / 365).ToString();
                }
                else
                {
                    lbl05.Text = "70";
                }
                               
                lbl510.Text = "0";
                lbl1015.Text = "0";
                lbl15ust.Text = "0";
            }
            if(toplamCalismaGunu >1825 && toplamCalismaGunu < 3650)
            {
                lblHak.Text = dataSecondFiveYears.ToString();
                if (toplamCalismaGunu < 1825)
                {
                    lbl05.Text = (toplamCalismaGunu * 14 / 365).ToString();
                }
                else
                {
                    lbl05.Text = "70";
                }
                if (toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650)
                {
                    lbl510.Text = (secondFiveYears * 18 / 365).ToString();
                }
                else
                {
                    lbl510.Text = "90";
                }    
                lbl1015.Text = "0";
                lbl15ust.Text = "0";
            }
            if (toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475)
            {
                lblHak.Text = dataThirdFiveYears.ToString();
                if (toplamCalismaGunu < 1825)
                {
                    lbl05.Text = (toplamCalismaGunu * 14 / 365).ToString();
                }
                else
                {
                    lbl05.Text = "70";
                }
                if (toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650)
                {
                    lbl510.Text = (secondFiveYears * 18 / 365).ToString();
                }
                else
                {
                    lbl510.Text = "90";
                }
                if (toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475)
                {
                    lbl1015.Text = (thirdFiveYears * 22 / 365).ToString();
                }
                else
                {
                    lbl1015.Text = "110";
                }
                    
                
                lbl15ust.Text = "0";
            }
            if (toplamCalismaGunu > 5475)
            {
                lblHak.Text = dataOver15Years.ToString();
                if (toplamCalismaGunu < 1825)
                {
                    lbl05.Text = (toplamCalismaGunu * 14 / 365).ToString();
                }
                else
                {
                    lbl05.Text = "70";
                }
                if (toplamCalismaGunu > 1825 && toplamCalismaGunu < 3650)
                {
                    lbl510.Text = (secondFiveYears * 18 / 365).ToString();
                }
                else
                {
                    lbl510.Text = "90";
                }
                if (toplamCalismaGunu > 3650 && toplamCalismaGunu < 5475)
                {
                    lbl1015.Text = (thirdFiveYears * 22 / 365).ToString();
                }
                else
                {
                    lbl1015.Text = "110";
                }
                   lbl15ust.Text = (over15Years * 25 / 365).ToString();
                
                    
            }
        }
        private void getVacations()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spSelectVacations;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    int num = Convert.ToInt32(this._personelID);
                    mySqlCommand.Parameters.Add(new MySqlParameter("personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        this.vacationgrid.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }
       
        private void getUsedVacations()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand mySqlCommand = new MySqlCommand("spUSedVacations;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                string str = this._personelID;
                mySqlCommand.Parameters.Add(new MySqlParameter("personelID", str));
                mySqlConnection.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spUsedVacations");
                lblKul.Text = dataSet.Tables["spUSedVacations"].Rows[0]["totalVacationUsed"].ToString();
                lblKullanilan.Text = dataSet.Tables["spUSedVacations"].Rows[0]["totalVacationUsed"].ToString();

                
                
                if (lblKul.Text == "")
                {

                    lblKul.Text = "0";
                }


                else
                {
                    int kullanilan = Convert.ToInt32(lblKul.Text);
                    int hakedilen = Convert.ToInt32(lblHak.Text);
                    lblKalan.Text = Convert.ToString(hakedilen - kullanilan);
                }
                
                mySqlConnection.Close();
            }
        }
        #endregion
        #region Maaslar
        private void getMaas()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spMaasArtislari;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    int num = Convert.ToInt32(this._personelID);
                    mySqlCommand.Parameters.Add(new MySqlParameter("personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        salaryGrid.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }
        #endregion
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
                    labelControl.Text = "Personel: " + txtNameSurname.Text + " | Departmanı: " + _departmentName + " | Pozisyonu: " + _pozisyon + " | Sicil No: " + _personelID + " | Kayıt No:" + _kayitID;
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
               
            }
        }
        #region Permission Control
        public Boolean hasPermissionToVacations { get; set; }
        public Boolean hasPermissionsToPersonelEditAdd { get; set; }
        public Boolean hasPermissionToAddEditTip { get; set; }
        void checkPermissions() //UserID ye gore permission control
        {
            MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * from permissions WHERE UserID ='" + _UserID + "'";
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
                hasPermissionToVacations = Convert.ToBoolean(reader["Vacations"].ToString());
                hasPermissionsToPersonelEditAdd = Convert.ToBoolean(reader["personelEkle"].ToString());
                hasPermissionToAddEditTip = Convert.ToBoolean(reader["MaasArtisi"].ToString());

            }
            conn.Close();
        }
        #endregion

        #region Utilities
        public static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var picturebox = c as PictureBox;
                if (textBox != null)
                    (textBox).Text = "";

                if (comboBox != null)
                    comboBox.SelectedIndex = -1;
                if (picturebox != null)
                    picturebox.Image = null;

                if (c.HasChildren)
                    ClearSpace(c);
            }
        }

        public static void LockControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var picturebox = c as PictureBox;
                var radiobox = c as RadioGroup;
                var button = c as SimpleButton;
                if (button != null)
                    button.Enabled = true;
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

        public static void UnlockLockControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var picturebox = c as PictureBox;
                var radiobox = c as RadioGroup;
                var button = c as SimpleButton;
                if (button != null)
                    button.Enabled = false;
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
                TimeSpan timeSpan = date2 - date1;
                switch (interval)
                {
                    case DateInterval.Year:
                        {
                            year = (long)(date2.Year - date1.Year);
                            break;
                        }
                    case DateInterval.Month:
                        {
                            year = (long)(date2.Month - date1.Month + 12 * (date2.Year - date1.Year));
                            break;
                        }
                    case DateInterval.Weekday:
                        {
                            year = Fix(timeSpan.TotalDays) / (long)7;
                            break;
                        }
                    case DateInterval.Day:
                        {
                            year = Fix(timeSpan.TotalDays);
                            break;
                        }
                    case DateInterval.Hour:
                        {
                            year = Fix(timeSpan.TotalHours);
                            break;
                        }
                    case DateInterval.Minute:
                        {
                            year = Fix(timeSpan.TotalMinutes);
                            break;
                        }
                    default:
                        {
                            year = Fix(timeSpan.TotalSeconds);
                            break;
                        }
                }
                return year;
            }

            private static long Fix(double Number)
            {
                long num;
                num = (Number < 0 ? (long)Math.Ceiling(Number) : (long)Math.Floor(Number));
                return num;
            }
        }
        #endregion
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
                labelControl.Text = "Personel: " + txtNameSurname.Text + " | Departmanı: " + _departmentName + " | Pozisyonu: " + _pozisyon + " | Sicil No: " + _personelID + " | Kayıt No:" + _kayitID;
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

                if (hasPermissionToAddEditTip == false)
                {

                }
                windowsUIButtonPanelMain.Buttons["Save"].Properties.Caption = "Edit";
                windowsUIButtonPanelMain.Buttons["Save And New"].Properties.Visible = false;
                windowsUIButtonPanelMain.Buttons["Save And Close"].Properties.Visible = false;
                txtMaas.Enabled = false;
                txtTip.Enabled = false;
            }
            else
            {
                getDepartments();
                tabLayout.Visibility = LayoutVisibility.Never;                
                labelControl.Text = "Yeni Personel Kaydı";
                
            }
            
        }
       
        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Image files | *.jpg"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.lblFileName.Text = openFileDialog.FileName.ToString();
                    this.pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
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
                this.popvacation.ShowPopup(Control.MousePosition);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (frmNewVacation frmvacation = new frmNewVacation())
            {
                frmvacation.personelID = _personelID.ToString();
                frmvacation.UserName = _UserNameFromMainForm;
                frmvacation.lblKalan.Text = lblKalan.Text;
                frmvacation.personelName = txtNameSurname.Text;
                DialogResult dr = frmvacation.ShowDialog();
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
            using (Forms.Maas.frmMaasArtisi frmMaasArtisi = new Forms.Maas.frmMaasArtisi())
            {
                frmMaasArtisi.personelID = _personelID.ToString();
                frmMaasArtisi.UserName = _UserNameFromMainForm;
                DialogResult dr = frmMaasArtisi.ShowDialog();
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
            rptMaasArtisi report = new rptMaasArtisi();

            report.RequestParameters = false;
            report.Parameters[0].Value = _personelID;
            new ReportPrintTool(report).ShowPreview();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Forms.Hatalar.frmHataEkle frmHatalar = new Forms.Hatalar.frmHataEkle())
            {
                frmHatalar.personelID = _personelID.ToString();
                
                DialogResult dr = frmHatalar.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    getHataListesi();
                }

            }
        }

        private void getHataListesi()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spLgHata;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    int num = Convert.ToInt32(this._personelID);
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        hatagrid.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }

        private void hatagridview_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popHata.ShowPopup(Control.MousePosition);
            }
        }

        private void btnOffAlacagi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Forms.Personel.frmOffAlacagi frmAlacaklar = new Forms.Personel.frmOffAlacagi())
            {
                frmAlacaklar.personelID = _personelID.ToString();
                frmAlacaklar.UserName = _UserNameFromMainForm.ToString();
                DialogResult dr = frmAlacaklar.ShowDialog();
                if (dr== DialogResult.OK)
                {
                    getVacations();
                    getUsedVacations();
                    calculateVacation();
                    getOffAlacaklari();
                    getToplamOffAlacagi();
                }
            }
        }
        #region offlar
        private void getOffAlacaklari()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spOffAlacaklari;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    int num = Convert.ToInt32(this._personelID);
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        gridOffAlacaklari.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }

        private void getOdenenOfflar()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spOdenenOfflar;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    int num = Convert.ToInt32(this._personelID);
                    mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        gridOdenenIzinler.DataSource = dataTable;
                    }
                    mySqlConnection.Close();
                }
            }
        }
        private void getToplamOffAlacagi()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand mySqlCommand = new MySqlCommand("spOffAlacaklariToplam;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                mySqlCommand.Parameters.Add(new MySqlParameter("_personelID", _personelID));
                mySqlConnection.Open();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spOffAlacaklariToplam");
                lblOffalacagi.Text = dataSet.Tables["spOffAlacaklariToplam"].Rows[0]["Toplam Off Alacagi"].ToString();




                if (lblOffalacagi.Text == "")
                {

                    lblOffalacagi.Text = "0";
                }


                else
                {

                }

                mySqlConnection.Close();
            }
        }
        #endregion

        private void gridView6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               popOffAlacak.ShowPopup(Control.MousePosition);
            }
        }

        private void xtraTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Equals(tabOffAlacak))
            {
                if (gridOffAlacaklari.DataSource == null)
                {
                    getOffAlacaklari();
                    getOdenenOfflar();
                }
               
            }
            if (xtraTabControl1.SelectedTabPage.Equals(tabMaas))
            {
                if (salaryGrid.DataSource == null)
                {
                    getMaas();
                }
               
                
            }

            if (xtraTabControl1.SelectedTabPage.Equals(tabPerformans))
            {
                if (hatagrid.DataSource == null)
                {
                    getHataListesi();
                }
                
            }
        }


        private void gridView6_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn Column = e.Column;
            if (Column == gridColumn1)
            {
                
                DialogResult result = MessageBox.Show("Off alacagini geri vereceksiniz.", "Emin misiniz?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (Forms.Personel.frmOdemeTarihi frmOdemeTarihi = new Forms.Personel.frmOdemeTarihi())
                    {
                       
                        DialogResult dr = frmOdemeTarihi.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            DateTime _odemeTarihi = Convert.ToDateTime(frmOdemeTarihi.dateEdit1.EditValue.ToString());
                            int rowid;
                            rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
                            using (MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                            {
                                using (MySqlCommand cmd = new MySqlCommand("spOffOde;", con)
                                {
                                    CommandType = CommandType.StoredProcedure
                                })
                                {

                                    cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                                    cmd.Parameters.Add(new MySqlParameter("userName", _UserNameFromMainForm));
                                    cmd.Parameters.Add(new MySqlParameter("odemeTarihi",_odemeTarihi));
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                                    {
                                        DataTable dataTable = new DataTable();
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
                    
                }
                else if (result == DialogResult.No)
                {
                    //code for No
                }
                else if (result == DialogResult.Cancel)
                {
                    //code for Cancel
                }

                                
            }
            
        }

 }
}