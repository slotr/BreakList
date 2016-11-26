using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using System.Speech.Synthesis;
namespace Break_List.Forms.Reader
{
    public partial class frmreader : DevExpress.XtraEditors.XtraForm
    {
        public frmreader()
        {
            InitializeComponent();
        }

       public string personel { get; set; }
        public string data { get; set; }  
        Boolean iceride { get; set; }        
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
                        mySqlCommand.Parameters.Add(new MySqlParameter("rfid", data));
                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();
                        mySqlConnection.Close();
                    }
                }
            
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var str = textEdit1.Text;
            var charsToRemove = new string[] { "?", ";", "ş", ":" };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }
            
            if (str.Length == 17) // RFID yapinca karakter sayisi degisebilir. Magnetic stripe icin suan boyle.
            {
                labelControl1.Text = "Lütfen Bekleyin";
                labelControl1.BackColor = Color.Red;
                data = str;
                timer1.Start();
                
            }
            
            
        }
        void konus()
        {
            MessageBox.Show(data);
            MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT ResourceName FROM resources WHERE rfid ='" + data + "' GROUp by ResourceName ORDER BY rfid DESC Limit 1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There were an Error", ex.ToString());
            }
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            personel = reader["resourceName"].ToString();
            conn.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Stop();

            getflag();
            if (iceride == true)
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand("spCheckout;", mySqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        mySqlCommand.Parameters.Add(new MySqlParameter("_rfidNo", data));

                        mySqlConnection.Open();
                        mySqlCommand.ExecuteNonQuery();

                        mySqlConnection.Close();
                    }
                }
                textEdit1.Text = "";
                labelControl1.BackColor = Color.Green;
                labelControl1.Text = "Lütfen Kartınızı Geçirin";
                SpeechSynthesizer synth = new SpeechSynthesizer();

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string.
                synth.Speak("Gulea Gulea, " + personel);
            }
            else if (iceride == false)
            {
                simpleButton1.PerformClick();
                textEdit1.Text = "";
                labelControl1.BackColor = Color.Green;
                labelControl1.Text = "Lütfen Kartınızı Geçirin";
                konus();
                
                SpeechSynthesizer synth = new SpeechSynthesizer();

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string.
                synth.Speak("Hoshgeldin, " +personel);

            }

           
            
        }

        private void frmreader_Load(object sender, EventArgs e)
        {
            if(textEdit1.Text == "")
            {
                labelControl1.Text = "Lütfen Kartınızı Geçirin";
                labelControl1.BackColor = Color.Green;
                labelControl1.ForeColor = Color.White;
                
            }
        }

        
        void getflag() 
        {
            MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT Max(ID) as ID , iceride, cikti FROM tblrfiddata WHERE rfidno ='" + data + "' GROUp by iceride, cikti ORDER BY ID DESC Limit 1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There were an Error", ex.ToString());
            }
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows == false)
            {
                iceride = false;               
            }

            else if (Convert.ToBoolean(reader["iceride"]) == true && Convert.ToBoolean(reader["cikti"])== false)
            {                
                iceride = true;                
                
            }
            else if (Convert.ToBoolean(reader["iceride"]) == true && Convert.ToBoolean(reader["cikti"]) == true)
            {
                iceride = false;                
            }
            
            conn.Close();
        }
    }
}