using System;

namespace TaxAuditCommunity.Domain.NFe.Cobr
{
    public class dup : dup<int>
    { }
    public class dup<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey cobrId { get; set; }
        public string nDup { get; set; }
        public DateTime dVenc { get; set; }
        public double vDup { get; set; }
    }
}