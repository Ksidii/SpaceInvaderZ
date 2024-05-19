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
            this.wlewo = new System.Windows.Forms.Button();
            this.wprawo = new System.Windows.Forms.Button();
            this.Opis = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // wlewo
            // 
            this.wlewo.Location = new System.Drawing.Point(273, 384);
            this.wlewo.Name = "wlewo";
            this.wlewo.Size = new System.Drawing.Size(75, 23);
            this.wlewo.TabIndex = 0;
            this.wlewo.Text = "W lewo\r\n";
            this.wlewo.UseVisualStyleBackColor = true;
            this.wlewo.Click += new System.EventHandler(this.wlewo_Click);
            // 
            // wprawo
            // 
            this.wprawo.Location = new System.Drawing.Point(470, 384);
            this.wprawo.Name = "wprawo";
            this.wprawo.Size = new System.Drawing.Size(75, 23);
            this.wprawo.TabIndex = 1;
            this.wprawo.Text = "W prawo\r\n";
            this.wprawo.UseVisualStyleBackColor = true;
            this.wprawo.Click += new System.EventHandler(this.wprawo_Click);
            // 
            // Opis
            // 
            this.Opis.Location = new System.Drawing.Point(273, 358);
            this.Opis.Name = "Opis";
            this.Opis.Size = new System.Drawing.Size(272, 20);
            this.Opis.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Opis);
            this.Controls.Add(this.wprawo);
            this.Controls.Add(this.wlewo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button wlewo;
        private System.Windows.Forms.Button wprawo;
        private System.Windows.Forms.TextBox Opis;
    }
}

