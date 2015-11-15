using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Application.RoomModule.Services;

namespace RoomM.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoomAssetService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RoomAssetService.svc or RoomAssetService.svc.cs at the Solution Explorer and start debugging.
    public class RoomManagementWS : IRoomManagementWS
    {
        private IRoomManagementService service;

        public RoomManagementWS(IRoomManagementService service)
        {
            this.service = service;
            this.service.EnableWSMode();
        }

        #region Basic CRUD

        public IList<Room> GetRoomList()
        {
            return this.service.GetRoomList();
        }

        public void AddRoom(Room room)
        {
            this.AddRoom(room);
        }

        public void EditRoom(Room room)
        {
            this.EditRoom(room);
        }

        public void DeleteRoom(Room room)
        {
            this.DeleteRoom(room);
        }

        #endregion

        #region Addition Lists

        public IList<RoomType> GetRoomTypeList()
        {
            return this.service.GetRoomTypeList();
        }

        public IList<RoomRegType> GetRoomRegTypeList()
        {
            return this.service.GetRoomRegTypeList();
        }

        public IList<AssetHistoryType> GetAssetHistoryTypeList()
        {
            return this.service.GetAssetHistoryTypeList();
        }

        public IList<RoomReg> GetRoomRegList(Int64 roomId)
        {
            return this.service.GetRoomRegList(roomId);
        }

        public IList<AssetDetail> GetAssetDetailList(Int64 roomId)
        {
            return this.service.GetAssetDetailList(roomId);
        }

        public IList<AssetHistory> GetAssetHistoryList(Int64 roomId)
        {
            return this.service.GetAssetHistoryList(roomId);
        }

        public IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return this.service.GetByRoom2RoomId(room, timeForBacktrace);
        }

        #endregion

        #region Addition Services

        public void ChangeRoomRegType(RoomReg roomReg)
        {
            this.service.ChangeRoomRegType(roomReg);
        }

        #endregion
    }
}
