using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RoomM.DeskApp.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RoomM.DeskApp.UIHelper
{
    public abstract class EditableViewModel<T> : ViewModelBase where T : class, new()
    {
        private bool isIncludeAll;
        private bool filterIsCheck;
        private T currentEntity;
        private List<T> entitiesList;
        private ICollectionView entitiesView;
        private string namefilter;

        protected NewEntityViewModel<T> newEntityViewModel;

        protected EditableViewModel()
            : base()
        {
            this.NameFilter = "";
            this.isIncludeAll = false;
            this.filterIsCheck = false;

            this.SaveCommand = new RelayCommand(this.SaveCommandHandler, () => { return this.currentEntity != null; });
            this.NewCommand = new RelayCommand(this.NewCommandHandler);
            this.NewDialogCommand = new RelayCommand(this.NewDialogCommandHandler);
            this.DeleteCommand = new RelayCommand(this.DeleteCommandHandler);
            this.FilterCommand = new RelayCommand(this.FilterCommandHandler);
            this.FilterAllCommand = new RelayCommand(this.FilterAllCommandHandler);
            this.FilterAllPlusCommand = new RelayCommand(this.FilterAllPlusCommandHandler);
        }

        protected void BaseInit()
        {
            this.currentEntity = default(T);
            this.entitiesList = this.GetEntitiesList();
            this.entitiesView = CollectionViewSource.GetDefaultView(this.entitiesList);
            this.entitiesView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            this.entitiesView.GroupDescriptions.Add(this.Grouping());
            this.entitiesView.Filter += EntityFilter;
        }

        protected abstract List<T> GetEntitiesList();

        protected abstract void AddCurrentEntity();

        protected abstract void EditCurrentEntity();

        protected abstract void DeleteCurrentEntity();

        protected abstract void CloseNewEntityDialog();

        public T CurrentEntity
        {
            get { return this.currentEntity; }
            set
            {
                if (this.currentEntity != value)
                {
                    this.currentEntity = value;
                    this.RaisePropertyChanged(() => this.CurrentEntity);
                    this.SetAdditionViewChange();
                }
            }
        }

        protected virtual PropertyGroupDescription Grouping()
        {
            return new PropertyGroupDescription("");
        }

        protected virtual bool IsUsing(T entity)
        {
            return true;
        }

        protected virtual bool GeneralFilter(T entity)
        {
            return true;
        }

        protected virtual void SetAdditionViewChange()
        {
        }

        private bool EntityFilter(object obj)
        {
            T entity = (T)obj;
            bool filter = true;
            if (!this.isIncludeAll)
                filter = filter && this.IsUsing(entity);
            if (this.filterIsCheck)
                filter = filter && this.GeneralFilter(entity);
            return filter;
        }

        public bool IsIncludeAll
        {
            get { return this.isIncludeAll; }
            set
            {
                this.isIncludeAll = value;
                this.RaisePropertyChanged(() => this.IsIncludeAll);
            }
        }

        public bool CanModify
        {
            get
            {
                if (this.currentEntity == null) return false;
                return this.IsUsing(this.currentEntity);
            }
        }

        public string NameFilter
        {
            get { return this.namefilter; }
            set { this.namefilter = value; }
        }

        protected List<T> EntitiesList
        {
            get { return this.entitiesList; }
            set { this.entitiesList = value; }
        }

        public ICollectionView EntitiesView
        {
            get { return this.entitiesView; }
        }

        public int NumRowRecord
        {
            get { return this.entitiesList.Count; }
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand NewCommand { get; private set; }
        public ICommand NewDialogCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand FilterCommand { get; private set; }
        public ICommand FilterAllCommand { get; private set; }
        public ICommand FilterAllPlusCommand { get; private set; }

        private void SaveCommandHandler()
        {
            MainWindowViewModel.instance.ChangeStateToReady();
            MessageBoxResult result = MessageBox.Show("Bạn muốn sửa thông tin ?", "Xác nhận sửa thông tin", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.EditCurrentEntity();
                MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
            }
            this.entitiesView.Refresh();
        }

        private void NewCommandHandler()
        {
            MainWindowViewModel.instance.ChangeStateToReady();
            MessageBoxResult result = MessageBox.Show("Bạn muốn thêm thông tin ?", "Xác nhận thêm thông tin", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.CurrentEntity = this.newEntityViewModel.NewEntity;
                this.AddCurrentEntity();
                this.CloseNewEntityDialog();
                MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
            }
            this.entitiesList.Add(this.currentEntity);
            this.entitiesView.MoveCurrentToLast();
            this.entitiesView.Refresh();
        }

        private void DeleteCommandHandler()
        {
            MainWindowViewModel.instance.ChangeStateToReady();
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xoá ?", "Xác nhận xóa", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.DeleteCurrentEntity();
                MainWindowViewModel.instance.ChangeStateToComplete("Xóa thành công");
            }
            this.entitiesView.Refresh();
        }

        protected virtual void NewDialogCommandHandler()
        {
        }

        private void FilterCommandHandler()
        {
            this.filterIsCheck = true;
            this.entitiesView.Refresh();
        }

        private void FilterAllCommandHandler()
        {
            this.filterIsCheck = false;
            this.entitiesView.Refresh();
        }

        private void FilterAllPlusCommandHandler()
        {
            this.entitiesView.Refresh();
        }
    }
}