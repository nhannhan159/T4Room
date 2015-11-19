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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(EFContext context)
            : base(context)
        { }

        protected override string IncludeProperties()
        {
            return "";
        }

        public Role GetByName(string roleName)
        {
            return this.Get().SingleOrDefault(p => p.Name.Equals(roleName));
        }
    }
}
