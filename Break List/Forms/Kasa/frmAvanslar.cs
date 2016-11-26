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
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Kasa
{
    public partial class frmAvanslar : XtraForm
    {
        public string personelID { get; set; }
        public string avansTipi { get; set; }
        public Boolean flag { get; set; }
        public string userName { get; set; }
        public frmAvanslar()
        {
            InitializeComponent();
        }

        private void frmAvanslar_Load(object sender, EventArgs e)
        {
            //lblPersonel.Text = avansTipi;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand("spInsertTipAvansi;", mySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        DateTime tarih = Convert.ToDateTime(dateEdit1.EditValue);
                        int _personelID = Convert.ToInt32(personelID);
                        string isleyen = userName;
                        decimal tipavansi = Convert.ToDecimal(textEdit1.Text.ToString());
                        
                        
                        mySqlCommand.Parameters.Add(new MySqlParameter("resourceID", _personelID));
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
                        int _personelID = Convert.ToInt32(personelID);
                        string isleyen = userName;
                        decimal tipavansi = Convert.ToDecimal(textEdit1.Text.ToString());


                        mySqlCommand.Parameters.Add(new MySqlParameter("resourceID", _personelID));
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