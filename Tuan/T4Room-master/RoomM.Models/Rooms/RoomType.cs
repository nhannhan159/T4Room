using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class RoomType : Detachable<RoomType>
    {
        public string Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        public RoomType()
        {
            this.Rooms = new List<Room>();
        }

        public RoomType(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public override RoomType GetDetached()
        {
            RoomType detached = new RoomType();
            detached.ID = this.ID;
            detached.Name = this.Name;
            return detached;
        }
    }
}
