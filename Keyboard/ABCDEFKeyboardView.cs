using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KomMee
{
    /// <summary>
    /// Simple alphabetic ordered keyboard layout 
    /// </summary>
    public partial class ABCDEFKeyboardView : KomMee.KeyboardView
    {
        /// <summary>
        /// Text color of the focused buttons
        /// </summary>
        private Color FocusBackgroundColor = Color.Black;
        /// <summary>
        /// Background color of the focused buttons
        /// </summary>
        private Color FocusForegroundColor = Color.White; //System.Drawing.SystemColors.Control;
        /// <summary>
        /// Default text color of the buttons
        /// </summary>
        private Color DefaultBackgroundColor = Color.White; //System.Drawing.SystemColors.Control;
        /// <summary>
        /// Default background color of the buttons
        /// </summary>
        private Color DefaultForegroundColor = Color.Black;

        /// <summary>
        /// Number of buttons in a column (1 button equals 50px height)
        /// </summary>
        private const int keyboardHeight = 5;
        /// <summary>
        /// Number of buttons in a row (1 button equals 50px width)
        /// </summary>
        private const int keyboardWidth = 15;

        /// <summary>
        /// Matrix of the values of the buttons. Will be passed by the events.
        /// </summary>
        private KeyboardButtons[,] valueMatrix = null;

        /// <summary>
        /// Simple alphabetic ordered keyboard layout
        /// </summary>
        public ABCDEFKeyboardView()
        {
            InitializeComponent();

            this.initKeyboardMatrix();
        }

        /// <summary>
        /// This procedure should be called in the constructor of your class. In it you can set up attributes like the KeyboardMatrix.
        /// </summary>
        protected override void initKeyboardMatrix() {
            this.keyboardMatrix = new Button[ABCDEFKeyboardView.keyboardWidth, ABCDEFKeyboardView.keyboardHeight];
            this.valueMatrix = new KeyboardButtons[ABCDEFKeyboardView.keyboardWidth, ABCDEFKeyboardView.keyboardHeight];

            // Event layout
            // Row 0
            this.valueMatrix[0, 0] = KeyboardButtons.MenuMessageNew;
            this.valueMatrix[1, 0] = KeyboardButtons.MenuMessageNew;
            this.valueMatrix[2, 0] = KeyboardButtons.MenuMessageRecv;
            this.valueMatrix[3, 0] = KeyboardButtons.MenuMessageRecv;
            this.valueMatrix[4, 0] = KeyboardButtons.MenuMessageSent;
            this.valueMatrix[5, 0] = KeyboardButtons.MenuMessageSent;
            this.valueMatrix[6, 0] = KeyboardButtons.MenuContactNew;
            this.valueMatrix[7, 0] = KeyboardButtons.MenuContactNew;
            this.valueMatrix[8, 0] = KeyboardButtons.MenuContactEdit;
            this.valueMatrix[9, 0] = KeyboardButtons.MenuContactEdit;
            this.valueMatrix[10, 0] = KeyboardButtons.MenuContactDelete;
            this.valueMatrix[11, 0] = KeyboardButtons.MenuContactDelete;
            this.valueMatrix[12, 0] = KeyboardButtons.TextSend;
            this.valueMatrix[13, 0] = KeyboardButtons.TextSend;
            this.valueMatrix[14, 0] = KeyboardButtons.ApplicationClose;

            // Row 1
            this.valueMatrix[0, 1] = KeyboardButtons.NumericOne;
            this.valueMatrix[1, 1] = KeyboardButtons.NumericTwo;
            this.valueMatrix[2, 1] = KeyboardButtons.NumericThree;
            this.valueMatrix[3, 1] = KeyboardButtons.NumericFour;
            this.valueMatrix[4, 1] = KeyboardButtons.NumericFive;
            this.valueMatrix[5, 1] = KeyboardButtons.NumericSix;
            this.valueMatrix[6, 1] = KeyboardButtons.NumericSeven;
            this.valueMatrix[7, 1] = KeyboardButtons.NumericEight;
            this.valueMatrix[8, 1] = KeyboardButtons.NumericNine;
            this.valueMatrix[9, 1] = KeyboardButtons.NumericZero;
            this.valueMatrix[10, 1] = KeyboardButtons.UmlautS;
            this.valueMatrix[11, 1] = KeyboardButtons.SpecialCharAt;
            this.valueMatrix[12, 1] = KeyboardButtons.SpecialCharBackspace;
            this.valueMatrix[13, 1] = KeyboardButtons.SpecialCharBackspace;
            this.valueMatrix[14, 1] = KeyboardButtons.TextSizeUp;

            // Row 2
            this.valueMatrix[0, 2] = KeyboardButtons.AlphaA;
            this.valueMatrix[1, 2] = KeyboardButtons.AlphaB;
            this.valueMatrix[2, 2] = KeyboardButtons.AlphaC;
            this.valueMatrix[3, 2] = KeyboardButtons.AlphaD;
            this.valueMatrix[4, 2] = KeyboardButtons.AlphaE;
            this.valueMatrix[5, 2] = KeyboardButtons.AlphaF;
            this.valueMatrix[6, 2] = KeyboardButtons.AlphaG;
            this.valueMatrix[7, 2] = KeyboardButtons.AlphaH;
            this.valueMatrix[8, 2] = KeyboardButtons.AlphaI;
            this.valueMatrix[9, 2] = KeyboardButtons.AlphaJ;
            this.valueMatrix[10, 2] = KeyboardButtons.AlphaK;
            this.valueMatrix[11, 2] = KeyboardButtons.AlphaL;
            this.valueMatrix[12, 2] = KeyboardButtons.AlphaM;
            this.valueMatrix[13, 2] = KeyboardButtons.SpecialCharReturn;
            this.valueMatrix[14, 2] = KeyboardButtons.TextSizeDown;

            // Row 3
            this.valueMatrix[0, 3] = KeyboardButtons.AlphaN;
            this.valueMatrix[1, 3] = KeyboardButtons.AlphaO;
            this.valueMatrix[2, 3] = KeyboardButtons.AlphaP;
            this.valueMatrix[3, 3] = KeyboardButtons.AlphaQ;
            this.valueMatrix[4, 3] = KeyboardButtons.AlphaR;
            this.valueMatrix[5, 3] = KeyboardButtons.AlphaS;
            this.valueMatrix[6, 3] = KeyboardButtons.AlphaT;
            this.valueMatrix[7, 3] = KeyboardButtons.AlphaU;
            this.valueMatrix[8, 3] = KeyboardButtons.AlphaV;
            this.valueMatrix[9, 3] = KeyboardButtons.AlphaW;
            this.valueMatrix[10, 3] = KeyboardButtons.AlphaX;
            this.valueMatrix[11, 3] = KeyboardButtons.AlphaY;
            this.valueMatrix[12, 3] = KeyboardButtons.AlphaZ;
            this.valueMatrix[13, 3] = KeyboardButtons.SpecialCharReturn;
            this.valueMatrix[14, 3] = KeyboardButtons.TextToSpeech;

            // Row 4
            this.valueMatrix[0, 4] = KeyboardButtons.UmlautA;
            this.valueMatrix[1, 4] = KeyboardButtons.UmlautO;
            this.valueMatrix[2, 4] = KeyboardButtons.UmlautU;
            this.valueMatrix[3, 4] = KeyboardButtons.SpecialCharSpace;
            this.valueMatrix[4, 4] = KeyboardButtons.SpecialCharSpace;
            this.valueMatrix[5, 4] = KeyboardButtons.SpecialCharSpace;
            this.valueMatrix[6, 4] = KeyboardButtons.SpecialCharSpace;
            this.valueMatrix[7, 4] = KeyboardButtons.SpecialCharSpace;
            this.valueMatrix[8, 4] = KeyboardButtons.SpecialCharSpace;
            this.valueMatrix[9, 4] = KeyboardButtons.SpecialCharSpace;
            this.valueMatrix[10, 4] = KeyboardButtons.PunctationDot;
            this.valueMatrix[11, 4] = KeyboardButtons.PunctationComma;
            this.valueMatrix[12, 4] = KeyboardButtons.PunctationQuestion;
            this.valueMatrix[13, 4] = KeyboardButtons.PunctationExclamation;
            this.valueMatrix[14, 4] = KeyboardButtons.NotInUse;

            // Button layout
            // Row 0
            this.keyboardMatrix[0, 0] = this.BtMenuMessageNew;
            this.keyboardMatrix[1, 0] = this.BtMenuMessageNew;
            this.keyboardMatrix[2, 0] = this.BtMenuMessageRecv;
            this.keyboardMatrix[3, 0] = this.BtMenuMessageRecv;
            this.keyboardMatrix[4, 0] = this.BtMenuMessageSent;
            this.keyboardMatrix[5, 0] = this.BtMenuMessageSent;
            this.keyboardMatrix[6, 0] = this.BtMenuContactAdd;
            this.keyboardMatrix[7, 0] = this.BtMenuContactAdd;
            this.keyboardMatrix[8, 0] = this.BtMenuContactEdit;
            this.keyboardMatrix[9, 0] = this.BtMenuContactEdit;
            this.keyboardMatrix[10, 0] = this.BtMenuContactDelete;
            this.keyboardMatrix[11, 0] = this.BtMenuContactDelete;
            this.keyboardMatrix[12, 0] = this.BtMenuSend;
            this.keyboardMatrix[13, 0] = this.BtMenuSend;
            this.keyboardMatrix[14, 0] = this.BtMenuClose;
            
            // Row 1
            this.keyboardMatrix[0, 1] = this.BtNum1;
            this.keyboardMatrix[1, 1] = this.BtNum2;
            this.keyboardMatrix[2, 1] = this.BtNum3;
            this.keyboardMatrix[3, 1] = this.BtNum4;
            this.keyboardMatrix[4, 1] = this.BtNum5;
            this.keyboardMatrix[5, 1] = this.BtNum6;
            this.keyboardMatrix[6, 1] = this.BtNum7;
            this.keyboardMatrix[7, 1] = this.BtNum8;
            this.keyboardMatrix[8, 1] = this.BtNum9;
            this.keyboardMatrix[9, 1] = this.BtNum0;
            this.keyboardMatrix[10, 1] = this.BtUmlS;
            this.keyboardMatrix[11, 1] = this.BtSpecAt;
            this.keyboardMatrix[12, 1] = this.BtSpecBackspace;
            this.keyboardMatrix[13, 1] = this.BtSpecBackspace;
            this.keyboardMatrix[14, 1] = this.BtMenuFontBigger;

            // Row 2
            this.keyboardMatrix[0, 2] = this.BtAlphaA;
            this.keyboardMatrix[1, 2] = this.BtAlphaB;
            this.keyboardMatrix[2, 2] = this.BtAlphaC;
            this.keyboardMatrix[3, 2] = this.BtAlphaD;
            this.keyboardMatrix[4, 2] = this.BtAlphaE;
            this.keyboardMatrix[5, 2] = this.BtAlphaF;
            this.keyboardMatrix[6, 2] = this.BtAlphaG;
            this.keyboardMatrix[7, 2] = this.BtAlphaH;
            this.keyboardMatrix[8, 2] = this.BtAlphaI;
            this.keyboardMatrix[9, 2] = this.BtAlphaJ;
            this.keyboardMatrix[10, 2] = this.BtAlphaK;
            this.keyboardMatrix[11, 2] = this.BtAlphaL;
            this.keyboardMatrix[12, 2] = this.BtAlphaM;
            this.keyboardMatrix[13, 2] = this.BtSpecReturn;
            this.keyboardMatrix[14, 2] = this.BtMenuFontSmaller;

            // Row 3
            this.keyboardMatrix[0, 3] = this.BtAlphaN;
            this.keyboardMatrix[1, 3] = this.BtAlphaO;
            this.keyboardMatrix[2, 3] = this.BtAlphaP;
            this.keyboardMatrix[3, 3] = this.BtAlphaQ;
            this.keyboardMatrix[4, 3] = this.BtAlphaR;
            this.keyboardMatrix[5, 3] = this.BtAlphaS;
            this.keyboardMatrix[6, 3] = this.BtAlphaT;
            this.keyboardMatrix[7, 3] = this.BtAlphaU;
            this.keyboardMatrix[8, 3] = this.BtAlphaV;
            this.keyboardMatrix[9, 3] = this.BtAlphaW;
            this.keyboardMatrix[10, 3] = this.BtAlphaX;
            this.keyboardMatrix[11, 3] = this.BtAlphaY;
            this.keyboardMatrix[12, 3] = this.BtAlphaZ;
            this.keyboardMatrix[13, 3] = this.BtSpecReturn;
            this.keyboardMatrix[14, 3] = this.BtMenuTextToSpeech;

            // Row 4
            this.keyboardMatrix[0, 4] = this.BtUmlA;
            this.keyboardMatrix[1, 4] = this.BtUmlO;
            this.keyboardMatrix[2, 4] = this.BtUmlU;
            this.keyboardMatrix[3, 4] = this.BtSpecSpace;
            this.keyboardMatrix[4, 4] = this.BtSpecSpace;
            this.keyboardMatrix[5, 4] = this.BtSpecSpace;
            this.keyboardMatrix[6, 4] = this.BtSpecSpace;
            this.keyboardMatrix[7, 4] = this.BtSpecSpace;
            this.keyboardMatrix[8, 4] = this.BtSpecSpace;
            this.keyboardMatrix[9, 4] = this.BtSpecSpace;
            this.keyboardMatrix[10, 4] = this.BtPunctDot;
            this.keyboardMatrix[11, 4] = this.BtPunctComma;
            this.keyboardMatrix[12, 4] = this.BtPunctQuestion;
            this.keyboardMatrix[13, 4] = this.BtPunctExclamation;
            this.keyboardMatrix[14, 4] = null;

            foreach (Button button in this.keyboardMatrix)
            {
                if (button != null)
                {
                    button.ForeColor = this.DefaultForegroundColor;
                    button.BackColor = this.DefaultBackgroundColor;
                }
            }

            // Select default focus (G)
            this.setNewFocus(new Point(6, 2));
        }

        /// <summary>
        /// Sets the new focused button
        /// </summary>
        /// <param name="newFocusPosition">The position in the matrix of the new focus</param>
        private void setNewFocus(Point newFocusPosition)
        {
            this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].ForeColor = this.DefaultForegroundColor;
            this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].BackColor = this.DefaultBackgroundColor;
            this.focusPosition = newFocusPosition;
            this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].ForeColor = this.FocusForegroundColor;
            this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].BackColor = this.FocusBackgroundColor;
        }

        /// <summary>
        /// This procedure is called when the user pressed the "up" button. You should update the selection.
        /// </summary>
        public override void up() {
            Point newFocusPosition = this.focusPosition;
            do
            {
                if (newFocusPosition.Y == 0)
                    newFocusPosition = new Point(newFocusPosition.X, ABCDEFKeyboardView.keyboardHeight - 1);
                else
                    newFocusPosition = new Point(newFocusPosition.X, newFocusPosition.Y - 1);
            } while (this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].Equals(this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y])
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Enabled == false
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Visible == false);

            this.setNewFocus(newFocusPosition);
        }

        /// <summary>
        /// This procedure is called when the user pressed the "down" button. You should update the selection.
        /// </summary>
        public override void down()
        {
            Point newFocusPosition = this.focusPosition;
            do
            {
                if (newFocusPosition.Y == ABCDEFKeyboardView.keyboardHeight - 1)
                    newFocusPosition = new Point(newFocusPosition.X, 0);
                else
                    newFocusPosition = new Point(newFocusPosition.X, newFocusPosition.Y + 1);
            } while (this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].Equals(this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y])
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Enabled == false
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Visible == false);

            this.setNewFocus(newFocusPosition);
        }

        /// <summary>
        /// This procedure is called when the user pressed the "left" button. You should update the selection.
        /// </summary>
        public override void left()
        {
            Point newFocusPosition = this.focusPosition;
            do
            {
                if (newFocusPosition.X == 0)
                    newFocusPosition = new Point(ABCDEFKeyboardView.keyboardWidth - 1, newFocusPosition.Y);
                else
                    newFocusPosition = new Point(newFocusPosition.X - 1, newFocusPosition.Y);
            } while (this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].Equals(this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y])
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Enabled == false
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Visible == false);

            this.setNewFocus(newFocusPosition);
        }

        /// <summary>
        /// This procedure is called when the user pressed the "right" button. You should update the selection.
        /// </summary>
        public override void right()
        {
            Point newFocusPosition = this.focusPosition;
            do
            {
                if (newFocusPosition.X == ABCDEFKeyboardView.keyboardWidth - 1)
                    newFocusPosition = new Point(0, newFocusPosition.Y);
                else
                    newFocusPosition = new Point(newFocusPosition.X + 1, newFocusPosition.Y);
            } while (this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y].Equals(this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y])
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Enabled == false
                || this.keyboardMatrix[newFocusPosition.X, newFocusPosition.Y].Visible == false);

            this.setNewFocus(newFocusPosition);
        }

        /// <summary>
        /// This procedure is called when the user pressed the "Apply" button. You should raise here some events.
        /// </summary>
        public override void apply() {
            // Raise the OnApply-Event
            this.OnApply(this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y], new KeyboardViewEventArgs(this.valueMatrix[this.focusPosition.X, this.focusPosition.Y]));
        }

        /// <summary>
        /// This procedure is called when the user pressed the "Cancel" button.
        /// </summary>
        public override void cancel() {
            // Raise the OnCancel-Event
            this.OnCancel(this.keyboardMatrix[this.focusPosition.X, this.focusPosition.Y], new KeyboardViewEventArgs(this.valueMatrix[this.focusPosition.X, this.focusPosition.Y]));
        }
    }
}
