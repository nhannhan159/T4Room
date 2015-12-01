using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomM.Infrastructure.Data.AssetModule.Repositories
{
    public class AssetHistoryRepository : Repository<AssetHistory>, IAssetHistoryRepository
    {
        public AssetHistoryRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "Asset,Room";
        }

        public IList<AssetHistory> GetByRoomId(Int64 id)
        {
            return this.Get(filter: p => p.RoomId == id).ToList();
        }

        public IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return this.Get(
                filter: p => p.Room2.Equals(room.Name) || p.RoomId == room.Id,
                orderBy: q => q.OrderBy(d => d.Date)).ToList();
        }
    }
}