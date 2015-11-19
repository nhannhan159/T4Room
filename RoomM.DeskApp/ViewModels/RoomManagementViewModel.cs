using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;

using GalaSoft.MvvmLight.Command;

using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Application.RoomModule.Services;

namespace RoomM.DeskApp.ViewModels
{
    public class RoomManagementViewModel : EditableViewModel<Room>
    {

        #region Contruction

        public RoomManagementViewModel(IRoomManagementService service)
            : base()
        {
            this.service = service;
            this.BaseInit();

            List<RoomType> roomTypeList = new List<RoomType>(this.service.GetRoomTypeList());
            roomTypeList.Add(new RoomType("Tất cả"));
            this.roomTypeFilters = new CollectionView(roomTypeList);
            this.roomTypeFilter = roomTypeList[roomTypeList.Count - 1];
            this.roomCalendarViewFilterIsCheck = false;
            this.roomAssetViewFilterIsCheck = false;
            this.roomHistoryViewFilterIsCheck = false;
            this.rcvDateFromFilter = new DateTime(2000, 1, 1);
            this.rcvDateToFilter = DateTime.Now;
            this.rcvPeriodsFilter = 0;
            this.rcvBeginTimeFilter = 0;
            this.rcvRegistrantFilter = "";

            this.RoomRegTypeView = RoomReg.GetRegType;
            this.RoomRegTypeView.Add(0, "Tất cả");
            this.RcvStatusFilters = this.RoomRegTypeView;
            this.rcvStatusFilter = 0;
            this.ravAssetNameFilter = "";
            this.rhvDateFromFilter = new DateTime(2000, 1, 1);
            this.rhvDateToFilter = DateTime.Now;
            this.rhvAssetNameFilter = "";

            this.RhvTypeFilters = AssetHistory.GetHistoryType;
            this.RhvTypeFilters.Add(0, "Tất cả");
            this.rhvTypeFilter = 0;
            this.currentRoomReg = default(RoomReg);

            this.timeForBacktrace = DateTime.Now;
            this.historiesList = new List<HistoryRecord>();
            this.historiesView = new CollectionView(historiesList);
        }

        #endregion

        #region PrivateField

        private IRoomManagementService service;

        private NewRoom newRoomDialog;
        private RoomType roomTypeFilter;
        private CollectionView roomTypeFilters;
        private RoomReg currentRoomReg;
        private ICollectionView currentRoomRegView;
        private ICollectionView currentRoomAssetView;
        private ICollectionView currentRoomHistoryView;
        private bool roomCalendarViewFilterIsCheck;
        private bool roomAssetViewFilterIsCheck;
        private bool roomHistoryViewFilterIsCheck;
        private DateTime rcvDateFromFilter;
        private DateTime rcvDateToFilter;
        private int rcvPeriodsFilter;
        private string rcvRegistrantFilter;
        private int rcvBeginTimeFilter;
        private int rcvStatusFilter;
        private string ravAssetNameFilter;
        private DateTime rhvDateFromFilter;
        private DateTime rhvDateToFilter;
        private string rhvAssetNameFilter;
        private int rhvTypeFilter;

        private List<HistoryRecord> historiesList;
        private ICollectionView historiesView;
        private DateTime timeForBacktrace;

        public List<HistoryRecord> HistoriesList
        {
            get { return historiesList; }
            set { historiesList = value; }
        }

        public ICollectionView HistoriesView
        {
            get { return historiesView; }
            set { historiesView = value; }
        }

        public DateTime TimeForBacktrace
        {
            get { return timeForBacktrace; }
            set { timeForBacktrace = value; }
        }

        public CollectionView RoomTypeFilters
        {
            get { return this.roomTypeFilters; }
        }

        protected override List<Room> GetEntitiesList()
        {
            return new List<Room>(this.service.GetRoomList());
        }

