using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomCalenderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomCalenderService.svc or RoomCalenderService.svc.cs at the Solution Explorer and start debugging.
    public class RoomCalenderService : ServiceBase<RoomCalendar>, IRoomCalenderService
    {
        public RoomCalenderService(EFDataContext context)
            : base(context)
        {
            this.repo = (IRepository<RoomCalendar>)this.uow.RoomCalendarRepository;
        }

        public RoomCalendar GetSingle(int roomCalId)
        {
            return this.uow.RoomCalendarRepository.GetSingle(roomCalId);
        }

        public IList<RoomCalendar> GetByRoomId(Int64 roomId)
        {
            return this.uow.RoomCalendarRepository.GetByRoomId(roomId);
        }


        public IList<RoomCalendar> GetByStaffId(Int64 staffId)
        {
            return this.uow.RoomCalendarRepository.GetByStaffId(staffId);
        }


        public IList<RoomCalendar> GetByDate(DateTime date)
        {
            return this.uow.RoomCalendarRepository.GetByDate(date);
        }


        public IList<RoomCalendar> GetByDateAndRoomId(DateTime date, long roomId)
        {
            return this.uow.RoomCalendarRepository.GetByDateAndRoomId(date, roomId);
        }


        public IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, long roomId)
        {
            return this.uow.RoomCalendarRepository.GetByWeekAndRoomId(date, roomId);
        }


        public IList<RoomCalendar> GetByWatchedState(bool isWatched, int staffId)
        {
            return this.uow.RoomCalendarRepository.GetByWatchedState(isWatched, staffId);
        }


        public IList<RoomCalendar> GetByRegisteredState(int registeredState, int staffId)
        {
            return this.uow.RoomCalendarRepository.GetByRegisteredState(registeredState, staffId);
        }
    }
}
