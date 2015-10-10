﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Rooms;

namespace RoomM.WebServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomService.RoomServiceClient roomServiceClient = new RoomService.RoomServiceClient();
            Room room = roomServiceClient.GetSingle(1);
            System.Console.WriteLine("TEST: " + room.Name + " END");
            System.Console.ReadLine();
        }
    }
}