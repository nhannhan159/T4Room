using System.Windows.Input;

namespace RoomM.DeskApp.UIHelper
{
    public class NewEntityViewModel<T> where T : class, new()
    {
        private T newEntity;

        public NewEntityViewModel()
        {
            newEntity = new T();
        }

        public T NewEntity
        {
            get { return this.newEntity; }
            set { this.newEntity = value; }
        }

        public ICommand NewCommand { get; set; }
    }
}