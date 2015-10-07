using RoomM.Models.Staffs;
using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoomM.DeskApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewStaff : Window
    {
        public NewStaff()
        {
            InitializeComponent();
        }

        public NewStaff(NewEntityViewModel<Staff> context)
            : this()
        {
            this.DataContext = context;
        }

    }
}
