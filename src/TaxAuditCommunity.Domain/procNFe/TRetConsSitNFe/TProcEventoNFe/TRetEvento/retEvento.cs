using System;
using TaxAuditCommunity.Domain.NFe;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TRetEvento
{
    public class retEvento : retEvento<int>
    { }
    public class retEvento<TKey> : retEvento<TKey, infEvento>
        where TKey : IComparable<TKey>
    { }
    public class retEvento<TKey, TInfEvento> : NodeBase<TKey>
        where TKey : IComparable<TKey>
        where TInfEvento : infEvento
    {
        public TKey procEventoNFeId { get; set; }
        public string versao { get; set; }
        public TInfEvento infEvento { get; set; }
    }
}