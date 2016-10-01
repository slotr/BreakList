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
    public partial class frmPositions : DevExpress.XtraEditors.XtraForm
    {
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        public frmPositions()
        {
            InitializeComponent();
            getDepartments();
           
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

                        comboBoxEdit1.Properties.Items.Add(Row["DepartmentName"]);

                    }

                    comboBoxEdit1.Properties.Sorted = true;


                }
            }

        }

        void InsertPosition()
        {
            con.Open();
            cmd = new MySqlCommand("INSERT INTO positions(DepartmentName, PositionName) VALUES(@DepartmentName, @PositionName)", con);
            cmd.Parameters.Add("@DepartmentName", MySqlDbType.VarChar, 45);
            cmd.Parameters.Add("@PositionName", MySqlDbType.VarChar, 45);
            cmd.Parameters["@DepartmentName"].Value = comboBoxEdit1.EditValue.ToString();
            cmd.Parameters["@PositionName"].Value = textEdit1.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    InsertPosition();
                    break;
                case "Save And Close":
                    InsertPosition();
                    Close();
                    break;
                case "Save And New":
                    InsertPosition();
                    txtPosition.Text = "";
                    break;
            }
        }
    }
}