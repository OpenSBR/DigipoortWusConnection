using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
			//Explicit prevent check on chain of trust            
			Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
			Credentials.ClientCertificate.Certificate = certClient;
			Credentials.ServiceCertificate.DefaultCertificate = certServer;
		}

	}
}
