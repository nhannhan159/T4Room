﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RoomM.Domain.UserModule.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        Boolean CheckPassword(User user, string password);
        Boolean CheckUserExists(string username);
        IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to);
        bool IsExists(string username);
        Int64 GetUserId(string username);
        bool UserNameIsWorking(string username);
        bool ValidateUser(string username, string password);
    }
}