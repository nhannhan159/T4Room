using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

using RoomM.Domain;
using RoomM.Domain.AssetModule.Aggregates;
using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Application.RoomModule.Services
{
    public class RoomManagementService : IRoomManagementService
    {
        private IUnitOfWork context;

        public RoomManagementService(IUnitOfWork context)
        {
            this.context = context;
        }

        public void EnableWSMode()
        {
            this.context.EnableWSMode();
        }

        #region Basic CRUD

        public Room GetRoom(Int64 roomId)
        {
            return this.context.RoomRep.GetSingle(roomId);
        }

        public IList<Room> GetRoomList()
        {
            return this.context.RoomRep.GetAll();
        }

        public IList<Room> GetRoomListByRoomId(Int64 roomTypeId)
        {
            return this.context.RoomRep.GetByRoomTypeId(roomTypeId);
        }

        public void AddRoom(Room room)
        {
            try
            {
                this.context.RoomRep.Edit(room);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            } 
        }

        public void EditRoom(Room room)
        {
            try
            {
                this.context.RoomRep.Edit(room);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            } 
        }

        public void DeleteRoom(Room room)
        {
            try
            {
                room.IsUsing = false;
                this.context.RoomRep.Edit(room);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        #endregion

        #region Addition Lists

        public IList<RoomType> GetRoomTypeList()
        {
            return this.context.RoomTypeRep.GetAll();
        }

        public RoomReg GetRoomReg(Int64 roomRegId)
        {
            return this.context.RoomRegRep.GetSingle(roomRegId);
        }

        public IList<RoomReg> GetRoomRegList(Int64 roomId)
        {
            return this.context.RoomRegRep.GetByRoomId(roomId);
        }

        public IList<RoomReg> GetRoomRegListByDate(DateTime date, Int64 roomId)
        {
            return this.context.RoomRegRep.GetByDateAndRoomId(date, roomId);
        }

        public IList<RoomReg> GetRoomRegListByWeek(DateTime date, Int64 roomId)
        {
            return this.context.RoomRegRep.GetByWeekAndRoomId(date, roomId);
        }

        public IList<RoomReg> GetRoomRegListByWatchedState(bool isWatched, Int64 userId)
        {
            return this.context.RoomRegRep.GetByWatchedState(isWatched, userId);
        }

        public IList<AssetDetail> GetAssetDetailList(Int64 roomId)
        {
            return this.context.AssetDetailRep.GetByRoomId(roomId);
        }

        public IList<AssetHistory> GetAssetHistoryList(Int64 roomId)
        {
            return this.context.AssetHistoryRep.GetByRoomId(roomId);
        }

        public IList<AssetHistory> GetByRoom2RoomId(Room room, DateTime timeForBacktrace)
        {
            return this.context.AssetHistoryRep.GetByRoom2RoomId(room, timeForBacktrace);
        }

        #endregion

        #region Addition Services

        public void EditRoomReg(RoomReg roomReg)
        {
            try
            {
                this.context.RoomRegRep.Edit(roomReg);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        public void DeleteRoomReg(Int64 roomRegId)
        {
            try
            {
                this.context.RoomRegRep.Delete(roomRegId);
                this.context.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                throw new ApplicationException(error.ErrorMessage);
            }
        }

        #endregion
    }
}
