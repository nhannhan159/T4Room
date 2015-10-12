using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomAssetHistoryTypeRepository : RepositoryBase<EFDataContext, HistoryType>, IRoomAssetHistoryTypeRepository
    {
        public RoomAssetHistoryTypeRepository()
        { }

        public HistoryType GetSingle(int typeId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == typeId);
            return query;
        }
    }
}
