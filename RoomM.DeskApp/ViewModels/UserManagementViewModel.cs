using System;
using System.Windows;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

using GalaSoft.MvvmLight.Command;

using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;
using RoomM.Application.UserModule.Services;

namespace RoomM.DeskApp.ViewModels
{
    public class UserManagementViewModel : EditableViewModel<User>
    {

        #region Construction

        public UserManagementViewModel(IUserManagementService service)
            : base() 
        {
            this.service = service;
            this.BaseInit();

            this.sexFilter = 0;
            this.roomCalendarViewFilterIsCheck = false;
            this.rcvRoomFilter = "";
            this.rcvDateFromFilter = new DateTime(2000, 1, 1);
            this.rcvDateToFilter = DateTime.Now;
            this.rcvPeriodsFilter = 0;
            this.rcvBeginTimeFilter = 0;
            List<RoomRegType> rcvStatusList = new List<RoomRegType>(this.service.GetRoomRegTypeList());
            rcvStatusList.Add(new RoomRegType("Tất cả"));
            this.rcvStatusFilters = new CollectionView(rcvStatusList);
            this.rcvStatusFilter = rcvStatusList[rcvStatusList.Count - 1];
        }

        #endregion

        #region PrivateField

        private IUserManagementService service;
        private NewUser newUserDialog;
        private int sexFilter;
        private ICollectionView currentRoomCalendarView;
        private bool roomCalendarViewFilterIsCheck;
        private string rcvRoomFilter;
        private DateTime rcvDateFromFilter;
        private DateTime rcvDateToFilter;
        private int rcvPeriodsFilter;
        private int rcvBeginTimeFilter;
        private RoomRegType rcvStatusFilter;
        private CollectionView rcvStatusFilters;

        #endregion

        #region General

        protected override List<User> GetEntitiesList()
        {
            return new List<User>(this.service.GetUserList());
        }

        public ICollectionView UserRoleView
        {
            get { return CollectionViewSource.GetDefaultView(this.service.GetUserRoleList()); }
        }

        protected override void AddCurrentEntity()
        {
            try
            {
                this.service.AddUser(this.CurrentEntity);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Thêm dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void EditCurrentEntity()
        {
            try
            {
                this.service.EditUser(this.CurrentEntity);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void DeleteCurrentEntity()
        {
            try
            {
                this.service.DeleteUser(this.CurrentEntity);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override bool IsUsing(User entity)
        {
            return entity.IsWorking;
        }

        protected override bool GeneralFilter(User entity)
        {
            bool filter = true;
            filter = filter && (entity.Name.Contains(this.NameFilter));
            if (this.SexFilter != 0)
                filter = filter && (this.SexFilter == 1 ? (entity.Sex == true) : (entity.Sex == false));
            return filter;
        }

        public int SexFilter
        {
            get { return this.sexFilter; }
            set { this.sexFilter = value; }
        }

        protected override PropertyGroupDescription Grouping()
        {
            return new PropertyGroupDescription("UserType");
        }

        protected override void NewDialogCommandHandler()
        {
            this.newEntityViewModel = new NewEntityViewModel<User>();
            this.newEntityViewModel.NewCommand = this.NewCommand;
            this.newUserDialog = new NewUser(this.newEntityViewModel);
            this.newUserDialog.userRoleCB.ItemsSource = this.UserRoleView;
            this.newUserDialog.ShowDialog();
        }

        protected override void CloseNewEntityDialog()
        {
            this.newUserDialog.Close();
        }

        protected override void SetAdditionViewChange()
        {
            if (this.CurrentEntity == null)
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(new List<RoomReg>());
            else
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(this.service.GetRoomRegList(this.CurrentEntity.ID));
            this.currentRoomCalendarView.Filter += RoomCalendarViewFilter;
            this.RaisePropertyChanged(() => this.CurrentRoomCalendarView);
        }

        #endregion

        public ICollectionView CurrentRoomCalendarView
        {
            get { return this.currentRoomCalendarView; }
        }

        public CollectionView RcvStatusFilters
        {
            get { return this.rcvStatusFilters; }
        }

        private bool RoomCalendarViewFilter(object obj)
        {
            RoomReg entity = obj as RoomReg;
            bool filter = true;
            if (this.roomCalendarViewFilterIsCheck)
            {
                filter = filter && entity.Room.Name.Contains(this.RcvRoomFilter);
                filter = filter && (entity.Date >= this.RcvDateFromFilter);
                filter = filter && (entity.Date <= this.RcvDateToFilter);
                if (this.RcvPeriodsFilter > 0)
                    filter = filter && (entity.Length == this.RcvPeriodsFilter);
                if (this.RcvBeginTimeFilter > 0)
                    filter = filter && (entity.Start == this.RcvBeginTimeFilter);
                if (this.RcvStatusFilter.Name != "Tất cả")
                    filter = filter && (entity.RoomRegType.Name == this.RcvStatusFilter.Name);
            }
            return filter;
        }

        public ICommand RoomCalendarViewFilterCommand { get { return new RelayCommand(RoomCalendarViewFilterCommandHandler); } }
        public ICommand RoomCalendarViewFilterAllCommand { get { return new RelayCommand(RoomCalendarViewFilterAllCommandHandler); } }

        private void RoomCalendarViewFilterCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = true;
            this.currentRoomCalendarView.Refresh();
        }

        private void RoomCalendarViewFilterAllCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = false;
            this.currentRoomCalendarView.Refresh();
        }

        public string RcvRoomFilter
        {
            get { return this.rcvRoomFilter; }
            set { this.rcvRoomFilter = value; }
        }

        public DateTime RcvDateFromFilter
        {
            get { return this.rcvDateFromFilter; }
            set { this.rcvDateFromFilter = value; }
        }

        public DateTime RcvDateToFilter
        {
            get { return this.rcvDateToFilter; }
            set { this.rcvDateToFilter = value; }
        }

        public int RcvPeriodsFilter
        {
            get { return this.rcvPeriodsFilter; }
            set { this.rcvPeriodsFilter = value; }
        }

        public int RcvBeginTimeFilter
        {
            get { return this.rcvBeginTimeFilter; }
            set { this.rcvBeginTimeFilter = value; }
        }

        public RoomRegType RcvStatusFilter
        {
            get { return this.rcvStatusFilter; }
            set { this.rcvStatusFilter = value; }
        }
    }
}
