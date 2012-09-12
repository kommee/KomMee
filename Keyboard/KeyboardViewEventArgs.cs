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
    
}
