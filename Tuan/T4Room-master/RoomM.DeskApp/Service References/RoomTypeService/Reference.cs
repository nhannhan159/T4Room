﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoomM.DeskApp.RoomTypeService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomTypeService.IRoomTypeService")]
    public interface IRoomTypeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/GetAll", ReplyAction="http://tempuri.org/IServiceOf_RoomType/GetAllResponse")]
        System.Collections.Generic.List<RoomM.Models.RoomType> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/GetAll", ReplyAction="http://tempuri.org/IServiceOf_RoomType/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomType>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/Add", ReplyAction="http://tempuri.org/IServiceOf_RoomType/AddResponse")]
        void Add(RoomM.Models.RoomType entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/Add", ReplyAction="http://tempuri.org/IServiceOf_RoomType/AddResponse")]
        System.Threading.Tasks.Task AddAsync(RoomM.Models.RoomType entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_RoomType/DeleteByTResponse")]
        void DeleteByT(RoomM.Models.RoomType entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_RoomType/DeleteByTResponse")]
        System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.RoomType entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_RoomType/DeleteByObjectResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.RoomType>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.RoomType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.RoomType>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.EntityBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.Room>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Room))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Detachable<RoomM.Models.Room>))]
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
        void DeleteByObject(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_RoomType/DeleteByObjectResponse")]
        System.Threading.Tasks.Task DeleteByObjectAsync(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/Edit", ReplyAction="http://tempuri.org/IServiceOf_RoomType/EditResponse")]
        void Edit(RoomM.Models.RoomType entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/Edit", ReplyAction="http://tempuri.org/IServiceOf_RoomType/EditResponse")]
        System.Threading.Tasks.Task EditAsync(RoomM.Models.RoomType entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/Save", ReplyAction="http://tempuri.org/IServiceOf_RoomType/SaveResponse")]
        void Save();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_RoomType/Save", ReplyAction="http://tempuri.org/IServiceOf_RoomType/SaveResponse")]
        System.Threading.Tasks.Task SaveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomTypeService/GetSingle", ReplyAction="http://tempuri.org/IRoomTypeService/GetSingleResponse")]
        RoomM.Models.RoomType GetSingle(int roomTypeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoomTypeService/GetSingle", ReplyAction="http://tempuri.org/IRoomTypeService/GetSingleResponse")]
        System.Threading.Tasks.Task<RoomM.Models.RoomType> GetSingleAsync(int roomTypeId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoomTypeServiceChannel : RoomM.DeskApp.RoomTypeService.IRoomTypeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoomTypeServiceClient : System.ServiceModel.ClientBase<RoomM.DeskApp.RoomTypeService.IRoomTypeService>, RoomM.DeskApp.RoomTypeService.IRoomTypeService {
        
        public RoomTypeServiceClient() {
        }
        
        public RoomTypeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoomTypeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomTypeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoomTypeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<RoomM.Models.RoomType> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.RoomType>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Add(RoomM.Models.RoomType entity) {
            base.Channel.Add(entity);
        }
        
        public System.Threading.Tasks.Task AddAsync(RoomM.Models.RoomType entity) {
            return base.Channel.AddAsync(entity);
        }
        
        public void DeleteByT(RoomM.Models.RoomType entity) {
            base.Channel.DeleteByT(entity);
        }
        
        public System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.RoomType entity) {
            return base.Channel.DeleteByTAsync(entity);
        }
        
        public void DeleteByObject(object id) {
            base.Channel.DeleteByObject(id);
        }
        
        public System.Threading.Tasks.Task DeleteByObjectAsync(object id) {
            return base.Channel.DeleteByObjectAsync(id);
        }
        
        public void Edit(RoomM.Models.RoomType entity) {
            base.Channel.Edit(entity);
        }
        
        public System.Threading.Tasks.Task EditAsync(RoomM.Models.RoomType entity) {
            return base.Channel.EditAsync(entity);
        }
        
        public void Save() {
            base.Channel.Save();
        }
        
        public System.Threading.Tasks.Task SaveAsync() {
            return base.Channel.SaveAsync();
        }
        
        public RoomM.Models.RoomType GetSingle(int roomTypeId) {
            return base.Channel.GetSingle(roomTypeId);
        }
        
        public System.Threading.Tasks.Task<RoomM.Models.RoomType> GetSingleAsync(int roomTypeId) {
            return base.Channel.GetSingleAsync(roomTypeId);
        }
    }
}
