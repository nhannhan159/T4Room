using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

using RoomM.DeskApp.UIHelper;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;
using RoomM.Application.RoomModule.Services;
using RoomM.Application.UserModule.Services;

namespace RoomM.DeskApp.ViewModels
{
    public class StatisticViewModel : ViewModelBase
    {
        private IRoomManagementService roomManagementService;
        private IUserManagementService userManagementService;
        private ObservableCollection<ChartElement> chartStaffItems;
        private ObservableCollection<ChartElement> chartRegisterItems;
        private DateTime fromTimeStaff;
        private DateTime toTimeStaff;
        private DateTime fromTimeRegister;
        private DateTime toTimeRegister;

        public StatisticViewModel(IRoomManagementService roomManagementService, IUserManagementService userManagementService)
        {
            this.roomManagementService = roomManagementService;
            this.userManagementService = userManagementService;

            this.fromTimeStaff = new DateTime(DateTime.Now.Year - 1, 1, 1);
            this.toTimeStaff = DateTime.Now;

            this.fromTimeRegister = new DateTime(DateTime.Now.Year - 1, 1, 1);
            this.toTimeRegister = DateTime.Now;

            this.rebuildUserData(fromTimeStaff, toTimeStaff);
            this.rebuildRegisterData(fromTimeRegister, toTimeRegister);
        }

        public ObservableCollection<ChartElement> GetStaffStatistic
        {
            get { return this.chartStaffItems; }
        }

        public ObservableCollection<ChartElement> GetRegisterStatistic
        {
            get { return this.chartRegisterItems; }
        }

        public DateTime FromTimeStaff 
        {
            get { return this.fromTimeStaff; }
            set 
            {
                this.fromTimeStaff = value;
                this.rebuildUserData(value, ToTimeStaff);
            }
        }

        public DateTime ToTimeStaff
        {
            get { return this.toTimeStaff; }
            set 
            {
                this.toTimeStaff = value;
                this.rebuildUserData(FromTimeStaff, value);   
            }
        }

        public DateTime FromTimeRegister
        {
            get { return this.fromTimeRegister; }
            set
            {
                this.fromTimeRegister = value;
                this.rebuildRegisterData(value, toTimeRegister);
            }
        }

        public DateTime ToTimeRegister
        {
            get { return this.toTimeRegister; }
            set
            {
                this.toTimeRegister = value;
                this.rebuildRegisterData(fromTimeRegister, value);
            }
        }

        private void rebuildUserData(DateTime from, DateTime to)
        {
            IList<KeyValuePair<User, int>> userDics = this.userManagementService.GetUserLimitByRegister(10, from, to);

            if (null == this.chartStaffItems)
                this.chartStaffItems = new ObservableCollection<ChartElement>();
            else
                this.chartStaffItems.Clear();

            foreach (KeyValuePair<User, int> d in userDics)
            {
                this.chartStaffItems.Add(new ChartElement
                {
                    Name = d.Key.FullName,
                    Value = d.Value
                });
            }
        }

        private void rebuildRegisterData(DateTime from, DateTime to)
        {
            IList<KeyValuePair<Room, int>> roomDics = this.roomManagementService.GetRoomLimitByRegister(10, from, to);

            if (null == this.chartRegisterItems)
                this.chartRegisterItems = new ObservableCollection<ChartElement>();
            else
                this.chartRegisterItems.Clear();

            foreach (KeyValuePair<Room, int> d in roomDics)
            {
                this.chartRegisterItems.Add(new ChartElement
                {
                    Name = d.Key.Name,
                    Value = d.Value
                });
            }
        }
    }


    public class ChartElement
    {
        private string name;
        private int value;

        public ChartElement(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public ChartElement()
        {
            // TODO: Complete member initialization
        }


        public string Name { get { return this.name; } set { this.name = value; } }
        public int Value { get { return this.value; } set { this.value = value; } }
    }
}
