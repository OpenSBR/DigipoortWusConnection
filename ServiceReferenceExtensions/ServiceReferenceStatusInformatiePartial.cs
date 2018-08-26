using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort.ServiceReferenceStatusInformatie
{
	public partial class getStatussenProcesRequest1
	{
		public getStatussenProcesRequest1(string kenmerk, string autorisatieAdres)
		{
			this.getStatussenProcesRequest = new getStatussenProcesRequest(kenmerk, autorisatieAdres);
		}
	}

	public partial class getStatussenProcesRequest
	{
		public getStatussenProcesRequest() { }

		public getStatussenProcesRequest(string kenmerk, string autorisatieAdres)
		{
			this.kenmerk = kenmerk;
			this.autorisatieAdres = autorisatieAdres;
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
