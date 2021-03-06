﻿using System;
using System.Collections.Generic;

namespace RoomM.Domain.UserModule.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        Int64 GetUserId(string username);

        User GetSingleByUsername(string username);

        IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to);
    }
}