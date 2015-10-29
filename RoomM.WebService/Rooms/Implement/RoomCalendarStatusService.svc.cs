using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomCalendarStatusService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomCalendarStatusService.svc or RoomCalendarStatusService.svc.cs at the Solution Explorer and start debugging.
    public class RoomCalendarStatusService : ServiceBase<RoomCalendarStatus>, IRoomCalendarStatusService
    {
        public RoomCalendarStatusService(EFDataContext context)
            : base(context)
        {
            this.repo = (IRepository<RoomCalendarStatus>)this.uow.RoomCalendarStatusRepository;
        }

        public RoomCalendarStatus GetSingle(int statusId)
        {
            return this.uow.RoomCalendarStatusRepository.GetSingle(statusId).GetDetached();
        }

        public IList<string> GetNameList()
        {
            return this.uow.RoomCalendarStatusRepository.GetNameList();
        }
    }
}
