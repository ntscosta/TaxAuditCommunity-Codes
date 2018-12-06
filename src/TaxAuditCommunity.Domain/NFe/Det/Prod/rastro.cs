using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class rastro : rastro<int>
    { }
    public class rastro<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey prodId { get; set; }
        public int nLote { get; set; }
        public double qLote { get; set; }
        public DateTime dFab { get; set; }
        public DateTime dVal { get; set; }
        public int cAgreg { get; set; }
    }
}