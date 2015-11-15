using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Domain.AssetModule.Aggregates
{
    public interface IAssetHistoryRepository : IRepository<AssetHistory>
    {
        IList<AssetHistory> GetByRoomId(Int64 id);
        IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace);
    }
}
