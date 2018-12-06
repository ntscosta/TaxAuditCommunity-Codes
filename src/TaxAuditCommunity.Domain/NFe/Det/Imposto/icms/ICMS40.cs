using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMS40 : ICMS40<int>
    { }
    public class ICMS40<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CST { get; set; }
        public double vICMSDeson { get; set; }
        public byte motDesICMS { get; set; }
    }
}