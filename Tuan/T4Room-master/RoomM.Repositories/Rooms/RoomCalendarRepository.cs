using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomCalendarRepository : RepositoryBase<EFDataContext, RoomCalendar>, IRoomCalendarRepository
    {
        public RoomCalendarRepository()
        { 
        }

        public RoomCalendar GetSingle(int roomCalId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomCalId);
            return query;
        }

        public IList<RoomCalendar> GetByRoomId(Int64 roomId)
        {
            return (from p in GetAllWithQuery()
                    where p.Room.ID == roomId
                    select p).ToList();
        }

        public IList<RoomCalendar> GetByStaffId(Int64 staffId)
        {
            return (from p in GetAllWithQuery()
                    where p.Staff.ID == staffId
                    select p).ToList();
        }

        public IList<RoomCalendar> GetByDate(DateTime date)
        {
            return (from p in GetAllWithQuery()
                    where p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year
                    select p).ToList();
        }

        public IList<RoomCalendar> GetByDateAndRoomId(DateTime date, long roomId)
        {
            return (from p in GetAllWithQuery()
                    where p.Room.ID == roomId && (p.Date.Day == date.Day && p.Date.Month == date.Month && p.Date.Year == date.Year)
                    select p).ToList();
        }

        public IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, long roomId)
        {

            List<DateTime> dateLst = new List<DateTime>();
            
            DateTime startDate = date;
            while (startDate.DayOfWeek != DayOfWeek.Monday) 
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day - 1);

            for (int i = 0; i < 7; ++i)
            {
                DateTime day = startDate.AddDays(i); // new DateTime(startDate.Year, startDate.Month, startDate.Day + i);
                dateLst.Add(day);
            }


            IList<RoomCalendar> calLst = new List<RoomCalendar>();
            foreach (DateTime dt in dateLst)
            {
                 foreach(RoomCalendar rc in GetByDateAndRoomId(dt, roomId)) 
                 {
                    calLst.Add(rc);
                 }
            }

            return calLst;
        }

        public IList<RoomCalendar> GetByWatchedState(bool isWatched, int staffId)
        {
            IList<RoomCalendar> dataR = new List<RoomCalendar>();
            IList<RoomCalendar> dataLst = (from p in GetAllWithQuery()
                                           orderby p.Date descending
                                           select p).ToList();

            foreach (RoomCalendar p in dataLst)
            {
                if (p.Staff.ID == staffId && p.IsWatched == isWatched)
                    dataR.Add(p);
            }

            return dataR;
            
        }

        public IList<RoomCalendar> GetByRegisteredState(int registeredState, int staffId)
        {
            return (from p in GetAllWithQuery()
                    where p.Staff.ID == staffId && p.RoomCalendarStatusId == registeredState
                    orderby p.Date descending
                    select p).ToList();
        }
    }
}
