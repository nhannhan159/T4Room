using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

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
            return this.Get().Select(p => p.Name).ToList();
        }
    }
}
