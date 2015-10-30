using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using Ninject.Modules;

using RoomM.DeskApp.ViewModels;
using RoomM.Repositories;

namespace RoomM.DeskApp
{
    public class DeskAppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<EFDataContext>().ToSelf().InSingletonScope();
            Bind<RoomManagementViewModel>().ToSelf().InTransientScope();
            Bind<AssetManagementViewModel>().ToSelf().InTransientScope();
            Bind<StaffManagementViewModel>().ToSelf().InTransientScope();
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
