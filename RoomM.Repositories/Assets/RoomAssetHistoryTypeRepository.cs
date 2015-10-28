using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomAssetHistoryTypeRepository : RepositoryBase<HistoryType>, IRoomAssetHistoryTypeRepository
    {
        public RoomAssetHistoryTypeRepository(EFDataContext _entities)
            : base(_entities)
        { }

        public HistoryType GetSingle(int typeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == typeId);
            return query;
        }
    }
}
