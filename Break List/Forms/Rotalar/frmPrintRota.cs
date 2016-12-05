using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.Data.PivotGrid;
using System.IO;

namespace Break_List
{
    public partial class frmPrintRota : DevExpress.XtraEditors.XtraForm
    {
         public frmPrintRota()
        {
            InitializeComponent();
            getDepartments();
        }
        void getDepartments() // Yeni Kayit Olusturulurken Aliyor
        {

            var connectionString = Settings.Default.livegameConnectionString2;
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spDepartment";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow Row in dt.Rows)
                    {

                        comboBoxEdit1.Properties.Items.Add(Row["DepartmentName"]);

                    }

                    comboBoxEdit1.Properties.Sorted = true;


                }
            }

        }
        private void frmPrintRota_Load(object sender, EventArgs e)
        {
            // getRota();
            pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
        }

        void getRota()
        {
            string connStr = Settings.Default.livegameConnectionString2;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand() { Connection = conn, CommandText = "CALL spPrintRota(@rDepartmentName, @rStartDate, @rEndDate);" };
                cmd.Parameters.AddWithValue("@rDepartmentName", comboBoxEdit1.EditValue);
                cmd.Parameters.AddWithValue("@rStartDate", dtStart);
                cmd.Parameters.AddWithValue("@rEndDate", dtEnd);

                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    pivotGridControl1.DataSource = dt;
                    pivotGridControl1.Fields["Shift"].SummaryType = PivotSummaryType.Max;
                }
                
                conn.Open();
                
                cmd.ExecuteNonQuery();
                
                conn.Clone();
            }

        }

        public DateTime dtStart { get; set; }
        public DateTime dtEnd { get; set; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            pivotGridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            pivotGridControl1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            pivotGridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            pivotGridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            pivotGridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            pivotGridControl1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = string.Format("The file could not be opened.{0}{1}Path: {2}", Environment.NewLine, Environment.NewLine, exportFilePath);
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = string.Format("The file could not be saved.{0}{1}Path: {2}", Environment.NewLine, Environment.NewLine, exportFilePath);
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtStart = Convert.ToDateTime(dateEdit1.EditValue.ToString());
            dtEnd = Convert.ToDateTime(dateEdit2.EditValue.ToString());
            if (dtEnd < dtStart)
            {
                MessageBox.Show(@"Personel Bilgisi Update edildi");
                return;
            }

            else
            {
                getRota();
            }
        }
    }
}