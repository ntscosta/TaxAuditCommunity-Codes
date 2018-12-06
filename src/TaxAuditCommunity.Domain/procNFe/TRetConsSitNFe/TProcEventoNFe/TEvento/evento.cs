using System;
using TaxAuditCommunity.Domain.NFe;



namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TEvento
{
    public class evento : evento<int>
    { }
    public class evento<TKey> : evento<TKey, infEvento>
        where TKey : IComparable<TKey>
    { }
    public class evento<TKey, TInfEvento> : NodeBase<TKey>
        where TKey : IComparable<TKey>
        where TInfEvento : infEvento
    {
        public TKey procEventoNFeId { get; set; }
        public string versao { get; set; }
        public TInfEvento infEvento { get; set; }
    }
}