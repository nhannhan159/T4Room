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
using RoomM.Application.RoomModule.Services;
using RoomM.Application.UserModule.Services;

namespace RoomM.DeskApp.ViewModels
{
    public class UserManagementViewModel : EditableViewModel<User>
    {

        #region Construction

        public UserManagementViewModel(IUserManagementService userManagementService, IRoomManagementService roomManagementService)
            : base() 
        {
            this.userManagementService = userManagementService;
            this.roomManagementService = roomManagementService;
            this.BaseInit();

            this.sexFilter = 0;
            this.roomCalendarViewFilterIsCheck = false;
            this.rcvRoomFilter = "";
            this.rcvDateFromFilter = new DateTime(2000, 1, 1);
            this.rcvDateToFilter = DateTime.Now;
            this.rcvPeriodsFilter = 0;
            this.rcvBeginTimeFilter = 0;

            this.RcvStatusFilters = new Dictionary<int, string>(RoomReg.GetRegType);
            this.RcvStatusFilters.Add(0, "Tất cả");
            this.rcvStatusFilter = 0;
        }

        #endregion

        #region PrivateField

        private IUserManagementService userManagementService;
        private IRoomManagementService roomManagementService;

        private NewUser newUserDialog;
        private int sexFilter;
        private ICollectionView currentRoomCalendarView;
        private bool roomCalendarViewFilterIsCheck;
        private string rcvRoomFilter;
        private DateTime rcvDateFromFilter;
        private DateTime rcvDateToFilter;
        private int rcvPeriodsFilter;
        private int rcvBeginTimeFilter;
        private int rcvStatusFilter;

        #endregion

        #region General

        protected override List<User> GetEntitiesList()
        {
            return new List<User>(this.userManagementService.GetUserList());
        }

        /*
        public ICollectionView UserRoleView
        {
            get { return CollectionViewSource.GetDefaultView(this.service.GetUserRoleList()); }
        }
        */

        protected override void AddCurrentEntity()
        {
            try
            {
                this.userManagementService.AddUser(this.CurrentEntity);
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
                this.userManagementService.EditUser(this.CurrentEntity);
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
                this.userManagementService.DeleteUser(this.CurrentEntity);
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
            filter = filter && (entity.FullName.Contains(this.NameFilter));
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
            //this.newUserDialog.userRoleCB.ItemsSource = this.UserRoleView;
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
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(
                    this.roomManagementService.GetRoomRegListByUserId(this.CurrentEntity.Id));
            this.currentRoomCalendarView.Filter += RoomCalendarViewFilter;
            this.RaisePropertyChanged(() => this.CurrentRoomCalendarView);
        }

        #endregion

        public ICollectionView CurrentRoomCalendarView
        {
            get { return this.currentRoomCalendarView; }
        }

        public Dictionary<int, string> RcvStatusFilters { get; set; }

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
                if (this.RcvStatusFilter != 0)
                    filter = filter && (entity.RoomRegTypeId == this.RcvStatusFilter);
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

        public int RcvStatusFilter
        {
            get { return this.rcvStatusFilter; }
            set { this.rcvStatusFilter = value; }
        }
    }
}
