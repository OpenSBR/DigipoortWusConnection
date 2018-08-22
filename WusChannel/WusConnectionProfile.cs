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
		/// <summary>
		/// Defines communication style of WUS server
		/// </summary>
		public enum WusConnectionStyle
		{
			/// <summary>
			/// Messages will always be accepted, and processed later on. A status information call is always required.
			/// </summary>
			asynchronous,
			/// <summary>
			/// Messages will be validated directly, and any error messages will be returned instantly.
			/// </summary>
			synchronous
		}

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
