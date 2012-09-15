using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomMee
{
    public class EMailMessage : Message
    {
        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
		}
		public EMailMessage(object data)
            : base(data)
        {
        }

        public override bool send()
        {
            throw new NotImplementedException();
        }

        protected override string validateSender(string sender)
        {
            throw new NotImplementedException();
        }

        public override void save()
        {
            throw new NotImplementedException();
        }

        public override void delete()
        {
            throw new NotImplementedException();
        }
    }
}
