using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Repositories.Rooms;
using RoomM.Models.Rooms;

namespace RoomM.WebService.Rooms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomService.svc or RoomService.svc.cs at the Solution Explorer and start debugging.
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository; 

        public RoomService()
        {
            this.roomRepository = new RoomRepository();
        }

        public Room GetSingle(Int64 roomId)
        {
            return this.roomRepository.GetSingle(roomId);
        }

        public IList<Room> GetByRoomTypeId(long roomTypeId)
        {
            return this.roomRepository.GetByRoomTypeId(roomTypeId);
        }

        public IList<Room> GetRoomListLimitByRegister(int limit)
        {
            return this.roomRepository.GetRoomListLimitByRegister(limit);
        }

        public List<DictionaryEntry> GetRoomLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return this.roomRepository.GetRoomLimitByRegister(limit, from, to);
        }

        public bool isUniqueName(string name)
        {
            return this.roomRepository.isUniqueName(name);
        }
    }
}
