using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;
using Ninject.Modules;

using RoomM.DeskApp.ViewModels;
using RoomM.Repositories;

namespace RoomM.DeskApp.ViewModels
{
    public class ViewModelLocator
    {
        public RoomManagementViewModel RoomManagementViewModel
        {
            get { return IocKernel.Get<RoomManagementViewModel>(); }
        }

        public AssetManagementViewModel AssetManagementViewModel
        {
            get { return IocKernel.Get<AssetManagementViewModel>(); }
        }

        public StaffManagementViewModel StaffManagementViewModel
        {
            get { return IocKernel.Get<StaffManagementViewModel>(); }
        }

        public StatisticViewModel StatisticViewModel
        {
            get { return IocKernel.Get<StatisticViewModel>(); }
        }
    }
}
