using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Subvertic.DocumentSecurity.PKI.StoreManager;

namespace Subvertic.DocumentSecurity.Examples.Console
{
    class Program
    {


        private static string ComputeDigest(byte[] data)
        {
            var alg = new SHA256Managed();
            var digest = alg.ComputeHash(data);
            return Convert.ToBase64String(digest);
        }




        static void Main(string[] args)
        {


            var sm = new X509StoreManager();
            if (sm.Open(StoreName.My, StoreLocation.CurrentUser))
            {

                var cert = sm.SelectCertificateWithUi(X509FindType.FindByTimeValid, DateTime.Now,
                    "Seleccionar Certificado", "Selecciones el certificado digital que desea utilizar");
                if (cert != null)
                {
                    System.Console.WriteLine("Friendly Name: " + cert.FriendlyName);
                    System.Console.WriteLine("Has Private Key: " + cert.HasPrivateKey);
                    System.Console.WriteLine("Issuer Name: " + cert.IssuerName.Name);
                    System.Console.WriteLine("Serial Number: " + cert.SerialNumber);
                    System.Console.WriteLine("Subject: " + cert.SubjectName.Name);
                    System.Console.WriteLine("Signature Algorithm: " + cert.SignatureAlgorithm.FriendlyName);
                    System.Console.WriteLine("Base64 Encoded Certificate: " +
                                             Convert.ToBase64String(cert.GetRawCertData()));

                } // IF ENDS
                else
                {
                    System.Console.WriteLine("No certificates found matching find criteria");
                }
            } // IF ENDS
            else
            {
                System.Console.WriteLine("Unable to open certificate store");
            }



            System.Console.ReadLine();


        }
    }
}
