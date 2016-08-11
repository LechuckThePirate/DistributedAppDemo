using System;
using System.Collections.Generic;
using System.Linq;
using DistributedAppDemo.Main.Contracts.ServiceLibrary;
using DistributedAppDemo.Main.Contracts.ServiceLibrary.DTO;
using DistributedAppDemo.Main.Contracts.ServiceLibrary.Enums;
using DistributedAppDemo.Renderer.Contracts.ServiceLibrary;

namespace DistributedAppDemo.Main.Impl.ServiceLibrary
{
    public class MainService : IMainService
    {

        private readonly IRenderServiceTransport _renderServiceTransport;

        public MainService(IRenderServiceTransport renderServiceTransport)
        {
            _renderServiceTransport = renderServiceTransport;
        }

        public List<ContactDTO> Getcontacts(Func<ContactDTO, bool> predicate)
        {
            return new List<ContactDTO>
            {
                new ContactDTO
                {
                    Name = "Joan",
                    Surname = "Vilariño",
                    Email = "joan.vilarino@gmail.com",
                    Type = ContactTypeEnum.Person
                },
                new ContactDTO
                {
                    Name = "Pepe",
                    Surname = "Flores",
                    Email = "pepe.flores@gmail.com",
                    Type = ContactTypeEnum.Person
                },
                new ContactDTO
                {
                    Name = "Imvery",
                    Surname = "Rich",
                    Email = "millions.galore@therichcompany.com",
                    Company = "The Rich Company",
                    Type = ContactTypeEnum.Customer
                },
                new ContactDTO
                {
                    Name = "John",
                    Surname = "Smith",
                    Email = "john.smith@thebigcompany.com",
                    Company = "The Big Company",
                    Type = ContactTypeEnum.Provider
                }
            }
            .Where(predicate).ToList();
        }

        public void Process(ProcessRequestDTO request)
        {
            _renderServiceTransport.Send(request);
        }
    }
}
