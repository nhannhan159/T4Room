using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RoomM.Domain.UserModule.Aggregates
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string roleName);
    }
}
