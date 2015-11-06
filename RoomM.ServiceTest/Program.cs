using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Models;

namespace RoomM.ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomService.RoomServiceClient roomService = new RoomService.RoomServiceClient();
            Room room = roomService.GetSingle(1);
            System.Console.Out.WriteLine("test: " + room.RoomType.Name + " end");
            System.Console.In.ReadLine();
            room.Name = "X201";
            roomService.Edit(room);
            System.Console.Out.WriteLine(roomService.GetSingle(1).Name);
            System.Console.In.ReadLine();
        }
    }
}
