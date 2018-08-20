using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort.WusChannel
{
	public static class WusHelpers
	{
		public static AsymmetricSecurityBindingElement CreateWusSecurityBindingElement()
		{
			//Create binding element for security        
			AsymmetricSecurityBindingElement secBE = (AsymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement(MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10);
			//secBE.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
			secBE.EnableUnsecuredResponse = true;
			secBE.MessageProtectionOrder = MessageProtectionOrder.EncryptBeforeSign;
			secBE.IncludeTimestamp = true;
			secBE.DefaultAlgorithmSuite = SecurityAlgorithmSuite.TripleDesRsa15;

			//Explicit accept secured answers from endpoint              
			secBE.AllowSerializedSigningTokenOnReply = true;

			return secBE;
		}
	}
}
