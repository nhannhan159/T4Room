﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoomM.DeskApp.StaffService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StaffService.IStaffService")]
    public interface IStaffService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/GetAll", ReplyAction="http://tempuri.org/IServiceOf_Staff/GetAllResponse")]
        System.Collections.Generic.List<RoomM.Models.Staff> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/GetAll", ReplyAction="http://tempuri.org/IServiceOf_Staff/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Staff>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/Add", ReplyAction="http://tempuri.org/IServiceOf_Staff/AddResponse")]
        void Add(RoomM.Models.Staff entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/Add", ReplyAction="http://tempuri.org/IServiceOf_Staff/AddResponse")]
        System.Threading.Tasks.Task AddAsync(RoomM.Models.Staff entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_Staff/DeleteByTResponse")]
        void DeleteByT(RoomM.Models.Staff entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/DeleteByT", ReplyAction="http://tempuri.org/IServiceOf_Staff/DeleteByTResponse")]
        System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.Staff entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_Staff/DeleteByObjectResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<RoomM.Models.Staff>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.Staff))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(RoomM.Models.EntityBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<System.Collections.DictionaryEntry>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.DictionaryEntry))]
        void DeleteByObject(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/DeleteByObject", ReplyAction="http://tempuri.org/IServiceOf_Staff/DeleteByObjectResponse")]
        System.Threading.Tasks.Task DeleteByObjectAsync(object id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/Edit", ReplyAction="http://tempuri.org/IServiceOf_Staff/EditResponse")]
        void Edit(RoomM.Models.Staff entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceOf_Staff/Edit", ReplyAction="http://tempuri.org/IServiceOf_Staff/EditResponse")]
        System.Threading.Tasks.Task EditAsync(RoomM.Models.Staff entity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetSingle", ReplyAction="http://tempuri.org/IStaffService/GetSingleResponse")]
        RoomM.Models.Staff GetSingle(int staffId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetSingle", ReplyAction="http://tempuri.org/IStaffService/GetSingleResponse")]
        System.Threading.Tasks.Task<RoomM.Models.Staff> GetSingleAsync(int staffId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/CheckPassword", ReplyAction="http://tempuri.org/IStaffService/CheckPasswordResponse")]
        bool CheckPassword(RoomM.Models.Staff staff, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/CheckPassword", ReplyAction="http://tempuri.org/IStaffService/CheckPasswordResponse")]
        System.Threading.Tasks.Task<bool> CheckPasswordAsync(RoomM.Models.Staff staff, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/CheckUserExists", ReplyAction="http://tempuri.org/IStaffService/CheckUserExistsResponse")]
        bool CheckUserExists(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/CheckUserExists", ReplyAction="http://tempuri.org/IStaffService/CheckUserExistsResponse")]
        System.Threading.Tasks.Task<bool> CheckUserExistsAsync(string username);
        
        // CODEGEN: Generating message contract since the wrapper name (GetStaffLimitByRegister_IList_x003C_Staff_x003E_) of message GetStaffLimitByRegister_IList_x003C_Staff_x003E_Request does not match the default value (GetStaffLimitByRegister_IListStaff)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetStaffLimitByRegister_IList<Staff>", ReplyAction="http://tempuri.org/IStaffService/GetStaffLimitByRegister_IList<Staff>Response")]
        RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffResponse GetStaffLimitByRegister_IListStaff(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetStaffLimitByRegister_IList<Staff>", ReplyAction="http://tempuri.org/IStaffService/GetStaffLimitByRegister_IList<Staff>Response")]
        System.Threading.Tasks.Task<RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffResponse> GetStaffLimitByRegister_IListStaffAsync(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest request);
        
        // CODEGEN: Generating message contract since the wrapper name (GetStaffLimitByRegister_List_x003C_DictionaryEntry_x003E_) of message GetStaffLimitByRegister_List_x003C_DictionaryEntry_x003E_Request does not match the default value (GetStaffLimitByRegister_ListDictionaryEntry)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetStaffLimitByRegister_List<DictionaryEntry>", ReplyAction="http://tempuri.org/IStaffService/GetStaffLimitByRegister_List<DictionaryEntry>Res" +
            "ponse")]
        RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryResponse GetStaffLimitByRegister_ListDictionaryEntry(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetStaffLimitByRegister_List<DictionaryEntry>", ReplyAction="http://tempuri.org/IStaffService/GetStaffLimitByRegister_List<DictionaryEntry>Res" +
            "ponse")]
        System.Threading.Tasks.Task<RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryResponse> GetStaffLimitByRegister_ListDictionaryEntryAsync(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/IsExists", ReplyAction="http://tempuri.org/IStaffService/IsExistsResponse")]
        bool IsExists(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/IsExists", ReplyAction="http://tempuri.org/IStaffService/IsExistsResponse")]
        System.Threading.Tasks.Task<bool> IsExistsAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetUserId", ReplyAction="http://tempuri.org/IStaffService/GetUserIdResponse")]
        int GetUserId(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/GetUserId", ReplyAction="http://tempuri.org/IStaffService/GetUserIdResponse")]
        System.Threading.Tasks.Task<int> GetUserIdAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/UserNameIsWorking", ReplyAction="http://tempuri.org/IStaffService/UserNameIsWorkingResponse")]
        bool UserNameIsWorking(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStaffService/UserNameIsWorking", ReplyAction="http://tempuri.org/IStaffService/UserNameIsWorkingResponse")]
        System.Threading.Tasks.Task<bool> UserNameIsWorkingAsync(string username);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetStaffLimitByRegister_IList<Staff>", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetStaffLimitByRegister_IListStaffRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int limit;
        
        public GetStaffLimitByRegister_IListStaffRequest() {
        }
        
        public GetStaffLimitByRegister_IListStaffRequest(int limit) {
            this.limit = limit;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetStaffLimitByRegister_IList<Staff>Response", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetStaffLimitByRegister_IListStaffResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetStaffLimitByRegister_IList_x003C_Staff_x003E_Result", Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.Generic.List<RoomM.Models.Staff> GetStaffLimitByRegister_IListStaffResult;
        
        public GetStaffLimitByRegister_IListStaffResponse() {
        }
        
        public GetStaffLimitByRegister_IListStaffResponse(System.Collections.Generic.List<RoomM.Models.Staff> GetStaffLimitByRegister_IListStaffResult) {
            this.GetStaffLimitByRegister_IListStaffResult = GetStaffLimitByRegister_IListStaffResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetStaffLimitByRegister_List<DictionaryEntry>", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetStaffLimitByRegister_ListDictionaryEntryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int limit;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public System.DateTime from;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public System.DateTime to;
        
        public GetStaffLimitByRegister_ListDictionaryEntryRequest() {
        }
        
        public GetStaffLimitByRegister_ListDictionaryEntryRequest(int limit, System.DateTime from, System.DateTime to) {
            this.limit = limit;
            this.from = from;
            this.to = to;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetStaffLimitByRegister_List<DictionaryEntry>Response", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetStaffLimitByRegister_ListDictionaryEntryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetStaffLimitByRegister_List_x003C_DictionaryEntry_x003E_Result", Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.Generic.List<System.Collections.DictionaryEntry> GetStaffLimitByRegister_ListDictionaryEntryResult;
        
        public GetStaffLimitByRegister_ListDictionaryEntryResponse() {
        }
        
        public GetStaffLimitByRegister_ListDictionaryEntryResponse(System.Collections.Generic.List<System.Collections.DictionaryEntry> GetStaffLimitByRegister_ListDictionaryEntryResult) {
            this.GetStaffLimitByRegister_ListDictionaryEntryResult = GetStaffLimitByRegister_ListDictionaryEntryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStaffServiceChannel : RoomM.DeskApp.StaffService.IStaffService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StaffServiceClient : System.ServiceModel.ClientBase<RoomM.DeskApp.StaffService.IStaffService>, RoomM.DeskApp.StaffService.IStaffService {
        
        public StaffServiceClient() {
        }
        
        public StaffServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StaffServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StaffServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StaffServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<RoomM.Models.Staff> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<RoomM.Models.Staff>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void Add(RoomM.Models.Staff entity) {
            base.Channel.Add(entity);
        }
        
        public System.Threading.Tasks.Task AddAsync(RoomM.Models.Staff entity) {
            return base.Channel.AddAsync(entity);
        }
        
        public void DeleteByT(RoomM.Models.Staff entity) {
            base.Channel.DeleteByT(entity);
        }
        
        public System.Threading.Tasks.Task DeleteByTAsync(RoomM.Models.Staff entity) {
            return base.Channel.DeleteByTAsync(entity);
        }
        
        public void DeleteByObject(object id) {
            base.Channel.DeleteByObject(id);
        }
        
        public System.Threading.Tasks.Task DeleteByObjectAsync(object id) {
            return base.Channel.DeleteByObjectAsync(id);
        }
        
        public void Edit(RoomM.Models.Staff entity) {
            base.Channel.Edit(entity);
        }
        
        public System.Threading.Tasks.Task EditAsync(RoomM.Models.Staff entity) {
            return base.Channel.EditAsync(entity);
        }
        
        public RoomM.Models.Staff GetSingle(int staffId) {
            return base.Channel.GetSingle(staffId);
        }
        
        public System.Threading.Tasks.Task<RoomM.Models.Staff> GetSingleAsync(int staffId) {
            return base.Channel.GetSingleAsync(staffId);
        }
        
        public bool CheckPassword(RoomM.Models.Staff staff, string password) {
            return base.Channel.CheckPassword(staff, password);
        }
        
        public System.Threading.Tasks.Task<bool> CheckPasswordAsync(RoomM.Models.Staff staff, string password) {
            return base.Channel.CheckPasswordAsync(staff, password);
        }
        
        public bool CheckUserExists(string username) {
            return base.Channel.CheckUserExists(username);
        }
        
        public System.Threading.Tasks.Task<bool> CheckUserExistsAsync(string username) {
            return base.Channel.CheckUserExistsAsync(username);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffResponse RoomM.DeskApp.StaffService.IStaffService.GetStaffLimitByRegister_IListStaff(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest request) {
            return base.Channel.GetStaffLimitByRegister_IListStaff(request);
        }
        
        public System.Collections.Generic.List<RoomM.Models.Staff> GetStaffLimitByRegister_IListStaff(int limit) {
            RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest inValue = new RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest();
            inValue.limit = limit;
            RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffResponse retVal = ((RoomM.DeskApp.StaffService.IStaffService)(this)).GetStaffLimitByRegister_IListStaff(inValue);
            return retVal.GetStaffLimitByRegister_IListStaffResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffResponse> RoomM.DeskApp.StaffService.IStaffService.GetStaffLimitByRegister_IListStaffAsync(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest request) {
            return base.Channel.GetStaffLimitByRegister_IListStaffAsync(request);
        }
        
        public System.Threading.Tasks.Task<RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffResponse> GetStaffLimitByRegister_IListStaffAsync(int limit) {
            RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest inValue = new RoomM.DeskApp.StaffService.GetStaffLimitByRegister_IListStaffRequest();
            inValue.limit = limit;
            return ((RoomM.DeskApp.StaffService.IStaffService)(this)).GetStaffLimitByRegister_IListStaffAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryResponse RoomM.DeskApp.StaffService.IStaffService.GetStaffLimitByRegister_ListDictionaryEntry(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest request) {
            return base.Channel.GetStaffLimitByRegister_ListDictionaryEntry(request);
        }
        
        public System.Collections.Generic.List<System.Collections.DictionaryEntry> GetStaffLimitByRegister_ListDictionaryEntry(int limit, System.DateTime from, System.DateTime to) {
            RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest inValue = new RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest();
            inValue.limit = limit;
            inValue.from = from;
            inValue.to = to;
            RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryResponse retVal = ((RoomM.DeskApp.StaffService.IStaffService)(this)).GetStaffLimitByRegister_ListDictionaryEntry(inValue);
            return retVal.GetStaffLimitByRegister_ListDictionaryEntryResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryResponse> RoomM.DeskApp.StaffService.IStaffService.GetStaffLimitByRegister_ListDictionaryEntryAsync(RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest request) {
            return base.Channel.GetStaffLimitByRegister_ListDictionaryEntryAsync(request);
        }
        
        public System.Threading.Tasks.Task<RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryResponse> GetStaffLimitByRegister_ListDictionaryEntryAsync(int limit, System.DateTime from, System.DateTime to) {
            RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest inValue = new RoomM.DeskApp.StaffService.GetStaffLimitByRegister_ListDictionaryEntryRequest();
            inValue.limit = limit;
            inValue.from = from;
            inValue.to = to;
            return ((RoomM.DeskApp.StaffService.IStaffService)(this)).GetStaffLimitByRegister_ListDictionaryEntryAsync(inValue);
        }
        
        public bool IsExists(string username) {
            return base.Channel.IsExists(username);
        }
        
        public System.Threading.Tasks.Task<bool> IsExistsAsync(string username) {
            return base.Channel.IsExistsAsync(username);
        }
        
        public int GetUserId(string username) {
            return base.Channel.GetUserId(username);
        }
        
        public System.Threading.Tasks.Task<int> GetUserIdAsync(string username) {
            return base.Channel.GetUserIdAsync(username);
        }
        
        public bool UserNameIsWorking(string username) {
            return base.Channel.UserNameIsWorking(username);
        }
        
        public System.Threading.Tasks.Task<bool> UserNameIsWorkingAsync(string username) {
            return base.Channel.UserNameIsWorkingAsync(username);
        }
    }
}
