using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain;

namespace RoomM.Application.UserModule.Services
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork context;

        public AuthService(IUnitOfWork context)
        {
            this.context = context;
        }

        public void EnableWSMode()
        {
            this.context.EnableWSMode();
        }

        public bool ValidateUser(string username, string password)
        {
            return this.context.UserRep.ValidateUser(username, password);
        }
    }
}
