using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomTypeRepository : RepositoryBase<EFDataContext, RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository()
        { }

        public RoomType GetSingle(int roomTypeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomTypeId);
            return query;
        }
    }
}
