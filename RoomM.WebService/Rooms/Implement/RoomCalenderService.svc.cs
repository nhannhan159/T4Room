using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomCalenderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomCalenderService.svc or RoomCalenderService.svc.cs at the Solution Explorer and start debugging.
    public class RoomCalenderService : ServiceBase<RoomCalendar>, IRoomCalenderService
    {
        private IRoomCalendarRepository roomCalendarRepository;

        public RoomCalenderService()
        {
            this.roomCalendarRepository = RepositoryFactory.GetRepository<IRoomCalendarRepository, RoomCalendar>();
            this.repo = (IRepository<RoomCalendar>)this.roomCalendarRepository;
        }

        public RoomCalendar GetSingle(int roomCalId)
        {
            return this.roomCalendarRepository.GetSingle(roomCalId).GetDetached();
        }

        public IList<RoomCalendar> GetByRoomId(Int64 roomId)
        {
            IList<RoomCalendar> roomCals = this.roomCalendarRepository.GetByRoomId(roomId);
            IList<RoomCalendar> detachedRoomCals = new List<RoomCalendar>();
            foreach (RoomCalendar roomCal in roomCals)
            {
                detachedRoomCals.Add(roomCal.GetDetached());
            }
            return detachedRoomCals;
        }


        public IList<RoomCalendar> GetByStaffId(Int64 staffId)
        {
            IList<RoomCalendar> roomCals = this.roomCalendarRepository.GetByStaffId(staffId);
            IList<RoomCalendar> detachedRoomCals = new List<RoomCalendar>();
            foreach (RoomCalendar roomCal in roomCals)
            {
                detachedRoomCals.Add(roomCal.GetDetached());
            }
            return detachedRoomCals;
        }


        public IList<RoomCalendar> GetByDate(DateTime date)
        {
            IList<RoomCalendar> roomCals = this.roomCalendarRepository.GetByDate(date);
            IList<RoomCalendar> detachedRoomCals = new List<RoomCalendar>();
            foreach (RoomCalendar roomCal in roomCals)
            {
                detachedRoomCals.Add(roomCal.GetDetached());
            }
            return detachedRoomCals;
        }


        public IList<RoomCalendar> GetByDateAndRoomId(DateTime date, long roomId)
        {
            IList<RoomCalendar> roomCals = this.roomCalendarRepository.GetByDateAndRoomId(date, roomId);
            IList<RoomCalendar> detachedRoomCals = new List<RoomCalendar>();
            foreach (RoomCalendar roomCal in roomCals)
            {
                detachedRoomCals.Add(roomCal.GetDetached());
            }
            return detachedRoomCals;
        }


        public IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, long roomId)
        {
            IList<RoomCalendar> roomCals = this.roomCalendarRepository.GetByWeekAndRoomId(date, roomId);
            IList<RoomCalendar> detachedRoomCals = new List<RoomCalendar>();
            foreach (RoomCalendar roomCal in roomCals)
            {
                detachedRoomCals.Add(roomCal.GetDetached());
            }
            return detachedRoomCals;
        }


        public IList<RoomCalendar> GetByWatchedState(bool isWatched, int staffId)
        {
            IList<RoomCalendar> roomCals = this.roomCalendarRepository.GetByWatchedState(isWatched, staffId);
            IList<RoomCalendar> detachedRoomCals = new List<RoomCalendar>();
            foreach (RoomCalendar roomCal in roomCals)
            {
                detachedRoomCals.Add(roomCal.GetDetached());
            }
            return detachedRoomCals;
        }


        public IList<RoomCalendar> GetByRegisteredState(int registeredState, int staffId)
        {
            IList<RoomCalendar> roomCals = this.roomCalendarRepository.GetByRegisteredState(registeredState, staffId);
            IList<RoomCalendar> detachedRoomCals = new List<RoomCalendar>();
            foreach (RoomCalendar roomCal in roomCals)
            {
                detachedRoomCals.Add(roomCal.GetDetached());
            }
            return detachedRoomCals;
        }
    }
}
