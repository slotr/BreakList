using System;
using System.Data;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Admin
{
    public partial class FrmUsers : XtraForm
    {
        public string UserId { get; set; }
        public FrmUsers()
        {
            InitializeComponent();
           
        }


        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        private void frmUsers_Load(object sender, EventArgs e)
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
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        cmbDepartment.Properties.Items.Add(row["DepartmentName"]);

                    }

                    cmbDepartment.Properties.Sorted = true;


                }
            }

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextEdit;
                var comboBox = c as ComboBoxEdit;
                var picturebox = c as PictureBox;
                if (textBox != null)
                    (textBox).Text = "";

                if (comboBox != null)
                    comboBox.SelectedIndex = -1;
                if (picturebox != null)
                    picturebox.Image = null;

                if (c.HasChildren)
                    ClearSpace(c);
            }
        }
        private void windowsUIButtonPanelMain_ButtonClick(object sender, ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    SaveStaff();
                    break;                
                case "Save And Close":
                    SaveStaff();
                        Close();
                    break;
                case "Save And New":
                        ClearSpace(this);
                    break;

            }
        }
        
        void SaveStaff()
        {


            var str = Settings.Default.livegameConnectionString2;
            var query = $"select * from users where UserName = '{txtUserName.Text}'";
            var con = new MySqlConnection(str);
            var cmd = new MySqlCommand(query, con);
            con.Open();
            var dbr = cmd.ExecuteReader();
            var count = 0;
            while (dbr != null && dbr.Read())
            {

                count = count + 1;
            }
            if (count == 1)
            {
                
                MessageBox.Show( @"Böyle bir Kullanıcı ismi daha önce kullanılmış", @"Bir Hata Oluştu.");
                

            }
            
            else 
            {
                try
                {
                    con.Close();
                    cmd = new MySqlCommand("INSERT INTO users(UserName, Department, FullName, Password,email) VALUES(@UserName, @Department, @FullName, @Password,@email)", con);


                    cmd.Parameters.Add("@UserName", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@Department", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@FullName", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@Password", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar, 200);
                    cmd.Parameters["@UserName"].Value = txtUserName.Text;
                    cmd.Parameters["@Department"].Value = cmbDepartment.EditValue.ToString();
                    cmd.Parameters["@FullName"].Value = txtFulName.Text;
                    cmd.Parameters["@Password"].Value = txtPassword.Text; //Base64Encode(txtPassword.Text);
                    cmd.Parameters["@email"].Value = txtemail.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show( ex.ToString(), @"Bir Hata Oluştu.");
                }
            }



           
        }

        private void cmbDepartment_Properties_ButtonClick_1(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind != ButtonPredefines.Plus) return;
            var departments = new FrmDepartments();
                
            departments.ShowDialog();
        }
    }
}