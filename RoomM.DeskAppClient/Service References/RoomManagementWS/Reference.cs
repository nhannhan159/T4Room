﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoomM.DeskApp.RoomManagementWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomManagementWS.IRoomManagementWS")]
    public interface IRoomManagementWS {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomResponse")]
        RoomM.Domain.RoomModule.Aggregates.Room GetRoom(long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomResponse")]
        System.Threading.Tasks.Task<RoomM.Domain.RoomModule.Aggregates.Room> GetRoomAsync(long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomList", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomListResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room> GetRoomList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomList", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room>> GetRoomListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomListByRoomId", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomListByRoomIdResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room> GetRoomListByRoomId(long roomTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomListByRoomId", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomListByRoomIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room>> GetRoomListByRoomIdAsync(long roomTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomTypeList", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomTypeListResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomType> GetRoomTypeList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomTypeList", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomTypeListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomType>> GetRoomTypeListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegResponse")]
        RoomM.Domain.RoomModule.Aggregates.RoomReg GetRoomReg(long roomRegId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegResponse")]
        System.Threading.Tasks.Task<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegAsync(long roomRegId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByRoomId", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByRoomIdResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByRoomId(long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByRoomId", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByRoomIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByRoomIdAsync(long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByUserId", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByUserIdResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByUserId(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByUserId", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByUserIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByUserIdAsync(long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByDate", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByDateResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByDate(System.DateTime date, long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByDate", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByDateResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByDateAsync(System.DateTime date, long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWeek", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWeekResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByWeek(System.DateTime date, long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWeek", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWeekResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByWeekAsync(System.DateTime date, long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWatchedState", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWatchedStateResponse")]
        System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByWatchedState(bool isWatched, long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWatchedState", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomRegListByWatchedStateResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByWatchedStateAsync(bool isWatched, long userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomLimitByRegister", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomLimitByRegisterResponse")]
        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<RoomM.Domain.RoomModule.Aggregates.Room, int>> GetRoomLimitByRegister(int limit, System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/GetRoomLimitByRegister", ReplyAction="http://tempuri.org/IRoomManagementWS/GetRoomLimitByRegisterResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<RoomM.Domain.RoomModule.Aggregates.Room, int>>> GetRoomLimitByRegisterAsync(int limit, System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/AddRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/AddRoomResponse")]
        void AddRoom(RoomM.Domain.RoomModule.Aggregates.Room room);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/AddRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/AddRoomResponse")]
        System.Threading.Tasks.Task AddRoomAsync(RoomM.Domain.RoomModule.Aggregates.Room room);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/EditRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/EditRoomResponse")]
        void EditRoom(RoomM.Domain.RoomModule.Aggregates.Room room);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/EditRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/EditRoomResponse")]
        System.Threading.Tasks.Task EditRoomAsync(RoomM.Domain.RoomModule.Aggregates.Room room);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/DeleteRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/DeleteRoomResponse")]
        void DeleteRoom(RoomM.Domain.RoomModule.Aggregates.Room room);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/DeleteRoom", ReplyAction="http://tempuri.org/IRoomManagementWS/DeleteRoomResponse")]
        System.Threading.Tasks.Task DeleteRoomAsync(RoomM.Domain.RoomModule.Aggregates.Room room);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/AddRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/AddRoomRegResponse")]
        void AddRoomReg(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/AddRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/AddRoomRegResponse")]
        System.Threading.Tasks.Task AddRoomRegAsync(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/EditRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/EditRoomRegResponse")]
        void EditRoomReg(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/EditRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/EditRoomRegResponse")]
        System.Threading.Tasks.Task EditRoomRegAsync(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/DeleteRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/DeleteRoomRegResponse")]
        void DeleteRoomReg(long roomRegId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomManagementWS/DeleteRoomReg", ReplyAction="http://tempuri.org/IRoomManagementWS/DeleteRoomRegResponse")]
        System.Threading.Tasks.Task DeleteRoomRegAsync(long roomRegId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoomManagementWSChannel : RoomM.DeskApp.RoomManagementWS.IRoomManagementWS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomManagementWSClient : System.ServiceModel.ClientBase<RoomM.DeskApp.RoomManagementWS.IRoomManagementWS>, RoomM.DeskApp.RoomManagementWS.IRoomManagementWS {
        
        public RoomManagementWSClient() {
        }
        
        public RoomManagementWSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomManagementWSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomManagementWSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomManagementWSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RoomM.Domain.RoomModule.Aggregates.Room GetRoom(long roomId) {
            return base.Channel.GetRoom(roomId);
        }
        
        public System.Threading.Tasks.Task<RoomM.Domain.RoomModule.Aggregates.Room> GetRoomAsync(long roomId) {
            return base.Channel.GetRoomAsync(roomId);
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room> GetRoomList() {
            return base.Channel.GetRoomList();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room>> GetRoomListAsync() {
            return base.Channel.GetRoomListAsync();
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room> GetRoomListByRoomId(long roomTypeId) {
            return base.Channel.GetRoomListByRoomId(roomTypeId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.Room>> GetRoomListByRoomIdAsync(long roomTypeId) {
            return base.Channel.GetRoomListByRoomIdAsync(roomTypeId);
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomType> GetRoomTypeList() {
            return base.Channel.GetRoomTypeList();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomType>> GetRoomTypeListAsync() {
            return base.Channel.GetRoomTypeListAsync();
        }
        
        public RoomM.Domain.RoomModule.Aggregates.RoomReg GetRoomReg(long roomRegId) {
            return base.Channel.GetRoomReg(roomRegId);
        }
        
        public System.Threading.Tasks.Task<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegAsync(long roomRegId) {
            return base.Channel.GetRoomRegAsync(roomRegId);
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByRoomId(long roomId) {
            return base.Channel.GetRoomRegListByRoomId(roomId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByRoomIdAsync(long roomId) {
            return base.Channel.GetRoomRegListByRoomIdAsync(roomId);
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByUserId(long userId) {
            return base.Channel.GetRoomRegListByUserId(userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByUserIdAsync(long userId) {
            return base.Channel.GetRoomRegListByUserIdAsync(userId);
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByDate(System.DateTime date, long roomId) {
            return base.Channel.GetRoomRegListByDate(date, roomId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByDateAsync(System.DateTime date, long roomId) {
            return base.Channel.GetRoomRegListByDateAsync(date, roomId);
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByWeek(System.DateTime date, long roomId) {
            return base.Channel.GetRoomRegListByWeek(date, roomId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByWeekAsync(System.DateTime date, long roomId) {
            return base.Channel.GetRoomRegListByWeekAsync(date, roomId);
        }
        
        public System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg> GetRoomRegListByWatchedState(bool isWatched, long userId) {
            return base.Channel.GetRoomRegListByWatchedState(isWatched, userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Domain.RoomModule.Aggregates.RoomReg>> GetRoomRegListByWatchedStateAsync(bool isWatched, long userId) {
            return base.Channel.GetRoomRegListByWatchedStateAsync(isWatched, userId);
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<RoomM.Domain.RoomModule.Aggregates.Room, int>> GetRoomLimitByRegister(int limit, System.DateTime from, System.DateTime to) {
            return base.Channel.GetRoomLimitByRegister(limit, from, to);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<RoomM.Domain.RoomModule.Aggregates.Room, int>>> GetRoomLimitByRegisterAsync(int limit, System.DateTime from, System.DateTime to) {
            return base.Channel.GetRoomLimitByRegisterAsync(limit, from, to);
        }
        
        public void AddRoom(RoomM.Domain.RoomModule.Aggregates.Room room) {
            base.Channel.AddRoom(room);
        }
        
        public System.Threading.Tasks.Task AddRoomAsync(RoomM.Domain.RoomModule.Aggregates.Room room) {
            return base.Channel.AddRoomAsync(room);
        }
        
        public void EditRoom(RoomM.Domain.RoomModule.Aggregates.Room room) {
            base.Channel.EditRoom(room);
        }
        
        public System.Threading.Tasks.Task EditRoomAsync(RoomM.Domain.RoomModule.Aggregates.Room room) {
            return base.Channel.EditRoomAsync(room);
        }
        
        public void DeleteRoom(RoomM.Domain.RoomModule.Aggregates.Room room) {
            base.Channel.DeleteRoom(room);
        }
        
        public System.Threading.Tasks.Task DeleteRoomAsync(RoomM.Domain.RoomModule.Aggregates.Room room) {
            return base.Channel.DeleteRoomAsync(room);
        }
        
        public void AddRoomReg(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg) {
            base.Channel.AddRoomReg(roomReg);
        }
        
        public System.Threading.Tasks.Task AddRoomRegAsync(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg) {
            return base.Channel.AddRoomRegAsync(roomReg);
        }
        
        public void EditRoomReg(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg) {
            base.Channel.EditRoomReg(roomReg);
        }
        
        public System.Threading.Tasks.Task EditRoomRegAsync(RoomM.Domain.RoomModule.Aggregates.RoomReg roomReg) {
            return base.Channel.EditRoomRegAsync(roomReg);
        }
        
        public void DeleteRoomReg(long roomRegId) {
            base.Channel.DeleteRoomReg(roomRegId);
        }
        
        public System.Threading.Tasks.Task DeleteRoomRegAsync(long roomRegId) {
            return base.Channel.DeleteRoomRegAsync(roomRegId);
        }
    }
}
