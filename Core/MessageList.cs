using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomMee
{
    class MessageList : List<Message>
    {
        private static MessageList msgListInstance = new MessageList();

        private MessageList()
        {
        }

        public static MessageList getInstance()
        {
            return MessageList.msgListInstance;
        }
    }
}
