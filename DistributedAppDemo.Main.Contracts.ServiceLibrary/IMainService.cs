using System;
using System.Collections.Generic;
using DistributedAppDemo.Main.Contracts.ServiceLibrary.DTO;

namespace DistributedAppDemo.Main.Contracts.ServiceLibrary
{
    public interface IMainService
    {
        List<ContactDTO> Getcontacts(Func<ContactDTO, bool> predicate);
        void Process(ProcessRequestDTO request);
    }
}