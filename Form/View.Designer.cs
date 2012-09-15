namespace KomMee
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.KyboardAndViewContainer = new System.Windows.Forms.SplitContainer();
            this.TopPanel = new System.Windows.Forms.SplitContainer();
            this.uctrlDialog1 = new KomMee.UctrlDialog();
            this.abcdefKeyboardView1 = new KomMee.ABCDEFKeyboardView();
            this.FocusResetTimer = new System.Windows.Forms.Timer(this.components);
            this.KyboardAndViewContainer.Panel1.SuspendLayout();
            this.KyboardAndViewContainer.Panel2.SuspendLayout();
            this.KyboardAndViewContainer.SuspendLayout();
            this.TopPanel.Panel1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // KyboardAndViewContainer
            // 
            this.KyboardAndViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KyboardAndViewContainer.IsSplitterFixed = true;
            this.KyboardAndViewContainer.Location = new System.Drawing.Point(0, 0);
            this.KyboardAndViewContainer.Name = "KyboardAndViewContainer";
            this.KyboardAndViewContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // KyboardAndViewContainer.Panel1
            // 
            this.KyboardAndViewContainer.Panel1.Controls.Add(this.TopPanel);
            // 
            // KyboardAndViewContainer.Panel2
            // 
            this.KyboardAndViewContainer.Panel2.Controls.Add(this.abcdefKeyboardView1);
            this.KyboardAndViewContainer.Size = new System.Drawing.Size(792, 573);
            this.KyboardAndViewContainer.SplitterDistance = 305;
            this.KyboardAndViewContainer.TabIndex = 0;
            this.KyboardAndViewContainer.TabStop = false;
            // 
            // TopPanel
            // 
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.IsSplitterFixed = true;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            // 
            // TopPanel.Panel1
            // 
            this.TopPanel.Panel1.Controls.Add(this.uctrlDialog1);
            this.TopPanel.Size = new System.Drawing.Size(792, 305);
            this.TopPanel.SplitterDistance = 296;
            this.TopPanel.TabIndex = 1;
            this.TopPanel.TabStop = false;
            // 
            // uctrlDialog1
            // 
            this.uctrlDialog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctrlDialog1.Location = new System.Drawing.Point(0, 0);
            this.uctrlDialog1.Name = "uctrlDialog1";
            this.uctrlDialog1.Size = new System.Drawing.Size(296, 305);
            this.uctrlDialog1.TabIndex = 0;
            // 
            // abcdefKeyboardView1
            // 
            this.abcdefKeyboardView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.abcdefKeyboardView1.Location = new System.Drawing.Point(18, 3);
            this.abcdefKeyboardView1.Name = "abcdefKeyboardView1";
            this.abcdefKeyboardView1.Size = new System.Drawing.Size(760, 265);
            this.abcdefKeyboardView1.TabIndex = 0;
            this.abcdefKeyboardView1.TabStop = false;
            this.abcdefKeyboardView1.Applied += new System.EventHandler(this.abcdefKeyboardView1_Applied);
            // 
            // FocusResetTimer
            // 
            this.FocusResetTimer.Enabled = true;
            this.FocusResetTimer.Tick += new System.EventHandler(this.FocusResetTimer_Tick);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.KyboardAndViewContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "View";
            this.Text = "KomMee";
            this.Shown += new System.EventHandler(this.View_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.View_KeyUp);
            this.KyboardAndViewContainer.Panel1.ResumeLayout(false);
            this.KyboardAndViewContainer.Panel2.ResumeLayout(false);
            this.KyboardAndViewContainer.ResumeLayout(false);
            this.TopPanel.Panel1.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer KyboardAndViewContainer;
        private ABCDEFKeyboardView abcdefKeyboardView1;
        private System.Windows.Forms.SplitContainer TopPanel;
        private System.Windows.Forms.Timer FocusResetTimer;
        private UctrlDialog uctrlDialog1;
    }
}