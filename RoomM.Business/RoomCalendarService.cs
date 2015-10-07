using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Rooms;
using RoomM.Repositories.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Business
{
    public class RoomCalendarService
    {

        private static IRoomCalendarRepository roomCalRepo;
        private static IRoomCalendarStatusRepository roomCalStatusRepo;

        static RoomCalendarService()
        {
            roomCalRepo = RepositoryFactory.GetRepository<IRoomCalendarRepository, RoomCalendar>();
            roomCalStatusRepo = RepositoryFactory.GetRepository<IRoomCalendarStatusRepository, RoomCalendarStatus>();
        }

        // get all calendar
        public static IList<RoomCalendar> GetAll()
        {
            return roomCalRepo.GetAll();
        }

        public static RoomCalendar GetByID(int id)
        {
            return roomCalRepo.GetSingle(id);
        }


        // get all calendar of room
        public static IList<RoomCalendar> GetByRoomId(int roomId)
        {
            return roomCalRepo.GetByRoomId(roomId);
        }

        // get all status of calendar
        public static IList<RoomCalendarStatus> GetAllStatus()
        {
            return roomCalStatusRepo.GetAll();
        }

        public static IList<String> GetAllStatusName()
        {
            return roomCalStatusRepo.GetNameList();
        }

        public static IList<RoomCalendar> GetByStaffId(int id)
        {
            return roomCalRepo.GetByStaffId(id);
        }

        public static IList<RoomCalendar> GetByDate(DateTime date)
        {
            return roomCalRepo.GetByDate(date);
        }

        public static IList<RoomCalendar> GetByDateAndRoomId(DateTime date, long roomId)
        {
            return roomCalRepo.GetByDateAndRoomId(date, roomId);
        }

        public static IList<RoomCalendar> GetByWeekAndRoomId(DateTime date, long roomId)
        {
            return roomCalRepo.GetByWeekAndRoomId(date, roomId);
        }

        public static void Add(RoomCalendar rc)
        {
            roomCalRepo.Add(rc);
        }

        public static void Edit(RoomCalendar rc)
        {
            roomCalRepo.Edit(rc);
        }

        public static void Delete(RoomCalendar rc)
        {
            roomCalRepo.Delete(rc);
        }

        public static void Delete(int id)
        {
            roomCalRepo.Delete(id);
        }


        //commit changes
        public static void Save()
        {
            roomCalRepo.Save();
        }







        
    }
}
