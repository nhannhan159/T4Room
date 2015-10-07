using RoomM.Models;
using RoomM.Models.Rooms;
using RoomM.Repositories.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomM.Models.Rooms;
using RoomM.Repositories.Rooms;

namespace RoomM.Business
{
    public partial class RoomService
    {
        public static IRoomRepository roomRepo;
        public static IRoomTypeRepository roomTypeRepo;
        
        static RoomService()
        {
            roomRepo = RepositoryFactory.GetRepository<IRoomRepository, Room>();
            roomTypeRepo = RepositoryFactory.GetRepository<IRoomTypeRepository, RoomType>();
        }

        // get all room
        public static IList<Room> GetAll()
        {
            return roomRepo.GetAll();
        }

        // get all room type
        public static IList<RoomType> GetAllRoomType()
        {
            return roomTypeRepo.GetAll();
        }

        // get all room type label
        public static IList<String> GetAllRoomTypeName()
        {
            IList<String> roomTypeNames = new List<String>();
            foreach (RoomType rt in GetAllRoomType()) 
            {
                roomTypeNames.Add(rt.Name);
            }
            return roomTypeNames;
        }

        public static Room GetByID(Int64 id)
        {
            return roomRepo.GetSingle(id);
        }

        public static void AddOrEdit(Room r)
        {
            if (r.ID == 0) roomRepo.Add(r);
            else roomRepo.Edit(r);
        }

        public static void Delete(Room r)
        {
            roomRepo.Delete(r);
        }

        public static void Delete(int id) {
            roomRepo.Delete(id);
        }


        // commit changes
        public static void Save() 
        {
            roomRepo.Save();
        }
    }
}
