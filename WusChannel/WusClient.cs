using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LogiusDigipoort.ServiceReferenceAanleveren;
using LogiusDigipoort.ServiceReferenceOphalen;
using LogiusDigipoort.ServiceReferenceStatusInformatie;

namespace LogiusDigipoort.WusChannel
{
	public class WusClient
	{
		public WusConnectionProfile Profile { get; private set; }

		X509Certificate2 ClientCertificate { get; set; }

		//public event EventHandler StatusUpdate;
		//public event EventHandler OnError;

		public WusClient(WusConnectionProfile profile, X509Certificate2 clientCertificate)
		{
			if (profile?.EndpointStatusInformatieService == null)
				throw new ArgumentOutOfRangeException("profile", "Profile or profile endpoint cannot be null");

			Profile = profile;
			ClientCertificate = clientCertificate;
		}

		public getBerichtenLijstResponse1 OphalenBerichtenLijst(getBerichtenLijstRequest1 request)
		{
			OphaalService_V1_2 client = WusChannelFactory<OphaalService_V1_2>.CreateServiceClient(Profile.EndpointOphaalService, ClientCertificate, Profile.ServerCertificate);
			getBerichtenLijstResponse1 response = client.getBerichtenLijst(request);

			return response;
		}

		public getBerichtenKenmerkResponse1 OphalenBericht(getBerichtenKenmerkRequest1 request)
		{
			OphaalService_V1_2 client = WusChannelFactory<OphaalService_V1_2>.CreateServiceClient(Profile.EndpointOphaalService, ClientCertificate, Profile.ServerCertificate);
			getBerichtenKenmerkResponse1 response = client.getBerichtenKenmerk(request);

			return response;
		}

		public getBerichtenLijstRequest1 CreateBerichtenLijstRequest(string berichtsoort, DateTime tijdstempelVanaf, DateTime tijdstempelTot)
		{
			return new getBerichtenLijstRequest1(berichtsoort, tijdstempelVanaf, tijdstempelTot, Profile.AuspService);
		}

		public getBerichtenKenmerkRequest1 CreateBerichtenKenmerkRequest(string kenmerk)
		{
			return new getBerichtenKenmerkRequest1(kenmerk, Profile.AuspService);
		}

		public aanleverenResponse Aanleveren(aanleverenRequest request)
		{
			AanleverService_V1_2 client = WusChannelFactory<AanleverService_V1_2>.CreateServiceClient(Profile.EndpointAanleverService, ClientCertificate, Profile.ServerCertificate);
			aanleverenResponse response = client.aanleveren(request);

			return response;
		}

		public async Task<aanleverenResponse> AanleverenAsync(aanleverenRequest request)
		{
			AanleverService_V1_2 client = WusChannelFactory<AanleverService_V1_2>.CreateServiceClient(Profile.EndpointAanleverService, ClientCertificate, Profile.ServerCertificate);
			aanleverenResponse response = await client.aanleverenAsync(request);

			return response;
		}

		public getStatussenProcesResponse1 StatusInformatie(string kenmerk)
		{
			return StatusInformatie(new getStatussenProcesRequest1(kenmerk, Profile.AuspService));
		}

		public getStatussenProcesResponse1 StatusInformatie(getStatussenProcesRequest1 request)
		{
			StatusinformatieService_V1_2 client = WusChannelFactory<StatusinformatieService_V1_2>.CreateServiceClient(Profile.EndpointStatusInformatieService, ClientCertificate, Profile.ServerCertificate);
			getStatussenProcesResponse1 response = client.getStatussenProces(request);

			return response;
		}

		public async Task<getStatussenProcesResponse1> StatusInformatieAsync(getStatussenProcesRequest1 request)
		{
			StatusinformatieService_V1_2 client = WusChannelFactory<StatusinformatieService_V1_2>.CreateServiceClient(Profile.EndpointStatusInformatieService, ClientCertificate, Profile.ServerCertificate);
			getStatussenProcesResponse1 response = await client.getStatussenProcesAsync(request);

			return response;
		}

		public aanleverenRequest CreateAanleverRequest(string aanleverkenmerk, string berichtsoort, ServiceReferenceAanleveren.identiteitType identiteitBelanghebbende, string rolBelanghebbende, string fileLocation)
		{
			// Create request           
			return new aanleverenRequest(aanleverkenmerk, berichtsoort, identiteitBelanghebbende, rolBelanghebbende, fileLocation, Profile.AuspService);
		}

		// Not relevant for regular WUS clients
		//public afleverenResponse Afleveren(afleverenRequest request)
		//{
		//	AfleverService_V1_2 client = WusChannelFactory<AfleverService_V1_2>.CreateServiceClient(Profile.EndpointAfleverService, ClientCertificate, Profile.ServerCertificate);
		//	afleverenResponse response = client.afleveren(request);

		//	return response;
		//}

		//public async Task<afleverenResponse> AfleverenAsync(afleverenRequest request)
		//{
		//	AfleverService_V1_2 client = WusChannelFactory<AfleverService_V1_2>.CreateServiceClient(Profile.EndpointAfleverService, ClientCertificate, Profile.ServerCertificate);
		//	afleverenResponse response = await client.afleverenAsync(request);

		//	return response;
		//}
	}
}
