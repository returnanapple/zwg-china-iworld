﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34003
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace zwg_china.client.framework.AuthorPushService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NormalResult", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service")]
    public partial class NormalResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ErrorField;
        
        private bool SuccessField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Error {
            get {
                return this.ErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorField, value) != true)) {
                    this.ErrorField = value;
                    this.RaisePropertyChanged("Error");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NoticeExport", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service.client")]
    public partial class NoticeExport : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ContextField;
        
        private int IdField;
        
        private int OwnerIdField;
        
        private int SourceIdField;
        
        private string SourceTypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Context {
            get {
                return this.ContextField;
            }
            set {
                if ((object.ReferenceEquals(this.ContextField, value) != true)) {
                    this.ContextField = value;
                    this.RaisePropertyChanged("Context");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OwnerId {
            get {
                return this.OwnerIdField;
            }
            set {
                if ((this.OwnerIdField.Equals(value) != true)) {
                    this.OwnerIdField = value;
                    this.RaisePropertyChanged("OwnerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SourceId {
            get {
                return this.SourceIdField;
            }
            set {
                if ((this.SourceIdField.Equals(value) != true)) {
                    this.SourceIdField = value;
                    this.RaisePropertyChanged("SourceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SourceType {
            get {
                return this.SourceTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.SourceTypeField, value) != true)) {
                    this.SourceTypeField = value;
                    this.RaisePropertyChanged("SourceType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LotteryTicketExport", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service.client")]
    public partial class LotteryTicketExport : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private string IssueField;
        
        private string LotteryValuesField;
        
        private string NameField;
        
        private string NextIssueField;
        
        private System.DateTime NextLotteryTimeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Issue {
            get {
                return this.IssueField;
            }
            set {
                if ((object.ReferenceEquals(this.IssueField, value) != true)) {
                    this.IssueField = value;
                    this.RaisePropertyChanged("Issue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LotteryValues {
            get {
                return this.LotteryValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.LotteryValuesField, value) != true)) {
                    this.LotteryValuesField = value;
                    this.RaisePropertyChanged("LotteryValues");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NextIssue {
            get {
                return this.NextIssueField;
            }
            set {
                if ((object.ReferenceEquals(this.NextIssueField, value) != true)) {
                    this.NextIssueField = value;
                    this.RaisePropertyChanged("NextIssue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime NextLotteryTime {
            get {
                return this.NextLotteryTimeField;
            }
            set {
                if ((this.NextLotteryTimeField.Equals(value) != true)) {
                    this.NextLotteryTimeField = value;
                    this.RaisePropertyChanged("NextLotteryTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthorPushService.IAuthorPushService", CallbackContract=typeof(zwg_china.client.framework.AuthorPushService.IAuthorPushServiceCallback))]
    public interface IAuthorPushService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IAuthorPushService/SetIn", ReplyAction="http://tempuri.org/IAuthorPushService/SetInResponse")]
        System.IAsyncResult BeginSetIn(string token, System.AsyncCallback callback, object asyncState);
        
        zwg_china.client.framework.AuthorPushService.NormalResult EndSetIn(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthorPushServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAuthorPushService/CallWhenHaveUnreadNotices")]
        void CallWhenHaveUnreadNotices(System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.NoticeExport> notices);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAuthorPushService/CallWhenLottery")]
        void CallWhenLottery(System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.LotteryTicketExport> tickets);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IAuthorPushService/CallWhenLeave")]
        void CallWhenLeave(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthorPushServiceChannel : zwg_china.client.framework.AuthorPushService.IAuthorPushService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SetInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SetInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public zwg_china.client.framework.AuthorPushService.NormalResult Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((zwg_china.client.framework.AuthorPushService.NormalResult)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthorPushServiceClient : System.ServiceModel.DuplexClientBase<zwg_china.client.framework.AuthorPushService.IAuthorPushService>, zwg_china.client.framework.AuthorPushService.IAuthorPushService {
        
        private BeginOperationDelegate onBeginSetInDelegate;
        
        private EndOperationDelegate onEndSetInDelegate;
        
        private System.Threading.SendOrPostCallback onSetInCompletedDelegate;
        
        private bool useGeneratedCallback;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public AuthorPushServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public AuthorPushServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public AuthorPushServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorPushServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public AuthorPushServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public AuthorPushServiceClient(string endpointConfigurationName) : 
                this(new AuthorPushServiceClientCallback(), endpointConfigurationName) {
        }
        
        private AuthorPushServiceClient(AuthorPushServiceClientCallback callbackImpl, string endpointConfigurationName) : 
                this(new System.ServiceModel.InstanceContext(callbackImpl), endpointConfigurationName) {
            useGeneratedCallback = true;
            callbackImpl.Initialize(this);
        }
        
        public AuthorPushServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                this(new AuthorPushServiceClientCallback(), binding, remoteAddress) {
        }
        
        private AuthorPushServiceClient(AuthorPushServiceClientCallback callbackImpl, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                this(new System.ServiceModel.InstanceContext(callbackImpl), binding, remoteAddress) {
            useGeneratedCallback = true;
            callbackImpl.Initialize(this);
        }
        
        public AuthorPushServiceClient() : 
                this(new AuthorPushServiceClientCallback()) {
        }
        
        private AuthorPushServiceClient(AuthorPushServiceClientCallback callbackImpl) : 
                this(new System.ServiceModel.InstanceContext(callbackImpl)) {
            useGeneratedCallback = true;
            callbackImpl.Initialize(this);
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("无法设置 CookieContainer。请确保绑定包含 HttpCookieContainerBindingElement。");
                }
            }
        }
        
        public event System.EventHandler<SetInCompletedEventArgs> SetInCompleted;
        
        public event System.EventHandler<CallWhenHaveUnreadNoticesReceivedEventArgs> CallWhenHaveUnreadNoticesReceived;
        
        public event System.EventHandler<CallWhenLotteryReceivedEventArgs> CallWhenLotteryReceived;
        
        public event System.EventHandler<CallWhenLeaveReceivedEventArgs> CallWhenLeaveReceived;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult zwg_china.client.framework.AuthorPushService.IAuthorPushService.BeginSetIn(string token, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSetIn(token, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        zwg_china.client.framework.AuthorPushService.NormalResult zwg_china.client.framework.AuthorPushService.IAuthorPushService.EndSetIn(System.IAsyncResult result) {
            return base.Channel.EndSetIn(result);
        }
        
        private System.IAsyncResult OnBeginSetIn(object[] inValues, System.AsyncCallback callback, object asyncState) {
            this.VerifyCallbackEvents();
            string token = ((string)(inValues[0]));
            return ((zwg_china.client.framework.AuthorPushService.IAuthorPushService)(this)).BeginSetIn(token, callback, asyncState);
        }
        
        private object[] OnEndSetIn(System.IAsyncResult result) {
            zwg_china.client.framework.AuthorPushService.NormalResult retVal = ((zwg_china.client.framework.AuthorPushService.IAuthorPushService)(this)).EndSetIn(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSetInCompleted(object state) {
            if ((this.SetInCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SetInCompleted(this, new SetInCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SetInAsync(string token) {
            this.SetInAsync(token, null);
        }
        
        public void SetInAsync(string token, object userState) {
            if ((this.onBeginSetInDelegate == null)) {
                this.onBeginSetInDelegate = new BeginOperationDelegate(this.OnBeginSetIn);
            }
            if ((this.onEndSetInDelegate == null)) {
                this.onEndSetInDelegate = new EndOperationDelegate(this.OnEndSetIn);
            }
            if ((this.onSetInCompletedDelegate == null)) {
                this.onSetInCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSetInCompleted);
            }
            base.InvokeAsync(this.onBeginSetInDelegate, new object[] {
                        token}, this.onEndSetInDelegate, this.onSetInCompletedDelegate, userState);
        }
        
        private void OnCallWhenHaveUnreadNoticesReceived(object state) {
            if ((this.CallWhenHaveUnreadNoticesReceived != null)) {
                object[] results = ((object[])(state));
                this.CallWhenHaveUnreadNoticesReceived(this, new CallWhenHaveUnreadNoticesReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void OnCallWhenLotteryReceived(object state) {
            if ((this.CallWhenLotteryReceived != null)) {
                object[] results = ((object[])(state));
                this.CallWhenLotteryReceived(this, new CallWhenLotteryReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void OnCallWhenLeaveReceived(object state) {
            if ((this.CallWhenLeaveReceived != null)) {
                object[] results = ((object[])(state));
                this.CallWhenLeaveReceived(this, new CallWhenLeaveReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void VerifyCallbackEvents() {
            if (((this.useGeneratedCallback != true) 
                        && (((this.CallWhenHaveUnreadNoticesReceived != null) 
                        || (this.CallWhenLotteryReceived != null)) 
                        || (this.CallWhenLeaveReceived != null)))) {
                throw new System.InvalidOperationException("指定了回调 InstanceContext 时无法使用回调事件。请选择是指定回调 InstanceContext 还是订阅回调事件。");
            }
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            this.VerifyCallbackEvents();
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override zwg_china.client.framework.AuthorPushService.IAuthorPushService CreateChannel() {
            return new AuthorPushServiceClientChannel(this);
        }
        
        private class AuthorPushServiceClientCallback : object, IAuthorPushServiceCallback {
            
            private AuthorPushServiceClient proxy;
            
            public void Initialize(AuthorPushServiceClient proxy) {
                this.proxy = proxy;
            }
            
            public void CallWhenHaveUnreadNotices(System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.NoticeExport> notices) {
                this.proxy.OnCallWhenHaveUnreadNoticesReceived(new object[] {
                            notices});
            }
            
            public void CallWhenLottery(System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.LotteryTicketExport> tickets) {
                this.proxy.OnCallWhenLotteryReceived(new object[] {
                            tickets});
            }
            
            public void CallWhenLeave(string message) {
                this.proxy.OnCallWhenLeaveReceived(new object[] {
                            message});
            }
        }
        
        private class AuthorPushServiceClientChannel : ChannelBase<zwg_china.client.framework.AuthorPushService.IAuthorPushService>, zwg_china.client.framework.AuthorPushService.IAuthorPushService {
            
            public AuthorPushServiceClientChannel(System.ServiceModel.DuplexClientBase<zwg_china.client.framework.AuthorPushService.IAuthorPushService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginSetIn(string token, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = token;
                System.IAsyncResult _result = base.BeginInvoke("SetIn", _args, callback, asyncState);
                return _result;
            }
            
            public zwg_china.client.framework.AuthorPushService.NormalResult EndSetIn(System.IAsyncResult result) {
                object[] _args = new object[0];
                zwg_china.client.framework.AuthorPushService.NormalResult _result = ((zwg_china.client.framework.AuthorPushService.NormalResult)(base.EndInvoke("SetIn", _args, result)));
                return _result;
            }
        }
    }
    
    public class CallWhenHaveUnreadNoticesReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CallWhenHaveUnreadNoticesReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.NoticeExport> notices {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.NoticeExport>)(this.results[0]));
            }
        }
    }
    
    public class CallWhenLotteryReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CallWhenLotteryReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.LotteryTicketExport> tickets {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.Generic.List<zwg_china.client.framework.AuthorPushService.LotteryTicketExport>)(this.results[0]));
            }
        }
    }
    
    public class CallWhenLeaveReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CallWhenLeaveReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string message {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}