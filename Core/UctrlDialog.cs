using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomMee
{
    public partial class UctrlDialog : UserControl
    {
        public UctrlDialog()
        {
            InitializeComponent();
            // Same size as the Usercontrol
            this.LbChoice.Width = this.Width;
            this.LbChoice.Height = this.Height;
        }

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

        /// <summary>
        /// This procedure is called when the user pressed the "up" button. You should update the selection.
        /// </summary>
        public virtual void up() { }

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
        public virtual void apply() { }

        /// <summary>
        /// This procedure is called when the user pressed the "Cancel" button.
        /// </summary>
        public virtual void cancel() { }
    }
}
