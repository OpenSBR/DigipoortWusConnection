using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort.WusChannel
{
	public class WusChannelFactory<T> : ChannelFactory<T>
	{
		public WusChannelFactory(EndpointAddress remoteAddress, X509Certificate2 certClient, X509Certificate2 certServer)
			: base(new WusCustomBinding(), remoteAddress)
		{
			Endpoint.Contract.ProtectionLevel = ProtectionLevel.Sign;

			//Explicit prevent check on chain of trust            
			Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
			Credentials.ClientCertificate.Certificate = certClient;
			Credentials.ServiceCertificate.DefaultCertificate = certServer;
		}

		public static T CreateServiceClient(string address, X509Certificate2 certClient, X509Certificate2 certServer)
		{
			return CreateServiceClient(new EndpointAddress(address), certClient, certServer);
		}

		public static T CreateServiceClient(EndpointAddress address, X509Certificate2 certClient, X509Certificate2 certServer)
		{
			WusChannelFactory<T> factory = new WusChannelFactory<T>(address, certClient, certServer);
			return factory.CreateChannel();
		}
	}
}
