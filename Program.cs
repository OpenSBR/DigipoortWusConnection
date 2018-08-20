using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading;
using LogiusDigipoort.ServiceReferenceAanleveren;
using LogiusDigipoort.ServiceReferenceStatusInformatie;
using LogiusDigipoort.WusChannel;

namespace LogiusDigipoort
{
	class Program
	{
		// Digipoort services "Aansluit Suite" test environment
		const string ENDPOINT_AANLEVER = "https://cs-bedrijven.procesinfrastructuur.nl/cpl/aanleverservice/1.2";
		const string ENDPOINT_STATUSINFORMATIE = "https://cs-bedrijven.procesinfrastructuur.nl/cpl/statusinformatieservice/1.2";

		// Location of server certificate file (crt, p12, etc.)
		// "Aansluit SUite" test environment server certificate provided - valid until December 2019
		const string SERVER_CERTIFICATE = @"cs-bedrijven_procesinfrastructuur_nl.crt";

		// Location and password for client certificate
		const string CLIENT_CERTIFICATE = @"Insert filename here";
		const string CLIENT_CERTIFICATE_PASSWORD = "Insert password here";

		// Location of SBR file to submit
		const string SAMPLE_FILE = @"Insert filename here";

		const string AUSP = "http://geenausp.nl";

		static void Main(string[] args)
		{
			// Create certificates from file
			X509Certificate2 certServer = new X509Certificate2(SERVER_CERTIFICATE);
			X509Certificate2 certClient = new X509Certificate2(CLIENT_CERTIFICATE, CLIENT_CERTIFICATE_PASSWORD);

			// Create submission request
			aanleverenRequest aanleverRequest = CreateAanleverRequest(SAMPLE_FILE);

			// Communicate with Digipoort
			aanleverenResponse aanleverResponse = ConnectAanleverService(certClient, certServer, aanleverRequest);

			// Write results to screen
			Console.WriteLine($"Message ID (kenmerk): {aanleverResponse.aanleverResponse.kenmerk}");
			Console.WriteLine($"Time stamp: {aanleverResponse.aanleverResponse.tijdstempelAangeleverd}");
			Console.WriteLine();
			Console.WriteLine("Waiting 10 seconds before retrieving status...");
			Console.WriteLine();

			Thread.Sleep(10000);


			// Create status request
			getStatussenProcesRequest1 statusRequest = CreateStatusRequest(aanleverResponse.aanleverResponse.kenmerk);

			// Communicate with Digipoort
			getStatussenProcesResponse1 statusResponse = ConnectStatusInformatieService(certClient, certServer, statusRequest);

			foreach (StatusResultaat status in statusResponse.getStatussenProcesResponse.getStatussenProcesReturn)
			{
				Console.WriteLine($"Status: {status.statuscode} - {status.statusomschrijving}");
			}

			Console.ReadKey();
		}

		static aanleverenRequest CreateAanleverRequest(string fileLocation)
		{
			// Read file as UTF-8 byte array
			byte[] array = FileIO.ReadFileToUtf8Array(fileLocation);

			// File name to submit in message
			string filename = Path.GetFileName(fileLocation);

			// Create request           
			aanleverenRequest request = new aanleverenRequest
			{
				aanleverRequest = new aanleverRequest
				{
					aanleverkenmerk = "Happyflow",
					berichtsoort = "Omzetbelasting",
					identiteitBelanghebbende = new ServiceReferenceAanleveren.identiteitType
					{
						nummer = "001000044B39",
						type = "BTW"
					},
					rolBelanghebbende = "Intermediair",
					berichtInhoud = new berichtInhoudType
					{
						bestandsnaam = filename,
						inhoud = array,
						mimeType = MediaTypeNames.Application.Xml
					},
					autorisatieAdres = AUSP
				}
			};
			return request;
		}

		static getStatussenProcesRequest1 CreateStatusRequest(string kenmerk)
		{
			getStatussenProcesRequest1 getStatus = new getStatussenProcesRequest1(new getStatussenProcesRequest()
			{
				kenmerk = kenmerk,
				autorisatieAdres = AUSP
			});

			return getStatus;
		}

		static aanleverenResponse ConnectAanleverService(X509Certificate2 certClient, X509Certificate2 certServer, aanleverenRequest request)
		{
			EndpointAddress address = new EndpointAddress(ENDPOINT_AANLEVER);

			WusChannelFactory<AanleverService_V1_2> factory = new WusChannelFactory<AanleverService_V1_2>(address, certClient, certServer);
			AanleverService_V1_2 client = factory.CreateChannel();

			aanleverenResponse result = client.aanleveren(request);

			return result;
		}


		static getStatussenProcesResponse1 ConnectStatusInformatieService(X509Certificate2 certClient, X509Certificate2 certServer, getStatussenProcesRequest1 statusRequest)
		{
			EndpointAddress address = new EndpointAddress(ENDPOINT_STATUSINFORMATIE);

			WusChannelFactory<StatusinformatieService_V1_2> factory = new WusChannelFactory<StatusinformatieService_V1_2>(address, certClient, certServer);
			StatusinformatieService_V1_2 client = factory.CreateChannel();

			getStatussenProcesResponse1 result = client.getStatussenProces(statusRequest);

			return result;
		}
	}
}
