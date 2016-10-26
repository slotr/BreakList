using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraPivotGrid;
using DevExpress.Data.PivotGrid;
using System.IO;

namespace Break_List
{
    public partial class frmPrintRota : DevExpress.XtraEditors.XtraForm
    {
        public string _departmentNameFromMainForm = "Live game";
        public DateTime _startDate = Convert.ToDateTime("2016-01-01");
        public DateTime _endDate = Convert.ToDateTime("2017-01-01");
        public frmPrintRota()
        {
            InitializeComponent();
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
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CALL spPrintRota(@rDepartmentName, @rStartDate, @rEndDate);";
                cmd.Parameters.AddWithValue("@rDepartmentName", _departmentNameFromMainForm);
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

        private void SetupPivot(PivotGridControl grid)
        {
            //DataTable Table = new DataTable();
            //Table.Columns.Add("Day", typeof(string));
            //Table.Columns.Add("Entry", typeof(string));
            //Table.Columns.Add("Employee", typeof(string));

            //Table.Rows.Add(new object[] { "Monday", "Gate A", "Johnny" });
            //Table.Rows.Add(new object[] { "Tuesday", "Gate B", "Mike" });
            //Table.Rows.Add(new object[] { "Monday", "Gate B", "Jack" });
            //Table.Rows.Add(new object[] { "Tuesday", "Gate A", "Nick" });

            //grid.DataSource = new BindingSource(Table, "");

            //grid.Fields.Add("Day", PivotArea.ColumnArea);
            //grid.Fields.Add("Entry", PivotArea.RowArea);
            //grid.Fields.Add("Employee", PivotArea.DataArea);
            //grid.Fields["Employee"].SummaryType = PivotSummaryType.Max;

            //grid.OptionsView.ShowColumnGrandTotals = false;
            //grid.OptionsView.ShowRowGrandTotals = false;
        }

        public DateTime dtStart { get; set; }
        public DateTime dtEnd { get; set; }
        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            dtStart = Convert.ToDateTime(dateEdit1.EditValue.ToString());
            dtEnd = Convert.ToDateTime(dateEdit2.EditValue.ToString());
            if (dtEnd < dtStart)
            {
                MessageBox.Show("End Date Can not be earlier date that Start Date");
                return;
            }

            else
            {
                getRota();
            }
        }

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
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}