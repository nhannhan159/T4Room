using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Data.Entity;

using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;

namespace RoomM.Infrastructure.Data.UserModule.Repositories
{
    public class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "User";
        }

        public IList<UserLogin> GetByUserId(Int64 userId)
        {
            return this.Get(filter: p => p.UserId == userId).ToList();
        }

        public Int64 GetUserId(string loginProvider, string providerKey)
        {
            var userLogin = this.Get(filter: p =>
                p.LoginProvider.Equals(loginProvider) && 
                p.ProviderKey.Equals(providerKey)).FirstOrDefault();
            if (userLogin != null)
                return userLogin.UserId;
            return 0;
        }

        public void Delete(Int64 userId, string loginProvider, string providerKey)
        {
            IList<UserLogin> userLogins = this.Get(filter:
                p => p.UserId == userId
                    && p.LoginProvider.Equals(loginProvider)
                    && p.ProviderKey.Equals(providerKey)).ToList();
            foreach (UserLogin userLogin in userLogins)
                this.Delete(userLogin);
        }
    }
}
