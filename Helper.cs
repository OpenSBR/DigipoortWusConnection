using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiusDigipoort
{
    public class Helper
    {
        public static byte[] ReadFileToUtf8Array(string fileLocation)
        {
            // The input String
            string value = File.ReadAllText(fileLocation);

            // Convert String to Byte array          
            byte[] array = Encoding.UTF8.GetBytes(value);

            return array;
        }
    }
}
