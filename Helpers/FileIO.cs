using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort
{
	public static class FileIO
	{
		public static byte[] ReadFileToUtf8Array(string fileLocation)
		{
			// The input String
			string value = File.ReadAllText(fileLocation);

			// Convert String to Byte array          
			byte[] array = Encoding.UTF8.GetBytes(value);

			return array;
		}

		public static byte[] GetEmbeddedFile(string path)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();

			using (Stream stream = assembly.GetManifestResourceStream(path))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string result = reader.ReadToEnd();
					return Encoding.UTF8.GetBytes(result);
				}
			}
		}
	}
}
