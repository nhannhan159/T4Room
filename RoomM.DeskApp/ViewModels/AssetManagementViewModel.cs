using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Application.AssetModule.Services;

namespace RoomM.DeskApp.ViewModels
{
    public class AssetManagementViewModel : EditableViewModel<Asset>
    {

        #region Contruction

        public AssetManagementViewModel(IAssetManagementService service)
            : base()
        {
            this.service = service;
            this.BaseInit();

            this.roomFilter = "";
            this.roomAssetViewFilterIsCheck = false;
            this.ravRoomNameFilter = "";
            this.currentAssetDetail = default(AssetDetail);
            List<RoomType> roomTypeList = new List<RoomType>(this.service.GetRoomTypeList());
            roomTypeList.Add(new RoomType("Tất cả"));
            this.roomTypeFilters1 = new CollectionView(roomTypeList);
            this.roomTypeFilters2 = new CollectionView(roomTypeList);
            this.roomTypeFilter1 = roomTypeList[roomTypeList.Count - 1];
            this.roomTypeFilter2 = roomTypeList[roomTypeList.Count - 1];
            List<Room> roomList = new List<Room>(this.service.GetRoomList());
            this.roomView1 = CollectionViewSource.GetDefaultView(roomList);
            this.roomView2 = CollectionViewSource.GetDefaultView(roomList);
            this.room1 = (roomList.Count == 0) ? null : roomList[0];
            this.room2 = (roomList.Count == 0) ? null : roomList[0];
            this.amount1 = 0;
            this.amount2 = 0;
            this.amount3 = 0;
        }

        #endregion

        #region PrivateField

        private IAssetManagementService service;

        private string roomFilter;
        private NewAsset newAssetDialog;
        private ICollectionView currentAssetDetailView;
        private AssetDetail currentAssetDetail;
        private bool roomAssetViewFilterIsCheck;
        private string ravRoomNameFilter;

        private RoomType roomTypeFilter1;
        private RoomType roomTypeFilter2;
        private CollectionView roomTypeFilters1;
        private CollectionView roomTypeFilters2;
        private ICollectionView roomView1;
        private ICollectionView roomView2;
        private Room room1;
        private Room room2;
        private int amount1;
        private int amount2;
        private int amount3;

        #endregion

        #region General

        protected override List<Asset> GetEntitiesList()
        {
            return new List<Asset>(this.service.GetAssetList());
        }

        protected override void AddCurrentEntity()
        {
            try
            {
                this.service.AddAsset(this.CurrentEntity);
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
                this.service.EditAsset(this.CurrentEntity);
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
                this.service.DeleteAsset(this.CurrentEntity);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override bool IsUsing(Asset entity)
        {
            return entity.IsUsing;
        }

        protected override bool GeneralFilter(Asset entity)
        {
            bool filter = true;
            filter = filter && (entity.Name.Contains(this.NameFilter));
            filter = filter && (entity.AllRoomName.Contains(this.RoomFilter));
            return filter;
        }

        public string RoomFilter
        {
            get { return this.roomFilter; }
            set { this.roomFilter = value; }
        }

        protected override void NewDialogCommandHandler()
        {
            this.newEntityViewModel = new NewEntityViewModel<Asset>();
            this.newEntityViewModel.NewCommand = this.NewCommand;
            this.newAssetDialog = new NewAsset(this.newEntityViewModel);
            this.newAssetDialog.ShowDialog();
        }

        protected override void CloseNewEntityDialog()
        {
            this.newAssetDialog.Close();
        }

        protected override void SetAdditionViewChange()
        {
            if (this.CurrentEntity == null)
                this.currentAssetDetailView = CollectionViewSource.GetDefaultView(new List<AssetDetail>());
            else
                this.currentAssetDetailView = CollectionViewSource.GetDefaultView(new List<AssetDetail>(
                    this.service.GetAssetDetailListByAssetId(this.CurrentEntity.Id)));
            this.currentAssetDetailView.Filter += AssetDetailViewFilter;
            this.EntitiesView.Refresh();
            this.RaisePropertyChanged(() => this.CurrentAssetDetailView);
            this.RaisePropertyChanged(() => this.AssFuncEnabled);
        }

        #endregion

        #region AdditionView

        public bool AssFuncEnabled
        {
            get { return this.currentAssetDetail != null; }
        }

        public AssetDetail CurrentAssetDetail
        {
            get { return this.currentAssetDetail; }
            set
            {
                if (this.currentAssetDetail != value)
                {
                    this.currentAssetDetail = value;
                    this.RaisePropertyChanged(() => this.CurrentAssetDetail);
                    this.RaisePropertyChanged(() => this.AssFuncEnabled);
                }
            }
        }

        public ICollectionView CurrentAssetDetailView
        {
            get { return this.currentAssetDetailView; }
        }

        private bool AssetDetailViewFilter(object obj)
        {
            AssetDetail entity = obj as AssetDetail;
            bool filter = true;
            if (this.roomAssetViewFilterIsCheck)
            {
                filter = filter && entity.Room.Name.Contains(this.RavRoomNameFilter);
            }
            return filter;
        }

        public ICommand AssetDetailViewFilterCommand { get { return new RelayCommand(AssetDetailViewFilterCommandHandler); } }
        public ICommand AssetDetailViewFilterAllCommand { get { return new RelayCommand(AssetDetailViewFilterAllCommandHandler); } }

        private void AssetDetailViewFilterCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = true;
            this.currentAssetDetailView.Refresh();
        }

        private void AssetDetailViewFilterAllCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = false;
            this.currentAssetDetailView.Refresh();
        }

