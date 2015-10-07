using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    // public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    public class RoomTypeRepository : RepositoryBase<EFDataContext, RoomType>, IRoomTypeRepository
    {

        public RoomTypeRepository()
        { 
        
        }

        public RoomType GetSingle(int roomTypeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomTypeId);
            return query;
        }
    }
}
