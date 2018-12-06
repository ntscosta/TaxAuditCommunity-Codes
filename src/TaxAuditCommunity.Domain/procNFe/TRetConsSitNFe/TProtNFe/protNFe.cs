using System;
using TaxAuditCommunity.Domain.NFe;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProtNFe
{
    public class protNFe : protNFe<int>
    { }
    public class protNFe<TKey> : protNFe<TKey, infProt>
        where TKey : IComparable<TKey>
    { }
    public class protNFe<TKey, TInfProt> : NodeBase<TKey>
        where TKey : IComparable<TKey>
        where TInfProt : infProt
    {
        public TKey retConsSitNFeId { get; set; }
        public string versao { get; set; }

        public TInfProt infProt { get; set; }
    }
}