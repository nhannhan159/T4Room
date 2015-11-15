using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using Ninject.Modules;

using RoomM.DeskApp.ViewModels;
using RoomM.Domain;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data;
using RoomM.Infrastructure.Data.UnitOfWork;
using RoomM.Infrastructure.Data.AssetModule.Repositories;
using RoomM.Infrastructure.Data.RoomModule.Repositories;
using RoomM.Infrastructure.Data.UserModule.Repositories;
using RoomM.Application.AssetModule.Services;
using RoomM.Application.RoomModule.Services;
using RoomM.Application.UserModule.Services;

namespace RoomM.DeskApp
{
    public class DeskAppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFContext>().InSingletonScope();

            Bind<IAssetManagementService>().To<AssetManagementService>().InTransientScope();
            Bind<IRoomManagementService>().To<RoomManagementService>().InTransientScope();
            Bind<IUserManagementService>().To<UserManagementService>().InTransientScope();
            Bind<IStatisticService>().To<StatisticService>().InTransientScope();

            Bind<RoomManagementViewModel>().ToSelf().InTransientScope();
            Bind<AssetManagementViewModel>().ToSelf().InTransientScope();
            Bind<UserManagementViewModel>().ToSelf().InTransientScope();
            Bind<StatisticViewModel>().ToSelf().InTransientScope();
        }
    }

    public static class IocKernel
    {
        private static StandardKernel _kernel;

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Initialize(params INinjectModule[] modules)
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel(modules);
            }
        }
    }
}
