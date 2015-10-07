using RoomM.DeskApp.ViewModels;
using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RoomM.DeskApp.UIHelper
{
    public abstract class EditableViewModel<T> 
        : ViewModel where T : EntityBase, new()
    {

        private bool allPlusIsCheck;
        private bool filterIsCheck;
        private T currentEntity;
        private List<T> entitiesList;
        private ICollectionView entitiesView;
        private string namefilter;
        protected bool canExecuteSaveCommand;
        protected bool canExecuteNewCommand;
        protected NewEntityViewModel<T> newEntityViewModel;

        protected EditableViewModel()
            : base()
        {
            this.currentEntity = default(T);
            this.entitiesList = this.GetEntitiesList();
            this.entitiesView = CollectionViewSource.GetDefaultView(this.entitiesList);
            this.entitiesView.CurrentChanged += EntitySelectionChanged;
            this.entitiesView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            this.entitiesView.GroupDescriptions.Add(this.Grouping());
            this.NameFilter = "";
            this.allPlusIsCheck = false;
            this.filterIsCheck = false;
            this.entitiesView.Filter += EntityFilter;
            this.canExecuteNewCommand = true;
            this.canExecuteSaveCommand = false;
        }

        protected abstract List<T> GetEntitiesList();
        protected abstract void SaveCurrentEntity();
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
                    this.canExecuteSaveCommand = (this.currentEntity != null);
                    this.OnPropertyChanged("CurrentEntity");
                    this.SetAdditionViewChange();
                }
            }
        }

        protected virtual PropertyGroupDescription Grouping()
        {
            return new PropertyGroupDescription("");
        }

        protected virtual void EntitySelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("CHANGED...");
        }

        protected virtual bool IsUsing(T entity) { return true; }
        protected virtual bool GeneralFilter(T entity) { return true; }
        protected virtual void SetAdditionViewChange() { }

        private bool EntityFilter(object obj)
        {
            T entity = obj as T;
            bool filter=true;
            if (!this.allPlusIsCheck)
                filter = filter && this.IsUsing(entity);
            if (this.filterIsCheck)
                filter = filter && this.GeneralFilter(entity);
            return filter;
        }

        public bool AllPlusIsCheck
        {
            get { return this.allPlusIsCheck; }
            set
            {
                this.allPlusIsCheck = value;
                OnPropertyChanged("AllPlusIsCheck");
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

        public ICommand SaveCommand { get { return new RelayCommand(SaveCommandHandler, CanExecuteSaveCommand); } }
        public ICommand NewCommand { get { return new RelayCommand(NewCommandHandler, CanExecuteNewCommand); } }
        public ICommand NewDialogCommand { get { return new RelayCommand(NewDialogCommandHandler, CanExecute); } }
        public ICommand DelCommand { get { return new RelayCommand(DeleteCommandHandler, CanExecute); } }
        public ICommand FilterCommand { get { return new RelayCommand(FilterCommandHandler, CanExecute); } }
        public ICommand FilterAllCommand { get { return new RelayCommand(FilterAllCommandHandler, CanExecute); } }
        public ICommand FilterAllPlusCommand { get { return new RelayCommand(FilterAllPlusCommandHandler, CanExecute); } }
       
        private bool CanExecuteSaveCommand() { return canExecuteSaveCommand; }
        private bool CanExecuteNewCommand() { return canExecuteNewCommand; }
        protected bool CanExecute() { return true; }

        public int NumRowRecord
        {
            get { return this.entitiesList.Count; }
        }

        protected virtual void SaveCommandHandler()
        {
            /* MainWindowViewModel.instance.ChangeStateToReady();
            MessageBoxResult result = MessageBox.Show("Bạn muốn sửa thông tin phòng?", "Xác nhận sửa thông tin", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.SaveCurrentEntity();
                MainWindowViewModel.instance.ChangeStateToComplete("Cập nhật thành công");
            }*/
            this.entitiesView.Refresh();
        }

        protected virtual void NewCommandHandler()
        {
            // this.CloseNewEntityDialog();
            this.CurrentEntity = this.newEntityViewModel.NewEntity;
            this.SaveCurrentEntity();
            this.entitiesList.Add(this.currentEntity);
            this.entitiesView.Refresh();
            this.entitiesView.MoveCurrentToLast();
        }

        private void DeleteCommandHandler()
        {
            MainWindowViewModel.instance.ChangeStateToReady();

            if (this.IsUsing(this.currentEntity))
            {
                MessageBoxResult result = MessageBox.Show("Bạn muốn xóa phòng này à?", "Xác nhận xóa phòng", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    this.DeleteCurrentEntity();
                    MainWindowViewModel.instance.ChangeStateToComplete("Xóa thành công");
                }
                this.entitiesView.Refresh();

            }
            else
            {
                MessageBox.Show("Phòng đã bị xoá, không thể xoá tiếp!");
            }
        }

        protected virtual void NewDialogCommandHandler() { }

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
