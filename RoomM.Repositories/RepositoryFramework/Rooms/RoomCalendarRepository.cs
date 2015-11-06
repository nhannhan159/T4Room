using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomCalendarRepository : RepositoryBase<RoomCalendar>, IRoomCalendarRepository
    {
        public RoomCalendarRepository(EFDataContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "Room,Staff,RoomCalendarStatus";
        }

        public IList<RoomCalendar> GetByRoomId(Int64 roomId)
        {
            return this.Get(filter: p => p.RoomId == roomId).ToList();
        }

        public IList<RoomCalendar> GetByStaffId(Int64 staffId)
        {
            return this.Get(filter: p => p.StaffId == staffId).ToList();
        }

        public IList<RoomCalendar> GetByDate(DateTime date)
        {
            return this.Get(filter: p => 
                p.Date.Day == date.Day 
                && p.Date.Month == date.Month 
                && p.Date.Year == date.Year).ToList();
        }

        public IList<RoomCalendar> GetByDateAndRoomId(DateTime date, Int64 roomId)
        {
            return this.Get(filter: p =>
                p.RoomId == roomId
                && p.Date.Day == date.Day
                && p.Date.Month == date.Month
                && p.Date.Year == date.Year).ToList();
        }

        public IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, Int64 roomId)
        {
            List<DateTime> dateLst = new List<DateTime>();
            
            DateTime startDate = date;
            while (startDate.DayOfWeek != DayOfWeek.Monday) 
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day - 1);

            for (int i = 0; i < 7; ++i)
            {
                DateTime day = startDate.AddDays(i);
                dateLst.Add(day);
            }

            IList<RoomCalendar> calLst = new List<RoomCalendar>();
            foreach (DateTime dt in dateLst)
            {
                 foreach (RoomCalendar rc in GetByDateAndRoomId(dt, roomId)) 
                 {
                    calLst.Add(rc);
                 }
            }

            return calLst;
        }

        public IList<RoomCalendar> GetByWatchedState(bool isWatched, Int64 staffId)
        {
            return this.Get(filter: p => p.StaffId == staffId && p.IsWatched == isWatched,
                orderBy: q => q.OrderByDescending(d => d.Date)).ToList();
        }

        public IList<RoomCalendar> GetByRegisteredState(int registeredState, Int64 staffId)
        {
            return this.Get(filter: p => p.StaffId == staffId && p.RoomCalendarStatusId == registeredState,
                orderBy: q => q.OrderByDescending(d => d.Date)).ToList();
        }
    }
}
