using System;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TRetCancNFe
{
    public class infCanc : infCanc<int>
    { }
    public class infCanc<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey retCancNFeId { get; set; }
        public TAmb tpAmb { get; set; }
        public string verAplic { get; set; }
        public string cStat { get; set; }
        public string xMotivo { get; set; }
        public TCodUfIBGE cUF { get; set; }
        public string chNFe { get; set; }
        public DateTime dhRecibo { get; set; }
        public string nProt { get; set; }
    }
}