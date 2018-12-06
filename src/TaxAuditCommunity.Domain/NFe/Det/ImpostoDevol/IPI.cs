using System;

namespace TaxAuditCommunity.Domain.NFe.Det.ImpostoDevol
{
    public class IPI : IPI<int>
    { }
    public class IPI<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoDevolId { get; set; }
        public double vIPIDevol { get; set; }

    }
}