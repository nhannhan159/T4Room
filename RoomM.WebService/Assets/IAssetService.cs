﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Models.Assets;

namespace RoomM.WebService.Assets
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAssetService
    {
        [OperationContract]
        Asset GetSingle(int deviceId);

        [OperationContract]
        IList<String> GetNameList();

        [OperationContract]
        bool isUniqueName(string name);
    }
}