using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Domain.RoomModule.Aggregates
{
    public interface IRoomRepository : IRepository<Room>
    {
        IList<Room> GetByRoomTypeId(Int64 roomTypeId);
        IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to);
        bool isUniqueName(string name);
    }
}
