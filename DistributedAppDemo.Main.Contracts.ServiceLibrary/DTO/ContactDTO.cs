using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributedAppDemo.Main.Contracts.ServiceLibrary.Enums;

namespace DistributedAppDemo.Main.Contracts.ServiceLibrary.DTO
{
    public class ContactDTO
    {
        public enum ContactTypeEnum
        {
            Other,
            Person,
            Customer,
            Provider
        }

        public Guid ContactId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public ContactTypeEnum ContactType { get; set; }
    }
}
