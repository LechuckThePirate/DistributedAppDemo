using System;
using DistributedAppDemo.Main.Contracts.ServiceLibrary.Enums;

namespace DistributedAppDemo.Main.Contracts.ServiceLibrary.DTO
{
    public class ProcessRequestDTO
    {
        public enum ProcessTypeEnum
        {
            Newsletter,
            WelcomeEmail
        }

        public Guid ProcessRequestId { get; set; }
        public ContactDTO Sender { get; set; }
        public ContactDTO Receiver { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Rendered { get; set; }
        public DateTime? Sent { get; set; }
        public DateTime? Finished { get; set; }
        public ProcessTypeEnum ProcessType { get; set; }
    }
}
