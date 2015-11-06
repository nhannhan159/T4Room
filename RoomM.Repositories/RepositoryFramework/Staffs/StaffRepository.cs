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
            return this.Get(orderBy: q => q.OrderBy(d => d.RoomCalendars.Count))
                .Take(limit)
                .ToList();
        }

        public List<DictionaryEntry> GetStaffLimitByRegister(int limit, DateTime from, DateTime to)
        {
            IList<Staff>  staffList = GetAll();
            
            IList<KeyValuePair<Staff, int>> result = new List<KeyValuePair<Staff, int>>();
            Hashtable hm = new Hashtable();
            
            foreach (Staff staff in staffList) 
            {
                int count = staff.RoomCalendars.Count(p => p.Date >= from && p.Date <= to);
                hm.Add(staff, count);
            }

            List<DictionaryEntry> dic = hm.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).Take(limit).ToList();

            return dic;
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
