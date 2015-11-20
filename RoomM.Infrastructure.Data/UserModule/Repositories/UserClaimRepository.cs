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
    public class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "User";
        }

        public IList<UserClaim> GetByUserId(Int64 userId)
        {
            return this.Get(filter: p => p.UserId == userId).ToList();
        }

        public void Delete(Int64 userId, string claimType, string claimValue)
        {
            IList<UserClaim> userClaims = this.Get(filter:
                p => p.UserId == userId
                    && p.ClaimType.Equals(claimType)
                    && p.ClaimValue.Equals(claimValue)).ToList();
            foreach (UserClaim userClaim in userClaims)
                this.Delete(userClaim);
        }
    }
}
