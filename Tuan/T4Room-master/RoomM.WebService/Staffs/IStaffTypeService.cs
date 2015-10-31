﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStaffTypeService" in both code and config file together.
    [ServiceContract]
    public interface IStaffTypeService : IService<StaffType>
    {
        [OperationContract]
        StaffType GetSingle(int staffTypeId);
    }
}