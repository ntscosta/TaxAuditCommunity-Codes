using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMS60 : ICMS60<int>
    { }
    public class ICMS60<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CST { get; set; }
        public double vBCSTRet { get; set; }
        public double pST { get; set; }
        public double vICMSSTRet { get; set; }
        public double vBCSFCPSTRet { get; set; }
        public double pFCPSTRet { get; set; }
        public double vFCPSTRet { get; set; }
        public double pRedBCEfet { get; set; }
        public double vBCEfet { get; set; }
        public double pICMSEfet { get; set; }
        public double vICMSEfet { get; set; }
    }
}