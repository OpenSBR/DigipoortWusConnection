﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogiusDigipoort.ServiceReferenceAanleveren {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/")]
    public partial class foutType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string foutcodeField;
        
        private string foutbeschrijvingField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=0)]
        public string foutcode {
            get {
                return this.foutcodeField;
            }
            set {
                this.foutcodeField = value;
                this.RaisePropertyChanged("foutcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=1)]
        public string foutbeschrijving {
            get {
                return this.foutbeschrijvingField;
            }
            set {
                this.foutbeschrijvingField = value;
                this.RaisePropertyChanged("foutbeschrijving");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/")]
    public partial class berichtInhoudType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mimeTypeField;
        
        private string bestandsnaamField;
        
        private byte[] inhoudField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=0)]
        public string mimeType {
            get {
                return this.mimeTypeField;
            }
            set {
                this.mimeTypeField = value;
                this.RaisePropertyChanged("mimeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=1)]
        public string bestandsnaam {
            get {
                return this.bestandsnaamField;
            }
            set {
                this.bestandsnaamField = value;
                this.RaisePropertyChanged("bestandsnaam");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", Order=2)]
        public byte[] inhoud {
            get {
                return this.inhoudField;
            }
            set {
                this.inhoudField = value;
                this.RaisePropertyChanged("inhoud");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/")]
    public partial class identiteitType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nummerField;
        
        private string typeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=0)]
        public string nummer {
            get {
                return this.nummerField;
            }
            set {
                this.nummerField = value;
                this.RaisePropertyChanged("nummer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=1)]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("type");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://logius.nl/digipoort/wus/2.0/aanleverservice/1.2/", ConfigurationName="ServiceReferenceAanleveren.AanleverService_V1_2")]
    public interface AanleverService_V1_2 {
        
        // CODEGEN: Generating message contract since the operation aanleveren is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://logius.nl/digipoort/wus/2.0/aanleverservice/1.2/AanleverService_V1_2/aanle" +
            "verenRequest", ReplyAction="http://logius.nl/digipoort/wus/2.0/aanleverservice/1.2/AanleverService/aanleveren" +
            "Response")]
        [System.ServiceModel.FaultContractAttribute(typeof(LogiusDigipoort.ServiceReferenceAanleveren.foutType), Action="http://logius.nl/digipoort/wus/2.0/aanleverservice/1.2/AanleverService/aanleveren" +
            "/Fault/", Name="aanleverFault", Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        LogiusDigipoort.ServiceReferenceAanleveren.aanleverenResponse aanleveren(LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://logius.nl/digipoort/wus/2.0/aanleverservice/1.2/AanleverService_V1_2/aanle" +
            "verenRequest", ReplyAction="http://logius.nl/digipoort/wus/2.0/aanleverservice/1.2/AanleverService/aanleveren" +
            "Response")]
        System.Threading.Tasks.Task<LogiusDigipoort.ServiceReferenceAanleveren.aanleverenResponse> aanleverenAsync(LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/")]
    public partial class aanleverRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string kenmerkField;
        
        private string berichtsoortField;
        
        private string aanleverkenmerkField;
        
        private string eerderAanleverkenmerkField;
        
        private identiteitType identiteitBelanghebbendeField;
        
        private string rolBelanghebbendeField;
        
        private identiteitType identiteitOntvangerField;
        
        private string rolOntvangerField;
        
        private berichtInhoudType berichtInhoudField;
        
        private berichtInhoudType[] berichtBijlagenField;
        
        private string autorisatieAdresField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=0)]
        public string kenmerk {
            get {
                return this.kenmerkField;
            }
            set {
                this.kenmerkField = value;
                this.RaisePropertyChanged("kenmerk");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=1)]
        public string berichtsoort {
            get {
                return this.berichtsoortField;
            }
            set {
                this.berichtsoortField = value;
                this.RaisePropertyChanged("berichtsoort");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=2)]
        public string aanleverkenmerk {
            get {
                return this.aanleverkenmerkField;
            }
            set {
                this.aanleverkenmerkField = value;
                this.RaisePropertyChanged("aanleverkenmerk");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=3)]
        public string eerderAanleverkenmerk {
            get {
                return this.eerderAanleverkenmerkField;
            }
            set {
                this.eerderAanleverkenmerkField = value;
                this.RaisePropertyChanged("eerderAanleverkenmerk");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public identiteitType identiteitBelanghebbende {
            get {
                return this.identiteitBelanghebbendeField;
            }
            set {
                this.identiteitBelanghebbendeField = value;
                this.RaisePropertyChanged("identiteitBelanghebbende");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=5)]
        public string rolBelanghebbende {
            get {
                return this.rolBelanghebbendeField;
            }
            set {
                this.rolBelanghebbendeField = value;
                this.RaisePropertyChanged("rolBelanghebbende");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public identiteitType identiteitOntvanger {
            get {
                return this.identiteitOntvangerField;
            }
            set {
                this.identiteitOntvangerField = value;
                this.RaisePropertyChanged("identiteitOntvanger");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=7)]
        public string rolOntvanger {
            get {
                return this.rolOntvangerField;
            }
            set {
                this.rolOntvangerField = value;
                this.RaisePropertyChanged("rolOntvanger");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public berichtInhoudType berichtInhoud {
            get {
                return this.berichtInhoudField;
            }
            set {
                this.berichtInhoudField = value;
                this.RaisePropertyChanged("berichtInhoud");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=9)]
        [System.Xml.Serialization.XmlArrayItemAttribute("bijlage", IsNullable=false)]
        public berichtInhoudType[] berichtBijlagen {
            get {
                return this.berichtBijlagenField;
            }
            set {
                this.berichtBijlagenField = value;
                this.RaisePropertyChanged("berichtBijlagen");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI", Order=10)]
        public string autorisatieAdres {
            get {
                return this.autorisatieAdresField;
            }
            set {
                this.autorisatieAdresField = value;
                this.RaisePropertyChanged("autorisatieAdres");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2102.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/")]
    public partial class aanleverResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string kenmerkField;
        
        private string berichtsoortField;
        
        private string aanleverkenmerkField;
        
        private string eerderAanleverkenmerkField;
        
        private System.DateTime tijdstempelAangeleverdField;
        
        private identiteitType identiteitBelanghebbendeField;
        
        private string rolBelanghebbendeField;
        
        private identiteitType identiteitOntvangerField;
        
        private string rolOntvangerField;
        
        private string autorisatieAdresField;
        
        private string statuscodeField;
        
        private System.DateTime tijdstempelStatusField;
        
        private bool tijdstempelStatusFieldSpecified;
        
        private string statusomschrijvingField;
        
        private foutType statusFoutcodeField;
        
        private string statusdetailsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=0)]
        public string kenmerk {
            get {
                return this.kenmerkField;
            }
            set {
                this.kenmerkField = value;
                this.RaisePropertyChanged("kenmerk");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=1)]
        public string berichtsoort {
            get {
                return this.berichtsoortField;
            }
            set {
                this.berichtsoortField = value;
                this.RaisePropertyChanged("berichtsoort");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=2)]
        public string aanleverkenmerk {
            get {
                return this.aanleverkenmerkField;
            }
            set {
                this.aanleverkenmerkField = value;
                this.RaisePropertyChanged("aanleverkenmerk");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=3)]
        public string eerderAanleverkenmerk {
            get {
                return this.eerderAanleverkenmerkField;
            }
            set {
                this.eerderAanleverkenmerkField = value;
                this.RaisePropertyChanged("eerderAanleverkenmerk");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public System.DateTime tijdstempelAangeleverd {
            get {
                return this.tijdstempelAangeleverdField;
            }
            set {
                this.tijdstempelAangeleverdField = value;
                this.RaisePropertyChanged("tijdstempelAangeleverd");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public identiteitType identiteitBelanghebbende {
            get {
                return this.identiteitBelanghebbendeField;
            }
            set {
                this.identiteitBelanghebbendeField = value;
                this.RaisePropertyChanged("identiteitBelanghebbende");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=6)]
        public string rolBelanghebbende {
            get {
                return this.rolBelanghebbendeField;
            }
            set {
                this.rolBelanghebbendeField = value;
                this.RaisePropertyChanged("rolBelanghebbende");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public identiteitType identiteitOntvanger {
            get {
                return this.identiteitOntvangerField;
            }
            set {
                this.identiteitOntvangerField = value;
                this.RaisePropertyChanged("identiteitOntvanger");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=8)]
        public string rolOntvanger {
            get {
                return this.rolOntvangerField;
            }
            set {
                this.rolOntvangerField = value;
                this.RaisePropertyChanged("rolOntvanger");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI", Order=9)]
        public string autorisatieAdres {
            get {
                return this.autorisatieAdresField;
            }
            set {
                this.autorisatieAdresField = value;
                this.RaisePropertyChanged("autorisatieAdres");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=10)]
        public string statuscode {
            get {
                return this.statuscodeField;
            }
            set {
                this.statuscodeField = value;
                this.RaisePropertyChanged("statuscode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public System.DateTime tijdstempelStatus {
            get {
                return this.tijdstempelStatusField;
            }
            set {
                this.tijdstempelStatusField = value;
                this.RaisePropertyChanged("tijdstempelStatus");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tijdstempelStatusSpecified {
            get {
                return this.tijdstempelStatusFieldSpecified;
            }
            set {
                this.tijdstempelStatusFieldSpecified = value;
                this.RaisePropertyChanged("tijdstempelStatusSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=12)]
        public string statusomschrijving {
            get {
                return this.statusomschrijvingField;
            }
            set {
                this.statusomschrijvingField = value;
                this.RaisePropertyChanged("statusomschrijving");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public foutType statusFoutcode {
            get {
                return this.statusFoutcodeField;
            }
            set {
                this.statusFoutcodeField = value;
                this.RaisePropertyChanged("statusFoutcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="normalizedString", Order=14)]
        public string statusdetails {
            get {
                return this.statusdetailsField;
            }
            set {
                this.statusdetailsField = value;
                this.RaisePropertyChanged("statusdetails");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class aanleverenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/", Order=0)]
        public LogiusDigipoort.ServiceReferenceAanleveren.aanleverRequest aanleverRequest;
        
        public aanleverenRequest() {
        }
        
        public aanleverenRequest(LogiusDigipoort.ServiceReferenceAanleveren.aanleverRequest aanleverRequest) {
            this.aanleverRequest = aanleverRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class aanleverenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://logius.nl/digipoort/koppelvlakservices/1.2/", Order=0)]
        public LogiusDigipoort.ServiceReferenceAanleveren.aanleverResponse aanleverResponse;
        
        public aanleverenResponse() {
        }
        
        public aanleverenResponse(LogiusDigipoort.ServiceReferenceAanleveren.aanleverResponse aanleverResponse) {
            this.aanleverResponse = aanleverResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AanleverService_V1_2Channel : LogiusDigipoort.ServiceReferenceAanleveren.AanleverService_V1_2, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AanleverService_V1_2Client : System.ServiceModel.ClientBase<LogiusDigipoort.ServiceReferenceAanleveren.AanleverService_V1_2>, LogiusDigipoort.ServiceReferenceAanleveren.AanleverService_V1_2 {
        
        public AanleverService_V1_2Client() {
        }
        
        public AanleverService_V1_2Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AanleverService_V1_2Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AanleverService_V1_2Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AanleverService_V1_2Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LogiusDigipoort.ServiceReferenceAanleveren.aanleverenResponse LogiusDigipoort.ServiceReferenceAanleveren.AanleverService_V1_2.aanleveren(LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest request) {
            return base.Channel.aanleveren(request);
        }
        
        public LogiusDigipoort.ServiceReferenceAanleveren.aanleverResponse aanleveren(LogiusDigipoort.ServiceReferenceAanleveren.aanleverRequest aanleverRequest) {
            LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest inValue = new LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest();
            inValue.aanleverRequest = aanleverRequest;
            LogiusDigipoort.ServiceReferenceAanleveren.aanleverenResponse retVal = ((LogiusDigipoort.ServiceReferenceAanleveren.AanleverService_V1_2)(this)).aanleveren(inValue);
            return retVal.aanleverResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LogiusDigipoort.ServiceReferenceAanleveren.aanleverenResponse> LogiusDigipoort.ServiceReferenceAanleveren.AanleverService_V1_2.aanleverenAsync(LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest request) {
            return base.Channel.aanleverenAsync(request);
        }
        
        public System.Threading.Tasks.Task<LogiusDigipoort.ServiceReferenceAanleveren.aanleverenResponse> aanleverenAsync(LogiusDigipoort.ServiceReferenceAanleveren.aanleverRequest aanleverRequest) {
            LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest inValue = new LogiusDigipoort.ServiceReferenceAanleveren.aanleverenRequest();
            inValue.aanleverRequest = aanleverRequest;
            return ((LogiusDigipoort.ServiceReferenceAanleveren.AanleverService_V1_2)(this)).aanleverenAsync(inValue);
        }
    }
}
