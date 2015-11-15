using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomCalendarStatusService" in both code and config file together.
    [ServiceContract]
    public interface IStatisticWS
    {
        [OperationContract]
        IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to);

        [OperationContract]
        IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to);
    }
}
