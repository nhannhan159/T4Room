using RoomM.Application.UserModule.Services;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaffService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaffService.svc or StaffService.svc.cs at the Solution Explorer and start debugging.
    public class UserManagementWS : UserManagementService, IUserManagementWS
    {
        public UserManagementWS(IUnitOfWork context)
            : base(context)
        {
            base.EnableWSMode();
        }
    }
}