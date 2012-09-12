using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyboardLayout
{
    /// <summary>
    /// Event arguments. Contains only more detailed information about the pressed button.
    /// </summary>
    public class KeyboardViewEventArgs: EventArgs
    {
        private KeyboardButtons specificValue;

        /// <summary>
        /// Detailed information about the pressed button.
        /// </summary>
        public KeyboardButtons Value
        {
            get { return specificValue; }
            set { specificValue = value; }
        }

        /// <summary>
        /// Creates a event argument with detailed information about the pressed button.
        /// </summary>
        /// <param name="value">Detailed information about the pressed button</param>
        public KeyboardViewEventArgs(KeyboardButtons value)
        {
            this.specificValue = value;
        }
    }

    /// <summary>
    /// Empty keyboardlayout for the input device.
    /// </summary>
    public partial class KeyboardView : UserControl
    {
        /// <summary>
        /// Matrix, in which all buttons are saved.
        /// </summary>
        protected Button[,] keyboardMatrix = null;
        /// <summary>
        /// Current focused button position in the matrix.
        /// </summary>
        protected Point focusPosition = new Point(0,0);

        /// <summary>
        /// Eventhandler for applying.
        /// </summary>
        public event EventHandler Applied;
        /// <summary>
        /// Eventhandler for canceling.
        /// </summary>
        public event EventHandler Canceled;

        /// <summary>
        /// Is raised when the apply-button was pushed.
        /// </summary>
        /// <param name="sender">Button which was applied</param>
        /// <param name="e">The specific button which was applied</param>
        protected virtual void OnApply(Button sender, KeyboardViewEventArgs e)
        {
            if (Applied != null)
            {
                Applied(this, e);
            }
        }

        /// <summary>
        /// Is raised when the cancel-button was pushed.
        /// </summary>
        /// <param name="sender">Button which was canceled</param>
        /// <param name="e">The specific button which was canceled</param>
        protected virtual void OnCancel(Button sender, KeyboardViewEventArgs e)
        {
            if (Canceled != null)
            {
                Canceled(this, e);
            }
        }
        

        public KeyboardView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This procedure should be called in the constructor of your class. In it you can set up attributes like the KeyboardMatrix.
        /// </summary>
        protected virtual void initKeyboardMatrix() { }

        /// <summary>
        /// This procedure is called when the user pressed the "up" button. You should update the selection.
        /// </summary>
        public virtual void up(){}

        /// <summary>
        /// This procedure is called when the user pressed the "down" button. You should update the selection.
        /// </summary>
        public virtual void down() { }

        /// <summary>
        /// This procedure is called when the user pressed the "left" button. You should update the selection.
        /// </summary>
        public virtual void left() { }

        /// <summary>
        /// This procedure is called when the user pressed the "right" button. You should update the selection.
        /// </summary>
        public virtual void right() { }

        /// <summary>
        /// This procedure is called when the user pressed the "Apply" button. You should raise here some events.
        /// </summary>
        public virtual void apply() {  }

        /// <summary>
        /// This procedure is called when the user pressed the "Cancel" button.
        /// </summary>
        public virtual void cancel() { }
    }
}
