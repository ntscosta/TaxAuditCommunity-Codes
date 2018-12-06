using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_CAC
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
            //Login().ConfigureAwait(false).GetAwaiter().GetResult();
            //RequestEcac().ConfigureAwait(false).GetAwaiter().GetResult();
            Teste();
        }
        async static Task MainAsync(string[] args)
        {
            HttpClient client = new HttpClient();
            WebClient webClient = new WebClient();
            var response = await client.GetAsync(@"https://cav.receita.fazenda.gov.br:443");
            var pageContents = await response.Content.ReadAsStringAsync();
            Console.WriteLine(pageContents);
            Console.ReadLine();
        }
        //https://cav.receita.fazenda.gov.br/autenticacao/Login/Certificado?id=-1
        static string host = @"https://cav.receita.fazenda.gov.br/ecac/";
        static string certName = @"D:\LUIS ANTONIO MARTINS12180163886.pfx";
        static string password = @"luis0770";

        async static Task RequestEcac()
        {

            //X509Certificate2 oCertificado;
            //var oX509Cert = new X509Certificate2();
            //var store = new X509Store("MY", StoreLocation.CurrentUser);
            //store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            //var collection = store.Certificates;

            //var collection2 = collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);

            //oX509Cert = collection2[6];
            //oCertificado = oX509Cert;
            //request.ClientCertificates.Add(oCertificado);

            X509Certificate2Collection certificates = new X509Certificate2Collection();
            certificates.Import(certName, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);

            
            request.ClientCertificates = certificates;


            request.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
            
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | 
                                                   SecurityProtocolType.Tls11 | 
                                                   SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.CheckCertificateRevocationList = true;

            WinHttpHandler winHttpHandler = new WinHttpHandler();
            winHttpHandler.ClientCertificates.Add(certificates[3]);
            winHttpHandler.PreAuthenticate = true;

            try
            {
                var client = new HttpClient(winHttpHandler)
                {
                    BaseAddress = new Uri(host)
                };



                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
                request.Referer = "https://cav.receita.fazenda.gov.br/autenticacao/login";
                //request.Connection = "Keep-Alive";
                //var response = (HttpWebResponse)(await request.GetResponseAsync());
                var response = await client.GetAsync(host);
                var result = await response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {

            }
        }


        // The following method is invoked by the RemoteCertificateValidationDelegate.
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }


        async static Task Teste()
        {
            X509Certificate2Collection certificates = new X509Certificate2Collection();
            certificates.Import(certName, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);

            using (var cert2 = new X509Certificate2(certificates[3]))
            {
                var _clientHandler = new HttpClientHandler();
                _clientHandler.ClientCertificates.Add(cert2);
                _clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
                var myModel = new Dictionary<string, string>
                {
                    { "property1","value" },
                    { "property2","value" },
                };
                using (var content = new FormUrlEncodedContent(myModel))
                using (var _client = new HttpClient(_clientHandler))
                using (HttpResponseMessage response = _client.PostAsync(host, content).Result)
                {
                    response.EnsureSuccessStatusCode();
                    string jsonString = response.Content.ReadAsStringAsync().Result;
                    var json = new Newtonsoft.Json.JsonSerializer();
                    //var myClass = JsonConvert.DeserializeObject<MyClass>(json);
                }
            }
        }

    }

    class MyClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);

            X509Certificate2 oCertificado;
            var oX509Cert = new X509Certificate2();
            var store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var collection = store.Certificates;

            var collection2 = collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);

            oX509Cert = collection2[6];
            oCertificado = oX509Cert;
            var cert = oCertificado;

            (request as HttpWebRequest).ClientCertificates.Add(cert);

            return request;
        }
    }
}
