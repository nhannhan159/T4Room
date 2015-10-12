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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetHistoryTypeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetHistoryTypeService.svc or RoomAssetHistoryTypeService.svc.cs at the Solution Explorer and start debugging.
    public class RoomAssetHistoryTypeService : ServiceBase<HistoryType>, IRoomAssetHistoryTypeService
    {
        private IRoomAssetHistoryTypeRepository roomAssetHistoryTypeRepository;

        public RoomAssetHistoryTypeService()
        {
            this.roomAssetHistoryTypeRepository = RepositoryFactory.GetRepository<IRoomAssetHistoryTypeRepository, HistoryType>();
            this.repo = (IRepository<HistoryType>)this.roomAssetHistoryTypeRepository;
        }

        public HistoryType GetSingle(int typeId)
        {
            return this.roomAssetHistoryTypeRepository.GetSingle(typeId).GetDetached();
        }
    }
}
