namespace Accueil
{
    partial class AdminForm
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
            this.gerer_etudiant = new System.Windows.Forms.ListBox();
            this.gerer_profs = new System.Windows.Forms.ListBox();
            this.gerer_absence = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_ajt_etd = new System.Windows.Forms.Button();
            this.btn_ajt_profs = new System.Windows.Forms.Button();
            this.btn_ajt_abs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.label1.Location = new System.Drawing.Point(197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(454, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Administration";
            // 
            // gerer_etudiant
            // 
            this.gerer_etudiant.FormattingEnabled = true;
            this.gerer_etudiant.Location = new System.Drawing.Point(77, 136);
            this.gerer_etudiant.Name = "gerer_etudiant";
            this.gerer_etudiant.Size = new System.Drawing.Size(177, 212);
            this.gerer_etudiant.TabIndex = 1;
            this.gerer_etudiant.SelectedIndexChanged += new System.EventHandler(this.gerer_etudiant_SelectedIndexChanged);
            // 
            // gerer_profs
            // 
            this.gerer_profs.FormattingEnabled = true;
            this.gerer_profs.Location = new System.Drawing.Point(318, 136);
            this.gerer_profs.Name = "gerer_profs";
            this.gerer_profs.Size = new System.Drawing.Size(177, 212);
            this.gerer_profs.TabIndex = 2;
            this.gerer_profs.SelectedIndexChanged += new System.EventHandler(this.gerer_profs_SelectedIndexChanged);
            // 
            // gerer_absence
            // 
            this.gerer_absence.FormattingEnabled = true;
            this.gerer_absence.Location = new System.Drawing.Point(563, 136);
            this.gerer_absence.Name = "gerer_absence";
            this.gerer_absence.Size = new System.Drawing.Size(211, 212);
            this.gerer_absence.TabIndex = 3;
            this.gerer_absence.SelectedIndexChanged += new System.EventHandler(this.gerer_absence_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gérer les absences des profs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gérer les professeurs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gérer les étudiants";
            // 
            // btn_ajt_etd
            // 
            this.btn_ajt_etd.Location = new System.Drawing.Point(194, 354);
            this.btn_ajt_etd.Name = "btn_ajt_etd";
            this.btn_ajt_etd.Size = new System.Drawing.Size(60, 34);
            this.btn_ajt_etd.TabIndex = 7;
            this.btn_ajt_etd.Text = "Add";
            this.btn_ajt_etd.UseVisualStyleBackColor = true;
            this.btn_ajt_etd.Click += new System.EventHandler(this.btn_ajt_etd_Click);
            // 
            // btn_ajt_profs
            // 
            this.btn_ajt_profs.Location = new System.Drawing.Point(437, 354);
            this.btn_ajt_profs.Name = "btn_ajt_profs";
            this.btn_ajt_profs.Size = new System.Drawing.Size(58, 34);
            this.btn_ajt_profs.TabIndex = 8;
            this.btn_ajt_profs.Text = "Add";
            this.btn_ajt_profs.UseVisualStyleBackColor = true;
            this.btn_ajt_profs.Click += new System.EventHandler(this.btn_ajt_profs_Click);
            // 
            // btn_ajt_abs
            // 
            this.btn_ajt_abs.Location = new System.Drawing.Point(720, 354);
            this.btn_ajt_abs.Name = "btn_ajt_abs";
            this.btn_ajt_abs.Size = new System.Drawing.Size(54, 34);
            this.btn_ajt_abs.TabIndex = 9;
            this.btn_ajt_abs.Text = "Add";
            this.btn_ajt_abs.UseVisualStyleBackColor = true;
            this.btn_ajt_abs.Click += new System.EventHandler(this.btn_ajt_abs_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ajt_abs);
            this.Controls.Add(this.btn_ajt_profs);
            this.Controls.Add(this.btn_ajt_etd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gerer_absence);
            this.Controls.Add(this.gerer_profs);
            this.Controls.Add(this.gerer_etudiant);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox gerer_etudiant;
        private System.Windows.Forms.ListBox gerer_profs;
        private System.Windows.Forms.ListBox gerer_absence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ajt_etd;
        private System.Windows.Forms.Button btn_ajt_profs;
        private System.Windows.Forms.Button btn_ajt_abs;
    }
}