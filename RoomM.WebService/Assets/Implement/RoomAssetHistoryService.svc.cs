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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetHistory" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetHistory.svc or RoomAssetHistory.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetHistoryService : ServiceBase<RoomAssetHistory>, IRoomAssetHistoryService
    {
        public RoomAssetHistoryService(EFDataContext context)
            : base(context)
        {
            this.repo = this.uow.RoomAssetHistoryRepository;
        }

        public IList<RoomAssetHistory> GetByRoomId(Int64 id)
        {
            return this.uow.RoomAssetHistoryRepository.GetByRoomId(id);
        }

        public IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return this.uow.RoomAssetHistoryRepository.GetByRoom2RoomId(room, timeForBacktrace);
        }
    }
}
