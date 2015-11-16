﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Application.UserModule.Services
{
    public interface IAuthService
    {
        void EnableWSMode();
        bool ValidateUser(string username, string password);
    }
}
