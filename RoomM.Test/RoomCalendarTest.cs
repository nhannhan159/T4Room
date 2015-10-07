using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RoomM.Models.Rooms;

namespace RoomM.Test
{

    public class RoomCalendarTest
    {

        public void showCalendar()
        {
            IList<RoomCalendar> lst = RoomCalendarService.GetAll();

            Console.WriteLine("show calendar");
            foreach (RoomCalendar rc in lst)
                Console.WriteLine(rc.ToString());
        
        }


        public void FindCalendar()
        {
            showCalendar();

            RoomCalendar cal = new RoomCalendar
            {
                RoomId = 3,
                Start = 10,
                Length = 5,
                StaffId = 1,
                Date = DateTime.Now,
                RoomCalendarStatusId = 2
            };


            RoomCalendarService.Add(cal);
            RoomCalendarService.Save();

            showCalendar();

            RoomCalendarService.Delete(RoomCalendarService.GetByID(1));
            RoomCalendarService.Save();

            showCalendar();

        }


        public void StatusTest()
        {
            IList<String> lst = RoomCalendarService.GetAllStatusName();
            foreach (string name in lst)
                Console.WriteLine(name);
        }


        [TestMethod]
        public void GetByRoom()
        {
            IList<RoomCalendar> lst = RoomCalendarService.GetByRoomId(3);
            foreach (RoomCalendar r in lst)
            {
                Console.WriteLine(r.ToString());
            }
        }

    }
}
