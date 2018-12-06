using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TaxAuditCommunity.Data;
using TaxAuditCommunity.Domain.procNFe;
using TaxAuditCommunity.Factory.Repository;
using TaxAuditCommunity.Factory.Store;
using ConsoleApp1.ServiceReferenceNFe;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using System.Xml.Serialization;
using TaxAuditCommunity.Domain.SchemaNFe.v4;
using System.Threading;
using TaxAuditCommunity.Factory.Prosoft;

namespace ConsoleApp1
{
    class Program
    {
        private static string conn;
        private static string hostPath;
        private static string arquivoXml;
        static void Main(string[] args)
        {


            //consultaSituacao();

            //NewMethod();

            //conn = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings["TaxAuditCommunity"].ConnectionString;
            //hostPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["Path"].Value;
            //TaxAuditCommunity.Factory.FileWatcher.Watcher watcher =
            //    new TaxAuditCommunity.Factory.FileWatcher.Watcher(hostPath, conn);

            //ThreadStart startWatcher = new ThreadStart(watcher.FileWatcher);
            //Thread threadWatcher = new Thread(startWatcher);
            //threadWatcher.Start();

            //ThreadStart Begining = new ThreadStart(watcher.Beging);
            //Thread threadBeginig = new Thread(Begining);

            //while (true)
            //{




            //    //threadBeginig.Start();

            //    //watcher.Beging();


            //}

            var conn = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                .ConnectionStrings.ConnectionStrings["TaxAuditCommunity"].ConnectionString;
            var connProsoft = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
                .ConnectionStrings.ConnectionStrings["Pervasive"].ConnectionString;
            using (var db = new NFeDbContext(conn))
            {
                IStoreEmpresas store = new StoreEmpresas(db);
                var teste = store.Syncronization(connProsoft, default(CancellationToken)).Result;
            }
        }

        private static void consultaSituacao()
        {
            XmlDocument document = new XmlDocument();
            FileInfo xml = new FileInfo(@"T:\2018\2018-10\35180900152891000100550010000001591000208700.xml");
            document.Load(xml.FullName);
            NFe NFe = new NFe();

            var node = document.GetElementsByTagName("NFe")[0];
            NFe.XmlNFe = new XmlNFe
            {
                DhChange = xml.LastWriteTimeUtc,
                XmlDocument = XElement.Parse(document.InnerXml)
            };
            NFe.SetProperties(node);

            TConsSitNFe consSitNFe = new TConsSitNFe();
            consSitNFe.chNFe = NFe.Id;
            consSitNFe.tpAmb = (TAmb)NFe.infNFe.ide.tpAmb;
            consSitNFe.versao = (TVerConsSitNFe)Enum.Parse(typeof(TVerConsSitNFe), string.Concat("Item", NFe.infNFe.versao.Replace(".", "")));
            consSitNFe.xServ = TConsSitNFeXServ.CONSULTAR;

            XmlSerializer xs = new XmlSerializer(typeof(TConsSitNFe));
            StringWriter stringWriter = new StringWriter();
            xs.Serialize(stringWriter, consSitNFe);

            XmlDocument consSit = new XmlDocument();
            consSit.LoadXml(stringWriter.ToString());

            XmlNode nodeConsSit = consSit.GetElementsByTagName("consSitNFe")[0];

            if (nodeConsSit != null)
            {
                X509Certificate2Collection certificates = new X509Certificate2Collection();
                DirectoryInfo directoryCert = new DirectoryInfo(@"G:\Sieg\Certificados");
                var certificados = directoryCert.GetFiles("x.pfx", SearchOption.AllDirectories).ToList();
                foreach(var fileCert in certificados)
                {
//                    certificates.Import()
                }
                certificates.Import(@"G:\Sieg\Certificados\0002-MOREIRA     moreira.pfx", "moreira", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
                foreach(var key in certificates)
                {
                    if (key.HasPrivateKey)
                        VerificarCnpj(key);
                }

                //NFeConsultaProtocolo4Soap12Client nFeConsultaProtocolo = new NFeConsultaProtocolo4Soap12Client();
                //nFeConsultaProtocolo.ClientCredentials.ClientCertificate.Certificate = cert;
                //var retorno = nFeConsultaProtocolo.nfeConsultaNF(nodeConsSit);

                //NFe.XmlNFe.retConsSitNFe = new TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.retConsSitNFe();
                //NFe.XmlNFe.retConsSitNFe.SetProperties(retorno);

                //XmlSerializer RetConsSitxs = new XmlSerializer(typeof(TRetConsSitNFe));
                //MemoryStream ms = new MemoryStream();



            }
        }

        public static string VerificarCnpj(X509Certificate2 certificado)
        {
            string cnpj = string.Empty;
            foreach (X509Extension extension in certificado.Extensions)
            {
                string s1 = extension.Format(true);
                string[] lines = s1.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!lines[i].Trim().StartsWith("2.16.76.1.3.3")) continue;
                    string value = lines[i].Substring(lines[i].IndexOf('=') + 1);
                    string[] elements = value.Split(' ');
                    byte[] cnpjBytes = new byte[14];
                    for (int j = 0; j < cnpjBytes.Length; j++)
                        cnpjBytes[j] = Convert.ToByte(elements[j + 2], 16);
                    cnpj = Encoding.UTF8.GetString(cnpjBytes);
                    break;
                }
                if (!string.IsNullOrEmpty(cnpj)) break;
            }
            return cnpj;
        }

