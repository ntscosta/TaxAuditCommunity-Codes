using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TaxAuditCommunity.Domain.procNFe;
using TaxAuditCommunity.Domain.SchemaNFe.v4;
using TaxAuditCommunity.Factory.Repository;

namespace TaxAuditCommunity.Factory.Store
{
    public class NFeManager
    {
        public NFeManager(INFeStore<NFe, NFeResult> store)
        {
            Store = store;
        }

        private readonly INFeStore<NFe, NFeResult> Store;

        public Task<NFe> GetNFe(string id)
        {
            return Store.GetNFeByIdAsync(id, default(CancellationToken));
        }

        public Task<NFeResult> GravarNFe(NFe nfe)
        {
            return Store.ImportTag(nfe, default(CancellationToken));
        }

        public async Task<DateTime> LastSaveed()
        {
            return await Store.GetLastFileSaveedAsync(default(CancellationToken));
        }

        public Task<List<NFe>> ListagemConsultaSituacao()
        {
            return Store.GetNotReturn(default(CancellationToken));
        }

        public Task<NFeResult> GravarProtocolo()
        {
            foreach(var nf in Store.GetNotReturn(default(CancellationToken)).Result)
            {
                TConsSitNFe consSitNFe = new TConsSitNFe();
                consSitNFe.chNFe = nf.Id;
                consSitNFe.tpAmb = (TAmb)nf.infNFe.ide.tpAmb;
                consSitNFe.versao = (TVerConsSitNFe)Enum.Parse(typeof(TVerConsSitNFe), 
                                                               string.Concat("Item", 
                                                               nf.infNFe.versao.Replace(".", "")));
                consSitNFe.xServ = TConsSitNFeXServ.CONSULTAR;

                XmlSerializer xs = new XmlSerializer(typeof(TConsSitNFe));
                StringWriter stringWriter = new StringWriter();
                xs.Serialize(stringWriter, consSitNFe);

                XmlDocument consSit = new XmlDocument();
                consSit.LoadXml(stringWriter.ToString());

                XmlNode nodeConsSit = consSit.GetElementsByTagName("consSitNFe")[0];

                //Store.Protocolo()
            }
            return Task.FromResult(NFeResult.Success);
        }

        public Task<List<NFe>> GetAllNFes()
        {
            return Store.GetAll(default(CancellationToken));
        }

        public Task<NFeResult> LimparBanco()
        {
            return Store.DeleteAll(default(CancellationToken));
        }
    }
}
