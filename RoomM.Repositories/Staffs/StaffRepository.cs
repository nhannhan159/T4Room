using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using RoomM.Models;

namespace RoomM.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(EFDataContext _entities)
            : base(_entities)
        { }

        public Staff GetSingle(int staffId)
        {
            var query = GetAllWithQuery().SingleOrDefault(x => x.ID == staffId);
            return query;
        }


        public bool CheckPassword(Staff staff, string password)
        {
            return staff.Password.Equals(password);
        }

        public bool CheckUserExists(string username)
        {
            return (from p in GetAllWithQuery()
                    where p.UserName.Equals(username)
                    select p).ToList().Count != 0;
        }

        public IList<Staff> GetStaffLimitByRegister(int limit)
        {
            return (from p in GetAllWithQuery()
                    orderby p.RoomCalendars.Count descending
                    select p).Take(limit).ToList();
        }


        public List<DictionaryEntry> GetStaffLimitByRegister(int limit, DateTime from, DateTime to)
        {
            IList<Staff>  staffList = GetAll();
            
            IList<KeyValuePair<Staff, int>> result = new List<KeyValuePair<Staff, int>>();
            Hashtable hm = new Hashtable();
            
            int c;
            foreach (Staff s in staffList) 
            {
                c = 0;
                foreach (RoomCalendar rc in s.RoomCalendars)
                    if (rc.Date.Date >= from.Date && rc.Date.Date <= to.Date)
                        c++;

                hm.Add(s, c);
            }

            List<DictionaryEntry> dic = hm.Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).Take(limit).ToList();

            return dic;
        }


        public bool IsExists(string username)
        {
            return (from p in GetAllWithQuery()
                    where p.Name.Equals(username)
                    select p).ToList().Count > 0;
        }


        public int GetUserId(string username)
        {
            return (int) (from p in GetAllWithQuery()
                    where p.Name.Equals(username)
                    select p).ToList()[0].ID;
        }


        public bool UserNameIsWorking(string username)
        {
            return (from p in GetAllWithQuery()
                         where p.Name.Equals(username) && p.IsWorking
                         select p).ToList().Count > 0;
        }
    }
}
