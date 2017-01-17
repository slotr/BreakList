using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.OleDb;
using Break_List.Properties;
using DevExpress.XtraGrid.Columns;
using MySql.Data.MySqlClient;
namespace Break_List.Forms.TopPlayers
{
    public partial class FrmSlots : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmSlots()
        {
            InitializeComponent();
        }
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private readonly string sifre = "135642";
        private string Sifre2 { get; set; }
        private void btnDaily_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            const string header = "YES";
            string sheetName;

            var conStr = string.Empty;
            switch (extension)
            {

                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, header);
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel07ConString, filePath, header);
                    break;
            }
            try
            {
//Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        var dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }

                //Read Data from the First Sheet.
                using (var con = new OleDbConnection(conStr))
                {
                    using (var cmd = new OleDbCommand())
                    {
                        using (var oda = new OleDbDataAdapter())
                        {
                            var dt = new DataTable();
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            //Populate DataGridView.
                            gridControl1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Excel Dosya formatını 97-2003 olarak kaydederek deneyin.", @"Dosya Formatı");
            }
            
        }

        private void SaveGridToDatabase()
        {
            if (gridView1.RowCount > 0)
            {
                for (var i = 0; i <= gridView1.RowCount - 1; i++)
                {
                    var no = gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString();
                    var vendor = gridView1.GetRowCellValue(i, gridView1.Columns[1]).ToString();
                    var cabinet = gridView1.GetRowCellValue(i, gridView1.Columns[2]).ToString();
                    var software = gridView1.GetRowCellValue(i, gridView1.Columns[3]).ToString();
                    var denom = gridView1.GetRowCellValue(i, gridView1.Columns[4]).ToString();
                    var basicsum = gridView1.GetRowCellValue(i, gridView1.Columns[5]).ToString();
                    var bill = gridView1.GetRowCellValue(i, gridView1.Columns[6]).ToString();
                    var turnover = gridView1.GetRowCellValue(i, gridView1.Columns[7]).ToString();
                    var totalwin = gridView1.GetRowCellValue(i, gridView1.Columns[8]).ToString();
                    var games = gridView1.GetRowCellValue(i, gridView1.Columns[9]).ToString();
                    var avgbet = gridView1.GetRowCellValue(i, gridView1.Columns[10]).ToString();
                    var date = gridView1.GetRowCellValue(i, gridView1.Columns[11]).ToString();
                    var daysworked = gridView1.GetRowCellValue(i, gridView1.Columns[12]).ToString();
                    var rate = gridView1.GetRowCellValue(i, gridView1.Columns[13]).ToString();

                    using (var con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        const string insert =
                            @"INSERT INTO tblslotresults(no, vendor,cabinet,software,denom,basicsum,bill,turnover,totalwin,games,avgbet,date,daysworked,rate) 
                            VALUES (@no, @vendor,@cabinet,@software,@denom,@basicsum,@bill,@turnover,@totalwin,@games,@avgbet,@date,@daysworked,@rate)";
                        con.Open();
                        var cmd = new MySqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@no", no);
                        cmd.Parameters.AddWithValue("@vendor", vendor);
                        cmd.Parameters.AddWithValue("@cabinet", cabinet);
                        cmd.Parameters.AddWithValue("@software", software);
                        cmd.Parameters.AddWithValue("@denom", Convert.ToDecimal(denom));
                        cmd.Parameters.AddWithValue("@basicsum", Convert.ToDecimal(basicsum));
                        cmd.Parameters.AddWithValue("@bill", Convert.ToDecimal(bill));
                        cmd.Parameters.AddWithValue("@turnover", Convert.ToDecimal(turnover));
                        cmd.Parameters.AddWithValue("@totalwin", Convert.ToDecimal(totalwin));
                        cmd.Parameters.AddWithValue("@games", Convert.ToDecimal(games));
                        cmd.Parameters.AddWithValue("@avgbet", Convert.ToDecimal(avgbet));
                        cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
                        cmd.Parameters.AddWithValue("@daysworked", daysworked);
                        cmd.Parameters.AddWithValue("@rate", rate);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private void btnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sifre == Sifre2)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                flyoutPanel1.ShowPopup();
            }
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            SaveGridToDatabase();
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splashScreenManager1.CloseWaitForm();
            gridControl1.DataSource = null;
            gridControl1.Refresh();
            flyoutPanel1.HidePopup();
        }

        private void btnSıfre_Click(object sender, EventArgs e)
        {
            Sifre2 = textEdit1.Text;
            if (sifre == Sifre2)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                XtraMessageBox.Show("Şifre Yanlış", "İzinsiz İşlem");
                textEdit1.Text = "";
                flyoutPanel1.HidePopup();
            }

        }
    }
}