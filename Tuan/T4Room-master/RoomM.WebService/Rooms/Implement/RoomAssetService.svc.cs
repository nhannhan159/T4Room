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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetService.svc or RoomAssetService.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetService : ServiceBase<RoomAsset>, IRoomAssetService
    {
        private IRoomAssetRepository roomAssetRepository;

        public RoomAssetService()
        {
            this.roomAssetRepository = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();
            this.repo = (IRepository<RoomAsset>)this.roomAssetRepository;
        }

        public RoomAsset GetSingle(Int64 roomDeviceId)
        {
            return this.roomAssetRepository.GetSingle(roomDeviceId).GetDetached();
        }

        public void AddOrUpdate(Int64 assetId, Int64 roomId, int amount)
        {
            this.roomAssetRepository.AddOrUpdate(assetId, roomId, amount);
        }

        public IList<RoomAsset> GetByRoomId(Int64 id)
        {
            IList<RoomAsset> roomAssets = this.roomAssetRepository.GetByRoomId(id);
            IList<RoomAsset> detachedRoomAssets = new List<RoomAsset>();
            foreach (RoomAsset roomAsset in roomAssets)
            {
                detachedRoomAssets.Add(roomAsset.GetDetached());
            }
            return detachedRoomAssets;
        }

        public IList<RoomAsset> GetByAssetId(Int64 id)
        {
            IList<RoomAsset> roomAssets = this.roomAssetRepository.GetByAssetId(id);
            IList<RoomAsset> detachedRoomAssets = new List<RoomAsset>();
            foreach (RoomAsset roomAsset in roomAssets)
            {
                detachedRoomAssets.Add(roomAsset.GetDetached());
            }
            return detachedRoomAssets;
        }
    }
}
