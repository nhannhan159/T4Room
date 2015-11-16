using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.Infrastructure.Data.UserModule.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "UserRole";
        }

        public bool CheckPassword(User user, string password)
        {
            return user.Password.Equals(password);
        }

        public bool ValidateUser(string username, string password)
        {
            var user = this.Get(filter: p => p.UserName.Equals(username) && p.IsWorking).First();
            return (user != null && user.Password.Equals(password));
        }

        public bool CheckUserExists(string username)
        {
            return this.Get(filter: p => p.UserName.Equals(username)).Count() != 0;
        }

        public IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to)
        {
            IList<User> userList = GetAll();
            IList<KeyValuePair<User, int>> list = new List<KeyValuePair<User, int>>();

            foreach (User user in userList) 
            {
                int count = user.RoomRegs.Count(p => p.Date >= from && p.Date <= to);
                list.Add(new KeyValuePair<User, int>(user, count));
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
