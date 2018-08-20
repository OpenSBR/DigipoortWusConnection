using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort.WusChannel
{
	public class WusCustomBinding : CustomBinding
	{
		public WusCustomBinding() :
			base(
				//Create binding element for security
				WusHelpers.CreateWusSecurityBindingElement(),

				//Create binding element for encoding            
				new TextMessageEncodingBindingElement(MessageVersion.Soap11WSAddressing10, Encoding.UTF8),

				//Create binding element for transport        
				new HttpsTransportBindingElement()
				{
					RequireClientCertificate = true,
					AuthenticationScheme = AuthenticationSchemes.Anonymous
				}
			)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		}
	}
}
