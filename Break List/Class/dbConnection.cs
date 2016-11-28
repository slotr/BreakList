using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using Break_List.Properties;

namespace Break_List.Class
{
    class dbConnection
    {
        private MySqlConnection con;
        public MySqlCommand cmd;
        public MySqlDataReader da;
        public DataTable dt;
        public DataSet ds;


        public void mysqlconnection()
        {


            string connectionstring = Settings.Default.livegameConnectionString2;
            con = new MySqlConnection(connectionstring);
            con.Open();
        }

        public void sqlquery(string quertext)
        {
            mysqlconnection();
            cmd = new MySqlCommand(quertext, con);
        }

        public void nonqueryex()
        {
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