        protected override void AddCurrentEntity()
        {
            try
            {
                this.service.AddRoom(this.CurrentEntity);
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
                this.service.EditRoom(this.CurrentEntity);
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
                this.service.DeleteRoom(this.CurrentEntity);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override bool IsUsing(Room entity) 
        {
            return entity.IsUsing;
        }

        protected override bool GeneralFilter(Room entity)
        {
            bool filter = true;
            filter = filter && (entity.Name.Contains(this.NameFilter));
            if (this.RoomTypeFilter.Name != "Tất cả")
                filter = filter && (entity.RoomType.Name == this.RoomTypeFilter.Name);
            return filter;
        }

        public RoomType RoomTypeFilter
        {
            get { return this.roomTypeFilter; }
            set { this.roomTypeFilter = value; }
        }

        protected override void NewDialogCommandHandler()
        {
            this.newEntityViewModel = new NewEntityViewModel<Room>();
            this.newEntityViewModel.NewCommand = this.NewCommand;
            this.newRoomDialog = new NewRoom(this.newEntityViewModel);
            this.newRoomDialog.roomTypeCB.ItemsSource = this.RoomTypesView;
            this.newRoomDialog.ShowDialog();
        }

        protected override void CloseNewEntityDialog()
        {
            this.newRoomDialog.Close();
        }

        protected override void SetAdditionViewChange()
        {
            if (this.CurrentEntity == null)
            {
                this.currentRoomRegView = CollectionViewSource.GetDefaultView(new List<RoomReg>());
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(new List<AssetDetail>());
                this.currentRoomHistoryView = CollectionViewSource.GetDefaultView(new List<AssetHistory>());
            }
            else
            {
                this.currentRoomRegView = CollectionViewSource.GetDefaultView(
                    this.service.GetRoomRegList(this.CurrentEntity.Id));
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(
                    this.service.GetAssetDetailList(this.CurrentEntity.Id));
                this.currentRoomHistoryView = CollectionViewSource.GetDefaultView(
                    this.service.GetAssetHistoryList(this.CurrentEntity.Id));
            }
            this.currentRoomRegView.Filter += RoomRegViewFilter;
            this.currentRoomAssetView.Filter += RoomAssetViewFilter;
            this.currentRoomHistoryView.Filter += RoomHistoryViewFilter;
            this.RaisePropertyChanged(() => this.CurrentRoomRegView);
            this.RaisePropertyChanged(() => this.CurrentRoomAssetView);
            this.RaisePropertyChanged(() => this.CurrentRoomHistoryView);
        }

        public ICollectionView RoomTypesView
        {
            get { return CollectionViewSource.GetDefaultView(this.service.GetRoomTypeList()); }
        }

        #endregion

        public Dictionary<int, string> RoomRegTypeView { get; set; }

        public RoomReg CurrentRoomReg
        {
            get { return this.currentRoomReg; }
            set
            {
                if (this.currentRoomReg != value)
                {
                    this.currentRoomReg = value;
                    this.RaisePropertyChanged(() => this.CurrentRoomReg);
                }
            }
        }

        public ICollectionView CurrentRoomRegView
        {
            get { return this.currentRoomRegView; }
        }

        public ICollectionView CurrentRoomAssetView
        {
            get { return this.currentRoomAssetView; }
        }

        public ICollectionView CurrentRoomHistoryView
        {
            get { return this.currentRoomHistoryView; }
        }

        private bool RoomRegViewFilter(object obj)
        {
            RoomReg entity = obj as RoomReg;
            bool filter = true;
            if (this.roomCalendarViewFilterIsCheck)
            {
                filter = filter && (entity.Date >= this.RcvDateFromFilter);
                filter = filter && (entity.Date <= this.RcvDateToFilter);
                filter = filter && entity.User.Name.Contains(this.RcvRegistrantFilter); 
                if (this.RcvPeriodsFilter > 0)
                    filter = filter && (entity.Length == this.RcvPeriodsFilter);
                if (this.RcvBeginTimeFilter > 0)
                    filter = filter && (entity.Start == this.RcvBeginTimeFilter);
                if (this.RcvStatusFilter != 0)
                    filter = filter && (entity.RoomRegTypeId == this.RcvStatusFilter);
            }
            return filter;
        }

        private bool RoomAssetViewFilter(object obj)
        {
            AssetDetail entity = obj as AssetDetail;
            bool filter = true;
            if (this.roomAssetViewFilterIsCheck)
            {
                filter = filter && entity.Asset.Name.Contains(this.RavAssetNameFilter);
            }
            return filter;
        }

        private bool RoomHistoryViewFilter(object obj)
        {
            AssetHistory entity = obj as AssetHistory;
            bool filter = true;
            if (this.roomHistoryViewFilterIsCheck)
            {
                filter = filter && (entity.Date >= this.RhvDateFromFilter);
                filter = filter && (entity.Date <= this.RhvDateToFilter);
                filter = filter && entity.Asset.Name.Contains(this.RhvAssetNameFilter);
                if (this.RhvTypeFilter != 0)
                    filter = filter && (entity.AssetHistoryTypeId == this.RhvTypeFilter);
            }
            return filter;
        }

        public ICommand RoomRegViewFilterCommand { get { return new RelayCommand(RoomRegViewFilterCommandHandler); } }
        public ICommand RoomAssetViewFilterCommand { get { return new RelayCommand(RoomAssetViewFilterCommandHandler); } }
        public ICommand RoomHistoryViewFilterCommand { get { return new RelayCommand(RoomHistoryViewFilterCommandHandler); } }
        public ICommand RoomRegViewFilterAllCommand { get { return new RelayCommand(RoomRegViewFilterAllCommandHandler); } }
        public ICommand RoomAssetViewFilterAllCommand { get { return new RelayCommand(RoomAssetViewFilterAllCommandHandler); } }
        public ICommand RoomHistoryViewFilterAllCommand { get { return new RelayCommand(RoomHistoryViewFilterAllCommandHandler); } }
        public ICommand ChangeCalendarStatusCommand { get { return new RelayCommand(ChangeCalendarStatusCommandHandler); } }

        private void RoomRegViewFilterCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = true;
            this.currentRoomRegView.Refresh();
        }


        private void RoomAssetViewFilterCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = true;
            this.currentRoomAssetView.Refresh();
        }

