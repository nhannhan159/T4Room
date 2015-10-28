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

using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.DeskApp.Views
{
    /// <summary>
    /// Interaction logic for Statictis.xaml
    /// </summary>
    public partial class Statictis : Page
    {

        // private IStaffRepository staffRep= RepositoryFactory.GetRepository<IStaffRepository, Staff>();
        // private IRoomRepository roomRep = RepositoryFactory.GetRepository<IRoomRepository, Room>();


        public Statictis()
        {
            InitializeComponent();

            // showColumnChar();
        }

        /*private void showColumnChar()
        {

            IList<Staff> staffList = staffRep.GetStaffLimitByRegister(10);
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();

            foreach (Staff staff in staffList)
            {
                valueList.Add(new KeyValuePair<string, int>(staff.Name, staff.RoomCalendars.Count()));
                // staff.RoomCalendars.Count();
            }

            //Setting data for fregister column chart
            fregisterChart.DataContext = valueList;


            IList<Room> roomList = roomRep.GetRoomListLimitByRegister(20);
            List<KeyValuePair<string, int>> valueList2 = new List<KeyValuePair<string, int>>();

            foreach (Room room in roomList)
            {
                valueList2.Add(new KeyValuePair<string, int>(room.Name, room.RoomCalendars.Count()));
            }

            // Setting data for fusing column chart
            fusingChart.DataContext = valueList2;

        }*/

    }
}
