using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort.WusChannel
{
	public class WusConnectionProfile
	{
		public enum WusConnectionStyle { asynchronous, synchronous }

		public string EndpointAanleverService { get; set; }

		public string EndpointStatusInformatieService { get; set; }

		public string AuspService { get; set; }

		public X509Certificate2 ServerCertificate { get; set; }

		public WusConnectionStyle ConnectionStyle { get; set; }

		public WusConnectionProfile()
		{
		}
	}
}
