using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RoomM.Models
{
    //khi T la mot the hien cua entitybase hoac la 1 lop ke thua tu entitybase va T phai co 1 public construstor
    public abstract class Detachable<T> : EntityBase where T : EntityBase, new()
    {
        public abstract T GetDetached();
    }
}
