using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IRoomCalendarRepository : IRepository<RoomCalendar>
    {
        RoomCalendar GetSingle(int roomCalId);
        IList<RoomCalendar> GetByRoomId(Int64 roomId);
        IList<RoomCalendar> GetByStaffId(Int64 staffId);
        IList<RoomCalendar> GetByDate(DateTime date);
        IList<RoomCalendar> GetByDateAndRoomId(DateTime date, long roomId);
        IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, long roomId);
        IList<RoomCalendar> GetByWatchedState(bool isWatched, int staffId);
        IList<RoomCalendar> GetByRegisteredState(int registeredState, int staffId);
    }
}
