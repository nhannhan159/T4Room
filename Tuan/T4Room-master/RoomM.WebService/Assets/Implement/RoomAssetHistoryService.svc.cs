using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetHistory" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetHistory.svc or RoomAssetHistory.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetHistoryService : ServiceBase<RoomAssetHistory>, IRoomAssetHistoryService
    {
        private IRoomAssetHistoryRepository roomAssetHistoryRepository;

        public RoomAssetHistoryService()
        {
            this.roomAssetHistoryRepository = RepositoryFactory.GetRepository<IRoomAssetHistoryRepository, RoomAssetHistory>();
            this.repo = (IRepository<RoomAssetHistory>)this.roomAssetHistoryRepository;
        }

        public RoomAssetHistory GetSingle(int assetId)
        {
            return this.roomAssetHistoryRepository.GetSingle(assetId).GetDetached();
        }

        public IList<RoomAssetHistory> GetByRoomId(Int64 id)
        {
            IList<RoomAssetHistory> roomAssetHistories = this.roomAssetHistoryRepository.GetByRoomId(id);
            IList<RoomAssetHistory> detachedRoomAssetHistories = new List<RoomAssetHistory>();
            foreach (RoomAssetHistory roomAssetHistory in roomAssetHistories)
            {
                detachedRoomAssetHistories.Add(roomAssetHistory.GetDetached());
            }
            return detachedRoomAssetHistories;
        }

        public IList<RoomAssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            IList<RoomAssetHistory> roomAssetHistories = this.roomAssetHistoryRepository.GetByRoom2RoomId(room, timeForBacktrace);
            IList<RoomAssetHistory> detachedRoomAssetHistories = new List<RoomAssetHistory>();
            foreach (RoomAssetHistory roomAssetHistory in roomAssetHistories)
            {
                detachedRoomAssetHistories.Add(roomAssetHistory.GetDetached());
            }
            return detachedRoomAssetHistories;
        }
    }
}
