using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Repositories.Rooms;
using RoomM.Models.Rooms;

namespace RoomM.WebService.Rooms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomCalenderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomCalenderService.svc or RoomCalenderService.svc.cs at the Solution Explorer and start debugging.
    public class RoomCalenderService : IRoomCalenderService
    {
        private IRoomCalendarRepository roomCalendarRepository;

        public RoomCalenderService()
        {
            this.roomCalendarRepository = new RoomCalendarRepository();
        }

        public RoomCalendar GetSingle(int roomCalId)
        {
            return this.roomCalendarRepository.GetSingle(roomCalId);
        }

        public IList<RoomCalendar> GetByRoomId(Int64 roomId)
        {
            return this.roomCalendarRepository.GetByRoomId(roomId);
        }


        public IList<RoomCalendar> GetByStaffId(Int64 staffId)
        {
            return this.roomCalendarRepository.GetByStaffId(staffId);
        }


        public IList<RoomCalendar> GetByDate(DateTime date)
        {
            return this.roomCalendarRepository.GetByDate(date);
        }


        public IList<RoomCalendar> GetByDateAndRoomId(DateTime date, long roomId)
        {
            return this.roomCalendarRepository.GetByDateAndRoomId(date, roomId);
        }


        public IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, long roomId)
        {
            return this.roomCalendarRepository.GetByWeekAndRoomId(date, roomId);
        }


        public IList<RoomCalendar> GetByWatchedState(bool isWatched, int staffId)
        {
            return this.roomCalendarRepository.GetByWatchedState(isWatched, staffId);
        }


        public IList<RoomCalendar> GetByRegisteredState(int registeredState, int staffId)
        {
            return this.roomCalendarRepository.GetByRegisteredState(registeredState, staffId);
        }
    }
}
