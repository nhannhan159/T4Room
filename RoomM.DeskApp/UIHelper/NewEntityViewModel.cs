using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;

using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;
using RoomM.Domain;

namespace RoomM.DeskApp.UIHelper
{
    public class NewEntityViewModel<T> where T : EntityBase, new()
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
