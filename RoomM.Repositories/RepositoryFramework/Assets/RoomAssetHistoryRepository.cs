using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomAssetHistoryRepository : RepositoryBase<RoomAssetHistory>, IRoomAssetHistoryRepository
    {
        public RoomAssetHistoryRepository(EFDataContext context)
            : base(context)
        { }

        public IList<RoomAssetHistory> GetByRoomId(Int64 id)
        {
            return (from p in GetAllWithQuery()
                    where p.Room.ID == id
                    select p).ToList();
        }

        public IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return (from p in GetAllWithQuery()
                    where (p.Room2.Equals(room.Name) || p.Room.ID == room.ID)
                    orderby p.Date
                    select p).ToList();
        }
    }
}
