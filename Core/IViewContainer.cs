using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KomMee
{
    public interface IViewContainer
    {
        void createViewForReading(Panel parentPanel);
        void createViewForNew(Panel parentPanel);
        void createViewForAnswer(Panel parentPanel);
        void addWriteInput(KeyboardViewEventArgs keyboardViewEventArgs);
        void setWriteInput(string Text);
        void setReadInput(string Text);
        object getData();
    }
}
