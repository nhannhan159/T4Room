using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IRoomAssetHistoryTypeRepository : IRepository<HistoryType>
    {
        HistoryType GetSingle(int id);      
    }
}