        private static void TesteServicoNFe()
        {
            X509Certificate2Collection certificates = new X509Certificate2Collection();
            certificates.Import(@"T:\certificados\BISPO ALIMENTOS.pfx", "12345678", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
            X509Certificate2 cert = certificates[0];

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, @"D:\OneDrive\Vscode\NFe schemas\PL_009_V4_2016_002_v160b\consSitNFe_v4.00.xsd");
            XmlDocument xml = new XmlDocument();
            using (XmlReader reader = XmlReader.Create(@"D:\35180855323216000260550010005239311311651503consSitNFe.xml", settings))
            {
                try
                {
                    xml.Load(reader);
                }
                catch (XmlException e)
                {

                }
            }

            //xml.Load(@"D:\35180902684965000257550000000826831003356225consSitNFe.xml");

            var node = xml.ChildNodes[0];
            try
            {
                object obj = null;
                //NFeConsultaProtocolo4Soap12Client nFeConsultaProtocolo = new NFeConsultaProtocolo4Soap12Client();
                //nFeConsultaProtocolo.ClientCredentials.ClientCertificate.Certificate = cert;
                //var retorno = nFeConsultaProtocolo.nfeConsultaNF(node);


                XmlSerializer xs = new XmlSerializer(typeof(TRetConsSitNFe));
                MemoryStream ms = new MemoryStream();
                XmlDocument document = new XmlDocument();
                document.Load(@"D:\teste.xml");
                document.Save(ms);

                byte[] vs = Encoding.Default.GetBytes(document.OuterXml);
                using (MemoryStream memoryStream = new MemoryStream(vs))
                {
                    obj = xs.Deserialize(memoryStream);
                }

                obj = xs.Deserialize(ms);

            }
            catch (MessageSecurityException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void NewMethod()
        {
            conn = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings["TaxAuditCommunity"].ConnectionString;
            hostPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["Path"].Value;
            try
            {
                DateTime lastsaveed = new DateTime();
                Task.Run(async () =>
                {
                    using (var db = new NFeDbContext(conn))
                    {
                        INFeStore<NFe, NFeResult> store = new NFeStore<NFe, NFeDbContext>(db);

                        NFeManager manager = new NFeManager(store);

                        lastsaveed = await manager.LastSaveed();
                    }
                }).Wait();

                DirectoryInfo directory = new DirectoryInfo(hostPath);

                var files = directory.GetFiles("*.xml", SearchOption.AllDirectories)
                                        .Where(d => d.CreationTimeUtc >= lastsaveed)
                                        .OrderBy(d => d.CreationTimeUtc);

                if (files.Count() > 0)
                {
                    int i = 0;
                    foreach (var xml in files)
                    {
                        arquivoXml = xml.FullName;
                        XmlDocument document = new XmlDocument();
                        try
                        {
                            i++;
                            document.Load(xml.FullName);

                            if (document.DocumentElement.Name == "nfeProc")
                            {
                                NFe NFe = new NFe();

                                var node = document.GetElementsByTagName("NFe")[0];
                                NFe.XmlNFe = new XmlNFe
                                {
                                    DhChange = xml.LastWriteTimeUtc,
                                    XmlDocument = XElement.Parse(document.InnerXml)
                                };
                                NFe.SetProperties(node);

                                using (var db = new NFeDbContext(conn))
                                {
                                    INFeStore<NFe, NFeResult> store = new NFeStore<NFe, NFeDbContext>(db);

                                    NFeManager manager = new NFeManager(store);
                                    var result = manager.GravarNFe(NFe).Result;

                                    if (result.Succeeded)
                                    {
                                        Console.WriteLine($"Index: {i} - O arquivo {xml.Name} foi gravado com sucesso.");
                                    }
                                    else
                                    {
                                        switch (result.NFeResultException)
                                        {
                                            case NFeResultException.DbUpdateConcurrencyException:
                                                {
                                                    Console.WriteLine($"Index: {i} - Erro: {xml.Name} - {result.DbUpdateConcurrencyException.ToString()}");
                                                }
                                                break;
                                            case NFeResultException.DbUpdateException:
                                                {
                                                    if(result.DbUpdateException.InnerException.ToString().Contains("truncated."))
                                                    {
                                                        Console.WriteLine(result.DbUpdateException.Entries[0].Entity.ToString());
                                                    }
                                                    Console.WriteLine($"Index: {i} - Erro: {xml.Name} - {result.DbUpdateException.InnerException.ToString()}");
                                                }
                                                break;
                                            case NFeResultException.Exception:
                                                {
                                                    Console.WriteLine($"Index: {i} - Erro: {xml.Name} - {result.Exception.ToString()}");
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Index: {i} - O arquivo xml {xml.Name} na pasta {xml.FullName.Replace(xml.Name, "")} " +
                                                  $"não é um arquivo de NFe valido ou o arquivo não foi transmitido para a SEFAZ." +
                                                  $"A Tag nfeProc não foi localizada.\n O arquivo não será gravado");
                            }
                        }
                        catch (XmlException e)
                        {
                            Console.WriteLine($"Erro: {xml.Name} - {e.ToString()}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.InnerException == null ? $"Index: {i} - Arquivo: {arquivoXml}\n {e.ToString()}" : $"Arquivo: {arquivoXml}\n{e.InnerException.ToString()}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException == null ? $"Arquivo: {arquivoXml}\n {e.ToString()}" : $"Arquivo: {arquivoXml}\n{e.InnerException.ToString()}");
            }
        }
    }
}
