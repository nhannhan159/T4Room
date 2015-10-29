using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject.Modules;

using RoomM.Repositories;

namespace RoomM.WebService
{
    public class ServiceModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<EFDataContext>().ToSelf();
        }
    }
}