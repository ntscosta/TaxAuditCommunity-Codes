using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace TaxAuditCommunity.Xml.WindowsService
{
    partial class FileWatcherXmlService : ServiceBase
    {
        private Thread threadWatcher;
#pragma warning disable CS0169 // O campo "FileWatcherXmlService.threadWatcherProsoft" nunca é usado
        private Thread threadWatcherProsoft;
#pragma warning restore CS0169 // O campo "FileWatcherXmlService.threadWatcherProsoft" nunca é usado
        private string conn;
        private string connProsoft;
        private string hostPath;
        private string hostPathProsoft;
        private Factory.FileWatcher.Watcher fileWatcher;
        
        public FileWatcherXmlService()
        {
            InitializeComponent();

            //Cria uma instância da classe EventLog para salvar as ocorrências no monitoramento dos arquivos
            eventLog1 = new EventLog();
            if(!EventLog.SourceExists("TaxAuditCommunityEvents"))
            {
                EventLog.CreateEventSource("TaxAuditCommunityEvents", "TaxAuditCommunityEventsLog");
            }
            eventLog1.Source = "TaxAuditCommunityEvents";
            eventLog1.Log = "TaxAuditCommunityEventsLog";
            eventLog1.MaximumKilobytes = 10240;

            CanPauseAndContinue = true;

            conn = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings["TaxAuditCommunity"].ConnectionString;
            connProsoft = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.ConnectionStrings["Pervasive"].ConnectionString;
            hostPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["Path"].Value;
            hostPathProsoft = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["PathProsoft"].Value;
        }

        protected override void OnStart(string[] args)
        {
            Thread.Sleep(15000);
            eventLog1.WriteEntry("Iniciando processo de monitoramento", EventLogEntryType.Information, 10000);
            fileWatcher = new Factory.FileWatcher.Watcher(hostPath, hostPathProsoft, conn, connProsoft, eventLog1);

            ThreadStart startWatcher = new ThreadStart(fileWatcher.FileWatcher);
            threadWatcher = new Thread(startWatcher);
            threadWatcher.Start();

            //ThreadStart startWatcherProsoft = new ThreadStart(fileWatcher.FileWatcherProsoft);
            //threadWatcherProsoft = new Thread(startWatcherProsoft);
            //threadWatcherProsoft.Start();

            ThreadStart Begining = new ThreadStart(fileWatcher.Beging);
            Thread threadBeginig = new Thread(Begining);
            threadBeginig.Start();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
        protected override void OnContinue()
        {
            ThreadStart Begining = new ThreadStart(fileWatcher.Beging);
            Thread threadBeginig = new Thread(Begining);
            threadBeginig.Start();
        }
    }
}
