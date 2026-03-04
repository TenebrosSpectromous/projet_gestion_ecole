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

namespace Accueil
{
    public partial class EleveForm : Form
    {
        private readonly string connString = "Server=localhost;Database=projet_ges_ecole;Uid=root;Pwd=;";
        private readonly int _idEtudiant;

        public EleveForm(int idEtudiant)
        {
            InitializeComponent();
            Theme.Apply(this);
            _idEtudiant = idEtudiant;

            ChargerNotes();
            ChargerAbsences();

            int idClasse = GetIdClasse(idEtudiant);
            ChargerEmploiDuTemps(idEtudiant, idClasse);
        }

        private int GetIdClasse(int idEtudiant)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = "SELECT idClasse FROM etudiant WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idEtudiant);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }



        private void ChargerNotes()
        {
            note_eleve.Items.Clear();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = @"
                    SELECT m.Libelle, n.Note, n.Coefficient, n.DateEval
                    FROM note n
                    JOIN matiere m ON n.idMatiere = m.id
                    WHERE n.idEtudiant = @id
                    ORDER BY n.DateEval DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _idEtudiant);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string date = Convert.ToDateTime(rdr["DateEval"]).ToString("yyyy-MM-dd");
                            string display = $"{rdr["Libelle"]} — {rdr["Note"]}/20 (coef. {rdr["Coefficient"]}) — {date}";
                            note_eleve.Items.Add(display);
                        }
                    }
                }
            }
        }

        private void ChargerAbsences()
        {
            absence_eleve.Items.Clear();

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                string sql = @"
                    SELECT Motif, DateAbsence
                    FROM absence
                    WHERE idEtudiant = @id
                    ORDER BY DateAbsence DESC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _idEtudiant);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string date = Convert.ToDateTime(rdr["DateAbsence"]).ToString("yyyy-MM-dd");
                            string display = $"{rdr["Motif"]} ({date})";
                            absence_eleve.Items.Add(display);
                        }
                    }
                }
            }
        }

        private void ChargerEmploiDuTemps(int idEleve, int idClasse)
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
    SELECT e.Jour, e.HeureDebut, e.HeureFin, m.Libelle, p.Nom, p.Prenom
    FROM emploi_du_temps e
    JOIN matiere m ON e.idMatiere = m.id
    JOIN professeur p ON e.idProfesseur = p.id
    WHERE e.idClasse = @idClasse
    AND (
        e.idMatiere NOT IN (9, 10)
        OR EXISTS (
            SELECT 1 FROM note n
            WHERE n.idEtudiant = @idEleve AND n.idMatiere = e.idMatiere
        )
    )";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idClasse", idClasse);
                    cmd.Parameters.AddWithValue("@idEleve", idEleve);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string jour = rdr["Jour"].ToString();
                            TimeSpan debut = (TimeSpan)rdr["HeureDebut"];
                            TimeSpan fin = (TimeSpan)rdr["HeureFin"];
                            string heure = $"{debut.Hours:D2}:{debut.Minutes:D2}-{fin.Hours:D2}:{fin.Minutes:D2}";
                            string contenu = $"{rdr["Libelle"]}\n{rdr["Prenom"]} {rdr["Nom"]}";

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
    }
}


