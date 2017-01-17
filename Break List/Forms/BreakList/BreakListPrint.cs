using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Break_List.Class;
using Break_List.Properties;
using DevExpress.XtraPrinting;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;

namespace Break_List.Forms.BreakList
{
    public partial class BreakListPrint : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DateTime Tarih { get; set; }
        
        
        public BreakListPrint()
        {
            InitializeComponent();
            gridView1.CustomDrawCell += gridView1_CustomDrawCell;
        }

        private void BreakListPrint_Load(object sender, EventArgs e)
        {
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

                        repositoryItemComboBox1.Items.Add(row["DepartmentName"]);

                    }

                    repositoryItemComboBox1.Sorted = true;


                }
            }

        }



        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.DisplayText == "/")
                e.Appearance.ForeColor = Color.DarkRed;
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "Personel")
            {
                if (e.DisplayText == "BREAK-/")
                    e.DisplayText = "/";
                var a = e.DisplayText;
                var str = a.Substring(a.IndexOf('-') + 1);
                e.DisplayText = str;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spPrintEskiBreakList;", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new MySqlParameter("ShiftDate", barEditItem1.EditValue));
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", barEditItem2.EditValue));
                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        var data2 = dt.AsEnumerable().Select(x => new {
                            Personel = x.Field<string>("Personel"),
                            Saat = x.Field<string>("Saat"),
                            Masa = x.Field<string>("Masa")
                        });

                        var pivotDataTable = data2.ToPivotTable(

                            item => item.Saat,
                            item => item.Personel,
                            items => items.Any() ? items.First().Masa : null);
                        gridControl1.DataSource = pivotDataTable;
                        gridView1.Columns["Personel"].Width = 150;
                    }

                }
                conn.Close();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            try
            {
                saveDialog.Filter = @"Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    var exportFilePath = saveDialog.FileName;
                    var fileExtenstion = new FileInfo(exportFilePath).Extension;
                    DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;

                    switch (fileExtenstion)
                    {

                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath, new XlsxExportOptions(TextExportMode.Text));
                            break;
                        case ".rtf":
                            gridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl1.ExportToMht(exportFilePath);
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            Process.Start(exportFilePath);
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
            finally
            {
                saveDialog.Dispose();
            }}
    }
    
}