        private void RoomHistoryViewFilterCommandHandler()
        {
            this.roomHistoryViewFilterIsCheck = true;
            this.currentRoomHistoryView.Refresh();
        }

        private void RoomRegViewFilterAllCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = false;
            this.currentRoomRegView.Refresh();
        }

        private void RoomAssetViewFilterAllCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = false;
            this.currentRoomAssetView.Refresh();
        }

        private void RoomHistoryViewFilterAllCommandHandler()
        {
            this.roomHistoryViewFilterIsCheck = false;
            this.currentRoomHistoryView.Refresh();
        }

        private void ChangeCalendarStatusCommandHandler()
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn đổi trạng thái đăng ký?", "Đổi trạng thái đăng ký", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    this.service.EditRoomReg(this.CurrentRoomReg);
                    this.EntitiesView.Refresh();
                    System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thành công!");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
                }
            }
            this.currentRoomRegView.Refresh();
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

        public string RcvRegistrantFilter
        {
            get { return this.rcvRegistrantFilter; }
            set { this.rcvRegistrantFilter = value; }
        }

        public int RcvStatusFilter
        {
            get { return this.rcvStatusFilter; }
            set { this.rcvStatusFilter = value; }
        }

        public string RavAssetNameFilter
        {
            get { return this.ravAssetNameFilter; }
            set { this.ravAssetNameFilter = value; }
        }

        public string RhvAssetNameFilter
        {
            get { return this.rhvAssetNameFilter; }
            set { this.rhvAssetNameFilter = value; }
        }

        public DateTime RhvDateFromFilter
        {
            get { return this.rhvDateFromFilter; }
            set { this.rhvDateFromFilter= value; }
        }

        public DateTime RhvDateToFilter
        {
            get { return this.rhvDateToFilter; }
            set { this.rhvDateToFilter = value; }
        }

        public int RhvTypeFilter
        {
            get { return this.rhvTypeFilter; }
            set { this.rhvTypeFilter = value; }
        }

        public Dictionary<int, string> RcvStatusFilters { get; set; }

        public Dictionary<int, string> RhvTypeFilters { get; set; }

        // commands
        public ICommand ExportToExcelCommand { get { return new RelayCommand(ExportToExcelCommandHandler); } }
        public ICommand ExportCalRegisterToExcelCommand { get { return new RelayCommand(ExportCalRegisterToExcelCommandHandler); } }
        public ICommand ExportAssetsToExcelCommand { get { return new RelayCommand(ExportAssetsToExcelCommandHandler); } }
        public ICommand ExportHistoriesToExcelCommand { get { return new RelayCommand(ExportHistoriesToExcelCommandHandler); } }

        private void ExportToExcelCommandHandler()
        {
            RoomReportToExcel report = new RoomReportToExcel("sgu university", "roomM", "templates/roomlist_tmp.xls");

            List<Room> dataList = new List<Room>();
            if (IsIncludeAll)
                dataList = EntitiesList;
            else
            {
                foreach (Room r in EntitiesList)
                    if (r.IsUsing)
                        dataList.Add(r);
            }

            report.setupExport(dataList);
            report.save();
        }

        private void ExportCalRegisterToExcelCommandHandler()
        {
            List<RoomReg> dataList = new List<RoomReg>();
            dataList = CurrentEntity.RoomRegs.ToList();

            RoomRegReportToExcel report = new RoomRegReportToExcel("sgu university", "roomM", "templates/roomcalendar_tmp.xls");

            report.setupExport(dataList, CurrentEntity);
            report.save();
        }

        private void ExportAssetsToExcelCommandHandler()
        {
            List<AssetDetail> dataList = new List<AssetDetail>();
            dataList = CurrentEntity.AssetDetails.ToList();

            AssetDetailReportToExcel report = new AssetDetailReportToExcel("sgu university", "roomM", "templates/roomasset_tmp.xls");

            report.setupExport(dataList, CurrentEntity);
            report.save();
        }     

        private void ExportHistoriesToExcelCommandHandler()
        {
            List<AssetHistory> dataList = new List<AssetHistory>();
            dataList = CurrentEntity.AssetHistories.ToList();

            AssetHistoryReportToExcel report = new AssetHistoryReportToExcel("sgu university", "roomM", "templates/roomhistory_tmp.xls");

            report.setupExport(dataList, CurrentEntity);
            report.save();
        }


        // backtrace button
        public ICommand BacktraceCommand { get { return new RelayCommand(BacktraceCommandHandler); } }

        private void BacktraceCommandHandler()
        {
            // proc amount
            // Dictionary<String, int> dic = new Dictionary<string,int>();
            Hashtable hm = new Hashtable();
            
            IList<AssetHistory> hisList = this.service.GetByRoom2RoomId(CurrentEntity, timeForBacktrace);
            foreach (AssetHistory his in hisList)
            {
                if (his.Date.Date <= timeForBacktrace)
                {

                    if (!hm.ContainsKey(his.Asset.Name))
                        hm[his.Asset.Name] = new HistoryRecord 
                        {
                            AssetName = his.Asset.Name,
                            Amount = 0, AmountImport = 0, AmountRemove = 0
                        };

                    if (his.AssetHistoryTypeId == Contants.ASSETS_IMPORT)
                    {
                        (hm[his.Asset.Name] as HistoryRecord).Amount = (hm[his.Asset.Name] as HistoryRecord).Amount + his.Amount;
                        (hm[his.Asset.Name] as HistoryRecord).AmountImport = (hm[his.Asset.Name] as HistoryRecord).AmountImport + his.Amount;
                    }
                    else if (his.AssetHistoryTypeId == Contants.ASSETS_REMOVE)
                    {
                        (hm[his.Asset.Name] as HistoryRecord).Amount = (hm[his.Asset.Name] as HistoryRecord).Amount - his.Amount;
                        (hm[his.Asset.Name] as HistoryRecord).AmountRemove = (hm[his.Asset.Name] as HistoryRecord).AmountRemove + his.Amount;
                    }
                    else if (his.AssetHistoryTypeId == Contants.ASSETS_TRANSFER)
                    {
                        if (his.Room.Id == CurrentEntity.Id)
                        {
                            (hm[his.Asset.Name] as HistoryRecord).Amount = (hm[his.Asset.Name] as HistoryRecord).Amount - his.Amount;
                            (hm[his.Asset.Name] as HistoryRecord).AmountRemove = (hm[his.Asset.Name] as HistoryRecord).AmountRemove + his.Amount;
                        }
                        else
                        {
                            (hm[his.Asset.Name] as HistoryRecord).Amount = (hm[his.Asset.Name] as HistoryRecord).Amount + his.Amount;
                            (hm[his.Asset.Name] as HistoryRecord).AmountImport = (hm[his.Asset.Name] as HistoryRecord).AmountImport + his.Amount;
                        }
                    }
                }
            }

            // refresh
            historiesList.Clear();

            foreach (String asset in hm.Keys)
            {
                HistoryRecord hr = hm[asset] as HistoryRecord;
                if (hr.Amount > 0 || hr.AmountImport > 0 || hr.AmountRemove > 0)
                    historiesList.Add(hr);
            }

            this.historiesView.Refresh();
        }

        // refresh
        public ICommand RefreshCommand { get { return new RelayCommand(RefreshCommandHandler); } }

        private void RefreshCommandHandler()
        {

            // init data context;
            // EFDataContext.instance = new EFDataContext();

            // EFDataContext

            this.EntitiesList = this.GetEntitiesList();
            this.EntitiesView.Refresh();

            this.currentRoomAssetView.Refresh();
            this.currentRoomHistoryView.Refresh();
            this.currentRoomRegView.Refresh();
            this.currentRoomAssetView.Refresh();
            this.currentRoomHistoryView.Refresh();
        }

        public class HistoryRecord {
            public String AssetName { get; set; }
            public int Amount { get; set; }
            public int AmountRemove { get; set; }
            public int AmountImport { get; set; }

            public HistoryRecord() { }

        }
            
    }

}

