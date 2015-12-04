using Ninject.Modules;
using RoomM.Application.AssetModule.Services;
using RoomM.Application.RoomModule.Services;
using RoomM.Application.UserModule.Services;
using RoomM.Domain;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.WebService
{
    public class ServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFContext>().InTransientScope();
            Bind<IAssetManagementService>().To<AssetManagementService>().InTransientScope();
            Bind<IRoomManagementService>().To<RoomManagementService>().InTransientScope();
            Bind<IUserManagementService>().To<UserManagementService>().InTransientScope();
        }
    }
}