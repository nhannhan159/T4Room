using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Assets
{
    public interface IRoomAssetHistoryTypeRepository : IRepository<HistoryType>
    {
        HistoryType GetSingle(int id);
        
        
    }
}
