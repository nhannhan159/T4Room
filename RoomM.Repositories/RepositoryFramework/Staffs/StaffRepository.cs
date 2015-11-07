using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(EFDataContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "StaffType";
        }

        public bool CheckPassword(Staff staff, string password)
        {
            return staff.Password.Equals(password);
        }

        public bool CheckUserExists(string username)
        {
            return this.Get(filter: p => p.UserName.Equals(username)).Count() != 0;
        }

        public IList<Staff> GetStaffLimitByRegister(int limit)
        {
            return this.Get(
                orderBy: q => q.OrderBy(d => d.RoomCalendars.Count),
                limit: limit).ToList();
        }

        public IList<KeyValuePair<Staff, int>> GetStaffLimitByRegister(int limit, DateTime from, DateTime to)
        {
            IList<Staff> staffList = GetAll();
            IList<KeyValuePair<Staff, int>> list = new List<KeyValuePair<Staff, int>>();
            
            foreach (Staff staff in staffList) 
            {
                int count = staff.RoomCalendars.Count(p => p.Date >= from && p.Date <= to);
                list.Add(new KeyValuePair<Staff, int>(staff, count));
            }

            return list.OrderByDescending(p => p.Value).Take(limit).ToList();
        }

        public bool IsExists(string username)
        {
            return this.Get(filter: p => p.Name.Equals(username)).Count() > 0;
        }

        public Int64 GetUserId(string username)
        {
            return this.Get(filter: p => p.Name.Equals(username)).First().ID;
        }

        public bool UserNameIsWorking(string username)
        {
            return this.Get(filter: p => p.Name.Equals(username) && p.IsWorking).Count() > 0;
        }
    }
}
