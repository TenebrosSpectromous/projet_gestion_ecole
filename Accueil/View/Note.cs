using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accueil
{
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        // Propriété accessible depuis ProfForm pour récupérer la note choisie
        public string SelectedNote
        {
            get { return comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : null; }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Note_Load(object sender, EventArgs e)
        {
            // Exemple : on remplit la combo avec des notes de 0 à 20
            if (comboBox1.Items.Count == 0)
            {
                for (int i = 0; i <= 20; i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            // Ferme la fenêtre en renvoyant DialogResult.OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
