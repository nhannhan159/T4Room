using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using RoomM.DeskApp.AssetManagementWS;
using RoomM.DeskApp.RoomManagementWS;
using RoomM.DeskApp.UserManagementWS;
using RoomM.Domain;

namespace RoomM.DeskApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<AssetManagementWSClient>(() => { return new AssetManagementWSClient("NetTcpBinding_IAssetManagementWS"); });
            SimpleIoc.Default.Register<RoomManagementWSClient>(() => { return new RoomManagementWSClient("NetTcpBinding_IRoomManagementWS"); });
            SimpleIoc.Default.Register<UserManagementWSClient>(() => { return new UserManagementWSClient("NetTcpBinding_IUserManagementWS"); });

            SimpleIoc.Default.Register<RoomManagementViewModel>();
            SimpleIoc.Default.Register<AssetManagementViewModel>();
            SimpleIoc.Default.Register<UserManagementViewModel>();
            SimpleIoc.Default.Register<StatisticViewModel>();
        }

        /// <summary>
        /// Gets the RoomManagementViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public RoomManagementViewModel RoomManagementViewModel
        {
            get { return ServiceLocator.Current.GetInstance<RoomManagementViewModel>(); }
        }

        /// <summary>
        /// Gets the AssetManagementViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public AssetManagementViewModel AssetManagementViewModel
        {
            get { return ServiceLocator.Current.GetInstance<AssetManagementViewModel>(); }
        }

        /// <summary>
        /// Gets the UserManagementViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public UserManagementViewModel UserManagementViewModel
        {
            get { return ServiceLocator.Current.GetInstance<UserManagementViewModel>(); }
        }

        /// <summary>
        /// Gets the StatisticViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public StatisticViewModel StatisticViewModel
        {
            get { return ServiceLocator.Current.GetInstance<StatisticViewModel>(); }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}