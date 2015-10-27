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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaffService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaffService.svc or StaffService.svc.cs at the Solution Explorer and start debugging.
    public class StaffService : ServiceBase<Staff>, IStaffService
    {
        private IStaffRepository staffRepository;

        public StaffService()
        {
            this.staffRepository = RepositoryFactory.GetRepository<IStaffRepository, Staff>();
            this.repo = (IRepository<Staff>)this.staffRepository;
        }

        public Staff GetSingle(int staffId)
        {
            return this.staffRepository.GetSingle(staffId).GetDetached();
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
            IList<Staff> staffs = this.staffRepository.GetStaffLimitByRegister(limit);
            IList<Staff> detachedStaffs = new List<Staff>();
            foreach (Staff staff in staffs)
            {
                detachedStaffs.Add(staff.GetDetached());
            }
            return detachedStaffs;
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
