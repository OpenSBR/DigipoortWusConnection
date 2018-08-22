using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
		// Location and password for client certificate
		const string CLIENT_CERTIFICATE = @"Insert filename here";
		const string CLIENT_CERTIFICATE_PASSWORD = "Insert password here";

		// Location of SBR file to submit
		const string SAMPLE_FILE = @"Insert filename here";

		static void Main(string[] args)
		{
			WusConnectionProfile digipoort = new WusConnectionProfile()
			{
				// "Aansluit Suite" test environment server certificate provided - valid until December 2019
				ServerCertificate = new X509Certificate2("cs-bedrijven_procesinfrastructuur_nl.crt"),
				EndpointAanleverService = "https://cs-bedrijven.procesinfrastructuur.nl/cpl/aanleverservice/1.2",
				EndpointStatusInformatieService = "https://cs-bedrijven.procesinfrastructuur.nl/cpl/statusinformatieservice/1.2",
				AuspService = "http://geenausp.nl",
				ConnectionStyle = WusConnectionProfile.WusConnectionStyle.asynchronous
			};
			//WusConnectionProfile biv = new WusConnectionProfile()
			//{
			//	ServerCertificate = new X509Certificate2(""),
			//	EndpointAanleverService = "https://bta-frcportaal.nl/biv-wus20v12/AanleverService",
			//	EndpointStatusInformatieService = "https://bta-frcportaal.nl/biv-wus20v12/StatusInformatieService",
			//	AuspService = "http://localhost:8080/ode/processes/CSPService-OK",
			//	ConnectionStyle = WusConnectionProfile.WusConnectionStyle.synchronous
			//};

			X509Certificate2 clientCertificate = new X509Certificate2(CLIENT_CERTIFICATE, CLIENT_CERTIFICATE_PASSWORD);

			WusClient wusClient = new WusClient(digipoort, clientCertificate);

			Console.WriteLine("Creating request");

			ServiceReferenceAanleveren.identiteitType identity = new ServiceReferenceAanleveren.identiteitType("001000044B39", "BTW");
			aanleverenRequest aanleverRequest = wusClient.CreateAanleverRequest("Happyflow", "Omzetbelasting", identity, "Intermediair", SAMPLE_FILE);

			Console.WriteLine("Sending request");
			Stopwatch timer = new Stopwatch();
			timer.Start();

			aanleverenResponse aanleverResponse = null;
			try
			{
				aanleverResponse = wusClient.Aanleveren(aanleverRequest);
			}
			catch (FaultException<ServiceReferenceAanleveren.foutType> ex)
			{
				Console.WriteLine($"{ex.Detail.foutcode} - {ex.Detail.foutbeschrijving}");
				Console.ReadKey();

				return;
			}

			timer.Stop();

			Console.WriteLine($"Message ID (kenmerk): {aanleverResponse.aanleverResponse.kenmerk}");
			Console.WriteLine($"Time stamp: {aanleverResponse.aanleverResponse.tijdstempelAangeleverd}");
			Console.WriteLine($"Received response in {timer.Elapsed}");
			Console.WriteLine();

			if (wusClient.Profile.ConnectionStyle == WusConnectionProfile.WusConnectionStyle.asynchronous)
			{
				Console.WriteLine("Waiting 8 seconds before retrieving status...");
				Console.WriteLine();

				Thread.Sleep(8000);

				try
				{
					getStatussenProcesResponse1 statusResponse = wusClient.StatusInformatie(aanleverResponse.aanleverResponse.kenmerk);

					if (statusResponse != null)
						foreach (StatusResultaat status in statusResponse.getStatussenProcesResponse.getStatussenProcesReturn)
							Console.WriteLine($"Status: {status.statuscode} - {status.statusomschrijving}");
					else
						Console.WriteLine("Unable to query status");
				}
				catch (FaultException<ServiceReferenceStatusInformatie.foutType> ex)
				{
					Console.WriteLine($"{ex.Detail.foutcode} - {ex.Detail.foutbeschrijving}");
				}
			}

			Console.ReadKey();
		}
	}
}
