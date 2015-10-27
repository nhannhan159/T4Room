using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RoomM.Models.Rooms;
using System.Linq;

namespace RoomM.Test
{
   
    public class RoomTest
    {
        public void showRoomList() {
            IList<Room> roomLst = RoomService.GetAll();
            Console.WriteLine("Get all room: ");
            foreach (Room r in roomLst)
            {
                Console.WriteLine(r.ToString());
            }
        }

        [TestMethod]
        public void GetRoomTest()
        {
            showRoomList();

            // using room 1
            Room rm = RoomService.GetByID(5);
            rm.IsUsing = true;

            // RoomService.Edit(rm);
            RoomService.Save();

            showRoomList();
        }

        [TestMethod]
        public void AddRoomTest()
        {
            Room rm = new Room
            {
                Name = "B009",
                DateCreate = DateTime.Now,
                RoomTypeId = 2,
                IsUsing = true
            };


            // RoomService.Add(rm);
            RoomService.Save();

            showRoomList();

        }

        [TestMethod]
        public void GetRoomTypeTest()
        {
            IList<String> lsp = RoomService.GetAllRoomTypeName();

            foreach (String name in lsp)
                Console.WriteLine(name);
        
        }


    }
}
