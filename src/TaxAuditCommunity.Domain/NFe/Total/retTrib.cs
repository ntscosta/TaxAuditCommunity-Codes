using System;

namespace TaxAuditCommunity.Domain.NFe.Total
{
    public class retTrib : retTrib<int>
    { }
    public class retTrib<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey totalId { get; set; }
        public double vRetPIS { get; set; }
        public double vRetCOFINS { get; set; }
        public double vRetCSLL { get; set; }
        public double vBCIRRF { get; set; }
        public double vIRRF { get; set; }
        public double vBCRetPrev { get; set; }
        public double vRetPrev { get; set; }
    }
}