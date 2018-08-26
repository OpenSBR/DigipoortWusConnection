using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort.ServiceReferenceOphalen
{
	partial class getBerichtenLijstRequest1
	{
		public getBerichtenLijstRequest1(string berichtsoort, DateTime tijdstempelVanaf, DateTime tijdstempelTot, string autorisatieAdres)
		{
			this.getBerichtenLijstRequest = new getBerichtenLijstRequest(berichtsoort, tijdstempelVanaf, tijdstempelTot, autorisatieAdres);
		}
	}
	partial class getBerichtenLijstRequest
	{
		public getBerichtenLijstRequest() { }

		public getBerichtenLijstRequest(string berichtsoort, DateTime tijdstempelVanaf, DateTime tijdstempelTot, string autorisatieAdres)
		{
			this.autorisatieAdres = autorisatieAdres;
			this.berichtsoort = berichtsoort;
			this.tijdstempelVanaf = tijdstempelVanaf;
			this.tijdstempelTot = tijdstempelTot;
			//this.tijdstempelVanaf = DateTime.Now.Subtract(new TimeSpan(365, 0, 0, 0));
			this.tijdstempelVanafSpecified = true;
		}
	}

	partial class getBerichtenKenmerkRequest1
	{
		public getBerichtenKenmerkRequest1(string kenmerk, string autorisatieAdres)
		{
			this.getBerichtenKenmerkRequest = new getBerichtenKenmerkRequest(kenmerk, autorisatieAdres);
		}
	}

	partial class getBerichtenKenmerkRequest
	{
		public getBerichtenKenmerkRequest()
		{
		}

		public getBerichtenKenmerkRequest(string kenmerk, string autorisatieAdres)
		{
			this.autorisatieAdres = autorisatieAdres;
			this.kenmerk = kenmerk;
		}
	}

	partial class getNieuweBerichtenLijstRequest
	{
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
