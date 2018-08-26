using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort.ServiceReferenceAanleveren
{
	public partial class aanleverenRequest
	{
		public aanleverenRequest(string aanleverkenmerk, string berichtsoort, identiteitType identiteitBelanghebbende, string rolBelanghebbende, string fileLocation, string autorisatieAdres)
		{
			// Create request           
			aanleverRequest = new aanleverRequest
			{
				aanleverkenmerk = aanleverkenmerk,
				berichtsoort = berichtsoort,
				identiteitBelanghebbende = identiteitBelanghebbende,
				rolBelanghebbende = rolBelanghebbende,
				berichtInhoud = new berichtInhoudType
				{
					// File name to submit in message
					bestandsnaam = Path.GetFileName(fileLocation),
					// Read file as UTF-8 byte array
					inhoud = FileIO.ReadFileToUtf8Array(fileLocation),
					mimeType = MediaTypeNames.Application.Xml
				},
				autorisatieAdres = autorisatieAdres
			};
		}
	}

	public partial class identiteitType
	{
		public identiteitType() { }

		public identiteitType(string nummer, string type)
		{
			this.nummer = nummer;
			this.type = type;
		}

		public override string ToString()
		{
			return $"{type}:{nummer}";
		}
	}
}
