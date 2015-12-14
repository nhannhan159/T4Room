using MahApps.Metro.Controls;
using RoomM.DeskApp.UIHelper;
using RoomM.Application.RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.DeskApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewRoom : MetroWindow
    {
        public NewRoom()
        {
            InitializeComponent();
        }

        public NewRoom(NewEntityViewModel<Room> context)
            : this()
        {
            this.DataContext = context;
        }
    }
}