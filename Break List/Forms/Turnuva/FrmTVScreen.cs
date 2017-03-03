using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Class;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmTvScreen : XtraForm
    {
       
        public FrmTvScreen()
        {
            InitializeComponent();
            
        }
       

        public string TurnuvaAdi { get; set; }
        public string TurnuvaId { get; set; }
        
        private string _o1;
        private string _o2;
        private string _o3;
        private string _o4;
        private string _o5;
        private string _o6;
        private string _o7;
        private string _o8;
        private string _o9;
        private string _o10;
        private string _o11;
        private string _o12;
        private string _o13;
        private string _o14;
        private string _o15;

        private void GetClassification()
        {
            var dtTable = new DataTable();
            using (var cnn = DbConnection.Con)
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_scoreBoard";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", TurnuvaId));
                
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dtTable);
                    gridControl1.DataSource = dtTable;
                }
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }


          
        }
        private void SetFocusedAppearance(bool isFocused)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = isFocused;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = isFocused;
        }
        private void GetOdul()
        {
           
          

            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("spTurnuva_oduller;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", TurnuvaId));
                conn.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    if (true)
                    {
                        _o1 = dbr["o1"].ToString();
                        _o2 = dbr["o2"].ToString();
                        _o3 = dbr["o3"].ToString();
                        _o4 = dbr["o4"].ToString();
                        _o5 = dbr["o5"].ToString();
                        _o6 = dbr["o6"].ToString();
                        _o7 = dbr["o7"].ToString();
                        _o8 = dbr["o8"].ToString();
                        _o9 = dbr["o9"].ToString();
                        _o10 = dbr["o10"].ToString();
                        _o11 = dbr["o11"].ToString();
                        _o12 = dbr["o12"].ToString();
                        _o13 = dbr["o13"].ToString();
                        _o14 = dbr["o14"].ToString();
                        _o15 = dbr["o15"].ToString();
                    }
                }
                conn.Close();
            }
        }

        
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            GetClassification();
        }

        
        private void FrmTVScreen_Load(object sender, EventArgs e)
        {
            GetOdul();
            GetClassification();
            SetFocusedAppearance(false);
            timer2.Interval = 10000;//10 saniye

            timer2.Tick += (timer1_Tick);
            timer2.Start();
           
        }

      

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            labelControl1.Text = TurnuvaAdi;
        }

        private void panelControl1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridControl1_Enter(object sender, EventArgs e)
        {
            SetFocusedAppearance(false);
        }

        private void gridControl1_Leave(object sender, EventArgs e)
        {
            SetFocusedAppearance(false);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void FrmTvScreen_Shown(object sender, EventArgs e)
        {
            
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "colSiralama")
            {
                switch (e.ListSourceRowIndex)
                {
                    case 0:
                        e.DisplayText = "1";
                        break;
                    case 1:
                        e.DisplayText = "2";
                        break;
                    case 2:
                        e.DisplayText = "3";
                        break;
                    case 3:
                        e.DisplayText = "4";
                        break;
                    case 4:
                        e.DisplayText = "5";
                        break;
                    case 5:
                        e.DisplayText = "6";
                        break;
                    case 6:
                        e.DisplayText = "7";
                        break;
                    case 7:
                        e.DisplayText = "8";
                        break;
                    case 8:
                        e.DisplayText = "9";
                        break;
                    case 9:
                        e.DisplayText = "10";
                        break;
                    case 10:
                        e.DisplayText = "11";
                        break;
                    case 11:
                        e.DisplayText = "12";
                        break;
                    case 12:
                        e.DisplayText = "13";
                        break;
                    case 13:
                        e.DisplayText = "14";
                        break;
                    case 14:
                        e.DisplayText = "15";
                        break;

                }
               
            }
            if (e.Column.FieldName == "colOdul")
            {
                switch (e.ListSourceRowIndex)
                {
                    case 0:
                        e.DisplayText = _o1;
                        break;
                    case 1:
                        e.DisplayText = _o2;
                        break;
                    case 2:
                        e.DisplayText = _o3;
                        break;
                    case 3:
                        e.DisplayText = _o4;
                        break;
                    case 4:
                        e.DisplayText = _o5;
                        break;
                    case 5:
                        e.DisplayText = _o6;
                        break;
                    case 6:
                        e.DisplayText = _o7;
                        break;
                    case 7:
                        e.DisplayText = _o8;
                        break;
                    case 8:
                        e.DisplayText = _o9;
                        break;
                    case 9:
                        e.DisplayText = _o10;
                        break;
                    case 10:
                        e.DisplayText = _o11;
                        break;
                    case 11:
                        e.DisplayText = _o12;
                        break;
                    case 12:
                        e.DisplayText = _o13;
                        break;
                    case 13:
                        e.DisplayText = _o14;
                        break;
                    case 14:
                        e.DisplayText = _o15;
                        break;

                }

            }
        }
    }
}