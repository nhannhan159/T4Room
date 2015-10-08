using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Repositories.Assets;
using RoomM.Models.Assets;
using RoomM.Models.Rooms;

namespace RoomM.WebService.Assets
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetHistory" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetHistory.svc or RoomAssetHistory.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetHistoryService : IRoomAssetHistoryService
    {
        private IRoomAssetHistoryRepository roomAssetHistoryRepository;

        public RoomAssetHistoryService()
        { 
            this.roomAssetHistoryRepository = new RoomAssetHistoryRepository();
        }

        public RoomAssetHistory GetSingle(int assetId)
        {
            return this.roomAssetHistoryRepository.GetSingle(assetId);
        }

        public IList<RoomAssetHistory> GetByRoomId(Int64 id)
        {
            return this.roomAssetHistoryRepository.GetByRoomId(id);
        }

        public IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return this.roomAssetHistoryRepository.GetByRoom2RoomId(room, timeForBacktrace);
        }
    }
}
