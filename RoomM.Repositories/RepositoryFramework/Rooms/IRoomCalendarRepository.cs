using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IRoomCalendarRepository : IRepository<RoomCalendar>
    {
        IList<RoomCalendar> GetByRoomId(Int64 roomId);
        IList<RoomCalendar> GetByStaffId(Int64 staffId);
        IList<RoomCalendar> GetByDate(DateTime date);
        IList<RoomCalendar> GetByDateAndRoomId(DateTime date, Int64 roomId);
        IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, Int64 roomId);
        IList<RoomCalendar> GetByWatchedState(bool isWatched, Int64 staffId);
        IList<RoomCalendar> GetByRegisteredState(int registeredState, Int64 staffId);
    }
}
