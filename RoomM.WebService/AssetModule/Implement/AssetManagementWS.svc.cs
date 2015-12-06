using RoomM.Application.AssetModule.Services;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AssetManagementWS : AssetManagementService, IAssetManagementWS
    {
        public AssetManagementWS(IUnitOfWork context)
            : base(context)
        {
            base.EnableWSMode();
        }
    }
}