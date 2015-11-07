using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StaffService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StaffService.svc or StaffService.svc.cs at the Solution Explorer and start debugging.
    public class StaffService : ServiceBase<Staff>, IStaffService
    {
        public StaffService(EFDataContext context)
            : base(context)
        {
            this.repo = this.uow.StaffRepository;
        }

        public bool CheckPassword(Staff staff, string password)
        {
            return this.uow.StaffRepository.CheckPassword(staff, password);
        }

        public bool CheckUserExists(string username)
        {
            return this.uow.StaffRepository.CheckUserExists(username);
        }

        public IList<Staff> GetStaffLimitByRegister(int limit)
        {
            return this.uow.StaffRepository.GetStaffLimitByRegister(limit);
        }

        public IList<KeyValuePair<Staff, int>> GetStaffLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return this.uow.StaffRepository.GetStaffLimitByRegister(limit, from, to);
        }

        public bool IsExists(string username)
        {
            return this.uow.StaffRepository.IsExists(username);
        }

        public Int64 GetUserId(string username)
        {
            return this.uow.StaffRepository.GetUserId(username);
        }

        public bool UserNameIsWorking(string username)
        {
            return this.uow.StaffRepository.UserNameIsWorking(username);
        }
    }
}