        public string RavRoomNameFilter
        {
            get { return this.ravRoomNameFilter; }
            set { this.ravRoomNameFilter = value; }
        }

        #endregion

        #region AssFunctions

        public ICommand AssFunc1Command { get { return new RelayCommand(AssFunc1CommandHandler); } }
        public ICommand AssFunc2Command { get { return new RelayCommand(AssFunc2CommandHandler); } }
        public ICommand AssFunc3Command { get { return new RelayCommand(AssFunc3CommandHandler); } }

        private void AssFunc1CommandHandler()
        {
            if (this.Amount1 > 0 && this.Room1 != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn nhập tài sản?", "Xác nhận nhập tài sản", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    this.service.ImportAsset(this.CurrentEntity.Id, this.Room1.Id, this.Amount1);
                    this.SetAdditionViewChange();
                    MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Thông tin nhập không hợp lệ");
                MainWindowViewModel.instance.ChangeStateToComplete("Thông tin nhập không hợp lệ");
            }
        }

        private void AssFunc2CommandHandler()
        {
            if (this.Amount2 > 0 && this.Amount2 <= this.CurrentAssetDetail.Amount)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn thanh lý tài sản?", "Xác nhận thanh lý", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        this.service.DropAsset(this.CurrentAssetDetail, this.Amount2);
                        this.SetAdditionViewChange();
                        MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Thông tin nhập không hợp lệ");
                MainWindowViewModel.instance.ChangeStateToComplete("Thông tin nhập không hợp lệ");
            }
        }

        private void AssFunc3CommandHandler()
        {
            if (this.Amount3 > 0 && this.Amount3 <= this.CurrentAssetDetail.Amount && this.Room2 != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn chuyển tài sản?", "Xác nhận chuyển tài sản", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        this.service.TransferAsset(this.CurrentAssetDetail, this.Room2, this.Amount3);
                        this.SetAdditionViewChange();
                        MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Thông tin nhập không hợp lệ");
                MainWindowViewModel.instance.ChangeStateToComplete("Thông tin nhập không hợp lệ");
            }
        }

        public CollectionView RoomTypeFilters1
        {
            get { return this.roomTypeFilters1; }
        }

        public CollectionView RoomTypeFilters2
        {
            get { return this.roomTypeFilters2; }
        }

        public RoomType RoomTypeFilter1
        {
            get { return this.roomTypeFilter1; }
            set
            {
                this.roomTypeFilter1 = value;
                List<Room> roomList = new List<Room>(this.service.GetRoomList());
                if (this.roomTypeFilter1.Name != "Tất cả")
                {
                    var query = roomList.Where(p => p.RoomType.Name == this.roomTypeFilter1.Name);
                    this.roomView1 = CollectionViewSource.GetDefaultView(query.ToList());
                    this.Room1 = (query.Count() > 0) ? query.First() : null;
                }
                else
                {
                    this.roomView1 = CollectionViewSource.GetDefaultView(roomList);
                    this.Room1 = roomList.First();
                }
                this.RaisePropertyChanged(() => this.RoomView1);
            }
        }

        public RoomType RoomTypeFilter2
        {
            get { return this.roomTypeFilter2; }
            set
            {
                this.roomTypeFilter2 = value;

                List<Room> roomList = new List<Room>(this.service.GetRoomList());
                if (this.roomTypeFilter2.Name != "Tất cả")
                {
                    var query = roomList.Where(p => p.RoomType.Name == this.roomTypeFilter2.Name);
                    this.roomView2 = CollectionViewSource.GetDefaultView(query.ToList());
                    this.Room2 = (query.Count() > 0) ? query.First() : null;
                }
                else
                {
                    this.roomView2 = CollectionViewSource.GetDefaultView(roomList);
                    this.Room2 = roomList.First();
                }
                this.RaisePropertyChanged(() => this.RoomView2);
            }
        }

        public Room Room1
        {
            get { return this.room1; }
            set { 
                this.room1 = value;
                this.RaisePropertyChanged(() => this.Room1);
            }
        }

        public Room Room2
        {
            get { return this.room2; }
            set
            {
                this.room2 = value;
                this.RaisePropertyChanged(() => this.Room2);
            }
        }

        public ICollectionView RoomView1
        {
            get { return this.roomView1; }
        }

        public ICollectionView RoomView2
        {
            get { return this.roomView2; }
        }

        public int Amount1
        {
            get { return this.amount1; }
            set { this.amount1 = value; }
        }

        public int Amount2
        {
            get { return this.amount2; }
            set { this.amount2 = value; }
        }

        public int Amount3
        {
            get { return this.amount3; }
            set { this.amount3 = value; }
        }

        #endregion


        // command handler
        public ICommand AssetsToExcelCommand { get { return new RelayCommand(AssetsToExcelCommandHandler); } }

        private void AssetsToExcelCommandHandler()
        {
            AssetReportToExcel report = new AssetReportToExcel("sgu university", "roomM", "templates/asset_tmp.xls");

            List<Asset> dataList = new List<Asset>();
            if (IsIncludeAll)
                dataList = EntitiesList;
            else
            {
                foreach (Asset r in EntitiesList)
                    if (r.IsUsing)
                        dataList.Add(r);
            }

            report.setupExport(dataList);
            report.save();
        }
    }
}
