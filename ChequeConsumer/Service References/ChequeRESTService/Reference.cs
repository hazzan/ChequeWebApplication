﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChequeConsumer.ChequeRESTService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChequeRESTService.IRESTChequeService")]
    public interface IRESTChequeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRESTChequeService/SaveMenuItem", ReplyAction="http://tempuri.org/IRESTChequeService/SaveMenuItemResponse")]
        void SaveMenuItem(ChequeBusinessData.Entity.BillingInformation[] listBillingInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRESTChequeService/MenuItem", ReplyAction="http://tempuri.org/IRESTChequeService/MenuItemResponse")]
        string MenuItem();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRESTChequeServiceChannel : ChequeConsumer.ChequeRESTService.IRESTChequeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RESTChequeServiceClient : System.ServiceModel.ClientBase<ChequeConsumer.ChequeRESTService.IRESTChequeService>, ChequeConsumer.ChequeRESTService.IRESTChequeService {
        
        public RESTChequeServiceClient() {
        }
        
        public RESTChequeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RESTChequeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RESTChequeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RESTChequeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SaveMenuItem(ChequeBusinessData.Entity.BillingInformation[] listBillingInfo) {
            base.Channel.SaveMenuItem(listBillingInfo);
        }
        
        public string MenuItem() {
            return base.Channel.MenuItem();
        }
    }
}
