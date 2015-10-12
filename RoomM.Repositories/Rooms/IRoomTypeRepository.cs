using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IRoomTypeRepository : IRepository<RoomType>
    {
        RoomType GetSingle(int roomTypeId);
    }
}
