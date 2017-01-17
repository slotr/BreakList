using System;
using System.Data;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Kasa
{
    public partial class FrmAvanslar : XtraForm
    {
        public string PersonelId { get; set; }
        public string AvansTipi { get; set; }
        public Boolean Flag { get; set; }
        public string UserName { get; set; }
        public FrmAvanslar()
        {
            InitializeComponent();
        }

        private void frmAvanslar_Load(object sender, EventArgs e)
        {
            //lblPersonel.Text = avansTipi;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Flag)
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand("spInsertTipAvansi;", mySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        DateTime tarih = Convert.ToDateTime(dateEdit1.EditValue);
                        int personelId = Convert.ToInt32(PersonelId);
                        string isleyen = UserName;
                        decimal tipavansi = Convert.ToDecimal(textEdit1.Text);
                        
                        
                        mySqlCommand.Parameters.Add(new MySqlParameter("resourceID", personelId));
                        mySqlCommand.Parameters.Add(new MySqlParameter("isleyen", isleyen));
                        mySqlCommand.Parameters.Add(new MySqlParameter("tarih", tarih));
                        mySqlCommand.Parameters.Add(new MySqlParameter("tipavansi", tipavansi));
                        
                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                }
            }
            else
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand("spInsertbankayayatan;", mySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        DateTime tarih = Convert.ToDateTime(dateEdit1.EditValue);
                        int personelId = Convert.ToInt32(PersonelId);
                        string isleyen = UserName;
                        decimal tipavansi = Convert.ToDecimal(textEdit1.Text);


                        mySqlCommand.Parameters.Add(new MySqlParameter("resourceID", personelId));
                        mySqlCommand.Parameters.Add(new MySqlParameter("isleyen", isleyen));
                        mySqlCommand.Parameters.Add(new MySqlParameter("tarih", tarih));
                        mySqlCommand.Parameters.Add(new MySqlParameter("tipavansi", tipavansi));

                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                }
            }
        }
    }
}