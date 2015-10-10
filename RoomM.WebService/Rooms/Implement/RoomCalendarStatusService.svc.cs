using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Repositories.Rooms;
using RoomM.Models.Rooms;

namespace RoomM.WebService.Rooms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomCalendarStatusService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomCalendarStatusService.svc or RoomCalendarStatusService.svc.cs at the Solution Explorer and start debugging.
    public class RoomCalendarStatusService : IRoomCalendarStatusService
    {
        private IRoomCalendarStatusRepository roomCalendarStatusRepository;

        public RoomCalendarStatusService()
        {
            this.roomCalendarStatusRepository = new RoomCalendarStatusRepository();
        }

        public RoomCalendarStatus GetSingle(int statusId)
        {
            return this.roomCalendarStatusRepository.GetSingle(statusId).GetDetached();
        }

        public IList<string> GetNameList()
        {
            return this.roomCalendarStatusRepository.GetNameList();
        }
    }
}
