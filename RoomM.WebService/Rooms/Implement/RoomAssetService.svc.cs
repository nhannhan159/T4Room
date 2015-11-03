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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetService.svc or RoomAssetService.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetService : ServiceBase<RoomAsset>, IRoomAssetService
    {
        public RoomAssetService(EFDataContext context)
            : base(context)
        {
            this.repo = this.uow.RoomAssetRepository;
        }

        public void AddOrUpdate(Int64 assetId, Int64 roomId, int amount)
        {
            this.uow.RoomAssetRepository.AddOrUpdate(assetId, roomId, amount);
            this.uow.Commit();
        }

        public IList<RoomAsset> GetByRoomId(Int64 id)
        {
            return this.uow.RoomAssetRepository.GetByRoomId(id);
        }

        public IList<RoomAsset> GetByAssetId(Int64 id)
        {
            return this.uow.RoomAssetRepository.GetByAssetId(id);
        }
    }
}
