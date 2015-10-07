using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Devices
{
    public class DeviceHistory : EntityBase
    {
        public Int64 DeviceHistoryTypeId { get; set; }
        public virtual DeviceHistoryType DeviceHistoryType { get; set; }
        
        public DateTime Date { get; set; }

        public Int64 DeviceId { get; set; }
        public virtual Device Device { get; set; }

        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }


        public override string ToString()
        {
            return ID + " # " + " #type:" + DeviceHistoryTypeId + " #roomID: " + RoomId;
        }

    }
}
