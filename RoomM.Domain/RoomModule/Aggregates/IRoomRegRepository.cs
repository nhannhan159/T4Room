using System;
using System.Collections.Generic;

namespace RoomM.Domain.RoomModule.Aggregates
{
    public interface IRoomRegRepository : IRepository<RoomReg>
    {
        IList<RoomReg> GetByRoomId(Int64 roomId);

        IList<RoomReg> GetByUserId(Int64 userId);

        IList<RoomReg> GetByDate(DateTime date);

        IList<RoomReg> GetByDateAndRoomId(DateTime date, Int64 roomId);

        IList<RoomReg> GetByWeekAndRoomId(DateTime date, Int64 roomId);

        IList<RoomReg> GetByWatchedState(bool isWatched, Int64 userId);

        IList<RoomReg> GetByRegisteredState(int registeredState, Int64 userId);
    }
}