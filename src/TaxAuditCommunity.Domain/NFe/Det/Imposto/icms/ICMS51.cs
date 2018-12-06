using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMS51 : ICMS51<int>
    { }
    public class ICMS51<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CST { get; set; }
        public byte modBC { get; set; }
        public double pRedBC { get; set; }
        public double vBC { get; set; }
        public double pICMS { get; set; }
        public double vICMSOp { get; set; }
        public double pDif { get; set; }
        public double pICMSDif { get; set; }
        public double vICMSDif { get; set; }
        public double vICMS { get; set; }
        public double vBCFCP { get; set; }
        public double pFCP { get; set; }
        public double vFCP { get; set; }
    }
}