using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;

namespace RoomM.Domain.AssetModule.Aggregates
{
    public interface IAssetHistoryRepository : IRepository<AssetHistory>
    {
        IList<AssetHistory> GetByRoomId(Int64 id);

        IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace);
    }
}