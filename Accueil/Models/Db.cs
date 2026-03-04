using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace Accueil
{
    public class Db
    {
        public void Connexion()
        {
            string cs = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
            var conn = new MySqlConnection(cs);
            conn.Open();
        }
    }
}
