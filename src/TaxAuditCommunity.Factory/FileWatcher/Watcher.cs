using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Xml.Linq;
using TaxAuditCommunity.Data;
using TaxAuditCommunity.Domain.procNFe;
using TaxAuditCommunity.Factory.Repository;
using TaxAuditCommunity.Factory.Store;
using TaxAuditCommunity.Factory.Prosoft;
using System.Threading;

namespace TaxAuditCommunity.Factory.FileWatcher
{
    public class Watcher
    {
        protected internal EventLog eventLog1;
        protected internal string hostPath;
        protected internal string hostPathProsoft;
        protected internal string conn;
        protected internal string connProsoft;
        protected internal FileSystemWatcher watcher;
        protected internal FileSystemWatcher watcherProsoft;
        public Watcher(string _hostPath, string _hostPathProsoft, string _conn, string _connProsoft, EventLog _eventLog1 = null)
        {
            eventLog1 = _eventLog1;
            hostPath = _hostPath;
            hostPathProsoft = _hostPathProsoft;
            conn = _conn;
            connProsoft = _connProsoft;
        }
        public void Beging()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(hostPath);

                List<FileInfo> files = directory.GetFiles("*.xml", SearchOption.AllDirectories).ToList();

                if (files.Count() > 0)
                {
                    int i = 0;
                    foreach (var xml in files.OrderByDescending(x => x.CreationTimeUtc))
                    {
                        var arquivoXml = xml.FullName;
                        XmlDocument document = new XmlDocument();
                        try
                        {
                            i++;
                            document.Load(xml.FullName);

                            if (document.DocumentElement.Name == "nfeProc")
                            {
                                NFe NFe = new NFe();
                                NFe.Hash = xml.CreateHash();
                                var node = document.GetElementsByTagName("NFe")[0];
                                NFe.XmlNFe = new XmlNFe
                                {
                                    DhChange = xml.CreationTimeUtc,
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
                                        eventLog1.WriteEntry($"O arquivo {xml.Name} foi gravado com sucesso.", EventLogEntryType.SuccessAudit);
                                    }
                                    else
                                    {
                                        switch (result.NFeResultException)
                                        {
                                            case NFeResultException.DbUpdateConcurrencyException:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                             $"{result.DbUpdateConcurrencyException.ToString()}",
                                                                             EventLogEntryType.Error, 1);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.DbUpdateConcurrencyException.ToString()}");
                                                    }
                                                }
                                                break;
                                            case NFeResultException.DbUpdateException:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        if (result.ErrorNumber != 2627)
                                                            eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                                 $"{result.DbUpdateException.InnerException.ToString()}",
                                                                                 EventLogEntryType.Error, result.ErrorNumber);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.DbUpdateException.InnerException.ToString()}");
                                                    }
                                                }
                                                break;
                                            case NFeResultException.Exception:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                             $"{result.Exception.ToString()}",
                                                                             EventLogEntryType.Error, 0);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.Exception.ToString()}");
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (eventLog1 != null)
                                {
                                    eventLog1.WriteEntry($"O arquivo xml {xml.Name} na pasta {xml.FullName.Replace(xml.Name, "")} " +
                                                         $"não é um arquivo de NFe valido ou o arquivo não foi transmitido para a SEFAZ." +
                                                         $"A Tag nfeProc não foi localizada.\n O arquivo não será gravado", EventLogEntryType.Error, 5);
                                }
                                else
                                {
                                    Console.WriteLine($"O arquivo xml {xml.Name} na pasta {xml.FullName.Replace(xml.Name, "")} " +
                                                      $"não é um arquivo de NFe valido ou o arquivo não foi transmitido para a SEFAZ." +
                                                      $"A Tag nfeProc não foi localizada.\n O arquivo não será gravado");
                                }
                            }
                        }
                        catch (XmlException err)
                        {
                            if (eventLog1 != null)
                            {
                                eventLog1.WriteEntry(err.InnerException == null ?
                                                     $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                     $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}",
                                                     EventLogEntryType.Error, 6);
                            }
                            else
                            {
                                Console.WriteLine(err.InnerException == null ?
                                                  $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                  $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}");
                            }
                        }
                        catch (Exception err)
                        {
                            if (eventLog1 != null)
                            {
                                eventLog1.WriteEntry(err.InnerException == null ?
                                                     $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                     $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}",
                                                     EventLogEntryType.Error, 7);
                            }
                            else
                            {
                                Console.WriteLine(err.InnerException == null ?
                                                  $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                  $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (eventLog1 != null)
                {
                    eventLog1.WriteEntry(e.InnerException == null ? e.ToString() : e.InnerException.ToString(), EventLogEntryType.Error, 8);
                }
                else
                {
                    Console.WriteLine(e.InnerException == null ? e.ToString() : e.InnerException.ToString());
                }
            }
            finally
            {
                if (eventLog1 != null)
                {
                    eventLog1.WriteEntry("Concluido a verificação completa", EventLogEntryType.Warning, 9);
                }
                else
                {
                    Console.WriteLine("Concluido a verificação completa");
                }
            }
        }
        public void Beging(bool OnError)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(hostPath);
                List<FileInfo> files = directory.GetFiles("*.xml", SearchOption.AllDirectories)
                    .Where(f => f.CreationTimeUtc > DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(5)) |
                                f.LastAccessTimeUtc > DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(5))).ToList();

                if (files.Count() > 0)
                {
                    int i = 0;
                    foreach (var xml in files)
                    {
                        var arquivoXml = xml.FullName;
                        XmlDocument document = new XmlDocument();
                        try
                        {
                            i++;
                            document.Load(xml.FullName);

                            if (document.DocumentElement.Name == "nfeProc")
                            {
                                NFe NFe = new NFe();
                                NFe.Hash = xml.CreateHash();
                                var node = document.GetElementsByTagName("NFe")[0];
                                NFe.XmlNFe = new XmlNFe
                                {
                                    DhChange = xml.CreationTimeUtc,
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
                                        if (eventLog1 != null)
                                        {
                                            eventLog1.WriteEntry($"O arquivo {xml.Name} foi gravado com sucesso.", EventLogEntryType.SuccessAudit, 1);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"O arquivo {xml.Name} foi gravado com sucesso.");
                                        }
                                    }
                                    else
                                    {
                                        switch (result.NFeResultException)
                                        {
                                            case NFeResultException.DbUpdateConcurrencyException:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                             $"{result.DbUpdateConcurrencyException.ToString()}",
                                                                             EventLogEntryType.Error, 2);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.DbUpdateConcurrencyException.ToString()}");
                                                    }
                                                }
                                                break;
                                            case NFeResultException.DbUpdateException:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        if (result.ErrorNumber != 2627)
                                                            eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                                 $"{result.DbUpdateException.InnerException.ToString()}",
                                                                                 EventLogEntryType.Error, result.ErrorNumber);
                                                    }
                                                    else
                                                    {
                                                        if (result.ErrorNumber != 2627)
                                                            Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                              $"{result.DbUpdateException.InnerException.ToString()}");
                                                    }
                                                }
                                                break;
                                            case NFeResultException.Exception:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                             $"{result.Exception.ToString()}",
                                                                             EventLogEntryType.Error, 3);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.Exception.ToString()}");
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (eventLog1 != null)
                                {
                                    eventLog1.WriteEntry($"O arquivo xml {xml.Name} na pasta {xml.FullName.Replace(xml.Name, "")} " +
                                                         $"não é um arquivo de NFe valido ou o arquivo não foi transmitido para a SEFAZ." +
                                                         $"A Tag nfeProc não foi localizada.\n O arquivo não será gravado", EventLogEntryType.Error, 4);
                                }
                                else
                                {
                                    Console.WriteLine($"O arquivo xml {xml.Name} na pasta {xml.FullName.Replace(xml.Name, "")} " +
                                                      $"não é um arquivo de NFe valido ou o arquivo não foi transmitido para a SEFAZ." +
                                                      $"A Tag nfeProc não foi localizada.\n O arquivo não será gravado");
                                }
                            }
                        }
                        catch (XmlException err)
                        {
                            if (eventLog1 != null)
                            {
                                eventLog1.WriteEntry(err.InnerException == null ?
                                                     $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                     $"Arquivo: {arquivoXml}\n {err.InnerException.ToString()}",
                                                     EventLogEntryType.Error, 6);
                            }
                            else
                            {
                                Console.WriteLine(err.InnerException == null ?
                                                  $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                  $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}");
                            }
                        }
                        catch (Exception err)
                        {
                            if (eventLog1 != null)
                            {
                                eventLog1.WriteEntry(err.InnerException == null ?
                                                     $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                     $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}",
                                                     EventLogEntryType.Error, 7);
                            }
                            else
                            {
                                Console.WriteLine(err.InnerException == null ?
                                                  $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                                  $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (eventLog1 != null)
                {
                    eventLog1.WriteEntry(e.InnerException == null ? e.ToString() : e.InnerException.ToString(), EventLogEntryType.Error, 8);
                }
                else
                {
                    Console.WriteLine(e.InnerException == null ? e.ToString() : e.InnerException.ToString());
                }
            }
            finally
            {
                if (eventLog1 != null)
                {
                    eventLog1.WriteEntry("Concluido a verificação completa", EventLogEntryType.Warning, 9);
                }
                else
                {
                    Console.WriteLine("Concluido a verificação completa");
                }
            }
        }
        public void FileWatcherProsoft()
        {
            watcherProsoft = new FileSystemWatcher();

            try
            {
                watcherProsoft.Path = hostPathProsoft;
                watcherProsoft.IncludeSubdirectories = true;
                watcherProsoft.Filter = "PRG_0008.MKD";
                watcherProsoft.NotifyFilter = NotifyFilters.FileName |
                                       NotifyFilters.LastWrite |
                                       NotifyFilters.DirectoryName |
                                       NotifyFilters.CreationTime |
                                       NotifyFilters.Size |
                                       NotifyFilters.Attributes |
                                       NotifyFilters.Security;

                watcherProsoft.Changed += new FileSystemEventHandler(OnChangedProsoft);

                watcherProsoft.EnableRaisingEvents = true;

                watcherProsoft.Error += Watcher_Error;
            }
            catch (ArgumentException err)
            {
                if (eventLog1 != null)
                {
                    eventLog1.WriteEntry(err.ToString(), EventLogEntryType.Error, 10);
                }
                else
                {
                    Console.WriteLine(err.ToString());
                }
            }
            catch (Exception err)
            {
                if (eventLog1 != null)
                {
                    eventLog1.WriteEntry(err.ToString(), EventLogEntryType.Error, 11);
                }
                else
                {
                    Console.WriteLine(err.ToString());
                }
            }
        }
        public void FileWatcher()
        {
            watcher = new FileSystemWatcher();

            try
            {
                watcher.Path = hostPath;
                watcher.IncludeSubdirectories = true;
                watcher.Filter = "*.xml";
                watcher.NotifyFilter = NotifyFilters.FileName |
                                       NotifyFilters.LastWrite |
                                       NotifyFilters.DirectoryName |
                                       NotifyFilters.CreationTime |
                                       NotifyFilters.Size |
                                       NotifyFilters.Attributes |
                                       NotifyFilters.Security;

                watcher.Created += new FileSystemEventHandler(OnChanged);

                watcher.EnableRaisingEvents = true;

                watcher.Error += Watcher_Error;
            }
            catch (ArgumentException err)
            {
                if(eventLog1 != null)
                {
                    eventLog1.WriteEntry(err.ToString(), EventLogEntryType.Error, 12);
                }
                else
                {
                    Console.WriteLine(err.ToString());
                }
            }
            catch (Exception err)
            {
                if(eventLog1 != null)
                {
                    eventLog1.WriteEntry(err.ToString(), EventLogEntryType.Error, 13);
                }
                else
                {
                    Console.WriteLine(err.ToString());
                }
            }
        }
        private void Watcher_Error(object sender, ErrorEventArgs e)
        {
            if (eventLog1 != null)
            {
                eventLog1.WriteEntry(e.GetException().ToString(), EventLogEntryType.FailureAudit, 14);
            }
            else
            {
                Console.WriteLine(e.GetException().ToString());
            }
            Beging(true);
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    {
                        var arquivoXml = e.FullPath;
                        try
                        {

                            bool isFileOpened = true;

                            FileInfo xml = new FileInfo(e.FullPath);
                            while (isFileOpened)
                            {
                                try
                                {
                                    xml.OpenRead();
                                    isFileOpened = false;
                                }
                                catch
                                {
                                    isFileOpened = true;
                                }
                            }


                            XmlDocument document = new XmlDocument();
                            document.Load(xml.OpenRead());

                            if (document.DocumentElement.Name == "nfeProc")
                            {
                                NFe NFe = new NFe();
                                NFe.Hash = xml.CreateHash();
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
                                        if (eventLog1 != null)
                                        {
                                            eventLog1.WriteEntry($"O arquivo {xml.Name} foi gravado com sucesso.", EventLogEntryType.SuccessAudit, 1);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"O arquivo {xml.Name} foi gravado com sucesso.");
                                        }
                                    }
                                    else
                                    {
                                        switch (result.NFeResultException)
                                        {
                                            case NFeResultException.DbUpdateConcurrencyException:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                             $"{result.DbUpdateConcurrencyException.ToString()}",
                                                                             EventLogEntryType.Error, 2);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.DbUpdateConcurrencyException.ToString()}");
                                                    }
                                                }
                                                break;
                                            case NFeResultException.DbUpdateException:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        if (result.ErrorNumber != 2627)
                                                            eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                                 $"{result.DbUpdateException.InnerException.ToString()}",
                                                                                 EventLogEntryType.Error, result.ErrorNumber);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.DbUpdateException.InnerException.ToString()}");
                                                    }
                                                }
                                                break;
                                            case NFeResultException.Exception:
                                                {
                                                    if (eventLog1 != null)
                                                    {
                                                        eventLog1.WriteEntry($"Erro: {xml.FullName} - " +
                                                                             $"{result.Exception.ToString()}",
                                                                             EventLogEntryType.Error, 3);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Erro: {xml.FullName} - " +
                                                                          $"{result.Exception.ToString()}");
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (eventLog1 != null)
                                {
                                    eventLog1.WriteEntry($"O arquivo xml {xml.Name} na pasta {xml.FullName.Replace(xml.Name, "")} " +
                                                         $"não é um arquivo de NFe valido ou o arquivo não foi transmitido para a SEFAZ." +
                                                         $"A Tag nfeProc não foi localizada.\n O arquivo não será gravado", EventLogEntryType.Error, 5);
                                }
                                else
                                {
                                    Console.WriteLine($"O arquivo xml {xml.Name} na pasta {xml.FullName.Replace(xml.Name, "")} " +
                                                      $"não é um arquivo de NFe valido ou o arquivo não foi transmitido para a SEFAZ." +
                                                      $"A Tag nfeProc não foi localizada.\n O arquivo não será gravado");
                                }
                            }
                        }
                        catch (XmlException err)
                        {
                            if (eventLog1 != null)
                            {
                                eventLog1.WriteEntry(err.InnerException == null ? $"Arquivo: {arquivoXml}\n {err.ToString()}" :
                                    $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}", EventLogEntryType.Error, 6);
                            }
                            else
                            {
                                Console.WriteLine(err.InnerException == null ? $"Arquivo: {arquivoXml}\n {err.ToString()}" : 
                                    $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}");
                            }
                        }
                        catch (Exception err)
                        {
                            if (eventLog1 != null)
                            {
                                eventLog1.WriteEntry(err.InnerException == null ? $"Arquivo: {arquivoXml}\n {err.ToString()}" : 
                                    $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}", EventLogEntryType.Error, 7);
                            }
                            else
                            {
                                Console.WriteLine(err.InnerException == null ? $"Arquivo: {arquivoXml}\n {err.ToString()}" : 
                                    $"Arquivo: {arquivoXml}\n{err.InnerException.ToString()}");
                            }
                        }
                    }
                    break;
            }
        }
        private void OnChangedProsoft(object sender, FileSystemEventArgs e)
        {
            try
            {
                using (var db = new NFeDbContext(conn))
                {
                    IStoreEmpresas store = new StoreEmpresas(db);
                    var teste = store.Syncronization(connProsoft, default(CancellationToken)).Result;
                }
            }
            catch(Exception err)
            {
                if (eventLog1 != null)
                {
                    eventLog1.WriteEntry(err.ToString(), EventLogEntryType.Error, 15);
                }
                else
                {
                    Console.WriteLine(err.ToString());
                }
            }
        }
    }
}
