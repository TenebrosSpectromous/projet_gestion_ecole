using System;

namespace Accueil
{
    partial class Connexion
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
            this.print_identifiant = new System.Windows.Forms.TextBox();
            this.print_mdp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_enreg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.label1.Location = new System.Drawing.Point(213, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connexion";
            // 
            // print_identifiant
            // 
            this.print_identifiant.Location = new System.Drawing.Point(399, 215);
            this.print_identifiant.Name = "print_identifiant";
            this.print_identifiant.Size = new System.Drawing.Size(100, 20);
            this.print_identifiant.TabIndex = 1;
            this.print_identifiant.TextChanged += new System.EventHandler(this.print_identifiant_TextChanged);
            // 
            // print_mdp
            // 
            this.print_mdp.Location = new System.Drawing.Point(399, 288);
            this.print_mdp.Name = "print_mdp";
            this.print_mdp.Size = new System.Drawing.Size(100, 20);
            this.print_mdp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(244, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Identifiant :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(208, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mot de passe :";
            // 
            // btn_enreg
            // 
            this.btn_enreg.Location = new System.Drawing.Point(318, 387);
            this.btn_enreg.Name = "btn_enreg";
            this.btn_enreg.Size = new System.Drawing.Size(127, 29);
            this.btn_enreg.TabIndex = 5;
            this.btn_enreg.Text = "Se connecter";
            this.btn_enreg.UseVisualStyleBackColor = true;
            this.btn_enreg.Click += new System.EventHandler(this.btn_enreg_Click);
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_enreg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.print_mdp);
            this.Controls.Add(this.print_identifiant);
            this.Controls.Add(this.label1);
            this.Name = "Connexion";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Connexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void print_identifiant_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Connexion_Load(object sender, EventArgs e)
        {
           
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox print_identifiant;
        private System.Windows.Forms.TextBox print_mdp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_enreg;
    }
}