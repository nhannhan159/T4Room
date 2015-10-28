using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.Repositories
{
    public interface IRoomCalendarStatusRepository : IRepository<RoomCalendarStatus>
    {
        RoomCalendarStatus GetSingle(int statusId);
        IList<String> GetNameList();
    }
}
