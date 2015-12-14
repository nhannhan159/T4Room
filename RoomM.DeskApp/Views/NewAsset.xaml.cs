using MahApps.Metro.Controls;
using RoomM.DeskApp.UIHelper;
using RoomM.Application.RoomM.Domain.AssetModule.Aggregates;

namespace RoomM.DeskApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewAsset : MetroWindow
    {
        public NewAsset()
        {
            InitializeComponent();
        }

        public NewAsset(NewEntityViewModel<Asset> context)
            : this()
        {
            this.DataContext = context;
        }
    }
}