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

        public IList<Room> GetRoomList()
        {
            return this.context.RoomRep.GetAll();
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

        public IList<RoomRegType> GetRoomRegTypeList()
        {
            return this.context.RoomRegTypeRep.GetAll();
        }

        public IList<AssetHistoryType> GetAssetHistoryTypeList()
        {
            return this.context.AssetHistoryTypeRep.GetAll();
        }

        public IList<RoomReg> GetRoomRegList(Int64 roomId)
        {
            return this.context.RoomRegRep.GetByRoomId(roomId);
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

        public void ChangeRoomRegType(RoomReg roomReg)
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

        #endregion
    }
}
