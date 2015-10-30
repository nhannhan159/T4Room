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

using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.DeskApp.ViewModels
{
    public class StaffManagementViewModel : EditableViewModel<Staff>
    {

        #region Construction

        public StaffManagementViewModel(EFDataContext context)
            : base(context) 
        {
            this.sexFilter = 0;
            this.roomCalendarViewFilterIsCheck = false;
            this.rcvRoomFilter = "";
            this.rcvDateFromFilter = new DateTime(2000, 1, 1);
            this.rcvDateToFilter = DateTime.Now;
            this.rcvPeriodsFilter = 0;
            this.rcvBeginTimeFilter = 0;
            List<RoomCalendarStatus> rcvStatusList = new List<RoomCalendarStatus>(this.uow.RoomCalendarStatusRepository.GetAll());
            rcvStatusList.Add(new RoomCalendarStatus("Tất cả"));
            this.rcvStatusFilters = new CollectionView(rcvStatusList);
            this.rcvStatusFilter = rcvStatusList[rcvStatusList.Count - 1];
        }

        #endregion

        #region PrivateField

        private NewStaff newStaffDialog;
        private int sexFilter;
        private ICollectionView currentRoomCalendarView;
        private bool roomCalendarViewFilterIsCheck;
        private string rcvRoomFilter;
        private DateTime rcvDateFromFilter;
        private DateTime rcvDateToFilter;
        private int rcvPeriodsFilter;
        private int rcvBeginTimeFilter;
        private RoomCalendarStatus rcvStatusFilter;
        private CollectionView rcvStatusFilters;

        #endregion

        #region General

        protected override List<Staff> GetEntitiesList()
        {
            return new List<Staff>(this.uow.StaffRepository.GetAll());
        }

        public ICollectionView StaffTypesView
        {
            get { return CollectionViewSource.GetDefaultView(this.uow.StaffTypeRepository.GetAll()); }
        }

        protected override void SaveCurrentEntity()
        {
            try
            {
                if (this.CurrentEntity.ID > 0)
                    this.uow.StaffRepository.Edit(this.CurrentEntity);
                else
                    this.uow.StaffRepository.Add(this.CurrentEntity);
                this.uow.Commit();
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void DeleteCurrentEntity()
        {
            this.CurrentEntity.IsWorking = false;
            this.SaveCurrentEntity();
        }

        protected override bool IsUsing(Staff entity)
        {
            return entity.IsWorking;
        }

        protected override bool GeneralFilter(Staff entity)
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
            return new PropertyGroupDescription("StaffType");
        }

        protected override void NewDialogCommandHandler()
        {
            this.newEntityViewModel = new NewEntityViewModel<Staff>();
            this.newEntityViewModel.NewCommand = this.NewCommand;
            this.newStaffDialog = new NewStaff(this.newEntityViewModel);
            this.newStaffDialog.staffTypeCB.ItemsSource = this.StaffTypesView;
            this.newStaffDialog.ShowDialog();
        }

        protected override void CloseNewEntityDialog()
        {
            this.newStaffDialog.Close();
        }

        protected override void EntitySelectionChanged(object sender, EventArgs e)
        {
            this.OnPropertyChanged("CurrentRoomCalendarView");
        }

        protected override void SetAdditionViewChange()
        {
            if (this.CurrentEntity == null)
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(new List<RoomCalendar>());
            else
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(this.uow.RoomCalendarRepository.GetByStaffId(this.CurrentEntity.ID));
            this.currentRoomCalendarView.Filter += RoomCalendarViewFilter;
            this.OnPropertyChanged("CurrentRoomCalendarView");
        }

        protected override void SaveCommandHandler()
        {
            MainWindowViewModel.instance.ChangeStateToReady();
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn sửa thông tin nhân viên?", "Xác nhận sửa thông tin", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // if (roomRepo.isUniqueName(CurrentEntity.Name.Trim()))
                // {
                this.SaveCurrentEntity();
                MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
                base.SaveCommandHandler();
                /* } 
                else 
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật thất bại, tên phòng bị trùng lắp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thất bại, tên phòng bị trùng lắp");
                }*/
            }
        }

        protected override void NewCommandHandler()
        {
            if (!this.uow.StaffRepository.CheckUserExists(newEntityViewModel.NewEntity.UserName.Trim()))
            {
                this.CloseNewEntityDialog();
                base.NewCommandHandler();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Thêm thất bại, tên đăng nhập đã có người sử dụng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainWindowViewModel.instance.ChangeStateToComplete("Thêm thất bại, tên đăng nhập đã có người sử dụng");
            }

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
            RoomCalendar entity = obj as RoomCalendar;
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
                    filter = filter && (entity.RoomCalendarStatus.Name == this.RcvStatusFilter.Name);
            }
            return filter;
        }

        public ICommand RoomCalendarViewFilterCommand { get { return new RelayCommand(RoomCalendarViewFilterCommandHandler, CanExecute); } }
        public ICommand RoomCalendarViewFilterAllCommand { get { return new RelayCommand(RoomCalendarViewFilterAllCommandHandler, CanExecute); } }

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

        public RoomCalendarStatus RcvStatusFilter
        {
            get { return this.rcvStatusFilter; }
            set { this.rcvStatusFilter = value; }
        }
    }
}
