using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Extensions.Wcf.SelfHost;
using Ninject.Web.Common.SelfHost;
using RoomM.WebService;
using System;

namespace RoomM.WSSelfHosting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Registry kernel
            IKernel kernel = new StandardKernel(new ServiceModule());

            // Create service config
            NinjectWcfConfiguration assetManagementWSConfig = NinjectWcfConfiguration.Create<AssetManagementWS, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration roomManagementWSConfig = NinjectWcfConfiguration.Create<RoomManagementWS, NinjectServiceSelfHostFactory>();
            NinjectWcfConfiguration userManagementWSConfig = NinjectWcfConfiguration.Create<UserManagementWS, NinjectServiceSelfHostFactory>();

            using (var selfHost = new NinjectSelfHostBootstrapper(() => kernel,
                assetManagementWSConfig,
                roomManagementWSConfig,
                userManagementWSConfig))
            {
                selfHost.Start();
                Console.Write("All Services Started. Press \"Enter\" to stop thems...");
                Console.ReadLine();
            }
        }
    }
}