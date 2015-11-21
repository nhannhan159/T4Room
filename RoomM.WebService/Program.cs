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
