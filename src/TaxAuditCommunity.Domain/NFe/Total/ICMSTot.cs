using System;

namespace TaxAuditCommunity.Domain.NFe.Total
{
    public class ICMSTot : ICMSTot<int>
    { }
    public class ICMSTot<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey totalId { get; set; }
        public double vBC { get; set; }
        public double vICMS { get; set; }
        public double vICMSDeson { get; set; }
        public double vFCPUFDest { get; set; }
        public double vICMSUFDest { get; set; }
        public double vICMSUFRemet { get; set; }
        public double vFCP { get; set; }
        public double vBCST { get; set; }
        public double vST { get; set; }
        public double vFCPST { get; set; }
        public double vFCPSTRet { get; set; }
        public double vProd { get; set; }
        public double vFrete { get; set; }
        public double vSeg { get; set; }
        public double vDesc { get; set; }
        public double vII { get; set; }
        public double vIPI { get; set; }
        public double vIPIDevol { get; set; }
        public double vPIS { get; set; }
        public double vCOFINS { get; set; }
        public double vOutro { get; set; }
        public double vNF { get; set; }
        public double vTotTrib { get; set; }
    }
}