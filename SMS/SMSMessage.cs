using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomMee
{
    public class SMSMessage : Message
    {
        public SMSMessage(object data)
            : base(data)
        {
        }
        public override bool send()
        {
            throw new NotImplementedException();
        }
    }
}
