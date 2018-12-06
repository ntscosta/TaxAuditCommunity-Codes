using System;

namespace TaxAuditCommunity.Domain.NFe.Cobr
{
    public class fat : fat<int>
    { }
    public class fat<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey cobrId { get; set; }
        public string nFat { get; set; }
        public double vOrig { get; set; }
        public double vDesc { get; set; }
        public double vLiq { get; set; }
    }
}