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
    public partial class FormulaireAjoutNote : Form
    {
        public FormulaireAjoutNote()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            classe_6 formAjout = new classe_6();

            formAjout.ShowDialog();
            this.Hide();
        }
    }
}
