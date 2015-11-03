using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IRoomAssetHistoryRepository : IRepository<RoomAssetHistory>
    {
        IList<RoomAssetHistory> GetByRoomId(Int64 id);
        IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace);
    }
}
