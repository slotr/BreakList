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
using DevExpress.XtraScheduler;

namespace Break_List.Forms.Personel
{
    public partial class frmCalismaIzinleri : DevExpress.XtraEditors.XtraForm
    {
        public frmCalismaIzinleri()
        {
            InitializeComponent();
        }

        private void frmCalismaIzinleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.spCalismaIzinTakibi' table. You can move, or remove it, as needed.
            this.spCalismaIzinTakibiTableAdapter.Fill(this.livegameDataSet1.spCalismaIzinTakibi);
            
        }
    }
    
}