using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Staffs
{
    public class StaffTypeRepository : RepositoryBase<EFDataContext, StaffType>, IStaffTypeRepository
    {

        public StaffTypeRepository()
        { 
        
        }

        public StaffType GetSingle(int staffTypeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == staffTypeId);
            return query;
        }
    }
}
