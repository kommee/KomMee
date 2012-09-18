using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomMee
{
    public partial class Dialog : Form
    {
        private List<Button> buttons;
        private int focusedButton;
        private string clickedDialogButton = "";
        public string ClickedDialogButton
        {
            get { return this.clickedDialogButton; }
        }

        public Dialog()
        {
            InitializeComponent();
        }

        public Dialog(string title, string text, string[] buttons)
        {
            InitializeComponent();
            this.Text = title;
            this.DialogText.Text = text;
            this.DialogText.Refresh();
            this.Width = this.DialogText.Width + 24;
            this.Height = this.DialogText.Height + 18;
            this.buttons = new List<Button>();
            this.focusedButton = 0;

            if (buttons.Length > 0)
            {
                this.SuspendLayout();

                int x = 12;
                int y = this.DialogText.Location.Y + this.DialogText.Size.Height + 9;
                int h = 0;

                for (int i = 0; i < buttons.Length; i++)
                {
                    string buttonText = buttons[i];
                    Button button = new Button();
                    button.Location = new System.Drawing.Point(x, y);
                    button.Name = buttonText;
                    button.Text = buttonText;
                    button.AutoSize = true;
                    button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
                    button.UseVisualStyleBackColor = true;
                    button.BackColor = KomMee.ABCDEFKeyboardView.DefaultBackgroundColor;
                    button.ForeColor = KomMee.ABCDEFKeyboardView.DefaultForegroundColor;
                    this.Controls.Add(button);
                    this.buttons.Add(button);
                    button.Refresh();
                    x += button.Width + 9;
                    if(button.Height > h)
                        h = button.Height;
                }
                if (x + 3 > this.Width)
                    this.Width = x + 3;
                this.Height += h + 50;

                this.buttons[this.focusedButton].BackColor = KomMee.ABCDEFKeyboardView.FocusBackgroundColor;
                this.buttons[this.focusedButton].ForeColor = KomMee.ABCDEFKeyboardView.FocusForegroundColor;

                this.ResumeLayout(false);
                this.PerformLayout();

                //this.Location = Input.getDialogLocation(this.Size);
            }
        }

        private void Dialog_KeyUp(object sender, KeyEventArgs e)
        {
			if (Input.KeyMapping.ContainsKey(e.KeyValue))
			{
                string keymappingValue = Input.KeyMapping[e.KeyValue];
				switch (keymappingValue)
				{
					case "Keymapping_Up":
					case "Keymapping_Down":
                        // Do nothing
						break;
					case "Keymapping_Left":
                        if (this.focusedButton == 0)
                            this.setNewFocus(this.buttons.Count - 1);
                        else
                            this.setNewFocus(this.focusedButton - 1);
						break;
                    case "Keymapping_Right":
                        if (this.focusedButton == this.buttons.Count - 1)
                            this.setNewFocus(0);
                        else
                            this.setNewFocus(this.focusedButton + 1);
						break;
					case "Keymapping_Apply":
                        this.clickedDialogButton = this.buttons[this.focusedButton].Text;
                        this.Close();
						break;
					case "Keymapping_Cancel":
                        this.Close();
						break;
					default:
						break;
				}
			}
        }

        private void setNewFocus(int newFocus)
        {
            this.buttons[this.focusedButton].BackColor = KomMee.ABCDEFKeyboardView.DefaultBackgroundColor;
            this.buttons[this.focusedButton].ForeColor = KomMee.ABCDEFKeyboardView.DefaultForegroundColor;
            this.focusedButton = newFocus;
            this.buttons[this.focusedButton].BackColor = KomMee.ABCDEFKeyboardView.FocusBackgroundColor;
            this.buttons[this.focusedButton].ForeColor = KomMee.ABCDEFKeyboardView.FocusForegroundColor;
        }

        private void FocusResetTimer_Tick(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
    }
}
