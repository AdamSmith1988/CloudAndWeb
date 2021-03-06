﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICATask4.SkillService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SkillsDTO", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRole1.DTO")]
    [System.SerializableAttribute()]
    public partial class SkillsDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string skillCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string skillDescriptionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string skillCode {
            get {
                return this.skillCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.skillCodeField, value) != true)) {
                    this.skillCodeField = value;
                    this.RaisePropertyChanged("skillCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string skillDescription {
            get {
                return this.skillDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.skillDescriptionField, value) != true)) {
                    this.skillDescriptionField = value;
                    this.RaisePropertyChanged("skillDescription");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SkillService.ISkillService")]
    public interface ISkillService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISkillService/GetSkill", ReplyAction="http://tempuri.org/ISkillService/GetSkillResponse")]
        ICATask4.SkillService.SkillsDTO GetSkill(string skillCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISkillService/GetSkill", ReplyAction="http://tempuri.org/ISkillService/GetSkillResponse")]
        System.Threading.Tasks.Task<ICATask4.SkillService.SkillsDTO> GetSkillAsync(string skillCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISkillService/GetAllSkills", ReplyAction="http://tempuri.org/ISkillService/GetAllSkillsResponse")]
        ICATask4.SkillService.SkillsDTO[] GetAllSkills();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISkillService/GetAllSkills", ReplyAction="http://tempuri.org/ISkillService/GetAllSkillsResponse")]
        System.Threading.Tasks.Task<ICATask4.SkillService.SkillsDTO[]> GetAllSkillsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISkillServiceChannel : ICATask4.SkillService.ISkillService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SkillServiceClient : System.ServiceModel.ClientBase<ICATask4.SkillService.ISkillService>, ICATask4.SkillService.ISkillService {
        
        public SkillServiceClient() {
        }
        
        public SkillServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SkillServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SkillServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SkillServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ICATask4.SkillService.SkillsDTO GetSkill(string skillCode) {
            return base.Channel.GetSkill(skillCode);
        }
        
        public System.Threading.Tasks.Task<ICATask4.SkillService.SkillsDTO> GetSkillAsync(string skillCode) {
            return base.Channel.GetSkillAsync(skillCode);
        }
        
        public ICATask4.SkillService.SkillsDTO[] GetAllSkills() {
            return base.Channel.GetAllSkills();
        }
        
        public System.Threading.Tasks.Task<ICATask4.SkillService.SkillsDTO[]> GetAllSkillsAsync() {
            return base.Channel.GetAllSkillsAsync();
        }
    }
}
