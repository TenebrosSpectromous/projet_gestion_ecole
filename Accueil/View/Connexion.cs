using System;
using System.Data.SqlClient;

using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Accueil
{
    public partial class Connexion : Form
    {
        private const string connectionString = "Server=localhost;Database=projet_ges_ecole;Uid=root;Pwd=;";

        public Connexion()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void btn_enreg_Click(object sender, EventArgs e)
        {
            string id = print_identifiant.Text.Trim();
            string mdp = print_mdp.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(mdp))
            {
                MessageBox.Show("Veuillez entrer l'identifiant et le mot de passe.");
                return;
            }

            // On récupère aussi l'id de l'utilisateur connecté
            string query = @"
SELECT Role, IdUtilisateur
FROM (
    SELECT 'ADMIN' AS Role, id AS IdUtilisateur FROM administration WHERE identifiant = @identifiant AND mdp = @motdepasse
    UNION ALL
    SELECT 'PROF'  AS Role, id AS IdUtilisateur FROM professeur      WHERE identifiant = @identifiant AND mdp = @motdepasse
    UNION ALL
    SELECT 'ELEVE' AS Role, id AS IdUtilisateur FROM etudiant        WHERE identifiant = @identifiant AND mdp = @motdepasse
) roles
LIMIT 1;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@identifiant", id);
                    command.Parameters.AddWithValue("@motdepasse", mdp);

                    try
                    {
                        connection.Open();
                        using (MySqlDataReader rdr = command.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                string role = rdr["Role"].ToString().ToUpper();
                                int idUtilisateur = Convert.ToInt32(rdr["IdUtilisateur"]);

                                Form nextForm = null;
                                switch (role)
                                {
                                    case "ADMIN":
                                        nextForm = new AdminForm();
                                        break;
                                    case "PROF":
                                        nextForm = new ProfForm(idUtilisateur);
                                        break;
                                    case "ELEVE":
                                        nextForm = new EleveForm(idUtilisateur); // ← on passe l'id
                                        break;
                                    default:
                                        MessageBox.Show("Rôle non reconnu.");
                                        return;
                                }

                                nextForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Identifiant ou mot de passe incorrect !");
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erreur MySQL : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur inattendue : " + ex.Message);
                    }
                }
            }
        }
    }
}