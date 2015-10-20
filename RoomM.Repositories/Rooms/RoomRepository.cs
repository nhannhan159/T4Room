using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository()
        { }

        public Room GetSingle(Int64 roomId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == roomId);
            return query;
        }

        public IList<Room> GetByRoomTypeId(long roomTypeId)
        {
            return (from p in GetAllWithQuery()
                    where p.RoomType.ID == roomTypeId
                    select p).ToList();
        }

        public IList<Room> GetRoomListLimitByRegister(int limit)
        {
            return (from p in GetAllWithQuery()
                    orderby p.RoomCalendars.Count descending
                    select p).Take(limit).ToList();
        }

        public List<DictionaryEntry> GetRoomLimitByRegister(int limit, DateTime from, DateTime to)
        {
            IList<Room> roomList = GetAll();
            Hashtable hm = new Hashtable();

            int c;
            foreach (Room s in roomList)
            {
                c = 0;
                foreach (RoomCalendar rc in s.RoomCalendars)
                    if (rc.Date.Date >= from.Date && rc.Date.Date <= to.Date)
                        c++;

                hm.Add(s, c);
            }

            List<DictionaryEntry> dic = hm.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).Take(limit).ToList();

            return dic;
        }

        public bool isUniqueName(string name)
        {
            return (from p in GetAllWithQuery()
                    where p.Name.Equals(name)
                    select p).ToList().Count == 0;

        }

    }
}
