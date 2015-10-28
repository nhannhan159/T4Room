using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room GetSingle(Int64 roomId);
        IList<Room> GetByRoomTypeId(Int64 roomTypeId);
        IList<Room> GetRoomListLimitByRegister(int limit);
        List<DictionaryEntry> GetRoomLimitByRegister(int limit, DateTime from, DateTime to);
        bool isUniqueName(string name);
    }
}
