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
namespace zwg_china.client.framework.ReportService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImportBase", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(zwg_china.client.framework.ReportService.GetPageListImportBase))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(zwg_china.client.framework.ReportService.GetPageListImportBaseOfReport))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport))]
    public partial class ImportBase : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string TokenField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Token {
            get {
                return this.TokenField;
            }
            set {
                if ((object.ReferenceEquals(this.TokenField, value) != true)) {
                    this.TokenField = value;
                    this.RaisePropertyChanged("Token");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="GetPageListImportBase", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(zwg_china.client.framework.ReportService.GetPageListImportBaseOfReport))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport))]
    public partial class GetPageListImportBase : zwg_china.client.framework.ReportService.ImportBase {
        
        private int PageIndexField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PageIndex {
            get {
                return this.PageIndexField;
            }
            set {
                if ((this.PageIndexField.Equals(value) != true)) {
                    this.PageIndexField = value;
                    this.RaisePropertyChanged("PageIndex");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetPageListImportBaseOfReport", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service.client")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport))]
    public partial class GetPageListImportBaseOfReport : zwg_china.client.framework.ReportService.GetPageListImportBase {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetRersonalAndTeamReportsImport", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service.client")]
    public partial class GetRersonalAndTeamReportsImport : zwg_china.client.framework.ReportService.GetPageListImportBaseOfReport {
        
        private zwg_china.client.framework.ReportService.MonthOrDay MODField;
        
        private zwg_china.client.framework.ReportService.TeamOrSelf TOSField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public zwg_china.client.framework.ReportService.MonthOrDay MOD {
            get {
                return this.MODField;
            }
            set {
                if ((this.MODField.Equals(value) != true)) {
                    this.MODField = value;
                    this.RaisePropertyChanged("MOD");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public zwg_china.client.framework.ReportService.TeamOrSelf TOS {
            get {
                return this.TOSField;
            }
            set {
                if ((this.TOSField.Equals(value) != true)) {
                    this.TOSField = value;
                    this.RaisePropertyChanged("TOS");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MonthOrDay", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service.client")]
    public enum MonthOrDay : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Month = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Day = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TeamOrSelf", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service.client")]
    public enum TeamOrSelf : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Team = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Self = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NormalResult", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4))]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="PageResultOfRersonalAndTeamReportExport1C_S7RQu4", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service")]
    public partial class PageResultOfRersonalAndTeamReportExport1C_S7RQu4 : zwg_china.client.framework.ReportService.NormalResult {
        
        private int CountOfAllMessageField;
        
        private int CountOfPageField;
        
        private System.Collections.Generic.List<zwg_china.client.framework.ReportService.RersonalAndTeamReportExport> ListField;
        
        private int PageIndeField;
        
        private int PageSizeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CountOfAllMessage {
            get {
                return this.CountOfAllMessageField;
            }
            set {
                if ((this.CountOfAllMessageField.Equals(value) != true)) {
                    this.CountOfAllMessageField = value;
                    this.RaisePropertyChanged("CountOfAllMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CountOfPage {
            get {
                return this.CountOfPageField;
            }
            set {
                if ((this.CountOfPageField.Equals(value) != true)) {
                    this.CountOfPageField = value;
                    this.RaisePropertyChanged("CountOfPage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<zwg_china.client.framework.ReportService.RersonalAndTeamReportExport> List {
            get {
                return this.ListField;
            }
            set {
                if ((object.ReferenceEquals(this.ListField, value) != true)) {
                    this.ListField = value;
                    this.RaisePropertyChanged("List");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PageInde {
            get {
                return this.PageIndeField;
            }
            set {
                if ((this.PageIndeField.Equals(value) != true)) {
                    this.PageIndeField = value;
                    this.RaisePropertyChanged("PageInde");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PageSize {
            get {
                return this.PageSizeField;
            }
            set {
                if ((this.PageSizeField.Equals(value) != true)) {
                    this.PageSizeField = value;
                    this.RaisePropertyChanged("PageSize");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RersonalAndTeamReportExport", Namespace="http://schemas.datacontract.org/2004/07/zwg_china.service.client")]
    public partial class RersonalAndTeamReportExport : object, System.ComponentModel.INotifyPropertyChanged {
        
        private double AmountOfBetsField;
        
        private double BonusField;
        
        private double CommissionField;
        
        private string DateField;
        
        private double DividendField;
        
        private string OwnerField;
        
        private int OwnerIdField;
        
        private double ProfitField;
        
        private double RebateField;
        
        private double RechargeField;
        
        private double RewardField;
        
        private int TimesOfLoginField;
        
        private double WithdrawalField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AmountOfBets {
            get {
                return this.AmountOfBetsField;
            }
            set {
                if ((this.AmountOfBetsField.Equals(value) != true)) {
                    this.AmountOfBetsField = value;
                    this.RaisePropertyChanged("AmountOfBets");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Bonus {
            get {
                return this.BonusField;
            }
            set {
                if ((this.BonusField.Equals(value) != true)) {
                    this.BonusField = value;
                    this.RaisePropertyChanged("Bonus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Commission {
            get {
                return this.CommissionField;
            }
            set {
                if ((this.CommissionField.Equals(value) != true)) {
                    this.CommissionField = value;
                    this.RaisePropertyChanged("Commission");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Date {
            get {
                return this.DateField;
            }
            set {
                if ((object.ReferenceEquals(this.DateField, value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Dividend {
            get {
                return this.DividendField;
            }
            set {
                if ((this.DividendField.Equals(value) != true)) {
                    this.DividendField = value;
                    this.RaisePropertyChanged("Dividend");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Owner {
            get {
                return this.OwnerField;
            }
            set {
                if ((object.ReferenceEquals(this.OwnerField, value) != true)) {
                    this.OwnerField = value;
                    this.RaisePropertyChanged("Owner");
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
        public double Profit {
            get {
                return this.ProfitField;
            }
            set {
                if ((this.ProfitField.Equals(value) != true)) {
                    this.ProfitField = value;
                    this.RaisePropertyChanged("Profit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Rebate {
            get {
                return this.RebateField;
            }
            set {
                if ((this.RebateField.Equals(value) != true)) {
                    this.RebateField = value;
                    this.RaisePropertyChanged("Rebate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Recharge {
            get {
                return this.RechargeField;
            }
            set {
                if ((this.RechargeField.Equals(value) != true)) {
                    this.RechargeField = value;
                    this.RaisePropertyChanged("Recharge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Reward {
            get {
                return this.RewardField;
            }
            set {
                if ((this.RewardField.Equals(value) != true)) {
                    this.RewardField = value;
                    this.RaisePropertyChanged("Reward");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TimesOfLogin {
            get {
                return this.TimesOfLoginField;
            }
            set {
                if ((this.TimesOfLoginField.Equals(value) != true)) {
                    this.TimesOfLoginField = value;
                    this.RaisePropertyChanged("TimesOfLogin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Withdrawal {
            get {
                return this.WithdrawalField;
            }
            set {
                if ((this.WithdrawalField.Equals(value) != true)) {
                    this.WithdrawalField = value;
                    this.RaisePropertyChanged("Withdrawal");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReportService.IReportService")]
    public interface IReportService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IReportService/GetRersonalAndTeamReports", ReplyAction="http://tempuri.org/IReportService/GetRersonalAndTeamReportsResponse")]
        System.IAsyncResult BeginGetRersonalAndTeamReports(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport import, System.AsyncCallback callback, object asyncState);
        
        zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4 EndGetRersonalAndTeamReports(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReportServiceChannel : zwg_china.client.framework.ReportService.IReportService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetRersonalAndTeamReportsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetRersonalAndTeamReportsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4 Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReportServiceClient : System.ServiceModel.ClientBase<zwg_china.client.framework.ReportService.IReportService>, zwg_china.client.framework.ReportService.IReportService {
        
        private BeginOperationDelegate onBeginGetRersonalAndTeamReportsDelegate;
        
        private EndOperationDelegate onEndGetRersonalAndTeamReportsDelegate;
        
        private System.Threading.SendOrPostCallback onGetRersonalAndTeamReportsCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ReportServiceClient() {
        }
        
        public ReportServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReportServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReportServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
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
        
        public event System.EventHandler<GetRersonalAndTeamReportsCompletedEventArgs> GetRersonalAndTeamReportsCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult zwg_china.client.framework.ReportService.IReportService.BeginGetRersonalAndTeamReports(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport import, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetRersonalAndTeamReports(import, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4 zwg_china.client.framework.ReportService.IReportService.EndGetRersonalAndTeamReports(System.IAsyncResult result) {
            return base.Channel.EndGetRersonalAndTeamReports(result);
        }
        
        private System.IAsyncResult OnBeginGetRersonalAndTeamReports(object[] inValues, System.AsyncCallback callback, object asyncState) {
            zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport import = ((zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport)(inValues[0]));
            return ((zwg_china.client.framework.ReportService.IReportService)(this)).BeginGetRersonalAndTeamReports(import, callback, asyncState);
        }
        
        private object[] OnEndGetRersonalAndTeamReports(System.IAsyncResult result) {
            zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4 retVal = ((zwg_china.client.framework.ReportService.IReportService)(this)).EndGetRersonalAndTeamReports(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetRersonalAndTeamReportsCompleted(object state) {
            if ((this.GetRersonalAndTeamReportsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetRersonalAndTeamReportsCompleted(this, new GetRersonalAndTeamReportsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetRersonalAndTeamReportsAsync(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport import) {
            this.GetRersonalAndTeamReportsAsync(import, null);
        }
        
        public void GetRersonalAndTeamReportsAsync(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport import, object userState) {
            if ((this.onBeginGetRersonalAndTeamReportsDelegate == null)) {
                this.onBeginGetRersonalAndTeamReportsDelegate = new BeginOperationDelegate(this.OnBeginGetRersonalAndTeamReports);
            }
            if ((this.onEndGetRersonalAndTeamReportsDelegate == null)) {
                this.onEndGetRersonalAndTeamReportsDelegate = new EndOperationDelegate(this.OnEndGetRersonalAndTeamReports);
            }
            if ((this.onGetRersonalAndTeamReportsCompletedDelegate == null)) {
                this.onGetRersonalAndTeamReportsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetRersonalAndTeamReportsCompleted);
            }
            base.InvokeAsync(this.onBeginGetRersonalAndTeamReportsDelegate, new object[] {
                        import}, this.onEndGetRersonalAndTeamReportsDelegate, this.onGetRersonalAndTeamReportsCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
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
        
        protected override zwg_china.client.framework.ReportService.IReportService CreateChannel() {
            return new ReportServiceClientChannel(this);
        }
        
        private class ReportServiceClientChannel : ChannelBase<zwg_china.client.framework.ReportService.IReportService>, zwg_china.client.framework.ReportService.IReportService {
            
            public ReportServiceClientChannel(System.ServiceModel.ClientBase<zwg_china.client.framework.ReportService.IReportService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetRersonalAndTeamReports(zwg_china.client.framework.ReportService.GetRersonalAndTeamReportsImport import, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = import;
                System.IAsyncResult _result = base.BeginInvoke("GetRersonalAndTeamReports", _args, callback, asyncState);
                return _result;
            }
            
            public zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4 EndGetRersonalAndTeamReports(System.IAsyncResult result) {
                object[] _args = new object[0];
                zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4 _result = ((zwg_china.client.framework.ReportService.PageResultOfRersonalAndTeamReportExport1C_S7RQu4)(base.EndInvoke("GetRersonalAndTeamReports", _args, result)));
                return _result;
            }
        }
    }
}
