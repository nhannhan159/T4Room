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
        public RoomCalendarStatusRepository(EFDataContext context)
            : base(context)
        { }

        public IList<string> GetNameList()
        {
            return (from p in GetAllWithQuery()
                    select p.Name).ToList();
        }
    }
}
