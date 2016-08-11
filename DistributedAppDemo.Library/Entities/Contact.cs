using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedAppDemo.Library.Entities
{
    public class Contact
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
