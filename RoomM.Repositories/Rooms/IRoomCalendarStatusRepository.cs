using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Rooms
{
    public interface IRoomCalendarStatusRepository : IRepository<RoomCalendarStatus>
    {
        RoomCalendarStatus GetSingle(int statusId);
        IList<String> GetNameList();

    }
}
