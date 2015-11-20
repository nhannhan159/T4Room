using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RoomM.Domain.UserModule.Aggregates
{
    public interface IUserClaimRepository : IRepository<UserClaim>
    {
        IList<UserClaim> GetByUserId(Int64 userId);
        void Delete(Int64 userId, string claimType, string claimValue);
    }
}
