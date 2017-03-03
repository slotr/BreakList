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

namespace Break_List.Forms.Personel
{
    public partial class FrmPersonelVacations : DevExpress.XtraEditors.XtraForm
    {
        public FrmPersonelVacations()
        {
            InitializeComponent();
        }

        private void FrmPersonelVacations_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.sp_Butun_Personel_vacation' table. You can move, or remove it, as needed.
            this.sp_Butun_Personel_vacationTableAdapter.Fill(this.livegameDataSet1.sp_Butun_Personel_vacation);

        }
    }
}