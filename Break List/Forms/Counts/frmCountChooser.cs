using System;
using DevExpress.XtraEditors;

namespace Break_List.Forms.Counts
{
    public partial class FrmCountChooser : XtraForm
    {
        public FrmCountChooser()
        {
            InitializeComponent();
        }
        public bool Tip { get; set; }
        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (Tip)
            {
                var print = new FrmPrintCount
                {
                    Tip = true,
                    Tarih = dateEdit1.DateTime
                };

                print.ShowDialog();
                Hide();
            }
            else
            {
                var print = new FrmPrintCount
                {
                    Tip = false,
                    Tarih = dateEdit1.DateTime
                };

                print.ShowDialog();
                Hide();
            }
        }
    }
}