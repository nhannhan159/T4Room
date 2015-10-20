using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomService.svc or RoomService.svc.cs at the Solution Explorer and start debugging.
    public class RoomService : ServiceBase<Room>, IRoomService
    {
        private IRoomRepository roomRepository; 

        public RoomService()
        {
            this.roomRepository = RepositoryFactory.GetRepository<IRoomRepository, Room>();
            this.repo = (IRepository<Room>)this.roomRepository;
        }

        public Room GetSingle(Int64 roomId)
        {
            return this.roomRepository.GetSingle(roomId).GetDetached();
        }

        public IList<Room> GetByRoomTypeId(long roomTypeId)
        {
            return this.GetDetachedList(this.roomRepository.GetByRoomTypeId(roomTypeId));
        }

        public IList<Room> GetRoomListLimitByRegister(int limit)
        {
            return this.GetDetachedList(this.roomRepository.GetRoomListLimitByRegister(limit));
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
