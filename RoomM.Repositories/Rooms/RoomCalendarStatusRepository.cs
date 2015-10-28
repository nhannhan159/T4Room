using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class RoomCalendarStatusRepository : RepositoryBase<RoomCalendarStatus>, IRoomCalendarStatusRepository
    {
        public RoomCalendarStatusRepository(EFDataContext _entities)
            : base(_entities)
        { }

        public RoomCalendarStatus GetSingle(int statusId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == statusId);
            return query;
        }


        public IList<string> GetNameList()
        {
            return (from p in GetAllWithQuery()
                    select p.Name).ToList();
        }
    }
}
