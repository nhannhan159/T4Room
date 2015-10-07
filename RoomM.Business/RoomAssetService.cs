using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Assets;
using RoomM.Models.Rooms;
using RoomM.Repositories.Assets;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Business
{
    public class RoomAssetService
    {
        public static IRoomAssetRepository roomDeviceRepo;
        public static IRoomAssetHistoryRepository assHistoryRepo;
        public static IRoomAssetHistoryTypeRepository assHistoryTypeRepo;
        public static IAssetRepository deviceRepo;

        static RoomAssetService()
        {
            roomDeviceRepo = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();
            deviceRepo = RepositoryFactory.GetRepository<IAssetRepository, Asset>();
            assHistoryRepo = RepositoryFactory.GetRepository<IRoomAssetHistoryRepository, RoomAssetHistory>();
            assHistoryTypeRepo = RepositoryFactory.GetRepository<IRoomAssetHistoryTypeRepository, HistoryType>();
        }

        // get all room device list
        public static IList<RoomAsset> GetAll() 
        {
            return roomDeviceRepo.GetAll();
        }

        public static RoomAsset GetByID(int id)
        {
            return roomDeviceRepo.GetSingle(id);
        }

        // get all room device with room id
        public static IList<RoomAsset> GetByRoomId(int id)
        {
            return roomDeviceRepo.GetByRoomId(id);
        }


        // get all device exist in store
        public static IList<Asset> GetAllAsset()
        {
            return deviceRepo.GetAll();
        }

        public static IList<HistoryType> GetAllAssetHistoryType()
        {
            return assHistoryTypeRepo.GetAll();
        }

        // get all device label
        public static IList<String> GetAllDeviceName()
        {
            return deviceRepo.GetNameList();
        }

        public static void AddOrEditAsset(Asset asset)
        {
            if (asset.ID == 0) deviceRepo.Add(asset);
            else deviceRepo.Edit(asset);
        }

        public static void Add(RoomAsset roomDevice)
        {
            roomDeviceRepo.Add(roomDevice);
        }

        public static void Edit(RoomAsset roomDevice)
        {
            roomDeviceRepo.Edit(roomDevice);
        }

        public static void Delete(RoomAsset roomDevice)
        {
            roomDeviceRepo.Delete(roomDevice);
        }

        // commit changes
        public static void Save()
        {
            deviceRepo.Save();
            roomDeviceRepo.Save();
        }

    }
}
