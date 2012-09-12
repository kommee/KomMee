namespace KomMee
{
    partial class UctrlDialog
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbChoice = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LbChoice
            // 
            this.LbChoice.FormattingEnabled = true;
            this.LbChoice.Location = new System.Drawing.Point(4, 4);
            this.LbChoice.Name = "LbChoice";
            this.LbChoice.Size = new System.Drawing.Size(120, 95);
            this.LbChoice.TabIndex = 0;
            // 
            // UctrlDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LbChoice);
            this.Name = "UctrlDialog";
            this.Size = new System.Drawing.Size(150, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbChoice;
    }
}
