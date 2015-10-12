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

using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.DeskApp.ViewModels
{
    class AssetManagementViewModel : EditableViewModel<Asset>
    {

        #region Contruction

        public AssetManagementViewModel()
            : base()
        {

            this.roomFilter = "";
            this.roomAssetViewFilterIsCheck = false;
            this.ravRoomNameFilter = "";
            this.currentRoomAsset = default(RoomAsset);
            List<RoomType> roomTypeList = new List<RoomType>(this.roomTypeRepo.GetAll());
            roomTypeList.Add(new RoomType("Tất cả"));
            this.roomTypeFilters1 = new CollectionView(roomTypeList);
            this.roomTypeFilters2 = new CollectionView(roomTypeList);
            this.roomTypeFilter1 = roomTypeList[roomTypeList.Count - 1];
            this.roomTypeFilter2 = roomTypeList[roomTypeList.Count - 1];
            List<Room> roomList = new List<Room>(this.roomRepo.GetAll());
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

        private IAssetRepository assRepo = RepositoryFactory.GetRepository<IAssetRepository, Asset>();
        private IRoomAssetHistoryRepository assHisRepo = RepositoryFactory.GetRepository<IRoomAssetHistoryRepository, RoomAssetHistory>();
        private IRoomRepository roomRepo = RepositoryFactory.GetRepository<IRoomRepository, Room>();
        private IRoomTypeRepository roomTypeRepo = RepositoryFactory.GetRepository<IRoomTypeRepository, RoomType>();
        private IRoomAssetRepository roomAssRepo = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();

        private string roomFilter;
        private NewAsset newAssetDialog;
        private ICollectionView currentRoomAssetView;
        private RoomAsset currentRoomAsset;
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
            return new List<Asset>(this.assRepo.GetAll());
        }

        protected override void SaveCurrentEntity()
        {
            try
            {
                if (this.CurrentEntity.ID > 0)
                    this.assRepo.Edit(this.CurrentEntity);
                else
                    this.assRepo.Add(this.CurrentEntity);
                this.assRepo.Save();
                // System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void DeleteCurrentEntity()
        {
            this.CurrentEntity.IsUsing = false;
            this.SaveCurrentEntity();
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
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(new List<RoomAsset>());
            else
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(new List<RoomAsset>(this.roomAssRepo.GetByAssetId(this.CurrentEntity.ID)));
            this.currentRoomAssetView.Filter += RoomAssetViewFilter;
            this.EntitiesView.Refresh();
            this.OnPropertyChanged("CurrentRoomAssetView");
            this.OnPropertyChanged("AssFuncEnabled");
        }

        protected override void SaveCommandHandler()
        {
            MainWindowViewModel.instance.ChangeStateToReady();
            MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn sửa thông tin tài sản?", "Xác nhận sửa thông tin", MessageBoxButton.YesNo);
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
            if (assRepo.isUniqueName(newEntityViewModel.NewEntity.Name.Trim()))
            {
                this.CloseNewEntityDialog();
                base.NewCommandHandler();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Thêm thất bại, tên tài sản bị trùng lắp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainWindowViewModel.instance.ChangeStateToComplete("Thêm thất bại, tên tài sản bị trùng lắp");
            }

        }

        #endregion

        #region AdditionView

        public bool AssFuncEnabled
        {
            get { return this.currentRoomAsset != null; }
        }

        public RoomAsset CurrentRoomAsset
        {
            get { return this.currentRoomAsset; }
            set
            {
                if (this.currentRoomAsset != value)
                {
                    this.currentRoomAsset = value;
                    this.OnPropertyChanged("CurrentRoomAsset");
                    this.OnPropertyChanged("AssFuncEnabled");
                }
            }
        }

        public ICollectionView CurrentRoomAssetView
        {
            get { return this.currentRoomAssetView; }
        }

        private bool RoomAssetViewFilter(object obj)
        {
            RoomAsset entity = obj as RoomAsset;
            bool filter = true;
            if (this.roomAssetViewFilterIsCheck)
            {
                filter = filter && entity.Room.Name.Contains(this.RavRoomNameFilter);
            }
            return filter;
        }

        public ICommand RoomAssetViewFilterCommand { get { return new RelayCommand(RoomAssetViewFilterCommandHandler, CanExecute); } }
        public ICommand RoomAssetViewFilterAllCommand { get { return new RelayCommand(RoomAssetViewFilterAllCommandHandler, CanExecute); } }

        private void RoomAssetViewFilterCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = true;
            this.currentRoomAssetView.Refresh();
        }

        private void RoomAssetViewFilterAllCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = false;
            this.currentRoomAssetView.Refresh();
        }

        public string RavRoomNameFilter
        {
            get { return this.ravRoomNameFilter; }
            set { this.ravRoomNameFilter = value; }
        }

        #endregion

        #region AssFunctions

        public ICommand AssFunc1Command { get { return new RelayCommand(AssFunc1CommandHandler, CanExecute); } }
        public ICommand AssFunc2Command { get { return new RelayCommand(AssFunc2CommandHandler, CanExecute); } }
        public ICommand AssFunc3Command { get { return new RelayCommand(AssFunc3CommandHandler, CanExecute); } }

        private void AssFunc1CommandHandler()
        {
            if (this.Amount1 > 0 && this.Room1 != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn nhập tài sản?", "Xác nhận nhập tài sản", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    this.roomAssRepo.AddOrUpdate(this.CurrentEntity.ID, this.Room1.ID, this.Amount1);
                    this.roomAssRepo.Save();
                    RoomAssetHistory roomAssHis = new RoomAssetHistory(DateTime.Now, 3, this.CurrentEntity.ID, this.Room1.ID, "", this.Amount1);
                    this.assHisRepo.Add(roomAssHis);
                    this.assHisRepo.Save();
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
            if (this.Amount2 > 0 && this.Amount2 <= this.CurrentRoomAsset.Amount)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn thanh lý tài sản?", "Xác nhận thanh lý", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        int num;
                        if (this.Amount2 >= this.CurrentRoomAsset.Amount)
                        {
                            num = this.CurrentRoomAsset.Amount;
                            this.roomAssRepo.Delete(this.CurrentRoomAsset);
                        }
                        else
                        {
                            num = this.Amount2;
                            this.CurrentRoomAsset.Amount -= this.Amount2;
                            this.roomAssRepo.Edit(this.CurrentRoomAsset);
                        }
                        this.roomAssRepo.Save();
                        RoomAssetHistory roomAssHis = new RoomAssetHistory(DateTime.Now, 2, this.CurrentEntity.ID, this.CurrentRoomAsset.RoomId, "", num);
                        this.assHisRepo.Add(roomAssHis);
                        this.assHisRepo.Save();
                        this.SetAdditionViewChange();
                        // System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thành công!");
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
            if (this.Amount3 > 0 && this.Amount3 <= this.CurrentRoomAsset.Amount && this.Room2 != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Bạn muốn chuyển tài sản?", "Xác nhận chuyển tài sản", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        int num;
                        if (this.Amount3 >= this.CurrentRoomAsset.Amount)
                        {
                            num = this.CurrentRoomAsset.Amount;
                            this.roomAssRepo.AddOrUpdate(this.CurrentEntity.ID, this.Room2.ID, this.CurrentRoomAsset.Amount);
                            this.roomAssRepo.Delete(this.CurrentRoomAsset);
                        }
                        else
                        {
                            num = this.Amount3;
                            this.roomAssRepo.AddOrUpdate(this.CurrentEntity.ID, this.Room2.ID, this.Amount3);
                            this.CurrentRoomAsset.Amount -= this.Amount3;
                            this.roomAssRepo.Edit(this.CurrentRoomAsset);
                        }
                        this.roomAssRepo.Save();
                        RoomAssetHistory roomAssHis1 = new RoomAssetHistory(DateTime.Now, 1, this.CurrentEntity.ID, this.CurrentRoomAsset.RoomId, this.Room2.Name, num);
                        RoomAssetHistory roomAssHis2 = new RoomAssetHistory(DateTime.Now, 4, this.CurrentEntity.ID, this.Room2.ID, this.CurrentRoomAsset.Room.Name, num);
                        this.assHisRepo.Add(roomAssHis1);
                        this.assHisRepo.Add(roomAssHis2);
                        this.assHisRepo.Save();
                        this.SetAdditionViewChange();
                        // System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thành công!");
                        MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Thông tin nhập không hợp lệ");
                    MainWindowViewModel.instance.ChangeStateToComplete("Thông tin nhập không hợp lệ");
                }
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
                List<Room> roomList = new List<Room>(this.roomRepo.GetAll());
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
                OnPropertyChanged("RoomView1");
            }
        }

        public RoomType RoomTypeFilter2
        {
            get { return this.roomTypeFilter2; }
            set
            {
                this.roomTypeFilter2 = value;

                List<Room> roomList = new List<Room>(this.roomRepo.GetAll());
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
                OnPropertyChanged("RoomView2");
            }
        }

        public Room Room1
        {
            get { return this.room1; }
            set { 
                this.room1 = value;
                this.OnPropertyChanged("Room1");
            }
        }

        public Room Room2
        {
            get { return this.room2; }
            set
            {
                this.room2 = value;
                this.OnPropertyChanged("Room2");
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
        public ICommand AssetsToExcelCommand { get { return new RelayCommand(AssetsToExcelCommandHandler, CanExecute); } }

        private void AssetsToExcelCommandHandler()
        {
            PureAssetsReportToExcel report = new PureAssetsReportToExcel("sgu university", "roomM", "templates/asset_tmp.xls");

            List<Asset> dataList = new List<Asset>();
            if (AllPlusIsCheck)
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
