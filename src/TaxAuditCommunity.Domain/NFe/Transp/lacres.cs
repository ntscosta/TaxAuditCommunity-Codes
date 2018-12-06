using System;

namespace TaxAuditCommunity.Domain.NFe.Transp
{
    public class lacres : lacres<int>
    { }
    public class lacres<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey volId { get; set; }
        public string nLacre { get; set; }
    }
}