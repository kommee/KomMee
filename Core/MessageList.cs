using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KomMee
{
    public class MessageList : List<Message>
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
