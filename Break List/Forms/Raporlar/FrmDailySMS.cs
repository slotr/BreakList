using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;

namespace Break_List.Forms.Raporlar
{
    public partial class FrmDailySms : XtraForm
    {
        public FrmDailySms()
        {
            InitializeComponent();
        }
        private readonly DataSet _ds = new DataSet();
        private double Lgdrop { get; set; }
        private double Lgresult { get; set; }
        private double Slresult { get; set; }
        public string UserName { get; set; }
        private OracleConnection Con { get; } = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
                                                                        (ADDRESS_LIST =
                                                                          (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.106)(PORT = 1521))
                                                                        )
                                                                        (CONNECT_DATA =
                                                                          (SERVICE_NAME = floor)
                                                                        )
                                                                      );PASSWORD=26091974;PERSIST SECURITY INFO=True;USER ID=HAKAN");

        private void QueryDatabase()
        {
            
            const string sql = @"SELECT
                                SUM(LG_DROP_CASH+ LG_DROP_PLAQUES) as LG_DROP,                                
                                SUM(LG_DROP_CASH + LG_DROP_PLAQUES - LG_CASH_OUT_CAGE) as LG_RESULT,
                                SUM(SL_BET - SL_CASH_OUT) as SL_RESULT                          
                                from casinocrm.v2_all_views
                                where GAMEDATE = :StartDate";

            
            
            var cmd = Con.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":StartDate", calendarControl1.DateTime);
                Con.Open();
                var reader = cmd.ExecuteReader();
                reader.Read();
                Lgdrop = Convert.ToDouble(reader["LG_DROP"].ToString());
                Lgresult = Convert.ToDouble(reader["LG_RESULT"].ToString());
                Slresult = Convert.ToDouble(reader["SL_RESULT"].ToString());
                //if (!reader.HasRows) return;
                //using (var dataAdapter = new OracleDataAdapter(cmd))
                //{
                //    _ds.Clear();
                //    dataAdapter.Fill(_ds, "sonuc");
                //    gridControl1.DataSource = _ds.Tables[0];

                //}
            }

            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
            }
            finally
            {
                Con.Close();

            }


        }

       

        private void QueryMajor()
        {

            const string sql = @"SELECT
                                CASINOCRM.V_ALL_PLAYERS.FIRST_NAME as NAME,
                                CASINOCRM.V_ALL_PLAYERS.LAST_NAME as SURNAME,
                                SUM(nvl(CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_CASH+ CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_PLAQUES,0)) as LG_DROP,
                                SUM(nvl(-(CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_CASH +CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_PLAQUES - CASINOCRM.V2_ALL_VEN_VIEWS.LG_CASH_OUT_CAGE),0)) as LG_RESULT,
                                SUM(nvl(-(CASINOCRM.V2_ALL_VEN_VIEWS.SL_BET - CASINOCRM.V2_ALL_VEN_VIEWS.SL_CASH_OUT),0)) as SL_RESULT
                                from CASINOCRM.V2_ALL_VEN_VIEWS
                                  LEFT JOIN CASINOCRM.V_ALL_PLAYERS ON CASINOCRM.V2_ALL_VEN_VIEWS.CUSTOMER_ID = CASINOCRM.V_ALL_PLAYERS.PLAYER_ID
                                where CASINOCRM.V2_ALL_VEN_VIEWS.GAMEDATE = :StartDate
                                      and CASINOCRM.V2_ALL_VEN_VIEWS.VENUE_ID = 1901
                                      and (
                                        (CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_CASH + CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_PLAQUES - CASINOCRM.V2_ALL_VEN_VIEWS.LG_CASH_OUT_CAGE) >= 10000
                                        OR
                                        (CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_CASH + CASINOCRM.V2_ALL_VEN_VIEWS.LG_DROP_PLAQUES - CASINOCRM.V2_ALL_VEN_VIEWS.LG_CASH_OUT_CAGE) <= -10000
                                        OR
                                        (CASINOCRM.V2_ALL_VEN_VIEWS.SL_BET - CASINOCRM.V2_ALL_VEN_VIEWS.SL_CASH_OUT >= 10000)
                                        OR
                                        (CASINOCRM.V2_ALL_VEN_VIEWS.SL_BET - CASINOCRM.V2_ALL_VEN_VIEWS.SL_CASH_OUT <= -10000)
                                      )
                                GROUP BY CASINOCRM.V_ALL_PLAYERS.FIRST_NAME,CASINOCRM.V_ALL_PLAYERS.LAST_NAME";



            var cmd = Con.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":StartDate", calendarControl1.DateTime);
                //cmd.Parameters.Add(":EndDate", dateEdit2.DateTime);


                Con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    using (var dataAdapter = new OracleDataAdapter(cmd))
                    {
                        _ds.Clear();
                        dataAdapter.Fill(_ds, "major");
                        gridControl1.DataSource = _ds.Tables[0];

                    }
                }
                else
                {
                    _ds.Clear();
                    MessageBox.Show(@"No Major Player Today");
                }
                
            }

            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
            }
            finally
            {
                Con.Close();
            }


        }
        private void EmailGonder()
        {
            var tarih = $"{calendarControl1.DateTime:dd/MM/yyyy}";
            var fromAddress = new MailAddress("hkcsmng@gmail.com", "Cyprus Daily Results");
            var toAddress = new MailAddress("rino@groupviva.com", "RC");
            const string fromPassword = "26091974-Emre!";
            var subject = "Cyprus Daily Results -" + tarih;
            var body = @"<html><body style=""color:#34495e"">" +richEditControl1.HtmlText + "</body></html>";
            var htmlView =
            AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                
                Subject = subject,
                AlternateViews = { htmlView },
                IsBodyHtml = true,
                Body = body,
                Priority = MailPriority.High,
                

            })
            {
                message.To.Add("ozcan@groupviva.com,coskund@groupviva.com,ramazank@groupviva.com,barisu@groupviva.com,mehmeti@groupviva.com,fazild@groupviva.com");
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), @"Mesaj Gönderilemedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }
        private void calendarControl1_DateTimeChanged(object sender, EventArgs e)
        {
            QueryDatabase();

            var tarih = $"{calendarControl1.DateTime:dd/MM/yyyy}";
            var drop = $"D :{Lgdrop:N0}";
            var result = $"LG :{Lgresult:N0}";
            var slot = $"SM :{Slresult:N0}";
            var total = Slresult+ Lgresult;
            var grandTotal = $"T : {total:N0}";
            const string major = "MC";

            
            

            if (richEditControl1.Text != null)
            {
                richEditControl1.Text = "";
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + tarih + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<br/>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + drop + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + result + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + slot + "</font></br>");

                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + grandTotal + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + "Att:" + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + major + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
            }
            else
            {
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + tarih + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<br/>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + drop + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + result + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + slot + "</font></br>");

                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + grandTotal + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + "Att:" + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + major + "</font></br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
                richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<hr>");
            }
            
            QueryMajor();
            gridView1.SelectAll();
            gridView1.CopyToClipboard();
            richEditControl1.Paste();
            richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
            richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" + "Best Regards"+ "</font></br>");
            richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "4" + ">" +UserName+ "</font></br>");
            richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "</br>");
            richEditControl1.Document.InsertHtmlText(richEditControl1.Document.CaretPosition, "<font size=" + "2" + ">" + "Note: This is an aoutomated email. Please don't reply this email directly." + "</font></br>");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            EmailGonder();}
    }
}