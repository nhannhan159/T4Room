using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class StaffTypeRepository : RepositoryBase<StaffType>, IStaffTypeRepository
    {
        public StaffTypeRepository(EFDataContext _entities)
            : base(_entities)
        { }

        public StaffType GetSingle(int staffTypeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == staffTypeId);
            return query;
        }
    }
}
