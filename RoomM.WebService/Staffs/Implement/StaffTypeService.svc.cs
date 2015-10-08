using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Repositories.Staffs;
using RoomM.Models.Staffs;

namespace RoomM.WebService.Staffs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaffTypeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaffTypeService.svc or StaffTypeService.svc.cs at the Solution Explorer and start debugging.
    public class StaffTypeService : IStaffTypeService
    {
        private IStaffTypeRepository staffTypeRepository;

        public StaffTypeService()
        {
            this.staffTypeRepository = new StaffTypeRepository();
        }

        public StaffType GetSingle(int staffTypeId)
        {
            return this.staffTypeRepository.GetSingle(staffTypeId);
        }
    }
}
