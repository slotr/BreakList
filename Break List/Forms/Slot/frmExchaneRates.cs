using System;
using System.Data;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Slot
{
    public partial class FrmExchaneRates : XtraForm
    {
        public FrmExchaneRates()
        {
            InitializeComponent();
            GetLastDate();
        }
        private readonly string _str = Settings.Default.livegameConnectionString2;
        private void GetLastDate()
        {
            var conn = new MySqlConnection(_str);
            var command = conn.CreateCommand();
            command.CommandText = "SELECT Max(tarih) as tarih from tblrates";
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
                labelControl1.Text = @"Son Girilen Tarih: "+ $@"{reader["tarih"]:d/M/yyyy}"; 
                
            }conn.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            using (var conn = new MySqlConnection(_str))
            {
                using (var cmd = new MySqlCommand("spInsertRape;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new MySqlParameter("prate", textEdit1.Text));
                    
                    cmd.Parameters.Add(new MySqlParameter("ptarih", dateEdit1.DateTime));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    Close();
                }
            }
        }
    }
}