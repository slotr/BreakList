using MySql.Data.MySqlClient;

namespace Break_List.Class
{
    internal static class DbConnection
    {
        private const string Server = "192.168.0.187";
        private const string Database = "livegame";
        private const string User = "hakan";
        private const string Password = "26091974";

        private const string Constring = "Server=" + Server + ";" + 
                                         "Database=" + Database + ";" + 
                                         "Uid=" + User + ";" + 
                                         "Password=" + Password + ";";
        public static readonly MySqlConnection Con = new MySqlConnection(Constring);
    }
}
