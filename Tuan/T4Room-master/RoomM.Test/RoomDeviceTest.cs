using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RoomM.Models.Rooms;
using RoomM.Models.Assets;

namespace RoomM.Test
{

    public class RoomDeviceTest
    {

        public void showRoomDeviceList()
        {
            IList<RoomAsset> lst = RoomAssetService.GetAll();

            Console.WriteLine("Room device list:");
            foreach (RoomAsset rm in lst)
            {
                Console.WriteLine(rm.ToString());
            }
        
        }

      
        public void FindRoomDeviceTest()
        {
            showRoomDeviceList();

            // RoomDeviceService.Add


            RoomAsset dl = RoomAssetService.GetByID(1);


            Console.WriteLine(dl.ToString());


            dl.Amount = 0;


            RoomAssetService.Delete(dl);
            RoomAssetService.Save();


            showRoomDeviceList();


        }

   
        public void AddRoomDeviceTest()
        { 
            RoomAsset rm = new RoomAsset
            {
                RoomId = 1,
                AssetId = 1,
                Amount = 150,
            };


            RoomAssetService.Add(rm);
            RoomAssetService.Save();
            showRoomDeviceList();

        }

        [TestMethod]
        public void GetByRoomIdTest()
        {
            IList<RoomAsset> lst = RoomAssetService.GetByRoomId(1);

            foreach (RoomAsset rm in lst)
                Console.WriteLine(rm.ToString());
        }


        [TestMethod]
        public void GetAllDeviceTest()
        {
            IList<Asset> lst = RoomAssetService.GetAllAsset();

            foreach (Asset d in lst)
                Console.WriteLine(d.ToString());

        }
    }
}
