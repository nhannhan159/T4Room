using RoomM.Models.Rooms;
using RoomM.Model.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Devices
{
    public class Device : EntityBase
    {
        public string Name { get; set; }
        public Boolean IsUsing { get; set; }

        public virtual ICollection<RoomDevice> RoomDevices { get; set; }
        public virtual ICollection<DeviceHistory> DeviceHistorys { get; set; }

        public override string ToString()
        {
            return ID + " # " + Name;
        }

    }
}
