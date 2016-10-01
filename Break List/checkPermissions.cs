using Break_List.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Break_List
{
    class checkPermissions
    {
        
        public Boolean hasPermissionToUsers { get; set; }
        public string userID { get; set; }
       
    }
}
