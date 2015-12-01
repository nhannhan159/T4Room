using RoomM.Domain.UserModule.Aggregates;
using RoomM.Infrastructure.Data.UnitOfWork;
using System.Linq;

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

        public Role GetSingleByName(string roleName)
        {
            return this.Get().SingleOrDefault(p => p.Name.Equals(roleName));
        }
    }
}