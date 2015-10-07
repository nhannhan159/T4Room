using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Staffs
{
    public interface IStaffTypeRepository : IRepository<StaffType>
    {
        StaffType GetSingle(int staffTypeId);
    }
}
