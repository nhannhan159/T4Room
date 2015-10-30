﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoomM.DeskApp.RoomService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomService.IRoomService")]
    public interface IRoomService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/GetAll", ReplyAction="http://tempuri.org/IServiceOf_Room/GetAllResponse")]
        System.Collections.Generic.List<RoomM.Models.Room> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/GetAll", ReplyAction="http://tempuri.org/IServiceOf_Room/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Room>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/Add", ReplyAction="http://tempuri.org/IServiceOf_Room/AddResponse")]
        void Add(RoomM.Models.Room entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/Add", ReplyAction="http://tempuri.org/IServiceOf_Room/AddResponse")]
        System.Threading.Tasks.Task AddAsync(RoomM.Models.Room entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_Room/DeleteByTResponse")]
        void DeleteByT(RoomM.Models.Room entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_Room/DeleteByTResponse")]
        System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.Room entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_Room/DeleteByObjectResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.Room>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Room))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.Room>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.EntityBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.RoomAssetHistory>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomAssetHistory))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomAssetHistory>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Asset))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.Asset>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.RoomAsset>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomAsset))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomAsset>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.HistoryType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.HistoryType>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.RoomCalendar>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomCalendar))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomCalendar>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomCalendarStatus))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomCalendarStatus>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Staff))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.Staff>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.StaffType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.StaffType>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.Staff>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomType>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<System.Collections.DictionaryEntry>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.DictionaryEntry))]
        void DeleteByObject(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_Room/DeleteByObjectResponse")]
        System.Threading.Tasks.Task DeleteByObjectAsync(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/Edit", ReplyAction="http://tempuri.org/IServiceOf_Room/EditResponse")]
        void Edit(RoomM.Models.Room entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Room/Edit", ReplyAction="http://tempuri.org/IServiceOf_Room/EditResponse")]
        System.Threading.Tasks.Task EditAsync(RoomM.Models.Room entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetSingle", ReplyAction="http://tempuri.org/IRoomService/GetSingleResponse")]
        RoomM.Models.Room GetSingle(long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetSingle", ReplyAction="http://tempuri.org/IRoomService/GetSingleResponse")]
        System.Threading.Tasks.Task<RoomM.Models.Room> GetSingleAsync(long roomId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetByRoomTypeId", ReplyAction="http://tempuri.org/IRoomService/GetByRoomTypeIdResponse")]
        System.Collections.Generic.List<RoomM.Models.Room> GetByRoomTypeId(long roomTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetByRoomTypeId", ReplyAction="http://tempuri.org/IRoomService/GetByRoomTypeIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Room>> GetByRoomTypeIdAsync(long roomTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetRoomListLimitByRegister", ReplyAction="http://tempuri.org/IRoomService/GetRoomListLimitByRegisterResponse")]
        System.Collections.Generic.List<RoomM.Models.Room> GetRoomListLimitByRegister(int limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetRoomListLimitByRegister", ReplyAction="http://tempuri.org/IRoomService/GetRoomListLimitByRegisterResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Room>> GetRoomListLimitByRegisterAsync(int limit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetRoomLimitByRegister", ReplyAction="http://tempuri.org/IRoomService/GetRoomLimitByRegisterResponse")]
        System.Collections.Generic.List<System.Collections.DictionaryEntry> GetRoomLimitByRegister(int limit, System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/GetRoomLimitByRegister", ReplyAction="http://tempuri.org/IRoomService/GetRoomLimitByRegisterResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.DictionaryEntry>> GetRoomLimitByRegisterAsync(int limit, System.DateTime from, System.DateTime to);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/isUniqueName", ReplyAction="http://tempuri.org/IRoomService/isUniqueNameResponse")]
        bool isUniqueName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomService/isUniqueName", ReplyAction="http://tempuri.org/IRoomService/isUniqueNameResponse")]
        System.Threading.Tasks.Task<bool> isUniqueNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoomServiceChannel : RoomM.DeskApp.RoomService.IRoomService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomServiceClient : System.ServiceModel.ClientBase<RoomM.DeskApp.RoomService.IRoomService>, RoomM.DeskApp.RoomService.IRoomService {
        
        public RoomServiceClient() {
        }
        
        public RoomServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<RoomM.Models.Room> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Room>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Add(RoomM.Models.Room entity) {
            base.Channel.Add(entity);
        }
        
        public System.Threading.Tasks.Task AddAsync(RoomM.Models.Room entity) {
            return base.Channel.AddAsync(entity);
        }
        
        public void DeleteByT(RoomM.Models.Room entity) {
            base.Channel.DeleteByT(entity);
        }
        
        public System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.Room entity) {
            return base.Channel.DeleteByTAsync(entity);
        }
        
        public void DeleteByObject(object id) {
            base.Channel.DeleteByObject(id);
        }
        
        public System.Threading.Tasks.Task DeleteByObjectAsync(object id) {
            return base.Channel.DeleteByObjectAsync(id);
        }
        
        public void Edit(RoomM.Models.Room entity) {
            base.Channel.Edit(entity);
        }
        
        public System.Threading.Tasks.Task EditAsync(RoomM.Models.Room entity) {
            return base.Channel.EditAsync(entity);
        }
        
        public RoomM.Models.Room GetSingle(long roomId) {
            return base.Channel.GetSingle(roomId);
        }
        
        public System.Threading.Tasks.Task<RoomM.Models.Room> GetSingleAsync(long roomId) {
            return base.Channel.GetSingleAsync(roomId);
        }
        
        public System.Collections.Generic.List<RoomM.Models.Room> GetByRoomTypeId(long roomTypeId) {
            return base.Channel.GetByRoomTypeId(roomTypeId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Room>> GetByRoomTypeIdAsync(long roomTypeId) {
            return base.Channel.GetByRoomTypeIdAsync(roomTypeId);
        }
        
        public System.Collections.Generic.List<RoomM.Models.Room> GetRoomListLimitByRegister(int limit) {
            return base.Channel.GetRoomListLimitByRegister(limit);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Room>> GetRoomListLimitByRegisterAsync(int limit) {
            return base.Channel.GetRoomListLimitByRegisterAsync(limit);
        }
        
        public System.Collections.Generic.List<System.Collections.DictionaryEntry> GetRoomLimitByRegister(int limit, System.DateTime from, System.DateTime to) {
            return base.Channel.GetRoomLimitByRegister(limit, from, to);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.DictionaryEntry>> GetRoomLimitByRegisterAsync(int limit, System.DateTime from, System.DateTime to) {
            return base.Channel.GetRoomLimitByRegisterAsync(limit, from, to);
        }
        
        public bool isUniqueName(string name) {
            return base.Channel.isUniqueName(name);
        }
        
        public System.Threading.Tasks.Task<bool> isUniqueNameAsync(string name) {
            return base.Channel.isUniqueNameAsync(name);
        }
    }
}
