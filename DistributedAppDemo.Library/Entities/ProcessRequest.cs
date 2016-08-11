using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedAppDemo.Library.Entities
{
    public class ProcessRequest
    {
        public enum ProcessTypeEnum
        {
            Newsletter,
            WelcomeEmail
        }

        public Guid ProcessRequestId { get; set; }
        public Contact Sender { get; set; }
        public Contact Receiver { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Rendered { get; set; }
        public DateTime? Sent { get; set; }
        public DateTime? Finished { get; set; }
        public ProcessTypeEnum ProcessType { get; set; }

    }
}
