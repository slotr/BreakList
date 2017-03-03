using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using System.Speech.Synthesis;
namespace Break_List.Forms.Reader
{
    public partial class Frmreader : DevExpress.XtraEditors.XtraForm
    {
        public Frmreader()
        {
            InitializeComponent();
        }

       public string Personel { get; set; }
        public string Data { get; set; }
        private Boolean Iceride { get; set; }        
        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

              

      

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            
                using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand("spCheckInAndInstert;", mySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        mySqlCommand.Parameters.Add(new MySqlParameter("rfid", Data));
                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();
                        mySqlConnection.Close();
                    }
                }
            
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var str = textEdit1.Text;
            var charsToRemove = new[] { "?", ";", "ş", ":" };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }

            if (str.Length != 17) return;
            labelControl1.Text = @"Lütfen Bekleyin";
            labelControl1.BackColor = Color.Red;
            Data = str;
            timer1.Start();
        }

        private void Konus()
        {
            MessageBox.Show(Data);
            MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT ResourceName FROM resources WHERE rfid ='" + Data + "' GROUp by ResourceName ORDER BY rfid DESC Limit 1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There were an Error", ex.ToString());
            }
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Personel = reader["resourceName"].ToString();
            conn.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Stop();

            Getflag();
            if (Iceride)
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand("spCheckout;", mySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        mySqlCommand.Parameters.Add(new MySqlParameter("_rfidNo", Data));

                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                }
                textEdit1.Text = "";
                labelControl1.BackColor = Color.Green;
                labelControl1.Text = @"Lütfen Kartınızı Geçirin";
                SpeechSynthesizer synth = new SpeechSynthesizer();

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string.
                synth.Speak("Gulea Gulea, " + Personel);
            }
            else if (Iceride == false)
            {
                simpleButton1.PerformClick();
                textEdit1.Text = "";
                labelControl1.BackColor = Color.Green;
                labelControl1.Text = @"Lütfen Kartınızı Geçirin";
                Konus();
                
                SpeechSynthesizer synth = new SpeechSynthesizer();

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string.
                synth.Speak("Hoshgeldin, " +Personel);

            }

           
            
        }

        private void frmreader_Load(object sender, EventArgs e)
        {
            if(textEdit1.Text == "")
            {
                labelControl1.Text = @"Lütfen Kartınızı Geçirin";
                labelControl1.BackColor = Color.Green;
                labelControl1.ForeColor = Color.White;
                
            }
        }


        private void Getflag() 
        {
            MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT Max(ID) as ID , iceride, cikti FROM tblrfiddata WHERE rfidno ='" + Data + "' GROUp by iceride, cikti ORDER BY ID DESC Limit 1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There were an Error", ex.ToString());
            }
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows == false)
            {
                Iceride = false;               
            }

            else if (Convert.ToBoolean(reader["iceride"]) && Convert.ToBoolean(reader["cikti"])== false)
            {                
                Iceride = true;                
                
            }
            else if (Convert.ToBoolean(reader["iceride"]) && Convert.ToBoolean(reader["cikti"]))
            {
                Iceride = false;                
            }
            
            conn.Close();
        }
    }
}