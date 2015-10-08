using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Repositories.Staffs;
using RoomM.Models.Staffs;

namespace RoomM.WebService.Staffs
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaffService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaffService.svc or StaffService.svc.cs at the Solution Explorer and start debugging.
    public class StaffService : IStaffService
    {
        private IStaffRepository staffRepository;

        public StaffService()
        {
            this.staffRepository = new StaffRepository();
        }

        public Staff GetSingle(int staffId)
        {
            return this.staffRepository.GetSingle(staffId);
        }


        public bool CheckPassword(Staff staff, string password)
        {
            return this.staffRepository.CheckPassword(staff, password);
        }

        public bool CheckUserExists(string username)
        {
            return this.staffRepository.CheckUserExists(username);
        }

        public IList<Staff> GetStaffLimitByRegister(int limit)
        {
            return this.staffRepository.GetStaffLimitByRegister(limit);
        }


        public List<DictionaryEntry> GetStaffLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return this.staffRepository.GetStaffLimitByRegister(limit, from, to);
        }


        public bool IsExists(string username)
        {
            return this.staffRepository.IsExists(username);
        }


        public int GetUserId(string username)
        {
            return this.staffRepository.GetUserId(username);
        }


        public bool UserNameIsWorking(string username)
        {
            return this.staffRepository.UserNameIsWorking(username);
        }
    }
}
