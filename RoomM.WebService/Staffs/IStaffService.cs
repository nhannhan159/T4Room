using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStaffService" in both code and config file together.
    [ServiceContract]
    public interface IStaffService : IService<Staff>
    {
        [OperationContract]
        Boolean CheckPassword(Staff staff, string password);

        [OperationContract]
        Boolean CheckUserExists(string username);

        [OperationContract(Name = "GetStaffLimitByRegister_IList<Staff>")]
        IList<Staff> GetStaffLimitByRegister(int limit);

        [OperationContract(Name = "GetStaffLimitByRegister_List<DictionaryEntry>")]
        List<DictionaryEntry> GetStaffLimitByRegister(int limit, DateTime from, DateTime to);

        [OperationContract]
        bool IsExists(string username);

        [OperationContract]
        Int64 GetUserId(string username);

        [OperationContract]
        bool UserNameIsWorking(string username);
    }
}
