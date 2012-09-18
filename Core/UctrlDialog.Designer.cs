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
            this.lbChoice = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbChoice
            // 
            this.lbChoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbChoice.FormattingEnabled = true;
            this.lbChoice.ItemHeight = 25;
            this.lbChoice.Location = new System.Drawing.Point(0, 0);
            this.lbChoice.Name = "lbChoice";
            this.lbChoice.Size = new System.Drawing.Size(150, 300);
            this.lbChoice.TabIndex = 0;
            this.lbChoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbChoice_KeyPress);
            // 
            // UctrlDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbChoice);
            this.Name = "UctrlDialog";
            this.Size = new System.Drawing.Size(150, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbChoice;

        public System.Windows.Forms.ListBox LbChoice
        {
            get { return lbChoice; }
            set { lbChoice = value; }
        }
    }
}
