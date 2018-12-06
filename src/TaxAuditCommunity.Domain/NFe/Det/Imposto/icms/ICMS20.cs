using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMS20 : ICMS20<int>
    { }
    public class ICMS20<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CST { get; set; }
        public byte modBC { get; set; }
        public double pRedBC { get; set; }
        public double vBC { get; set; }
        public double pICMS { get; set; }
        public double vICMS { get; set; }
        public double vBCFCP { get; set; }
        public double pFCP { get; set; }
        public double vFCP { get; set; }
        public double vICMSDeson { get; set; }
        public byte motDesICMS { get; set; }
    }
}