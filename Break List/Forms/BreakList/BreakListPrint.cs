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
using System.Linq.Expressions;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace Break_List.Forms.BreakList
{
    public partial class BreakListPrint : XtraForm
    {
        public DateTime Tarih { get; set; }
        
        
        public BreakListPrint()
        {
            InitializeComponent();
            gridView1.CustomDrawCell += gridView1_CustomDrawCell;
        }

        private void BreakListPrint_Load(object sender, EventArgs e)
        {
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


        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            
            using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("spPrintEskiBreakList;", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.Add(new MySqlParameter("ShiftDate", dateEdit1.EditValue));
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", comboBoxEdit1.EditValue));
                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);  
                        var data2 = dt.AsEnumerable().Select(x => new {                           
                            Personel = x.Field<String>("Personel"),
                            Saat = x.Field<String>("Saat"),
                            Masa = x.Field<String>("Masa")
                        });

                        DataTable pivotDataTable = data2.ToPivotTable(
                            
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            var saveDialog = new SaveFileDialog();
            try
            {
                saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
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
                        default:
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
                            var msg = string.Format("The file could not be opened.{0}{1}Path: {2}", Environment.NewLine, Environment.NewLine, exportFilePath);
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        var msg = string.Format("The file could not be saved.{0}{1}Path: {2}", Environment.NewLine, Environment.NewLine, exportFilePath);
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                if (saveDialog != null)
                    saveDialog.Dispose();
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
                string A = e.DisplayText;
                string str = A.Substring(A.IndexOf('-') + 1);
                e.DisplayText = str;
            }
        }
    }
    
}