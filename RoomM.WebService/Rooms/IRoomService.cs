﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Models.Rooms;

namespace RoomM.WebService.Rooms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomService" in both code and config file together.
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        Room GetSingle(Int64 roomId);

        [OperationContract]
        IList<Room> GetByRoomTypeId(Int64 roomTypeId);

        [OperationContract]
        IList<Room> GetRoomListLimitByRegister(int limit);

        [OperationContract]
        List<DictionaryEntry> GetRoomLimitByRegister(int limit, DateTime from, DateTime to);

        [OperationContract]
        bool isUniqueName(string name);
    }
}
