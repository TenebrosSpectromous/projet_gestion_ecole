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
    public partial class ProfForm : Form
    {
        private readonly string connString = "Server=localhost;Database=projet_ges_ecole;Uid=root;Pwd=;";
        private readonly int _idProfesseur;
        private int _idMatiere;

        public ProfForm(int idProfesseur)
        {
            InitializeComponent();
            Theme.Apply(this);
            _idProfesseur = idProfesseur;
            ChargerMatiere();
            ChargerNotes();
            ChargerAbsencesEleves();
            ChargerEmploiDuTempsProf();
        }

        private void ProfForm_Load(object sender, EventArgs e) { }

        // ───────────────────────────────────────────
        // CHARGEMENT
        // ───────────────────────────────────────────

        private void ChargerMatiere()
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT idMatiere FROM professeur WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _idProfesseur);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        _idMatiere = Convert.ToInt32(result);
                }
            }
        }

        private void ChargerNotes()
        {
            gerer_note.Items.Clear();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = @"
                    SELECT e.nom, e.prenom, m.Libelle, n.Note, n.Coefficient, n.DateEval
                    FROM note n
                    JOIN etudiant e ON n.idEtudiant = e.id
                    JOIN matiere m ON n.idMatiere = m.id
                    WHERE n.idProfesseur = @id
                    ORDER BY n.DateEval DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _idProfesseur);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string date = Convert.ToDateTime(rdr["DateEval"]).ToString("yyyy-MM-dd");
                            string display = $"{rdr["prenom"]} {rdr["nom"]} — {rdr["Libelle"]} — {rdr["Note"]}/20 (coef. {rdr["Coefficient"]}) — {date}";
                            gerer_note.Items.Add(display);
                        }
                    }
                }
            }
        }

        private void ChargerAbsencesEleves()
        {
            gerer_absence_eleve.Items.Clear();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = @"
                    SELECT e.nom, e.prenom, a.Motif, a.DateAbsence
                    FROM absence a
                    JOIN etudiant e ON a.idEtudiant = e.id
                    WHERE a.idProfesseur = @id
                    ORDER BY a.DateAbsence DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _idProfesseur);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string date = Convert.ToDateTime(rdr["DateAbsence"]).ToString("yyyy-MM-dd");
                            string display = $"{rdr["prenom"]} {rdr["nom"]} — {rdr["Motif"]} ({date})";
                            gerer_absence_eleve.Items.Add(display);
                        }
                    }
                }
            }
        }

        private void ChargerEmploiDuTempsProf()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Horaire");
            dt.Columns.Add("Lundi");
            dt.Columns.Add("Mardi");
            dt.Columns.Add("Mercredi");
            dt.Columns.Add("Jeudi");
            dt.Columns.Add("Vendredi");

            string[] horaires = { "08:00-09:00", "09:00-10:00", "10:00-11:00", "11:00-12:00", "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00" };

            foreach (string h in horaires)
            {
                DataRow row = dt.NewRow();
                row["Horaire"] = h;
                if (h == "12:00-13:00")
                {
                    row["Lundi"] = row["Mardi"] = row["Mercredi"] = row["Jeudi"] = row["Vendredi"] = "";
                }
                dt.Rows.Add(row);
            }

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = @"
                    SELECT e.Jour, e.HeureDebut, e.HeureFin, m.Libelle AS LibelleMatiere, c.Libelle AS LibelleClasse
                    FROM emploi_du_temps e
                    JOIN matiere m ON e.idMatiere = m.id
                    JOIN classe c ON e.idClasse = c.id
                    WHERE e.idProfesseur = @idProfesseur";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idProfesseur", _idProfesseur);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string jour = rdr["Jour"].ToString();
                            TimeSpan debut = (TimeSpan)rdr["HeureDebut"];
                            TimeSpan fin = (TimeSpan)rdr["HeureFin"];
                            string heure = $"{debut.Hours:D2}:{debut.Minutes:D2}-{fin.Hours:D2}:{fin.Minutes:D2}";
                            string contenu = $"{rdr["LibelleMatiere"]}\n{rdr["LibelleClasse"]}";

                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["Horaire"].ToString() == heure)
                                {
                                    row[jour] = contenu;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.RowTemplate.Height = 50;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        // ───────────────────────────────────────────
        // AJOUT NOTE
        // ───────────────────────────────────────────

        private void gerer_note_SelectedIndexChanged(object sender, EventArgs e) { }

        private void add_note_eleve_Click(object sender, EventArgs e)
        {
            string nom = Interaction.InputBox("Nom de l'élève :", "Ajouter une note", "");
            if (string.IsNullOrEmpty(nom)) return;

            string prenom = Interaction.InputBox("Prénom de l'élève :", "Ajouter une note", "");
            if (string.IsNullOrEmpty(prenom)) return;

            string noteStr = Interaction.InputBox("Note (/20) :", "Ajouter une note", "");
            if (string.IsNullOrEmpty(noteStr)) return;
            if (!decimal.TryParse(noteStr, out decimal note))
            {
                MessageBox.Show("Note invalide.");
                return;
            }

            string coefStr = Interaction.InputBox("Coefficient :", "Ajouter une note", "1");
            if (string.IsNullOrEmpty(coefStr)) return;
            if (!int.TryParse(coefStr, out int coef))
            {
                MessageBox.Show("Coefficient invalide.");
                return;
            }

            string dateStr = Interaction.InputBox("Date (YYYY-MM-DD) :", "Ajouter une note", DateTime.Now.ToString("yyyy-MM-dd"));
            if (string.IsNullOrEmpty(dateStr)) return;
            if (!DateTime.TryParse(dateStr, out DateTime dateEval))
            {
                MessageBox.Show("Date invalide.");
                return;
            }

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                int idEtudiant;
                string sqlSelect = "SELECT id FROM etudiant WHERE nom = @nom AND prenom = @prenom";
                using (MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn))
                {
                    cmdSelect.Parameters.AddWithValue("@nom", nom);
                    cmdSelect.Parameters.AddWithValue("@prenom", prenom);
                    object result = cmdSelect.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Élève introuvable.");
                        return;
                    }
                    idEtudiant = Convert.ToInt32(result);
                }

                string sqlInsert = @"INSERT INTO note (idEtudiant, idProfesseur, idMatiere, Note, Coefficient, DateEval)
                                     VALUES (@idEtudiant, @idProfesseur, @idMatiere, @note, @coef, @dateEval)";
                using (MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@idEtudiant", idEtudiant);
                    cmdInsert.Parameters.AddWithValue("@idProfesseur", _idProfesseur);
                    cmdInsert.Parameters.AddWithValue("@idMatiere", _idMatiere);
                    cmdInsert.Parameters.AddWithValue("@note", note);
                    cmdInsert.Parameters.AddWithValue("@coef", coef);
                    cmdInsert.Parameters.AddWithValue("@dateEval", dateEval.ToString("yyyy-MM-dd"));
                    cmdInsert.ExecuteNonQuery();
                }
            }

            ChargerNotes();
            MessageBox.Show("Note ajoutée avec succès !");
        }

        // ───────────────────────────────────────────
        // AJOUT ABSENCE ÉLÈVE
        // ───────────────────────────────────────────

        private void add_absence_eleve_Click(object sender, EventArgs e)
        {
            string nom = Interaction.InputBox("Nom de l'élève :", "Ajouter une absence", "");
            if (string.IsNullOrEmpty(nom)) return;

            string prenom = Interaction.InputBox("Prénom de l'élève :", "Ajouter une absence", "");
            if (string.IsNullOrEmpty(prenom)) return;

            string motif = Interaction.InputBox("Motif de l'absence :", "Ajouter une absence", "");
            if (string.IsNullOrEmpty(motif)) return;

            string dateStr = Interaction.InputBox("Date (YYYY-MM-DD) :", "Ajouter une absence", DateTime.Now.ToString("yyyy-MM-dd"));
            if (string.IsNullOrEmpty(dateStr)) return;
            if (!DateTime.TryParse(dateStr, out DateTime dateAbsence))
            {
                MessageBox.Show("Date invalide.");
                return;
            }

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                int idEtudiant;
                string sqlSelect = "SELECT id FROM etudiant WHERE nom = @nom AND prenom = @prenom";
                using (MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, conn))
                {
                    cmdSelect.Parameters.AddWithValue("@nom", nom);
                    cmdSelect.Parameters.AddWithValue("@prenom", prenom);
                    object result = cmdSelect.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Élève introuvable.");
                        return;
                    }
                    idEtudiant = Convert.ToInt32(result);
                }

                string sqlInsert = "INSERT INTO absence (idEtudiant, idProfesseur, Motif, DateAbsence) VALUES (@idEtudiant, @idProfesseur, @motif, @dateAbsence)";
                using (MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@idEtudiant", idEtudiant);
                    cmdInsert.Parameters.AddWithValue("@idProfesseur", _idProfesseur);
                    cmdInsert.Parameters.AddWithValue("@motif", motif);
                    cmdInsert.Parameters.AddWithValue("@dateAbsence", dateAbsence.ToString("yyyy-MM-dd"));
                    cmdInsert.ExecuteNonQuery();
                }
            }

            ChargerAbsencesEleves();
            MessageBox.Show("Absence ajoutée avec succès !");
        }
    }
}