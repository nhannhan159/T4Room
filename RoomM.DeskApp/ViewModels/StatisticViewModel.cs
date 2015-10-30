using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.DeskApp.UIHelper;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.DeskApp.ViewModels
{
    public class StatisticViewModel : EditableViewModel<Room>
    {
        private ObservableCollection<ChartElement> chartStaffItems;
        private ObservableCollection<ChartElement> chartRegisterItems;
        private DateTime fromTimeStaff;
        private DateTime toTimeStaff;
        private DateTime fromTimeRegister;
        private DateTime toTimeRegister;


        public StatisticViewModel(EFDataContext context)
            : base(context)
        {
            // DateTime now = new DateTime(DateTime.);
            fromTimeStaff = new DateTime(DateTime.Now.Year - 1, 1, 1);
            toTimeStaff = DateTime.Now;

            fromTimeRegister = new DateTime(DateTime.Now.Year - 1, 1, 1);
            toTimeRegister = DateTime.Now;

            rebuildStaffData(fromTimeStaff, toTimeStaff);
            rebuildRegisterData(fromTimeRegister, toTimeRegister);
        }


        protected override List<Room> GetEntitiesList()
        {
            return this.uow.RoomRepository.GetAll() as List<Room>;
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
            get { return fromTimeStaff; }
            set 
            { 
                fromTimeStaff = value;
                rebuildStaffData(value, ToTimeStaff);
            }
        }

        public DateTime ToTimeStaff
        {
            get { return toTimeStaff; }
            set 
            { 
                toTimeStaff = value;
                rebuildStaffData(FromTimeStaff, value);   
            }
        }

        public DateTime FromTimeRegister
        {
            get { return fromTimeRegister; }
            set
            {
                fromTimeRegister = value;
                rebuildRegisterData(value, toTimeRegister);
            }
        }

        public DateTime ToTimeRegister
        {
            get { return toTimeRegister; }
            set
            {
                toTimeRegister = value;
                rebuildRegisterData(fromTimeRegister, value);
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
            List<DictionaryEntry> staffDics = this.uow.StaffRepository.GetStaffLimitByRegister(10, from, to);

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
        }

        private void rebuildRegisterData(DateTime from, DateTime to)
        {
            List<DictionaryEntry> roomDics = this.uow.RoomRepository.GetRoomLimitByRegister(10, from, to);

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
