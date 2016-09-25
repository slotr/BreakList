﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using MySql.Data.MySqlClient;

namespace Break_List
{
    public partial class frmExport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmExport()
        {
            InitializeComponent();           

            
        }



        
        private void btnGoster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime StartDate = Convert.ToDateTime(calStart1.EditValue);
            DateTime EndDate = Convert.ToDateTime(calEnd.EditValue);
            string query = @"SELECT Appointments.Subject, 
                            Appointments.Location, Appointments.StartDate, 
                            Appointments.EndDate, Resources.ResourceName FROM Appointments 
                            INNER JOIN Resources ON Appointments.ResourceID = Resources.ResourceID 
                            WHERE(Appointments.StartDate BETWEEN StartDate AND EndDate)";
            using (var conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            using (var command = new MySqlCommand(query, conn)
            {
                CommandType = CommandType.Text

            })
            {
                conn.Open();
                command.Parameters.AddWithValue("StartDate", StartDate);
                command.Parameters.AddWithValue("EndDate", EndDate);
                command.ExecuteNonQuery();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = command;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;


                    }
                }


            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath);
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

        private void frmExport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.spResources1' table. You can move, or remove it, as needed.
            this.spResources1TableAdapter.Fill(this.livegameDataSet1.spResources1);

        }
    }
}