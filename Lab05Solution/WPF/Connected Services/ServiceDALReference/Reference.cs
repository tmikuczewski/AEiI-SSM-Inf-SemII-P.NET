﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF.ServiceDALReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/DAL.Models")]
    [System.SerializableAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public System.Guid Id {
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
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceDALReference.IServiceDAL")]
    public interface IServiceDAL {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/GetPeople", ReplyAction="http://tempuri.org/IServiceDAL/GetPeopleResponse")]
        WPF.ServiceDALReference.Person[] GetPeople();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/GetPeople", ReplyAction="http://tempuri.org/IServiceDAL/GetPeopleResponse")]
        System.Threading.Tasks.Task<WPF.ServiceDALReference.Person[]> GetPeopleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/Find", ReplyAction="http://tempuri.org/IServiceDAL/FindResponse")]
        WPF.ServiceDALReference.Person Find(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/Find", ReplyAction="http://tempuri.org/IServiceDAL/FindResponse")]
        System.Threading.Tasks.Task<WPF.ServiceDALReference.Person> FindAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/AddPerson", ReplyAction="http://tempuri.org/IServiceDAL/AddPersonResponse")]
        bool AddPerson(WPF.ServiceDALReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/AddPerson", ReplyAction="http://tempuri.org/IServiceDAL/AddPersonResponse")]
        System.Threading.Tasks.Task<bool> AddPersonAsync(WPF.ServiceDALReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/EditPerson", ReplyAction="http://tempuri.org/IServiceDAL/EditPersonResponse")]
        bool EditPerson(WPF.ServiceDALReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/EditPerson", ReplyAction="http://tempuri.org/IServiceDAL/EditPersonResponse")]
        System.Threading.Tasks.Task<bool> EditPersonAsync(WPF.ServiceDALReference.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/RemovePerson", ReplyAction="http://tempuri.org/IServiceDAL/RemovePersonResponse")]
        bool RemovePerson(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDAL/RemovePerson", ReplyAction="http://tempuri.org/IServiceDAL/RemovePersonResponse")]
        System.Threading.Tasks.Task<bool> RemovePersonAsync(System.Guid id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceDALChannel : WPF.ServiceDALReference.IServiceDAL, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceDALClient : System.ServiceModel.ClientBase<WPF.ServiceDALReference.IServiceDAL>, WPF.ServiceDALReference.IServiceDAL {
        
        public ServiceDALClient() {
        }
        
        public ServiceDALClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceDALClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDALClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDALClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WPF.ServiceDALReference.Person[] GetPeople() {
            return base.Channel.GetPeople();
        }
        
        public System.Threading.Tasks.Task<WPF.ServiceDALReference.Person[]> GetPeopleAsync() {
            return base.Channel.GetPeopleAsync();
        }
        
        public WPF.ServiceDALReference.Person Find(string username, string password) {
            return base.Channel.Find(username, password);
        }
        
        public System.Threading.Tasks.Task<WPF.ServiceDALReference.Person> FindAsync(string username, string password) {
            return base.Channel.FindAsync(username, password);
        }
        
        public bool AddPerson(WPF.ServiceDALReference.Person person) {
            return base.Channel.AddPerson(person);
        }
        
        public System.Threading.Tasks.Task<bool> AddPersonAsync(WPF.ServiceDALReference.Person person) {
            return base.Channel.AddPersonAsync(person);
        }
        
        public bool EditPerson(WPF.ServiceDALReference.Person person) {
            return base.Channel.EditPerson(person);
        }
        
        public System.Threading.Tasks.Task<bool> EditPersonAsync(WPF.ServiceDALReference.Person person) {
            return base.Channel.EditPersonAsync(person);
        }
        
        public bool RemovePerson(System.Guid id) {
            return base.Channel.RemovePerson(id);
        }
        
        public System.Threading.Tasks.Task<bool> RemovePersonAsync(System.Guid id) {
            return base.Channel.RemovePersonAsync(id);
        }
    }
}
