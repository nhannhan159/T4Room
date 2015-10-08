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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetService.svc or RoomAssetService.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetService : IRoomAssetService
    {
        private IRoomAssetRepository roomAssetRepository;

        public RoomAssetService()
        {
            this.roomAssetRepository = new RoomAssetRepository();
        }

        public RoomAsset GetSingle(Int64 roomDeviceId)
        {
            return this.roomAssetRepository.GetSingle(roomDeviceId);
        }

        public void AddOrUpdate(Int64 assetId, Int64 roomId, int amount)
        {
            this.roomAssetRepository.AddOrUpdate(assetId, roomId, amount);
        }

        public IList<RoomAsset> GetByRoomId(Int64 id)
        {
            return this.roomAssetRepository.GetByRoomId(id);
        }

        public IList<RoomAsset> GetByAssetId(Int64 id)
        {
            return this.roomAssetRepository.GetByAssetId(id);
        }
    }
}
