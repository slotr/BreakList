﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Break_List
{
    public partial class rptMaasArtisi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptMaasArtisi()
        {
            InitializeComponent();
        }

        private void rptMaasArtisi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            spPrintPersonelMaaslariTableAdapter1.Fill(livegameDataSet11.spPrintPersonelMaaslari, Convert.ToString(Parameters["parameter1"].Value));
        }
    }
}
