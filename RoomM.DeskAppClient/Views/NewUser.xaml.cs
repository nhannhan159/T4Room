using MahApps.Metro.Controls;
using RoomM.DeskApp.UIHelper;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.DeskApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewUser : MetroWindow
    {
        public NewUser()
        {
            InitializeComponent();
        }

        public NewUser(NewEntityViewModel<User> context)
            : this()
        {
            this.DataContext = context;
        }
    }
}