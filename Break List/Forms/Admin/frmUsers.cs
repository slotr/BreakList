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
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using Break_List.Properties;
using MySql.Data.MySqlClient;

namespace Break_List
{
    public partial class frmUsers : DevExpress.XtraEditors.XtraForm
    {
        public string userID { get; set; }
        public frmUsers()
        {
            InitializeComponent();
           
        }

        
    

        private void frmUsers_Load(object sender, EventArgs e)
        {
            getDepartments();
        }

        private void permissionsBindingNavigatorSaveItem1_Click(object sender, EventArgs e)
        {
           

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

                        cmbDepartment.Properties.Items.Add(Row["DepartmentName"]);

                    }

                    cmbDepartment.Properties.Sorted = true;


                }
            }

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        public static void ClearSpace(Control control)
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
        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    saveStaff();
                    break;                
                case "Save And Close":
                    saveStaff();
                        Close();
                    break;
                case "Save And New":
                        ClearSpace(this);
                    break;

            }
        }
        
        void saveStaff()
        {


            var str = Settings.Default.livegameConnectionString2;
            var query = string.Format("select * from users where UserName = '{0}'",
                txtUserName.Text);
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
                
                MessageBox.Show( "Böyle bir Kullanıcı ismi daha önce kullanılmış", @"Bir Hata Oluştu.");
                

            }
            
            else 
            {
                try
                {
                    con.Close();
                    cmd = new MySqlCommand("INSERT INTO users(UserName, Department, FullName, Password) VALUES(@UserName, @Department, @FullName, @Password)", con);


                    cmd.Parameters.Add("@UserName", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@Department", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@FullName", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@Password", MySqlDbType.VarChar, 45);   
                    cmd.Parameters["@UserName"].Value = txtUserName.Text;
                    cmd.Parameters["@Department"].Value = cmbDepartment.EditValue.ToString();
                    cmd.Parameters["@FullName"].Value = txtFulName.Text;
                    cmd.Parameters["@Password"].Value = txtPassword.Text;
                    
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

        private void cmbDepartment_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void cmbDepartment_Properties_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                frmDepartments Departments = new frmDepartments();
                
                Departments.ShowDialog();
            }
        }
    }
}