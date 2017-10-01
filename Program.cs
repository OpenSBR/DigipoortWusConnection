using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using LogiusDigipoort.ServiceReferenceAanleveren;
using LogiusDigipoort.ServiceReferenceStatusInformatie;

namespace LogiusDigipoort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Location of file to submit
            string filename = @"Insert file name here";

            // Location of certificate files (crt, p12, etc.)
            string serverCertificate = @"Insert file name here";
            string clientCertificate = @"Insert file name here";
            // Password for client certificate
            string clientCertificatePassword = "Insert password here";

            // Create certificates from file
            X509Certificate2 certServer = new X509Certificate2(serverCertificate);
            X509Certificate2 certClient = new X509Certificate2(clientCertificate, clientCertificatePassword);

            // Create submission request
            aanleverenRequest aanleverRequest = CreateAanleverRequest(filename);

            // Communicate with Digipoort
            aanleverenResponse aanleverResponse = ConnectAanleverService(certClient, certServer, aanleverRequest);

            // Write results to screen
            Console.WriteLine($"Message ID (kenmerk): {aanleverResponse.aanleverResponse.kenmerk}");
            Console.WriteLine($"Time stamp: {aanleverResponse.aanleverResponse.tijdstempelAangeleverd}");
            Console.WriteLine();
            Console.WriteLine("Waiting 10 seconds before retrieving status...");
            Console.WriteLine();

            Thread.Sleep(10000);


            // Create status request
            getStatussenProcesRequest1 statusRequest = CreateStatusRequest(aanleverResponse.aanleverResponse.kenmerk);

            // Communicate with Digipoort
            getStatussenProcesResponse1 statusResponse = ConnectStatusInformatieService(certClient, certServer, statusRequest);

            foreach (StatusResultaat status in statusResponse.getStatussenProcesResponse.getStatussenProcesReturn)
            {
                Console.WriteLine($"Status: {status.statuscode} - {status.statusomschrijving}");
            }

            Console.ReadKey();
        }

        static aanleverenRequest CreateAanleverRequest(string fileLocation)
        {
            // Read file as UTF-8 byte array          
            byte[] array = Helper.ReadFileToUtf8Array(fileLocation);

            // File name to submit in message
            string filename = Path.GetFileName(fileLocation);

            // Create request           
            aanleverenRequest request = new aanleverenRequest
            {
                aanleverRequest = new aanleverRequest
                {
                    aanleverkenmerk = "Happyflow",
                    berichtsoort = "Omzetbelasting",
                    identiteitBelanghebbende = new ServiceReferenceAanleveren.identiteitType
                    {
                        nummer = "001000044B39",
                        type = "BTW"
                    },
                    rolBelanghebbende = "Intermediair",
                    berichtInhoud = new berichtInhoudType
                    {
                        bestandsnaam = filename,
                        inhoud = array,
                        mimeType = "application/xml"
                    },
                    autorisatieAdres = "http://geenausp.nl"
                }
            };
            return request;
        }

        static getStatussenProcesRequest1 CreateStatusRequest(string kenmerk)
        {
            var getStatus = new getStatussenProcesRequest1(new getStatussenProcesRequest()
            {
                kenmerk = kenmerk,
                autorisatieAdres = "http://geenausp.nl"
            });

            return getStatus;
        }

        static aanleverenResponse ConnectAanleverService(X509Certificate2 certClient, X509Certificate2 certServer, aanleverenRequest request)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Create binding element for security        
            AsymmetricSecurityBindingElement secBE = (AsymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10);
            secBE.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
            secBE.EnableUnsecuredResponse = true;
            secBE.MessageProtectionOrder = MessageProtectionOrder.EncryptBeforeSign;
            secBE.IncludeTimestamp = true;
            secBE.DefaultAlgorithmSuite = SecurityAlgorithmSuite.TripleDesRsa15;

            //Explicit accept secured answers from endpoint              
            secBE.AllowSerializedSigningTokenOnReply = true;

            //Create binding element for encoding            
            TextMessageEncodingBindingElement textBE = new TextMessageEncodingBindingElement(MessageVersion.Soap11WSAddressing10, Encoding.UTF8);

            //Create binding element for transport        
            HttpsTransportBindingElement httpsBE = new HttpsTransportBindingElement
            {
                RequireClientCertificate = true,
                AuthenticationScheme = AuthenticationSchemes.Anonymous
            };

            CustomBinding cbinding = new CustomBinding(secBE, textBE, httpsBE);

            EndpointAddress address = new EndpointAddress("https://cs-bedrijven.procesinfrastructuur.nl/cpl/aanleverservice/1.2");

            ChannelFactory<AanleverService_V1_2> factory = new ChannelFactory<AanleverService_V1_2>(cbinding, address);

            //Explicit prevent check on chain of trust            
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            factory.Credentials.ClientCertificate.Certificate = certClient;
            factory.Credentials.ServiceCertificate.DefaultCertificate = certServer;

            AanleverService_V1_2 client = factory.CreateChannel();

            aanleverenResponse result = client.aanleveren(request);

            return result;
        }

        static getStatussenProcesResponse1 ConnectStatusInformatieService(X509Certificate2 certClient, X509Certificate2 certService, getStatussenProcesRequest1 statusRequest)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //Create binding element for security        
            AsymmetricSecurityBindingElement secBE = (AsymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10);
            secBE.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
            secBE.EnableUnsecuredResponse = true;
            secBE.MessageProtectionOrder = MessageProtectionOrder.EncryptBeforeSign;
            secBE.IncludeTimestamp = true;
            secBE.DefaultAlgorithmSuite = SecurityAlgorithmSuite.TripleDesRsa15;

            //Explicit accept secured answers from endpoint              
            secBE.AllowSerializedSigningTokenOnReply = true;

            //Create binding element for encoding            
            TextMessageEncodingBindingElement textBE = new TextMessageEncodingBindingElement(MessageVersion.Soap11WSAddressing10, Encoding.UTF8);

            //Create binding element for transport        
            HttpsTransportBindingElement httpsBE = new HttpsTransportBindingElement
            {
                RequireClientCertificate = true,
                AuthenticationScheme = AuthenticationSchemes.Anonymous
            };

            CustomBinding cbinding = new CustomBinding(secBE, textBE, httpsBE);

            EndpointAddress address = new EndpointAddress("https://cs-bedrijven.procesinfrastructuur.nl/cpl/statusinformatieservice/1.2");

            ChannelFactory<StatusinformatieService_V1_2> factory = new ChannelFactory<StatusinformatieService_V1_2>(cbinding, address);

            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            factory.Credentials.ClientCertificate.Certificate = certClient;
            factory.Credentials.ServiceCertificate.DefaultCertificate = certService;

            StatusinformatieService_V1_2 client = factory.CreateChannel();

            getStatussenProcesResponse1 result = client.getStatussenProces(statusRequest);

            return result;
        }
    }
}
