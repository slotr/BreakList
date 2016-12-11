using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar.Keyboard;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Counts
{
    public partial class frmTipAdd : XtraForm
    {
        public int rowID;
        public frmTipAdd()
        {
            InitializeComponent();
            textEdit1.Focus();
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            keyboardControl1.Invalidate();
        }
        private Keyboard CreateNumericKeyboard()
        {
            var keyboard = new Keyboard();

            var klNumLockOn = new LinearKeyboardLayout();


            klNumLockOn.AddKey("7");
            klNumLockOn.AddKey("8");
            klNumLockOn.AddKey("9");
            klNumLockOn.AddKey("Backspace", "{BACKSPACE}", height: 21);

            klNumLockOn.AddLine();

            klNumLockOn.AddKey("4");
            klNumLockOn.AddKey("5");
            klNumLockOn.AddKey("6");
            klNumLockOn.AddLine();

            klNumLockOn.AddKey("1");
            klNumLockOn.AddKey("2");
            klNumLockOn.AddKey("3");

            klNumLockOn.AddKey("OK", "{ENTER}", style: KeyStyle.Light, height: 21);
            klNumLockOn.AddLine();

            klNumLockOn.AddKey("0", width: 32);
            //klNumLockOn.AddKey(".");


            keyboard.Layouts.Add(klNumLockOn);


            return keyboard;
        } //Keyboard Ends

        private void frmTipAdd_Load(object sender, EventArgs e)
        {
            textEdit1.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spInsertUpdateTip;", conn)
                    { CommandType = CommandType.StoredProcedure };
                    
                    cmd.Parameters.Add(new MySqlParameter("tip", textEdit1.Text));
                    cmd.Parameters.Add(new MySqlParameter("rowid", rowID));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                simpleButton1.PerformClick();
            }
        }
    }
}