using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.DeskApp.UIHelper;
using RoomM.Models;

namespace RoomM.DeskApp.ViewModels
{
    public class StatisticViewModel : EditableViewModel<Room>
    {

        private StaffService.StaffServiceClient staffService = new StaffService.StaffServiceClient();
        private RoomService.RoomServiceClient roomService = new RoomService.RoomServiceClient();

        private ObservableCollection<ChartElement> chartStaffItems;
        private ObservableCollection<ChartElement> chartRegisterItems;
        private DateTime fromTimeStaff;
        private DateTime toTimeStaff;
        private DateTime fromTimeRegister;
        private DateTime toTimeRegister;


        public StatisticViewModel()
            //: base()
        {
            // DateTime now = new DateTime(DateTime.);
            this.fromTimeStaff = new DateTime(DateTime.Now.Year - 1, 1, 1);
            this.toTimeStaff = DateTime.Now;

            this.fromTimeRegister = new DateTime(DateTime.Now.Year - 1, 1, 1);
            this.toTimeRegister = DateTime.Now;

            this.rebuildStaffData(fromTimeStaff, toTimeStaff);
            this.rebuildRegisterData(fromTimeRegister, toTimeRegister);
        }


        protected override List<Room> GetEntitiesList()
        {
            return this.roomService.GetAll();
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
                this.rebuildStaffData(value, ToTimeStaff);
            }
        }

        public DateTime ToTimeStaff
        {
            get { return this.toTimeStaff; }
            set 
            {
                this.toTimeStaff = value;
                this.rebuildStaffData(FromTimeStaff, value);   
            }
        }

        public DateTime FromTimeRegister
        {
            get { return fromTimeRegister; }
            set
            {
                this.fromTimeRegister = value;
                this.rebuildRegisterData(value, toTimeRegister);
            }
        }

        public DateTime ToTimeRegister
        {
            get { return toTimeRegister; }
            set
            {
                this.toTimeRegister = value;
                this.rebuildRegisterData(fromTimeRegister, value);
            }
        }

        protected override void SaveCurrentEntity()
        {
            throw new NotImplementedException();
        }

        protected override void DeleteCurrentEntity()
        {
            throw new NotImplementedException();
        }

        protected override void CloseNewEntityDialog()
        {
            throw new NotImplementedException();
        }

        private void rebuildStaffData(DateTime from, DateTime to)
        { 
            /*
            List<DictionaryEntry> staffDics = staffService.GetStaffLimitByRegister_ListDictionaryEntry(10, from, to);

            if (null == chartStaffItems)
                chartStaffItems = new ObservableCollection<ChartElement>();
            else
                chartStaffItems.Clear();

            foreach (DictionaryEntry d in staffDics)
            {
                chartStaffItems.Add(new ChartElement
                {
                    Name = (d.Key as Staff).Name,
                    Value = (int) d.Value
                });

            }
             */
        }

        private void rebuildRegisterData(DateTime from, DateTime to)
        {
            /*
            List<DictionaryEntry> roomDics = roomService.GetRoomLimitByRegister(10, from, to);

            if (null == chartRegisterItems)
                chartRegisterItems = new ObservableCollection<ChartElement>();
            else
                chartRegisterItems.Clear();

            foreach (DictionaryEntry d in roomDics)
            {
                chartRegisterItems.Add(new ChartElement
                {
                    Name = (d.Key as Room).Name,
                    Value = (int)d.Value
                });

            }
             */
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
