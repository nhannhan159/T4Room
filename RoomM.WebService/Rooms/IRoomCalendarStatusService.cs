using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomM.Models.Rooms;

namespace RoomM.WebService.Rooms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoomCalendarStatusService" in both code and config file together.
    [ServiceContract]
    public interface IRoomCalendarStatusService
    {
        [OperationContract]
        RoomCalendarStatus GetSingle(int statusId);

        [OperationContract]
        IList<String> GetNameList();
    }
}
