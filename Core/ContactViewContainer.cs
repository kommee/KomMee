using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace KomMee
{
    public class ContactViewContainer: IViewContainer
    {
        static TextBox firstNameTextbox = null;
        static TextBox lastNameTextbox = null;
        static TextBox mobileNumberTextbox = null;
        static Label firstNameLabel = null;
        static Label lastNameLabel = null;
        static Label mobileNumberLabel = null;
        static TextBox activeControl = null;

        public void createViewForReading(System.Windows.Forms.Panel parentPanel)
        {
            ContactViewContainer.firstNameTextbox = null;
            ContactViewContainer.lastNameTextbox = null;
            ContactViewContainer.mobileNumberTextbox = null;
            ContactViewContainer.firstNameLabel = null;
            ContactViewContainer.lastNameLabel = null;
            ContactViewContainer.mobileNumberLabel = null;

            parentPanel.SuspendLayout();

            ContactViewContainer.firstNameLabel = new Label();
            ContactViewContainer.firstNameLabel.SuspendLayout();
            ContactViewContainer.firstNameLabel.Width = 490;
            ContactViewContainer.firstNameLabel.Height = 25;
            ContactViewContainer.firstNameLabel.Left = 0;
            ContactViewContainer.firstNameLabel.Top = 0;
            ContactViewContainer.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.firstNameLabel.Text = "Vorname:";

            ContactViewContainer.firstNameTextbox = new TextBox();
            ContactViewContainer.firstNameTextbox.SuspendLayout();
            ContactViewContainer.firstNameTextbox.Width = 490;
            ContactViewContainer.firstNameTextbox.Height = 50;
            ContactViewContainer.firstNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.firstNameTextbox.Left = 0;
            ContactViewContainer.firstNameTextbox.Top = 35;
            ContactViewContainer.firstNameTextbox.ReadOnly = true;
            ContactViewContainer.firstNameTextbox.BackColor = Color.MistyRose;

            ContactViewContainer.lastNameLabel = new Label();
            ContactViewContainer.lastNameLabel.SuspendLayout();
            ContactViewContainer.lastNameLabel.Width = 490;
            ContactViewContainer.lastNameLabel.Height = 25;
            ContactViewContainer.lastNameLabel.Left = 0;
            ContactViewContainer.lastNameLabel.Top = 70;
            ContactViewContainer.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.lastNameLabel.Text = "Nachname:";

            ContactViewContainer.lastNameTextbox = new TextBox();
            ContactViewContainer.lastNameTextbox.SuspendLayout();
            ContactViewContainer.lastNameTextbox.Width = 490;
            ContactViewContainer.lastNameTextbox.Height = 50;
            ContactViewContainer.lastNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.lastNameTextbox.Left = 0;
            ContactViewContainer.lastNameTextbox.Top = 105;
            ContactViewContainer.lastNameTextbox.ReadOnly = true;
            ContactViewContainer.lastNameTextbox.BackColor = System.Drawing.Color.White;

            ContactViewContainer.mobileNumberLabel = new Label();
            ContactViewContainer.mobileNumberLabel.SuspendLayout();
            ContactViewContainer.mobileNumberLabel.Width = 490;
            ContactViewContainer.mobileNumberLabel.Height = 25;
            ContactViewContainer.mobileNumberLabel.Left = 0;
            ContactViewContainer.mobileNumberLabel.Top = 140;
            ContactViewContainer.mobileNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.mobileNumberLabel.Text = "Telefonnummer:";

            ContactViewContainer.mobileNumberTextbox = new TextBox();
            ContactViewContainer.mobileNumberTextbox.SuspendLayout();
            ContactViewContainer.mobileNumberTextbox.Width = 490;
            ContactViewContainer.mobileNumberTextbox.Height = 50;
            ContactViewContainer.mobileNumberTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.mobileNumberTextbox.Left = 0;
            ContactViewContainer.mobileNumberTextbox.Top = 175;
            ContactViewContainer.mobileNumberTextbox.ReadOnly = true;
            ContactViewContainer.mobileNumberTextbox.BackColor = System.Drawing.Color.White;

            parentPanel.Controls.Add(ContactViewContainer.firstNameLabel);
            parentPanel.Controls.Add(ContactViewContainer.firstNameTextbox);
            parentPanel.Controls.Add(ContactViewContainer.lastNameLabel);
            parentPanel.Controls.Add(ContactViewContainer.lastNameTextbox);
            parentPanel.Controls.Add(ContactViewContainer.mobileNumberLabel);
            parentPanel.Controls.Add(ContactViewContainer.mobileNumberTextbox);

            ContactViewContainer.firstNameLabel.ResumeLayout(false);
            ContactViewContainer.firstNameTextbox.ResumeLayout(false);
            ContactViewContainer.lastNameLabel.ResumeLayout(false);
            ContactViewContainer.lastNameTextbox.ResumeLayout(false);
            ContactViewContainer.mobileNumberLabel.ResumeLayout(false);
            ContactViewContainer.mobileNumberTextbox.ResumeLayout(false);

            parentPanel.ResumeLayout(false);
        }

        public void createViewForNew(System.Windows.Forms.Panel parentPanel)
        {
            ContactViewContainer.firstNameTextbox = null;
            ContactViewContainer.lastNameTextbox = null;
            ContactViewContainer.mobileNumberTextbox = null;
            ContactViewContainer.firstNameLabel = null;
            ContactViewContainer.lastNameLabel = null;
            ContactViewContainer.mobileNumberLabel = null;

            parentPanel.SuspendLayout();

            ContactViewContainer.firstNameLabel = new Label();
            ContactViewContainer.firstNameLabel.SuspendLayout();
            ContactViewContainer.firstNameLabel.Width = 490;
            ContactViewContainer.firstNameLabel.Height = 25;
            ContactViewContainer.firstNameLabel.Left = 0;
            ContactViewContainer.firstNameLabel.Top = 0;
            ContactViewContainer.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.firstNameLabel.Text = "Vorname:";

            ContactViewContainer.firstNameTextbox = new TextBox();
            ContactViewContainer.firstNameTextbox.SuspendLayout();
            ContactViewContainer.firstNameTextbox.Width = 490;
            ContactViewContainer.firstNameTextbox.Height = 50;
            ContactViewContainer.firstNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.firstNameTextbox.Left = 0;
            ContactViewContainer.firstNameTextbox.Top = 35;
            ContactViewContainer.firstNameTextbox.BackColor = System.Drawing.Color.MistyRose;

            ContactViewContainer.lastNameLabel = new Label();
            ContactViewContainer.lastNameLabel.SuspendLayout();
            ContactViewContainer.lastNameLabel.Width = 490;
            ContactViewContainer.lastNameLabel.Height = 25;
            ContactViewContainer.lastNameLabel.Left = 0;
            ContactViewContainer.lastNameLabel.Top = 70;
            ContactViewContainer.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.lastNameLabel.Text = "Nachname:";

            ContactViewContainer.lastNameTextbox = new TextBox();
            ContactViewContainer.lastNameTextbox.SuspendLayout();
            ContactViewContainer.lastNameTextbox.Width = 490;
            ContactViewContainer.lastNameTextbox.Height = 50;
            ContactViewContainer.lastNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.lastNameTextbox.Left = 0;
            ContactViewContainer.lastNameTextbox.Top = 105;
            ContactViewContainer.lastNameTextbox.BackColor = System.Drawing.Color.White;

            ContactViewContainer.mobileNumberLabel = new Label();
            ContactViewContainer.mobileNumberLabel.SuspendLayout();
            ContactViewContainer.mobileNumberLabel.Width = 490;
            ContactViewContainer.mobileNumberLabel.Height = 25;
            ContactViewContainer.mobileNumberLabel.Left = 0;
            ContactViewContainer.mobileNumberLabel.Top = 140;
            ContactViewContainer.mobileNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.mobileNumberLabel.Text = "Telefonnummer:";

            ContactViewContainer.mobileNumberTextbox = new TextBox();
            ContactViewContainer.mobileNumberTextbox.SuspendLayout();
            ContactViewContainer.mobileNumberTextbox.Width = 490;
            ContactViewContainer.mobileNumberTextbox.Height = 50;
            ContactViewContainer.mobileNumberTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            ContactViewContainer.mobileNumberTextbox.Left = 0;
            ContactViewContainer.mobileNumberTextbox.Top = 175;
            ContactViewContainer.mobileNumberTextbox.BackColor = System.Drawing.Color.White;

            parentPanel.Controls.Add(ContactViewContainer.firstNameLabel);
            parentPanel.Controls.Add(ContactViewContainer.firstNameTextbox);
            parentPanel.Controls.Add(ContactViewContainer.lastNameLabel);
            parentPanel.Controls.Add(ContactViewContainer.lastNameTextbox);
            parentPanel.Controls.Add(ContactViewContainer.mobileNumberLabel);
            parentPanel.Controls.Add(ContactViewContainer.mobileNumberTextbox);

            ContactViewContainer.firstNameLabel.ResumeLayout(false);
            ContactViewContainer.firstNameTextbox.ResumeLayout(false);
            ContactViewContainer.lastNameLabel.ResumeLayout(false);
            ContactViewContainer.lastNameTextbox.ResumeLayout(false);
            ContactViewContainer.mobileNumberLabel.ResumeLayout(false);
            ContactViewContainer.mobileNumberTextbox.ResumeLayout(false);

            parentPanel.ResumeLayout(false);

            ContactViewContainer.activeControl = ContactViewContainer.firstNameTextbox;
        }

        public void addWriteInput(KeyboardViewEventArgs keyboardViewEventArgs)
        {
            switch (keyboardViewEventArgs.Value)
            {
                case KeyboardButtons.AlphaA:
                    ContactViewContainer.activeControl.Text += "A";
                    break;
                case KeyboardButtons.AlphaB:
                    ContactViewContainer.activeControl.Text += "B";
                    break;
                case KeyboardButtons.AlphaC:
                    ContactViewContainer.activeControl.Text += "C";
                    break;
                case KeyboardButtons.AlphaD:
                    ContactViewContainer.activeControl.Text += "D";
                    break;
                case KeyboardButtons.AlphaE:
                    ContactViewContainer.activeControl.Text += "E";
                    break;
                case KeyboardButtons.AlphaF:
                    ContactViewContainer.activeControl.Text += "F";
                    break;
                case KeyboardButtons.AlphaG:
                    ContactViewContainer.activeControl.Text += "G";
                    break;
                case KeyboardButtons.AlphaH:
                    ContactViewContainer.activeControl.Text += "H";
                    break;
                case KeyboardButtons.AlphaI:
                    ContactViewContainer.activeControl.Text += "I";
                    break;
                case KeyboardButtons.AlphaJ:
                    ContactViewContainer.activeControl.Text += "J";
                    break;
                case KeyboardButtons.AlphaK:
                    ContactViewContainer.activeControl.Text += "K";
                    break;
                case KeyboardButtons.AlphaL:
                    ContactViewContainer.activeControl.Text += "L";
                    break;
                case KeyboardButtons.AlphaM:
                    ContactViewContainer.activeControl.Text += "M";
                    break;
                case KeyboardButtons.AlphaN:
                    ContactViewContainer.activeControl.Text += "N";
                    break;
                case KeyboardButtons.AlphaO:
                    ContactViewContainer.activeControl.Text += "O";
                    break;
                case KeyboardButtons.AlphaP:
                    ContactViewContainer.activeControl.Text += "P";
                    break;
                case KeyboardButtons.AlphaQ:
                    ContactViewContainer.activeControl.Text += "Q";
                    break;
                case KeyboardButtons.AlphaR:
                    ContactViewContainer.activeControl.Text += "R";
                    break;
                case KeyboardButtons.AlphaS:
                    ContactViewContainer.activeControl.Text += "S";
                    break;
                case KeyboardButtons.AlphaT:
                    ContactViewContainer.activeControl.Text += "T";
                    break;
                case KeyboardButtons.AlphaU:
                    ContactViewContainer.activeControl.Text += "U";
                    break;
                case KeyboardButtons.AlphaV:
                    ContactViewContainer.activeControl.Text += "V";
                    break;
                case KeyboardButtons.AlphaW:
                    ContactViewContainer.activeControl.Text += "W";
                    break;
                case KeyboardButtons.AlphaX:
                    ContactViewContainer.activeControl.Text += "X";
                    break;
                case KeyboardButtons.AlphaY:
                    ContactViewContainer.activeControl.Text += "Y";
                    break;
                case KeyboardButtons.AlphaZ:
                    ContactViewContainer.activeControl.Text += "Z";
                    break;
                case KeyboardButtons.NumericOne:
                    ContactViewContainer.activeControl.Text += "1";
                    break;
                case KeyboardButtons.NumericTwo:
                    ContactViewContainer.activeControl.Text += "2";
                    break;
                case KeyboardButtons.NumericThree:
                    ContactViewContainer.activeControl.Text += "3";
                    break;
                case KeyboardButtons.NumericFour:
                    ContactViewContainer.activeControl.Text += "4";
                    break;
                case KeyboardButtons.NumericFive:
                    ContactViewContainer.activeControl.Text += "5";
                    break;
                case KeyboardButtons.NumericSix:
                    ContactViewContainer.activeControl.Text += "6";
                    break;
                case KeyboardButtons.NumericSeven:
                    ContactViewContainer.activeControl.Text += "7";
                    break;
                case KeyboardButtons.NumericEight:
                    ContactViewContainer.activeControl.Text += "8";
                    break;
                case KeyboardButtons.NumericNine:
                    ContactViewContainer.activeControl.Text += "9";
                    break;
                case KeyboardButtons.NumericZero:
                    ContactViewContainer.activeControl.Text += "0";
                    break;
                case KeyboardButtons.SpecialCharAt:
                    ContactViewContainer.activeControl.Text += "@";
                    break;
                case KeyboardButtons.SpecialCharSpace:
                    ContactViewContainer.activeControl.Text += " ";
                    break;
                case KeyboardButtons.SpecialCharBackspace:
                    if (ContactViewContainer.activeControl.Text.Length > 0)
                        ContactViewContainer.activeControl.Text = ContactViewContainer.activeControl.Text.Substring(0, ContactViewContainer.activeControl.Text.Length - 1);
                    break;
                case KeyboardButtons.PunctationDot:
                    ContactViewContainer.activeControl.Text += ".";
                    break;
                case KeyboardButtons.PunctationComma:
                    ContactViewContainer.activeControl.Text += ",";
                    break;
                case KeyboardButtons.PunctationQuestion:
                    ContactViewContainer.activeControl.Text += "?";
                    break;
                case KeyboardButtons.PunctationExclamation:
                    ContactViewContainer.activeControl.Text += "!";
                    break;
                case KeyboardButtons.UmlautA:
                    ContactViewContainer.activeControl.Text += "Ä";
                    break;
                case KeyboardButtons.UmlautO:
                    ContactViewContainer.activeControl.Text += "Ö";
                    break;
                case KeyboardButtons.UmlautU:
                    ContactViewContainer.activeControl.Text += "Ü";
                    break;
                case KeyboardButtons.UmlautS:
                    ContactViewContainer.activeControl.Text += "ß";
                    break;
                default:
                    break;
            }
        }

        public bool apply()
        {
            if (ContactViewContainer.activeControl.Text.Length == 0)
                return false;

            if (ContactViewContainer.activeControl == ContactViewContainer.firstNameTextbox)
            {
                ContactViewContainer.firstNameTextbox.BackColor = Color.White;
                ContactViewContainer.lastNameTextbox.BackColor = Color.MistyRose;
                ContactViewContainer.activeControl = ContactViewContainer.lastNameTextbox;
                return false;
            }
            else if (ContactViewContainer.activeControl == ContactViewContainer.lastNameTextbox)
            {
                ContactViewContainer.lastNameTextbox.BackColor = Color.White;
                ContactViewContainer.mobileNumberTextbox.BackColor = Color.MistyRose;
                ContactViewContainer.activeControl = ContactViewContainer.mobileNumberTextbox;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool cancel()
        {
            if (ContactViewContainer.activeControl == ContactViewContainer.firstNameTextbox)
            {
                return true;
            }
            else if (ContactViewContainer.activeControl == ContactViewContainer.lastNameTextbox)
            {
                ContactViewContainer.lastNameTextbox.BackColor = Color.White;
                ContactViewContainer.firstNameTextbox.BackColor = Color.MistyRose;
                ContactViewContainer.activeControl.Text = "";
                ContactViewContainer.activeControl = ContactViewContainer.firstNameTextbox;
                return false;
            }
            else
            {
                ContactViewContainer.mobileNumberTextbox.BackColor = Color.White;
                ContactViewContainer.lastNameTextbox.BackColor = Color.MistyRose;
                ContactViewContainer.activeControl.Text = "";
                ContactViewContainer.activeControl = ContactViewContainer.lastNameTextbox;
                return false;
            }
        }

        public void setWriteInput(string Text)
        {
        }

        public void setReadInput(string Text)
        {
        }

        public object getData()
        {
            return new String[] { ContactViewContainer.firstNameTextbox.Text, ContactViewContainer.lastNameTextbox.Text, ContactViewContainer.mobileNumberTextbox.Text };
        }


        public void createViewForAnswer(Panel parentPanel)
        {
            throw new NotImplementedException();
        }
    }
}
