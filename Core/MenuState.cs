using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomMee
{
    public enum MenuState
    {
        None,
        ViewMessage,
        AnswerMessage,
        DeleteMessage,
        NewMessage,
        ChoseReceiver,
        ChoseMessageType,
        AddNewContact,
        EditContact,
        DeleteContact,
        AddMessageTypeToContact
    }
}
