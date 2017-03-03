using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.Data.PivotGrid;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Rotalar
{
    public partial class FrmPrintRota : DevExpress.XtraEditors.XtraForm
    {
         public FrmPrintRota()
        {
            InitializeComponent();
            GetDepartments();
        }

        private void GetDepartments() // Yeni Kayit Olusturulurken Aliyor
        {

            var connectionString = Settings.Default.livegameConnectionString2;
            using (var cnn = new MySqlConnection(connectionString))
            using (var cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spDepartment";
                cmd.CommandType = CommandType.StoredProcedure;
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        comboBoxEdit1.Properties.Items.Add(row["DepartmentName"]);

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

        private void GetRota()
        {
            var connStr = Settings.Default.livegameConnectionString2;
            using (var conn = new MySqlConnection(connStr))
            {
                var cmd = new MySqlCommand() { Connection = conn, CommandText = "CALL spPrintRota(@rDepartmentName, @rStartDate, @rEndDate);" };
                cmd.Parameters.AddWithValue("@rDepartmentName", comboBoxEdit1.EditValue);
                cmd.Parameters.AddWithValue("@rStartDate", DtStart);
                cmd.Parameters.AddWithValue("@rEndDate", DtEnd);

                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    pivotGridControl1.DataSource = dt;
                    pivotGridControl1.Fields["Shift"].SummaryType = PivotSummaryType.Max;
                }
                
                conn.Open();
                
                cmd.ExecuteNonQuery();

                conn.Close();
            }

        }

        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = @"Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() == DialogResult.Cancel) return;
                var exportFilePath = saveDialog.FileName;
                var fileExtenstion = new FileInfo(exportFilePath).Extension;
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
                        var msg =
                            $"The file could not be opened.{Environment.NewLine}{Environment.NewLine}Path: {exportFilePath}";
                        MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var msg =
                        $"The file could not be saved.{Environment.NewLine}{Environment.NewLine}Path: {exportFilePath}";
                    MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DtStart = Convert.ToDateTime(dateEdit1.EditValue.ToString());
            DtEnd = Convert.ToDateTime(dateEdit2.EditValue.ToString());
            if (DtEnd < DtStart)
            {
                MessageBox.Show(@"Personel Bilgisi Update edildi");
            }

            else
            {
                GetRota();
            }
        }
    }
}