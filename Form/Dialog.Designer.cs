namespace KomMee
{
    partial class Dialog
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
            this.components = new System.ComponentModel.Container();
            this.DialogText = new System.Windows.Forms.Label();
            this.FocusResetTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // DialogText
            // 
            this.DialogText.AutoSize = true;
            this.DialogText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.DialogText.Location = new System.Drawing.Point(12, 9);
            this.DialogText.Name = "DialogText";
            this.DialogText.Size = new System.Drawing.Size(0, 25);
            this.DialogText.TabIndex = 0;
            // 
            // FocusResetTimer
            // 
            this.FocusResetTimer.Enabled = true;
            this.FocusResetTimer.Tick += new System.EventHandler(this.FocusResetTimer_Tick);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(104, 48);
            this.ControlBox = false;
            this.Controls.Add(this.DialogText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Dialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            this.TopMost = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dialog_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DialogText;
        private System.Windows.Forms.Timer FocusResetTimer;
    }
}