using System;

namespace TaxAuditCommunity.Domain.NFe.Ide
{
    public class refECF : refECF<int>
    { }
    public class refECF<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey NFrefId { get; set; }
        public string mod { get; set; }
        public int nECF { get; set; }
        public int nCOO { get; set; }
    }
}