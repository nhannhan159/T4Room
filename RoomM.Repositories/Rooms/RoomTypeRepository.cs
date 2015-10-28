using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(EFDataContext _entities)
            : base(_entities)
        { }

        public RoomType GetSingle(int roomTypeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomTypeId);
            return query;
        }
    }
}
