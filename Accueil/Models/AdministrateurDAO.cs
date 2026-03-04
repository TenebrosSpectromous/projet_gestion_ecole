using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accueil.Models
{
    internal class AdministrateurDAO
    {
        // Chaîne de connexion réutilisée dans toutes les méthodes
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public List<Administration> GetAll()
        {
            List<Administration> list = new List<Administration>();

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Administration";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Administration()
                        {
                            Id = rdr.GetInt32("id"),
                            Nom = rdr.GetString("nom"),
                            Prenom = rdr.GetString("prenom"),
                            Identifiant = rdr.GetString("identifiant"),
                            Mdp = rdr.GetString("mdp")
                        });
                    }
                }
            }

            return list;
        }

        public void Add(Administration e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // On insère les mêmes colonnes que celles lues dans GetAll : nom, prenom, identifiant, mdp
                string sql = "INSERT INTO Administration (nom, prenom, identifiant, mdp) VALUES (@n, @p, @ident, @mdp)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", e.Nom);
                cmd.Parameters.AddWithValue("@p", e.Prenom);
                cmd.Parameters.AddWithValue("@ident", e.Identifiant);
                cmd.Parameters.AddWithValue("@mdp", e.Mdp);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Administration WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
