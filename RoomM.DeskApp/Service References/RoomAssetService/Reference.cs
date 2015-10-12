﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoomM.DeskApp.RoomAssetService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomAssetService.IRoomAssetService")]
    public interface IRoomAssetService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/GetAll", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/GetAllResponse")]
        System.Collections.Generic.List<RoomM.Models.RoomAsset> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/GetAll", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomAsset>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/Add", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/AddResponse")]
        void Add(RoomM.Models.RoomAsset entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/Add", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/AddResponse")]
        System.Threading.Tasks.Task AddAsync(RoomM.Models.RoomAsset entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/DeleteByTResponse")]
        void DeleteByT(RoomM.Models.RoomAsset entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/DeleteByTResponse")]
        System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.RoomAsset entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/DeleteByObjectResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.RoomAsset>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomAsset))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomAsset>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.EntityBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Asset))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.Asset>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.RoomAssetHistory>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomAssetHistory))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomAssetHistory>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.HistoryType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.HistoryType>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Room))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.Room>))]
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
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.Room>))]
        void DeleteByObject(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/DeleteByObjectResponse")]
        System.Threading.Tasks.Task DeleteByObjectAsync(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/Edit", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/EditResponse")]
        void Edit(RoomM.Models.RoomAsset entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/Edit", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/EditResponse")]
        System.Threading.Tasks.Task EditAsync(RoomM.Models.RoomAsset entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/Save", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/SaveResponse")]
        void Save();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomAsset/Save", ReplyAction="http://tempuri.org/IServiceOf_RoomAsset/SaveResponse")]
        System.Threading.Tasks.Task SaveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/GetSingle", ReplyAction="http://tempuri.org/IRoomAssetService/GetSingleResponse")]
        RoomM.Models.RoomAsset GetSingle(long roomDeviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/GetSingle", ReplyAction="http://tempuri.org/IRoomAssetService/GetSingleResponse")]
        System.Threading.Tasks.Task<RoomM.Models.RoomAsset> GetSingleAsync(long roomDeviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/GetByRoomId", ReplyAction="http://tempuri.org/IRoomAssetService/GetByRoomIdResponse")]
        System.Collections.Generic.List<RoomM.Models.RoomAsset> GetByRoomId(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/GetByRoomId", ReplyAction="http://tempuri.org/IRoomAssetService/GetByRoomIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomAsset>> GetByRoomIdAsync(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/GetByAssetId", ReplyAction="http://tempuri.org/IRoomAssetService/GetByAssetIdResponse")]
        System.Collections.Generic.List<RoomM.Models.RoomAsset> GetByAssetId(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/GetByAssetId", ReplyAction="http://tempuri.org/IRoomAssetService/GetByAssetIdResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomAsset>> GetByAssetIdAsync(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/AddOrUpdate", ReplyAction="http://tempuri.org/IRoomAssetService/AddOrUpdateResponse")]
        void AddOrUpdate(long roomId, long assetId, int amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomAssetService/AddOrUpdate", ReplyAction="http://tempuri.org/IRoomAssetService/AddOrUpdateResponse")]
        System.Threading.Tasks.Task AddOrUpdateAsync(long roomId, long assetId, int amount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoomAssetServiceChannel : RoomM.DeskApp.RoomAssetService.IRoomAssetService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomAssetServiceClient : System.ServiceModel.ClientBase<RoomM.DeskApp.RoomAssetService.IRoomAssetService>, RoomM.DeskApp.RoomAssetService.IRoomAssetService {
        
        public RoomAssetServiceClient() {
        }
        
        public RoomAssetServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomAssetServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomAssetServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomAssetServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<RoomM.Models.RoomAsset> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomAsset>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Add(RoomM.Models.RoomAsset entity) {
            base.Channel.Add(entity);
        }
        
        public System.Threading.Tasks.Task AddAsync(RoomM.Models.RoomAsset entity) {
            return base.Channel.AddAsync(entity);
        }
        
        public void DeleteByT(RoomM.Models.RoomAsset entity) {
            base.Channel.DeleteByT(entity);
        }
        
        public System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.RoomAsset entity) {
            return base.Channel.DeleteByTAsync(entity);
        }
        
        public void DeleteByObject(object id) {
            base.Channel.DeleteByObject(id);
        }
        
        public System.Threading.Tasks.Task DeleteByObjectAsync(object id) {
            return base.Channel.DeleteByObjectAsync(id);
        }
        
        public void Edit(RoomM.Models.RoomAsset entity) {
            base.Channel.Edit(entity);
        }
        
        public System.Threading.Tasks.Task EditAsync(RoomM.Models.RoomAsset entity) {
            return base.Channel.EditAsync(entity);
        }
        
        public void Save() {
            base.Channel.Save();
        }
        
        public System.Threading.Tasks.Task SaveAsync() {
            return base.Channel.SaveAsync();
        }
        
        public RoomM.Models.RoomAsset GetSingle(long roomDeviceId) {
            return base.Channel.GetSingle(roomDeviceId);
        }
        
        public System.Threading.Tasks.Task<RoomM.Models.RoomAsset> GetSingleAsync(long roomDeviceId) {
            return base.Channel.GetSingleAsync(roomDeviceId);
        }
        
        public System.Collections.Generic.List<RoomM.Models.RoomAsset> GetByRoomId(long id) {
            return base.Channel.GetByRoomId(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomAsset>> GetByRoomIdAsync(long id) {
            return base.Channel.GetByRoomIdAsync(id);
        }
        
        public System.Collections.Generic.List<RoomM.Models.RoomAsset> GetByAssetId(long id) {
            return base.Channel.GetByAssetId(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomAsset>> GetByAssetIdAsync(long id) {
            return base.Channel.GetByAssetIdAsync(id);
        }
        
        public void AddOrUpdate(long roomId, long assetId, int amount) {
            base.Channel.AddOrUpdate(roomId, assetId, amount);
        }
        
        public System.Threading.Tasks.Task AddOrUpdateAsync(long roomId, long assetId, int amount) {
            return base.Channel.AddOrUpdateAsync(roomId, assetId, amount);
        }
    }
}
