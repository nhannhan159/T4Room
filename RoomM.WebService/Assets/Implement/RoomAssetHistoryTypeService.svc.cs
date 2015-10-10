using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Repositories.Assets;
using RoomM.Models.Assets;

namespace RoomM.WebService.Assets
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetHistoryTypeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetHistoryTypeService.svc or RoomAssetHistoryTypeService.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetHistoryTypeService : IRoomAssetHistoryTypeService
    {
        private IRoomAssetHistoryTypeRepository roomAssetHistoryTypeRepository;

        public RoomAssetHistoryTypeService()
        {
            this.roomAssetHistoryTypeRepository = new RoomAssetHistoryTypeRepository();
        }

        public HistoryType GetSingle(int typeId)
        {
            return this.roomAssetHistoryTypeRepository.GetSingle(typeId).GetDetached();
        }
    }
}
