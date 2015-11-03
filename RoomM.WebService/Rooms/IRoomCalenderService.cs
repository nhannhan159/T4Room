using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomCalenderService" in both code and config file together.
    [ServiceContract]
    public interface IRoomCalenderService : IService<RoomCalendar>
    {
        [OperationContract]
        IList<RoomCalendar> GetByRoomId(Int64 roomId);

        [OperationContract]
        IList<RoomCalendar> GetByStaffId(Int64 staffId);

        [OperationContract]
        IList<RoomCalendar> GetByDate(DateTime date);

        [OperationContract]
        IList<RoomCalendar> GetByDateAndRoomId(DateTime date, Int64 roomId);

        [OperationContract]
        IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, Int64 roomId);

        [OperationContract]
        IList<RoomCalendar> GetByWatchedState(bool isWatched, Int64 staffId);

        [OperationContract]
        IList<RoomCalendar> GetByRegisteredState(int registeredState, Int64 staffId);
    }
}
