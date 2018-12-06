using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMSST : ICMSST<int>
    { }
    public class ICMSST<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CST { get; set; }
        public double vBCSTRet { get; set; }
        public double vICMSSTRet { get; set; }
        public double vBCSTDest { get; set; }
        public double vICMSSTDest { get; set; }
    }
}