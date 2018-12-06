using System;
using TaxAuditCommunity.Domain.NFe;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TRetCancNFe
{
    public class retCancNFe : retCancNFe<int>
    { }
    public class retCancNFe<TKey> : retCancNFe<TKey, infCanc>
        where TKey : IComparable<TKey>
    { }
    public class retCancNFe<TKey, TInfCanc> : NodeBase<TKey>
        where TKey : IComparable<TKey>
        where TInfCanc : infCanc
    {
        public TKey retConsSitNFeId { get; set; }
        public string versao { get; set; }

        public TInfCanc infCanc { get; set; }
    }
}