using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;
using System.Linq.Expressions;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(EFDataContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "RoomType";
        }

        public IList<Room> GetByRoomTypeId(Int64 roomTypeId)
        {
            return this.Get(filter: p => p.ID == roomTypeId).ToList();
        }

        public IList<Room> GetRoomListLimitByRegister(int limit)
        {
            return this.Get(
                orderBy: q => q.OrderBy(d => d.RoomCalendars.Count),
                limit: limit).ToList();
        }

        public List<DictionaryEntry> GetRoomLimitByRegister(int limit, DateTime from, DateTime to)
        {
            IList<Room> roomList = GetAll();
            Hashtable hm = new Hashtable();

            foreach (Room room in roomList)
            {
                int count = room.RoomCalendars.Count(p => p.Date >= from && p.Date <= to);
                hm.Add(room, count);
            }

            List<DictionaryEntry> dic = hm.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).Take(limit).ToList();

            return dic;
        }

        public bool isUniqueName(string name)
        {
            return this.Get(filter: p => p.Name.Equals(name)).Count() == 0;
        }
    }
}
