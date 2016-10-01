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

namespace Break_List
{
    public partial class frmPersonelDetails : DevExpress.XtraEditors.XtraForm
    {
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        private FileStream fs;
        private BinaryReader br;
        public string _personelID { get; set; }
        
        public frmPersonelDetails()
        {
            InitializeComponent();

        }

        private void addPersonel()
        {
            try
            {
                try
                {
                    if ((txtNameSurname.Text.Length <= 0 ? true : lblFileName.Text.Length <= 0))
                    {
                        MessageBox.Show("Incomplete data!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                        cmd = new MySqlCommand("INSERT INTO resources(ResourceName, customField1, Image, ResourceID, Department, StartDate, EndDate, Position, BirthDate) VALUES(@ResourceName, @customField1, @Image, @resourceID, @Department, @StartDate, @EndDate, @Position, @BirthDate)", con);


                        cmd.Parameters.Add("@ResourceName", MySqlDbType.VarChar, 45);
                        cmd.Parameters.Add("@customField1", MySqlDbType.VarChar, 45);
                        cmd.Parameters.Add("@Image", MySqlDbType.Blob);
                        cmd.Parameters.Add("@resourceID", MySqlDbType.Int32);
                        cmd.Parameters.Add("@Department", MySqlDbType.VarChar, 45);
                        cmd.Parameters.Add("@StartDate", MySqlDbType.Date);
                        cmd.Parameters.Add("@EndDate", MySqlDbType.Date);
                        cmd.Parameters.Add("@BirthDate", MySqlDbType.Date);
                        cmd.Parameters.Add("@Position", MySqlDbType.VarChar, 45);
                        cmd.Parameters["@ResourceName"].Value = txtNameSurname.Text;
                        cmd.Parameters["@customField1"].Value = txtPosition.Text;
                        cmd.Parameters["@Image"].Value = ImageData;
                        cmd.Parameters["@resourceID"].Value = txtPersonelId.Text;
                        cmd.Parameters["@Department"].Value = cmbDepartment.EditValue.ToString();
                        cmd.Parameters["@StartDate"].Value = dtStartDate.EditValue;
                        cmd.Parameters["@EndDate"].Value = dtEndDate.EditValue;
                        cmd.Parameters["@Position"].Value = txtPosition.EditValue.ToString();
                        cmd.Parameters["@BirthDate"].Value = dtBirthDate.EditValue;
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Personel Added Succesfully");
                        }
                        con.Close();
                    }
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
        void getNames()
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
                this.txtPersonelId.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Personel ID"].ToString();
                this.txtNameSurname.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["FullName"].ToString();
                this.cmbDepartment.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["Department"].ToString();
                this.txtPosition.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["Position"].ToString();
                this.dtStartDate.EditValue = dataSet.Tables["spSinglePersonel"].Rows[0]["Start Date"].ToString();
                this.dtEndDate.Text = dataSet.Tables["spSinglePersonel"].Rows[0]["End Date"].ToString();
                byte[] item = (byte[])dataSet.Tables["spSinglePersonel"].Rows[0]["Image"];
                MemoryStream memoryStream = new MemoryStream(item);
                this.pictureBox1.Image = Image.FromStream(memoryStream);
                this.Text = this.txtNameSurname.Text;
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


                }
            }

        }


        private void calculateVacation()
        {
            DateTime dateTime = this.dtStartDate.DateTime;
            long num = frmPersonelDetails.DateTimeUtil.DateDiff(frmPersonelDetails.DateInterval.Day, dateTime, DateTime.Today);
            int num1 = Convert.ToInt32(num);
            this.lblEarnedVacation.Text = string.Concat("Earned Vacation:", Convert.ToString(num1 / 30), " Days");
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
                    mySqlCommand.Parameters.Add(new MySqlParameter("personelID", (object)num));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        this.gridControl1.DataSource = dataTable;
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
                this.lblUsedVacations.Text = string.Concat("Used Total Vacation:", dataSet.Tables["spUSedVacations"].Rows[0]["totalVacationUsed"].ToString(), " Days");
                mySqlConnection.Close();
            }
        }
        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    addPersonel();
                    break;
                case "Sipariş Notu":

                    break;
                case "Kapat":

                case "Kategori":


                    break;
                case "Urun":
                    break;
                case "Yeni Sipariş":

                    break;
                case "Siparişi Gönder":

                    break;
                case "About":


                    break;
                case "Ayarlar":

                    break;
                case "Rapor":

                    break;
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

        private void frmPersonelDetails_Load(object sender, EventArgs e)
        {
            
            if (this._personelID != null)
            {
                getNames();
                
                txtPersonelId.ReadOnly = true;
                txtNameSurname.ReadOnly = true;
                txtDocumentNo.ReadOnly = true;
                cmbDepartment.ReadOnly = true;
                txtPosition.ReadOnly = true;
                cmbDocumentType.ReadOnly = true;
                dtStartDate.ReadOnly = true;
                dtEndDate.ReadOnly = true;
                calculateVacation();
                getVacations();
                getUsedVacations();
                labelControl.Text = "Employee: " + txtNameSurname.Text;
            }
            else
            {
                getDepartments();
                lblEarnedVacation.Visible = false;
                lblUsedVacations.Visible = false;
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
                this.popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNewVacation newVacation = new frmNewVacation();

            newVacation.ShowDialog();
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPosition.Properties.Items.Clear();
            bringPositions();
        }
    }
}