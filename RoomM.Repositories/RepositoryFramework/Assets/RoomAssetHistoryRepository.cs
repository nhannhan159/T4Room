using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomAssetHistoryRepository : RepositoryBase<RoomAssetHistory>, IRoomAssetHistoryRepository
    {
        public RoomAssetHistoryRepository(EFDataContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "HistoryType,Asset,Room";
        }

        public IList<RoomAssetHistory> GetByRoomId(Int64 id)
        {
            return this.Get(filter: p => p.RoomId == id).ToList();
        }

        public IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return this.Get(
                filter: p => p.Room2.Equals(room.Name) || p.RoomId == room.ID,
                orderBy: q => q.OrderBy(d => d.Date)).ToList();
        }
    }
}
