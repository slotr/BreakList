using System;
using System.Data;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Counts
{
    public partial class frmInitiator : XtraForm
    {
        public frmInitiator()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spNewCount;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("CountDate", dateEdit1.DateTime));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
            }
        }
    }
}