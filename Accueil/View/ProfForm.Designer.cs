namespace Accueil
{
    partial class ProfForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gerer_absence_eleve = new System.Windows.Forms.ListBox();
            this.gerer_note = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.add_note_eleve = new System.Windows.Forms.Button();
            this.add_absence_eleve = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Professeur";
            // 
            // gerer_absence_eleve
            // 
            this.gerer_absence_eleve.FormattingEnabled = true;
            this.gerer_absence_eleve.Location = new System.Drawing.Point(487, 304);
            this.gerer_absence_eleve.Name = "gerer_absence_eleve";
            this.gerer_absence_eleve.Size = new System.Drawing.Size(250, 134);
            this.gerer_absence_eleve.TabIndex = 4;
            // 
            // gerer_note
            // 
            this.gerer_note.FormattingEnabled = true;
            this.gerer_note.Location = new System.Drawing.Point(487, 126);
            this.gerer_note.Name = "gerer_note";
            this.gerer_note.Size = new System.Drawing.Size(250, 134);
            this.gerer_note.TabIndex = 5;
            this.gerer_note.SelectedIndexChanged += new System.EventHandler(this.gerer_note_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Gérer les absences des élèves";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gérer les notes";
            // 
            // add_note_eleve
            // 
            this.add_note_eleve.Location = new System.Drawing.Point(676, 267);
            this.add_note_eleve.Name = "add_note_eleve";
            this.add_note_eleve.Size = new System.Drawing.Size(60, 23);
            this.add_note_eleve.TabIndex = 8;
            this.add_note_eleve.Text = "Add";
            this.add_note_eleve.UseVisualStyleBackColor = true;
            this.add_note_eleve.Click += new System.EventHandler(this.add_note_eleve_Click);
            // 
            // add_absence_eleve
            // 
            this.add_absence_eleve.Location = new System.Drawing.Point(676, 445);
            this.add_absence_eleve.Name = "add_absence_eleve";
            this.add_absence_eleve.Size = new System.Drawing.Size(61, 23);
            this.add_absence_eleve.TabIndex = 9;
            this.add_absence_eleve.Text = "Add";
            this.add_absence_eleve.UseVisualStyleBackColor = true;
            this.add_absence_eleve.Click += new System.EventHandler(this.add_absence_eleve_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(413, 311);
            this.dataGridView1.TabIndex = 10;
            // 
            // ProfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 480);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.add_absence_eleve);
            this.Controls.Add(this.add_note_eleve);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gerer_note);
            this.Controls.Add(this.gerer_absence_eleve);
            this.Controls.Add(this.label1);
            this.Name = "ProfForm";
            this.Text = "ProfForm";
            this.Load += new System.EventHandler(this.ProfForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox gerer_absence_eleve;
        private System.Windows.Forms.ListBox gerer_note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button add_note_eleve;
        private System.Windows.Forms.Button add_absence_eleve;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}