using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomM.Infrastructure.Data.RoomModule.Repositories
{
    public class RoomRegRepository : Repository<RoomReg>, IRoomRegRepository
    {
        public RoomRegRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "Room,User";
        }

        public IList<RoomReg> GetByRoomId(Int64 roomId)
        {
            return this.Get(filter: p => p.RoomId == roomId).ToList();
        }

        public IList<RoomReg> GetByUserId(Int64 userId)
        {
            return this.Get(filter: p => p.UserId == userId).ToList();
        }

        public IList<RoomReg> GetByDate(DateTime date)
        {
            return this.Get(filter: p =>
                p.Date.Day      == date.Day
                && p.Date.Month == date.Month
                && p.Date.Year  == date.Year).ToList();
        }

        public IList<RoomReg> GetByDateAndRoomId(DateTime date, Int64 roomId)
        {
            return this.Get(filter: p =>
                p.RoomId        == roomId
                && p.Date.Day   == date.Day
                && p.Date.Month == date.Month
                && p.Date.Year  == date.Year).ToList();
        }

        public IList<RoomReg> GetByWeekAndRoomId(DateTime date, Int64 roomId)
        {
            DateTime startDate = date.AddDays(DayOfWeek.Monday - date.DayOfWeek);

            IList<RoomReg> calLst = new List<RoomReg>();
            for (int i = 0; i < 7; ++i)
            {
                foreach (RoomReg rc in GetByDateAndRoomId(startDate.AddDays(i), roomId))
                    calLst.Add(rc);
            }

            return calLst;
        }

        public IList<RoomReg> GetByWatchedState(bool isWatched, Int64 userId)
        {
            return this.Get(filter: p => p.UserId == userId && p.IsWatched == isWatched,
                orderBy: q => q.OrderByDescending(d => d.Date)).ToList();
        }

        public IList<RoomReg> GetByRegisteredState(int registeredState, Int64 userId)
        {
            return this.Get(filter: p => p.UserId == userId && p.RoomRegTypeId == registeredState,
                orderBy: q => q.OrderByDescending(d => d.Date)).ToList();
        }
    }
}