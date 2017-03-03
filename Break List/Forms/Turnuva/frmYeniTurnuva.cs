using System;
using System.Data;
using DevExpress.XtraEditors;
using Break_List.Class;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmYeniTurnuva : XtraForm
{
    public FrmYeniTurnuva()
    {
        InitializeComponent();
    }
        public string TurnuvaId;
        public bool YeniTurnuva { get; set; }
        private void frmYeniTurnuva_Load(object sender, EventArgs e)
        {

            if (YeniTurnuva == false)
            {
                
                ParametreGetir();
            }
            

        }

        private void ParametreGetir()
        {
           
            using (var mySqlConnection = new MySqlConnection(ConString))
            {
                var cmd = new MySqlCommand("spTurnuva_Select;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_turnuvaID", TurnuvaId));
                mySqlConnection.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    if (dbr.HasRows)
                    {
                        txtTurnuvaAdi.Text      =dbr["turnuva_name"        ].ToString();
                        dateEdit1.EditValue     =dbr["tarih"      ].ToString();
                        tf1.Text                =dbr["ilk_spin_5K"   ].ToString();
                        tf2.Text                =dbr["5K"         ].ToString();
                        tf3.Text                =dbr["10K"        ].ToString();
                        tf4.Text                =dbr["25k"        ].ToString();
                        tf5.Text                =dbr["50K"        ].ToString();
                        tf6.Text                =dbr["100K"       ].ToString();
                        rb1.Text                =dbr["rebuy1"     ].ToString();
                        rb2.Text                =dbr["rebuy2"     ].ToString();
                        rb3.Text                =dbr["rebuy3"     ].ToString();
                        rb4.Text                =dbr["rebuy4"     ].ToString();
                        rb5.Text                =dbr["rebuy5"     ].ToString();
                        rb6.Text                =dbr["rebuy6"     ].ToString();
                        textEdit1.Text          =dbr["o1"           ].ToString();
                        textEdit2.Text          =dbr["o2"           ].ToString();
                        textEdit3.Text          =dbr["o3"           ].ToString();
                        textEdit4.Text          =dbr["o4"           ].ToString();
                        textEdit5.Text          =dbr["o5"           ].ToString();
                        textEdit6.Text          =dbr["o6"           ].ToString();
                        textEdit7.Text          =dbr["o7"           ].ToString();
                        textEdit8.Text          =dbr["o8"           ].ToString();
                        textEdit9.Text          =dbr["o9"           ].ToString();
                        textEdit10.Text         =dbr["o10"          ].ToString();
                        textEdit11.Text         =dbr["o11"          ].ToString();
                        textEdit12.Text         =dbr["o12"          ].ToString();
                        textEdit13.Text         =dbr["o13"          ].ToString();
                        textEdit14.Text         =dbr["o14"          ].ToString();
                        textEdit15.Text         =dbr["o15"].ToString();
                    }                                


                }
                mySqlConnection.Close();
            }
        }

       
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (YeniTurnuva)
            {
                
                ParametreKaydet();
            }
            else
            {
                ParametreUpdateEt();

            }
            
        }

    private void ParametreUpdateEt()
    {
        using (var conn = new MySqlConnection(ConString))
        {
            using (var cmd = new MySqlCommand("spTurnuva_Update;", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                cmd.Parameters.Add(new MySqlParameter("t_adi", txtTurnuvaAdi.Text));
                cmd.Parameters.Add(new MySqlParameter("t_tarih", dateEdit1.DateTime));
                cmd.Parameters.Add(new MySqlParameter("t_ilk_spin", tf1.Text));
                cmd.Parameters.Add(new MySqlParameter("t_5K", tf2.Text));
                cmd.Parameters.Add(new MySqlParameter("t_10K", tf3.Text));
                cmd.Parameters.Add(new MySqlParameter("t_25k", tf4.Text));
                cmd.Parameters.Add(new MySqlParameter("t_50K", tf5.Text));
                cmd.Parameters.Add(new MySqlParameter("t_100K", tf6.Text));
                cmd.Parameters.Add(new MySqlParameter("t_rebuy1", rb1.Text));
                cmd.Parameters.Add(new MySqlParameter("t_rebuy2", rb2.Text));
                cmd.Parameters.Add(new MySqlParameter("t_rebuy3", rb3.Text));
                cmd.Parameters.Add(new MySqlParameter("t_rebuy4", rb4.Text));
                cmd.Parameters.Add(new MySqlParameter("t_rebuy5", rb5.Text));
                cmd.Parameters.Add(new MySqlParameter("t_rebuy6", rb6.Text));
                cmd.Parameters.Add(new MySqlParameter("o1", textEdit1.Text));
                cmd.Parameters.Add(new MySqlParameter("o2", textEdit2.Text));
                cmd.Parameters.Add(new MySqlParameter("o3", textEdit3.Text));
                cmd.Parameters.Add(new MySqlParameter("o4", textEdit4.Text));
                cmd.Parameters.Add(new MySqlParameter("o5", textEdit5.Text));
                cmd.Parameters.Add(new MySqlParameter("o6", textEdit6.Text));
                cmd.Parameters.Add(new MySqlParameter("o7", textEdit7.Text));
                cmd.Parameters.Add(new MySqlParameter("o8", textEdit8.Text));
                cmd.Parameters.Add(new MySqlParameter("o9", textEdit9.Text));
                cmd.Parameters.Add(new MySqlParameter("o10", textEdit10.Text));
                cmd.Parameters.Add(new MySqlParameter("o11", textEdit11.Text));
                cmd.Parameters.Add(new MySqlParameter("o12", textEdit12.Text));
                cmd.Parameters.Add(new MySqlParameter("o13", textEdit13.Text));
                cmd.Parameters.Add(new MySqlParameter("o14", textEdit14.Text));
                cmd.Parameters.Add(new MySqlParameter("o15", textEdit15.Text));
                cmd.Parameters.Add(new MySqlParameter("turnuvaID", TurnuvaId));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();

            }
        }
        }

    private const string ConString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";


    private void ParametreKaydet()
        {
            if (dateEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Tarih Bos olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEdit1.ShowPopup();
                dateEdit1.Focus();

            }
            else
            {
                using (var conn = new MySqlConnection(ConString))
                {
                    using (var cmd = new MySqlCommand("spTurnuva_yeni_turnuva;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new MySqlParameter("t_adi", txtTurnuvaAdi.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_tarih", dateEdit1.EditValue));
                        cmd.Parameters.Add(new MySqlParameter("t_ilk_spin", tf1.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_5K", tf2.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_10K", tf3.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_25k", tf4.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_50K", tf5.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_100K", tf6.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_rebuy1", rb1.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_rebuy2", rb2.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_rebuy3", rb3.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_rebuy4", rb4.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_rebuy5", rb5.Text));
                        cmd.Parameters.Add(new MySqlParameter("t_rebuy6", rb6.Text));
                        cmd.Parameters.Add(new MySqlParameter("o1", textEdit1.Text));
                        cmd.Parameters.Add(new MySqlParameter("o2", textEdit2.Text));
                        cmd.Parameters.Add(new MySqlParameter("o3", textEdit3.Text));
                        cmd.Parameters.Add(new MySqlParameter("o4", textEdit4.Text));
                        cmd.Parameters.Add(new MySqlParameter("o5", textEdit5.Text));
                        cmd.Parameters.Add(new MySqlParameter("o6", textEdit6.Text));
                        cmd.Parameters.Add(new MySqlParameter("o7", textEdit7.Text));
                        cmd.Parameters.Add(new MySqlParameter("o8", textEdit8.Text));
                        cmd.Parameters.Add(new MySqlParameter("o9", textEdit9.Text));
                        cmd.Parameters.Add(new MySqlParameter("o10", textEdit10.Text));
                        cmd.Parameters.Add(new MySqlParameter("o11", textEdit11.Text));
                        cmd.Parameters.Add(new MySqlParameter("o12", textEdit12.Text));
                        cmd.Parameters.Add(new MySqlParameter("o13", textEdit13.Text));
                        cmd.Parameters.Add(new MySqlParameter("o14", textEdit14.Text));
                        cmd.Parameters.Add(new MySqlParameter("o15", textEdit15.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();

                    }
                }}
            
        }
        
}
}
