using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LogiusDigipoort.ServiceReferenceAanleveren;
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
			Profile = profile;
			ClientCertificate = clientCertificate;
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
			return StatusInformatie(CreateStatusRequest(kenmerk));
		}

		public getStatussenProcesResponse1 StatusInformatie(getStatussenProcesRequest1 request)
		{
			if (Profile.EndpointStatusInformatieService == null)
				return null;

			StatusinformatieService_V1_2 client = WusChannelFactory<StatusinformatieService_V1_2>.CreateServiceClient(Profile.EndpointStatusInformatieService, ClientCertificate, Profile.ServerCertificate);
			getStatussenProcesResponse1 response = client.getStatussenProces(request);

			return response;
		}

		public aanleverenRequest CreateAanleverRequest(string aanleverkenmerk, string berichtsoort, ServiceReferenceAanleveren.identiteitType identiteitBelanghebbende, string rolBelanghebbende, string fileLocation)
		{
			// Create request           
			return new aanleverenRequest(aanleverkenmerk, berichtsoort, identiteitBelanghebbende, rolBelanghebbende, fileLocation, Profile.AuspService);
		}

		public getStatussenProcesRequest1 CreateStatusRequest(string kenmerk)
		{
			getStatussenProcesRequest1 getStatus = new getStatussenProcesRequest1(new getStatussenProcesRequest()
			{
				kenmerk = kenmerk,
				autorisatieAdres = Profile.AuspService
			});

			return getStatus;
		}
	}
}
