using System;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TEvento;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TRetEvento;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe
{
    public class procEventoNFe : procEventoNFe<int>
    { }
    public class procEventoNFe<TKey> : procEventoNFe<TKey, evento, retEvento>
        where TKey : IComparable<TKey>
    { }
    public class procEventoNFe<TKey, TEvento, TRetEvento> : NodeBase<TKey>
        where TKey : IComparable<TKey>
        where TEvento : evento
        where TRetEvento : retEvento
    {
        public TKey retConsSitNFeId { get; set; }
        public string versao { get; set; }
        public TEvento evento { get; set; }
        public TRetEvento retEvento { get; set; }
    }
}