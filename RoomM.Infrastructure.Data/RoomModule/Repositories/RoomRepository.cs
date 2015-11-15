using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;
using System.Linq.Expressions;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.Infrastructure.Data.RoomModule.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(EFContext context)
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

        public IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to)
        {
            IList<Room> roomList = GetAll();
            IList<KeyValuePair<Room, int>> list = new List<KeyValuePair<Room, int>>();

            foreach (Room room in roomList)
            {
                int count = room.RoomRegs.Count(p => p.Date >= from && p.Date <= to);
                list.Add(new KeyValuePair<Room, int>(room, count));
            }

            return list.OrderByDescending(p => p.Value).Take(limit).ToList();
        }

        public bool isUniqueName(string name)
        {
            return this.Get(filter: p => p.Name.Equals(name)).Count() == 0;
        }
    }
}
