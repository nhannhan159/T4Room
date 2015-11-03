using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Extensions.Wcf.SelfHost;
using Ninject.Web.Common.SelfHost;

namespace RoomM.WebService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Registry kernel
            IKernel kernel = new StandardKernel(new ServiceModule());

            // Create service config
            NinjectWcfConfiguration roomServiceConfig = NinjectWcfConfiguration.Create<RoomService, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration roomTypeServiceConfig = NinjectWcfConfiguration.Create<RoomTypeService, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration roomAssetServiceConfig = NinjectWcfConfiguration.Create<RoomAssetService, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration roomCalenderServiceConfig = NinjectWcfConfiguration.Create<RoomCalenderService, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration roomCalendarStatusServiceConfig = NinjectWcfConfiguration.Create<RoomCalendarStatusService, NinjectServiceSelfHostFactory>();

            NinjectWcfConfiguration staffServiceConfig = NinjectWcfConfiguration.Create<StaffService, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration staffTypeServiceConfig = NinjectWcfConfiguration.Create<StaffTypeService, NinjectServiceSelfHostFactory>();

            NinjectWcfConfiguration assetServiceConfig = NinjectWcfConfiguration.Create<AssetService, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration roomAssetHistoryServiceConfig = NinjectWcfConfiguration.Create<RoomAssetHistoryService, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration roomAssetHistoryTypeServiceConfig = NinjectWcfConfiguration.Create<RoomAssetHistoryTypeService, NinjectServiceSelfHostFactory>();

            using (var selfHost = new NinjectSelfHostBootstrapper(() => kernel,
                roomServiceConfig,
                roomTypeServiceConfig,
                roomAssetServiceConfig,
                roomCalenderServiceConfig,
                roomCalendarStatusServiceConfig,
                staffServiceConfig,
                staffTypeServiceConfig,
                assetServiceConfig,
                roomAssetHistoryServiceConfig,
                roomAssetHistoryTypeServiceConfig))
            {
                selfHost.Start();
                Console.Write("All Services Started. Press \"Enter\" to stop thems...");
                Console.ReadLine();
            }
        }
    }
}
