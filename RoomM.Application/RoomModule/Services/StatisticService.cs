using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RoomM.Domain;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.Application.RoomModule.Services
{
    public class StatisticService : IStatisticService
    {
        private IUnitOfWork context;

        public StatisticService(IUnitOfWork context)
        {
            this.context = context;
        }

        public void EnableWSMode()
        {
            this.context.EnableWSMode();
        }

        public IList<KeyValuePair<Room, int>> GetRoomLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return this.context.RoomRep.GetRoomLimitByRegister(limit, from, to);
        }

        public IList<KeyValuePair<User, int>> GetUserLimitByRegister(int limit, DateTime from, DateTime to)
        {
            return this.context.UserRep.GetUserLimitByRegister(limit, from, to);
        }
    }
}
