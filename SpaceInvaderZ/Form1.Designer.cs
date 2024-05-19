namespace SpaceInvaderZ
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Start = new System.Windows.Forms.Button();
            this.poleGry1 = new SpaceInvaderZ.PoleGry();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Start.Location = new System.Drawing.Point(584, 688);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 4;
            this.Start.Text = "Reset";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // poleGry1
            // 
            this.poleGry1.BackColor = System.Drawing.Color.Navy;
            this.poleGry1.BackgroundImage = global::SpaceInvaderZ.Properties.Resources.space;
            this.poleGry1.Location = new System.Drawing.Point(12, 12);
            this.poleGry1.Name = "poleGry1";
            this.poleGry1.Size = new System.Drawing.Size(1220, 670);
            this.poleGry1.TabIndex = 3;
            this.poleGry1.Paint += new System.Windows.Forms.PaintEventHandler(this.poleGry1_Paint);
            this.poleGry1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.poleGry1_MouseDown);
            this.poleGry1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.poleGry1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1244, 723);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.poleGry1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "SpaceInvaderZ";
            this.ResumeLayout(false);

        }

        #endregion
        private PoleGry poleGry1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Start;
    }
}

