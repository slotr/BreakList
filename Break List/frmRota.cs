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
using System.Data.SqlClient;
using Break_List.Properties;

namespace Break_List
{

    public partial class frmRota : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmRota()
        {
            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            DateTime tuesday = sunday.AddDays(2);
            DateTime wednesday = sunday.AddDays(3);
            DateTime thursday = sunday.AddDays(4);
            DateTime friday = sunday.AddDays(5);
            DateTime saturday = sunday.AddDays(6);

            string Sunday = String.Format("{0:ddd}\n{0:MMM d/ yyyy}", sunday);
            string Monday = String.Format("{0:ddd}\n{0:MMM d/ yyyy}", monday);
            string Tuesday = String.Format("{0:ddd}\n{0:MMM d/ yyyy}", tuesday);
            string Wednesday = String.Format("{0:ddd}\n{0:MMM d/ yyyy}", wednesday);
            string Thursday = String.Format("{0:ddd}\n{0:MMM d/ yyyy}", thursday);
            string Friday = String.Format("{0:ddd}\n{0:MMM d/ yyyy}", friday);
            string Saturday = String.Format("{0:ddd}\n{0:MMM d/ yyyy}", saturday);



            InitializeComponent();
            gridView1.Columns[2].Caption = Monday;
            gridView1.Columns[3].Caption = Tuesday;
            gridView1.Columns[4].Caption = Wednesday;
            gridView1.Columns[5].Caption = Thursday;
            gridView1.Columns[6].Caption = Friday;
            gridView1.Columns[7].Caption = Saturday;
            gridView1.Columns[8].Caption = Sunday;

            // This line of code is generated by Data Source Configuration Wizard
            
        }

        private void frmRota_Load(object sender, EventArgs e)
        {

            resourcesTableAdapter1.Fill(livegameDataSet11.resources);

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult result = XtraMessageBox.Show("Yapılan Değişiklikler kayıt edilsin mi?", "Konfirmasyon", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Validate();
                bindingSource1.EndEdit();
                resourcesTableAdapter1.Update(livegameDataSet11);
                
            }
            else if (result == DialogResult.No)
            {

            }
            
        }

        private void frmRota_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void btnYeniRota_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        //private void SaveGridDataToDatabase()
        //{
        //    string Monday = gridView1.Columns[2].Caption.ToString();
        //    try
        //    {
        //        if (gridView1.RowCount > 0)
        //        {
        //            for (var i = 0; i <= gridView1.RowCount - 1; i++)
        //            {
        //                //string col1 = gridView1.GetRowCellValue(i, "Musteri").ToString();
        //                var personel = gridView1.GetRowCellValue(i, "Personel").ToString();
        //                var monday = gridView1.GetRowCellValue(i, Monday).ToString();


        //                using (var con = new SqlConnection(Settings.Default.LiveGameConnectionString))
        //                {
        //                    const string insert =
        //                        "INSERT INTO Rotalar(Siparis_ID, Musteri,Tarih,Siparis,Adet) VALUES (@Siparis_ID,@Musteri,@Tarih,@Siparis,@Adet)";
        //                    con.Open();
        //                    var cmd = new SqlCommand(insert, con);
        //                    cmd.Parameters.AddWithValue("@Siparis_ID", OrderId);
        //                    cmd.Parameters.AddWithValue("@Musteri", Musteri);
        //                    cmd.Parameters.AddWithValue("@Tarih", Convert.ToDateTime(col2));
        //                    cmd.Parameters.AddWithValue("@Siparis", col3);
        //                    cmd.Parameters.AddWithValue("@Adet", col4);
        //                    cmd.ExecuteNonQuery();
        //                    con.Close();
        //                }
        //            }
        //        }
        //        using (var con = new SqlConnection(Settings.Default.UrunlerString))
        //        {
        //            const string insert =
        //                "INSERT INTO SiparisAciklama(OrderID, SiparisNotu) VALUES (@OrderID,@SiparisNotu)";
        //            con.Open();
        //            var cmd = new SqlCommand(insert, con);
        //            cmd.Parameters.AddWithValue("@OrderID", OrderId);
        //            cmd.Parameters.AddWithValue("@SiparisNotu", SiparisNotu);

        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        var message = ex.Message;
        //        MessageBox.Show(message);
        //    }
        //}
    }
}