using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.Infrastructure.Data.AssetModule.Repositories
{
    public class AssetHistoryRepository : Repository<AssetHistory>, IAssetHistoryRepository
    {
        public AssetHistoryRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "AssetHistoryType,Asset,Room";
        }

        public IList<AssetHistory> GetByRoomId(Int64 id)
        {
            return this.Get(filter: p => p.RoomId == id).ToList();
        }

        public IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return this.Get(
                filter: p => p.Room2.Equals(room.Name) || p.RoomId == room.ID,
                orderBy: q => q.OrderBy(d => d.Date)).ToList();
        }
    }
}
