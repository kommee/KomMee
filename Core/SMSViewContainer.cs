using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomMee
{
    public class SMSViewContainer: IViewContainer
    {
        static TextBox RecvTextbox = null;
        static TextBox SendTextbox = null;
        static Label RecvLabel = null;
        static Label SendLabel = null;

        public void createViewForReading(System.Windows.Forms.Panel parentPanel)
        {
            SMSViewContainer.RecvTextbox = null;
            SMSViewContainer.SendTextbox = null;
            SMSViewContainer.RecvLabel = null;
            SMSViewContainer.SendLabel = null;

            parentPanel.SuspendLayout();

            SMSViewContainer.RecvLabel = new Label();
            SMSViewContainer.RecvLabel.SuspendLayout();
            SMSViewContainer.RecvLabel.Width = 490;
            SMSViewContainer.RecvLabel.Height = 25;
            SMSViewContainer.RecvLabel.Left = 0;
            SMSViewContainer.RecvLabel.Top = 0;
            SMSViewContainer.RecvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            SMSViewContainer.RecvLabel.Text = "Empfangene Nachricht:";

            SMSViewContainer.RecvTextbox = new TextBox();
            SMSViewContainer.RecvTextbox.SuspendLayout();
            SMSViewContainer.RecvTextbox.Width = 490;
            SMSViewContainer.RecvTextbox.Height = 268;
            SMSViewContainer.RecvTextbox.Left = 0;
            SMSViewContainer.RecvTextbox.Top = 35;
            SMSViewContainer.RecvTextbox.Multiline = true;
            SMSViewContainer.RecvTextbox.ReadOnly = true;
            SMSViewContainer.RecvTextbox.BackColor = System.Drawing.Color.White;

            parentPanel.Controls.Add(SMSViewContainer.RecvLabel);
            parentPanel.Controls.Add(SMSViewContainer.RecvTextbox);

            SMSViewContainer.RecvLabel.ResumeLayout(false);
            SMSViewContainer.RecvTextbox.ResumeLayout(false);
            parentPanel.ResumeLayout(false);
        }

        public void createViewForNew(System.Windows.Forms.Panel parentPanel)
        {
            SMSViewContainer.RecvTextbox = null;
            SMSViewContainer.SendTextbox = null;
            SMSViewContainer.RecvLabel = null;
            SMSViewContainer.SendLabel = null;

            parentPanel.SuspendLayout();

            SMSViewContainer.RecvLabel = new Label();
            SMSViewContainer.RecvLabel.SuspendLayout();
            SMSViewContainer.RecvLabel.Width = 490;
            SMSViewContainer.RecvLabel.Height = 25;
            SMSViewContainer.RecvLabel.Left = 0;
            SMSViewContainer.RecvLabel.Top = 0;
            SMSViewContainer.RecvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            SMSViewContainer.RecvLabel.Text = "Neue Nachricht:";

            SMSViewContainer.RecvTextbox = new TextBox();
            SMSViewContainer.RecvTextbox.SuspendLayout();
            SMSViewContainer.RecvTextbox.Width = 490;
            SMSViewContainer.RecvTextbox.Height = 268;
            SMSViewContainer.RecvTextbox.Left = 0;
            SMSViewContainer.RecvTextbox.Top = 35;
            SMSViewContainer.RecvTextbox.Multiline = true;

            parentPanel.Controls.Add(SMSViewContainer.RecvLabel);
            parentPanel.Controls.Add(SMSViewContainer.RecvTextbox);

            SMSViewContainer.RecvLabel.ResumeLayout(false);
            SMSViewContainer.RecvTextbox.ResumeLayout(false);
            parentPanel.ResumeLayout(false);
        }

        public void createViewForAnswer(System.Windows.Forms.Panel parentPanel)
        {
            SMSViewContainer.RecvTextbox = null;
            SMSViewContainer.SendTextbox = null;
            SMSViewContainer.RecvLabel = null;
            SMSViewContainer.SendLabel = null;

            parentPanel.SuspendLayout();

            SMSViewContainer.RecvLabel = new Label();
            SMSViewContainer.RecvLabel.SuspendLayout();
            SMSViewContainer.RecvLabel.Width = 490;
            SMSViewContainer.RecvLabel.Height = 25;
            SMSViewContainer.RecvLabel.Left = 0;
            SMSViewContainer.RecvLabel.Top = 0;
            SMSViewContainer.RecvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            SMSViewContainer.RecvLabel.Text = "Empfangene Nachricht:";

            SMSViewContainer.RecvTextbox = new TextBox();
            SMSViewContainer.RecvTextbox.SuspendLayout();
            SMSViewContainer.RecvTextbox.Width = 490;
            SMSViewContainer.RecvTextbox.Height = 121;
            SMSViewContainer.RecvTextbox.Left = 0;
            SMSViewContainer.RecvTextbox.Top = 35;
            SMSViewContainer.RecvTextbox.ReadOnly = true;
            SMSViewContainer.RecvTextbox.Multiline = true;
            SMSViewContainer.RecvTextbox.BackColor = System.Drawing.Color.White;

            SMSViewContainer.SendLabel = new Label();
            SMSViewContainer.SendLabel.SuspendLayout();
            SMSViewContainer.SendLabel.Width = 490;
            SMSViewContainer.SendLabel.Height = 25;
            SMSViewContainer.SendLabel.Left = 0;
            SMSViewContainer.SendLabel.Top = 157;
            SMSViewContainer.SendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold);
            SMSViewContainer.SendLabel.Text = "Neue Nachricht:";

            SMSViewContainer.SendTextbox = new TextBox();
            SMSViewContainer.SendTextbox.SuspendLayout();
            SMSViewContainer.SendTextbox.Width = 490;
            SMSViewContainer.SendTextbox.Height = 121;
            SMSViewContainer.SendTextbox.Left = 0;
            SMSViewContainer.SendTextbox.Top = 182;
            SMSViewContainer.SendTextbox.Multiline = true;

            parentPanel.Controls.Add(SMSViewContainer.RecvLabel);
            parentPanel.Controls.Add(SMSViewContainer.RecvTextbox);
            parentPanel.Controls.Add(SMSViewContainer.SendLabel);
            parentPanel.Controls.Add(SMSViewContainer.SendTextbox);

            SMSViewContainer.RecvLabel.ResumeLayout(false);
            SMSViewContainer.RecvTextbox.ResumeLayout(false);
            SMSViewContainer.SendLabel.ResumeLayout(false);
            SMSViewContainer.SendTextbox.ResumeLayout(false);
            parentPanel.ResumeLayout(false);
        }

        public void addWriteInput(KeyboardViewEventArgs keyboardViewEventArgs)
        {
            switch (keyboardViewEventArgs.Value)
            {
                case KeyboardButtons.AlphaA:
                    SMSViewContainer.SendTextbox.Text += "a";
                    break;
                case KeyboardButtons.AlphaB:
                    SMSViewContainer.SendTextbox.Text += "b";
                    break;
                case KeyboardButtons.AlphaC:
                    SMSViewContainer.SendTextbox.Text += "c";
                    break;
                case KeyboardButtons.AlphaD:
                    SMSViewContainer.SendTextbox.Text += "d";
                    break;
                case KeyboardButtons.AlphaE:
                    SMSViewContainer.SendTextbox.Text += "e";
                    break;
                case KeyboardButtons.AlphaF:
                    SMSViewContainer.SendTextbox.Text += "f";
                    break;
                case KeyboardButtons.AlphaG:
                    SMSViewContainer.SendTextbox.Text += "g";
                    break;
                case KeyboardButtons.AlphaH:
                    SMSViewContainer.SendTextbox.Text += "h";
                    break;
                case KeyboardButtons.AlphaI:
                    SMSViewContainer.SendTextbox.Text += "i";
                    break;
                case KeyboardButtons.AlphaJ:
                    SMSViewContainer.SendTextbox.Text += "j";
                    break;
                case KeyboardButtons.AlphaK:
                    SMSViewContainer.SendTextbox.Text += "k";
                    break;
                case KeyboardButtons.AlphaL:
                    SMSViewContainer.SendTextbox.Text += "l";
                    break;
                case KeyboardButtons.AlphaM:
                    SMSViewContainer.SendTextbox.Text += "m";
                    break;
                case KeyboardButtons.AlphaN:
                    SMSViewContainer.SendTextbox.Text += "n";
                    break;
                case KeyboardButtons.AlphaO:
                    SMSViewContainer.SendTextbox.Text += "o";
                    break;
                case KeyboardButtons.AlphaP:
                    SMSViewContainer.SendTextbox.Text += "p";
                    break;
                case KeyboardButtons.AlphaQ:
                    SMSViewContainer.SendTextbox.Text += "q";
                    break;
                case KeyboardButtons.AlphaR:
                    SMSViewContainer.SendTextbox.Text += "r";
                    break;
                case KeyboardButtons.AlphaS:
                    SMSViewContainer.SendTextbox.Text += "s";
                    break;
                case KeyboardButtons.AlphaT:
                    SMSViewContainer.SendTextbox.Text += "t";
                    break;
                case KeyboardButtons.AlphaU:
                    SMSViewContainer.SendTextbox.Text += "u";
                    break;
                case KeyboardButtons.AlphaV:
                    SMSViewContainer.SendTextbox.Text += "v";
                    break;
                case KeyboardButtons.AlphaW:
                    SMSViewContainer.SendTextbox.Text += "w";
                    break;
                case KeyboardButtons.AlphaX:
                    SMSViewContainer.SendTextbox.Text += "x";
                    break;
                case KeyboardButtons.AlphaY:
                    SMSViewContainer.SendTextbox.Text += "y";
                    break;
                case KeyboardButtons.AlphaZ:
                    SMSViewContainer.SendTextbox.Text += "z";
                    break;
                case KeyboardButtons.NumericOne:
                    SMSViewContainer.SendTextbox.Text += "1";
                    break;
                case KeyboardButtons.NumericTwo:
                    SMSViewContainer.SendTextbox.Text += "2";
                    break;
                case KeyboardButtons.NumericThree:
                    SMSViewContainer.SendTextbox.Text += "3";
                    break;
                case KeyboardButtons.NumericFour:
                    SMSViewContainer.SendTextbox.Text += "4";
                    break;
                case KeyboardButtons.NumericFive:
                    SMSViewContainer.SendTextbox.Text += "5";
                    break;
                case KeyboardButtons.NumericSix:
                    SMSViewContainer.SendTextbox.Text += "6";
                    break;
                case KeyboardButtons.NumericSeven:
                    SMSViewContainer.SendTextbox.Text += "7";
                    break;
                case KeyboardButtons.NumericEight:
                    SMSViewContainer.SendTextbox.Text += "8";
                    break;
                case KeyboardButtons.NumericNine:
                    SMSViewContainer.SendTextbox.Text += "9";
                    break;
                case KeyboardButtons.NumericZero:
                    SMSViewContainer.SendTextbox.Text += "0";
                    break;
                case KeyboardButtons.SpecialCharAt:
                    SMSViewContainer.SendTextbox.Text += "@";
                    break;
                case KeyboardButtons.SpecialCharSpace:
                    SMSViewContainer.SendTextbox.Text += " ";
                    break;
                case KeyboardButtons.SpecialCharReturn:
                    SMSViewContainer.SendTextbox.Text += "\n\r";
                    break;
                case KeyboardButtons.SpecialCharBackspace:
                    SMSViewContainer.SendTextbox.Text = SMSViewContainer.SendTextbox.Text.Substring(0, SMSViewContainer.SendTextbox.Text.Length-1);
                    break;
                case KeyboardButtons.PunctationDot:
                    SMSViewContainer.SendTextbox.Text += ".";
                    break;
                case KeyboardButtons.PunctationComma:
                    SMSViewContainer.SendTextbox.Text += ",";
                    break;
                case KeyboardButtons.PunctationQuestion:
                    SMSViewContainer.SendTextbox.Text += "?";
                    break;
                case KeyboardButtons.PunctationExclamation:
                    SMSViewContainer.SendTextbox.Text += "!";
                    break;
                case KeyboardButtons.UmlautA:
                    SMSViewContainer.SendTextbox.Text += "ä";
                    break;
                case KeyboardButtons.UmlautO:
                    SMSViewContainer.SendTextbox.Text += "ö";
                    break;
                case KeyboardButtons.UmlautU:
                    SMSViewContainer.SendTextbox.Text += "ü";
                    break;
                case KeyboardButtons.UmlautS:
                    SMSViewContainer.SendTextbox.Text += "ß";
                    break;
                default:
                    break;
            }
        }

        public void setWriteInput(string Text)
        {
            SMSViewContainer.SendTextbox.Text = Text;
        }

        public void setReadInput(string Text)
        {
            SMSViewContainer.RecvTextbox.Text = Text;
        }

        public object getData()
        {
            throw new NotImplementedException();
        }
    }
}
