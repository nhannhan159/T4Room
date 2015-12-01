using System;
using System.Collections.Generic;

namespace RoomM.Domain.RoomModule.Aggregates
{
    public interface IRoomRepository : IRepository<Room>
    {
        IList<Room> GetByRoomTypeId(Int64 roomTypeId);

        IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to);
    }
}