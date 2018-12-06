using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class CIDE : CIDE<int>
    { }
    public class CIDE<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey compId { get; set; }
        public double qBCProd { get; set; }
        public double vAliqProd { get; set; }
        public double vCIDE { get; set; }
    }
}