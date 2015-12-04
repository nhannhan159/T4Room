using RoomM.Application.RoomModule.Services;
using RoomM.Domain;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetService.svc or RoomAssetService.svc.cs at the Solution Explorer and start debugging.
    public class RoomManagementWS : RoomManagementService, IRoomManagementWS
    {
        public RoomManagementWS(IUnitOfWork context)
            : base(context)
        {
            base.EnableWSMode();
        }
    }
}