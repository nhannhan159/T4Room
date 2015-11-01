using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaffTypeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaffTypeService.svc or StaffTypeService.svc.cs at the Solution Explorer and start debugging.
    public class StaffTypeService : ServiceBase<StaffType>, IStaffTypeService
    {
        public StaffTypeService(EFDataContext context)
            : base(context)
        {
            this.repo = (IRepository<StaffType>)this.uow.StaffTypeRepository;
        }

        public StaffType GetSingle(int staffTypeId)
        {
            return this.uow.StaffTypeRepository.GetSingle(staffTypeId);
        }
    }
}
