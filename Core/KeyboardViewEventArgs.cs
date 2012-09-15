using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomMee
{
    
    /// <summary>
    /// Event arguments. Contains only more detailed information about the pressed button.
    /// </summary>
    public class KeyboardViewEventArgs : EventArgs
    {
        private KeyboardButtons specificValue;
        private bool isMenu;

        /// <summary>
        /// Detailed information about the pressed button.
        /// </summary>
        public KeyboardButtons Value
        {
            get { return specificValue; }
            set { specificValue = value; }
        }

        /// <summary>
        /// Values if the argument is a printable char
        /// </summary>
        public bool IsMenu
        {
            get { return isMenu; }
            set { isMenu = value; }
        }

        /// <summary>
        /// Creates a event argument with detailed information about the pressed button.
        /// </summary>
        /// <param name="value">Detailed information about the pressed button</param>
        public KeyboardViewEventArgs(KeyboardButtons value, bool isMenu)
        {
            this.specificValue = value;
            this.isMenu = isMenu;
        }
    }
    
}
