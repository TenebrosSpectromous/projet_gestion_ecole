using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace Accueil
{
    public partial class AdminForm : Form
    {
        private readonly string connString = "Server=localhost;Database=projet_ges_ecole;Uid=root;Pwd=;";

        public AdminForm()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            ChargerEtudiants();
            ChargerProfesseurs(); // ← ajouté
            ChargerAbsences();    // ← ajouté
        }

        // ───────────────────────────────────────────
        // CHARGEMENT DES LISTES
        // ───────────────────────────────────────────

        private void ChargerEtudiants()
        {
            gerer_etudiant.Items.Clear();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT id, nom, prenom, identifiant FROM etudiant ORDER BY nom, prenom";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string display = $"{rdr["prenom"]} {rdr["nom"]} ({rdr["identifiant"]})";
                        gerer_etudiant.Items.Add(display);
                    }
                }
            }
        }

        private void ChargerProfesseurs()
        {
            gerer_profs.Items.Clear();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT id, nom, prenom, identifiant FROM professeur ORDER BY nom, prenom";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string display = $"{rdr["prenom"]} {rdr["nom"]} ({rdr["identifiant"]})";
                        gerer_profs.Items.Add(display);
                    }
                }
            }
        }

        private void ChargerAbsences()
        {
            gerer_absence.Items.Clear();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = @"
            SELECT a.id, p.nom, p.prenom, a.Motif, a.DateDebut, a.DateFin
            FROM absences_professeurs a
            JOIN professeur p ON a.idProfesseur = p.id
            ORDER BY a.DateDebut DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string dateDebut = Convert.ToDateTime(rdr["DateDebut"]).ToString("yyyy-MM-dd");
                        string dateFin = Convert.ToDateTime(rdr["DateFin"]).ToString("yyyy-MM-dd");
                        string display = $"{rdr["prenom"]} {rdr["nom"]} — {rdr["Motif"]} (du {dateDebut} au {dateFin})";
                        gerer_absence.Items.Add(display);
                    }
                }
            }
        }



        // ───────────────────────────────────────────
        // EVENTS LISTBOX
        // ───────────────────────────────────────────

        private void gerer_etudiant_SelectedIndexChanged(object sender, EventArgs e) { }
        private void gerer_profs_SelectedIndexChanged(object sender, EventArgs e) { }
        private void gerer_absence_SelectedIndexChanged(object sender, EventArgs e) { }

        // ───────────────────────────────────────────
        // AJOUT ÉTUDIANT
        // ───────────────────────────────────────────

        private void btn_ajt_etd_Click(object sender, EventArgs e)
        {
            string nom = Interaction.InputBox("Nom de l'étudiant :", "Ajouter un étudiant", "");
            if (string.IsNullOrWhiteSpace(nom)) return;

            string prenom = Interaction.InputBox("Prénom de l'étudiant :", "Ajouter un étudiant", "");
            if (string.IsNullOrWhiteSpace(prenom)) return;

            string identifiant = Interaction.InputBox("Identifiant de connexion :", "Ajouter un étudiant", "");
            if (string.IsNullOrWhiteSpace(identifiant)) return;

            string mdp = Interaction.InputBox("Mot de passe :", "Ajouter un étudiant", "");
            if (string.IsNullOrWhiteSpace(mdp)) return;

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "INSERT INTO etudiant (nom, prenom, identifiant, mdp) VALUES (@nom, @prenom, @identifiant, @mdp)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
                    cmd.Parameters.AddWithValue("@identifiant", identifiant);
                    cmd.Parameters.AddWithValue("@mdp", mdp);
                    cmd.ExecuteNonQuery();
                }
            }

            ChargerEtudiants();
            MessageBox.Show("Étudiant ajouté avec succès !");
        }

        // ───────────────────────────────────────────
        // AJOUT PROFESSEUR
        // ───────────────────────────────────────────

        private void btn_ajt_profs_Click(object sender, EventArgs e)
        {
            string nom = Interaction.InputBox("Nom du professeur :", "Ajouter un professeur", "");
            if (string.IsNullOrEmpty(nom)) return;

            string prenom = Interaction.InputBox("Prénom du professeur :", "Ajouter un professeur", "");
            if (string.IsNullOrEmpty(prenom)) return;

            string identifiant = Interaction.InputBox("Identifiant de connexion :", "Ajouter un professeur", "");
            if (string.IsNullOrEmpty(identifiant)) return;

            string mdp = Interaction.InputBox("Mot de passe :", "Ajouter un professeur", "");
            if (string.IsNullOrEmpty(mdp)) return;

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "INSERT INTO professeur (nom, prenom, identifiant, mdp) VALUES (@nom, @prenom, @identifiant, @mdp)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
                    cmd.Parameters.AddWithValue("@identifiant", identifiant);
                    cmd.Parameters.AddWithValue("@mdp", mdp);
                    cmd.ExecuteNonQuery();
                }
            }

            ChargerProfesseurs();
            MessageBox.Show("Professeur ajouté avec succès !");
        }

        // ───────────────────────────────────────────
        // AJOUT ABSENCE PROFESSEUR
        // ───────────────────────────────────────────

        private void btn_ajt_abs_Click(object sender, EventArgs e)
        {
            string nom = Interaction.InputBox("Nom du professeur :", "Ajouter une absence", "");
            if (string.IsNullOrEmpty(nom)) return;
            string prenom = Interaction.InputBox("Prénom du professeur :", "Ajouter une absence", "");
            if (string.IsNullOrEmpty(prenom)) return;
            string motif = Interaction.InputBox("Motif de l'absence :", "Ajouter une absence", "");
            if (string.IsNullOrEmpty(motif)) return;
            string dateDebutStr = Interaction.InputBox("Date début (YYYY-MM-DD) :", "Ajouter une absence", DateTime.Now.ToString("yyyy-MM-dd"));
            if (string.IsNullOrEmpty(dateDebutStr)) return;
            string dateFinStr = Interaction.InputBox("Date fin (YYYY-MM-DD) :", "Ajouter une absence", DateTime.Now.ToString("yyyy-MM-dd"));
            if (string.IsNullOrEmpty(dateFinStr)) return;

            if (!DateTime.TryParse(dateDebutStr, out DateTime dateDebut) || !DateTime.TryParse(dateFinStr, out DateTime dateFin))
            {
                MessageBox.Show("Date invalide.");
                return;
            }

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                // 1. Chercher l'idProfesseur via nom + prénom
                string sqlSelect = "SELECT id FROM professeur WHERE Nom = @nom AND Prenom = @prenom";
                int idProfesseur;
                using (MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn))
                {
                    cmdSelect.Parameters.AddWithValue("@nom", nom);
                    cmdSelect.Parameters.AddWithValue("@prenom", prenom);
                    object result = cmdSelect.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Professeur introuvable. Vérifiez le nom et prénom.");
                        return;
                    }
                    idProfesseur = Convert.ToInt32(result);
                }
                // 2. Insérer l'absence
                string sqlInsert = "INSERT INTO absences_professeurs (idProfesseur, DateDebut, DateFin, Motif) VALUES (@idProfesseur, @dateDebut, @dateFin, @motif)";
                using (MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@idProfesseur", idProfesseur);
                    cmdInsert.Parameters.AddWithValue("@dateDebut", dateDebut.ToString("yyyy-MM-dd"));
                    cmdInsert.Parameters.AddWithValue("@dateFin", dateFin.ToString("yyyy-MM-dd"));
                    cmdInsert.Parameters.AddWithValue("@motif", motif);
                    cmdInsert.ExecuteNonQuery();
                }
            }
            ChargerAbsences();
            MessageBox.Show("Absence ajoutée avec succès !");
        }
    }
}