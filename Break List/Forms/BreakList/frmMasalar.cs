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

namespace Break_List
{
    public partial class frmMasalar : DevExpress.XtraEditors.XtraForm
    {
        public frmMasalar()
        {
            InitializeComponent();
        }

        private void tablesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           

        }

        private void frmMasalar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.tables' table. You can move, or remove it, as needed.
            this.tablesTableAdapter.Fill(this.livegameDataSet1.tables);


        }

        private void tablesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tablesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.livegameDataSet1);

        }
    }
}