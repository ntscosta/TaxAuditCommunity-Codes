using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.ipi
{
    public class IPINT : IPINT<int>
    { }
    public class IPINT<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey IPIId { get; set; }
        public string CST { get; set; }
    }
}