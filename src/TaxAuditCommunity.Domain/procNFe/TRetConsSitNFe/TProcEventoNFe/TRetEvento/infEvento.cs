using System;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TRetEvento
{
    public class infEvento : infEvento<int>
    { }
    public class infEvento<TKey> : Nodebase
        where TKey : IComparable<TKey>
    {

        public string Id { get; set; }
        public TKey retEventoId { get; set; }
        public TAmb tpAmb { get; set; }
        public string verAplic { get; set; }
        public string cOrgao { get; set; }
        public string cStat { get; set; }
        public string xMotivo { get; set; }
        public string chNFe { get; set; }
        public string tpEvento { get; set; }
        public string xEvento { get; set; }
        public string nSeqEvento { get; set; }
        public string CNPJDest { get; set; }
        public string CPFDest { get; set; }
        public string emailDest { get; set; }
        public DateTime dhRegEvento { get; set; }
        public string nProt { get; set; }
    }
}