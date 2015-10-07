using RoomM.Repositories.RepositoryFramework;
using RoomM.Models.Staffs;
using RoomM.Repositories.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Business
{
    public class StaffService
    {
        private static IStaffRepository userRepo;

        static StaffService()
        {
            userRepo = RepositoryFactory.GetRepository<IStaffRepository, Staff>();
        }

        public static Staff GetByID(int id)
        {
            return userRepo.GetSingle(id);
        }

        public static Boolean CheckPassword(Staff u, string password)
        {
            return userRepo.CheckPassword(u, password);
        }

        public static Boolean CheckUserExists(string username)
        {
            return userRepo.CheckUserExists(username);
        }


    }
}
