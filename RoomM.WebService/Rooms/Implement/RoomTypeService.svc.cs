﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Repositories;
using RoomM.Models;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomTypeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomTypeService.svc or RoomTypeService.svc.cs at the Solution Explorer and start debugging.
    public class RoomTypeService : ServiceBase<RoomType>, IRoomTypeService
    {
        public RoomTypeService(EFDataContext context)
            : base(context)
        {
            this.repo = this.uow.RoomTypeRepository;
        }
    }
}
