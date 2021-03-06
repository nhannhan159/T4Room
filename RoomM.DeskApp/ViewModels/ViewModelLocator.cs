﻿using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using RoomM.Application.AssetModule.Services;
using RoomM.Application.RoomModule.Services;
using RoomM.Application.UserModule.Services;
using RoomM.Domain;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.DeskApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IUnitOfWork, EFContext>();

            SimpleIoc.Default.Register<IAssetManagementService, AssetManagementService>();
            SimpleIoc.Default.Register<IRoomManagementService, RoomManagementService>();
            SimpleIoc.Default.Register<IUserManagementService, UserManagementService>();

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