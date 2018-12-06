using System;

namespace TaxAuditCommunity.Domain.NFe.InfAdic
{
    public class procRef : procRef<int>
    { }
    public class procRef<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey infAdicId { get; set; }
        public string nProc { get; set; }
        public byte indProc { get; set; }
    }
}