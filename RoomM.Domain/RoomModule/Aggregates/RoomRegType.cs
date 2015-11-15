using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RoomM.Domain.RoomModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class RoomRegType : EntityBase
    {
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<RoomReg> RoomRegs
        {
            get
            {
                if (this.roomRegs == null)
                    this.roomRegs = new List<RoomReg>();
                return this.roomRegs;
            }
            set
            {
                this.roomRegs = new List<RoomReg>(value);
            }
        }

        private IList<RoomReg> roomRegs;

        public RoomRegType() { }

        public RoomRegType(string name)
        {
            this.Name = name;
        }
    }
}
