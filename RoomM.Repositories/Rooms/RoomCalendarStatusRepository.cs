using RoomM.Models;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public class RoomCalendarStatusRepository : RepositoryBase<EFDataContext, RoomCalendarStatus>, IRoomCalendarStatusRepository
    {
        public RoomCalendarStatusRepository()
        { 
        
        }

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
