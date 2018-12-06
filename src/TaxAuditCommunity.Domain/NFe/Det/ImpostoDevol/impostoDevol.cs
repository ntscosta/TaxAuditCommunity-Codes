using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.ImpostoDevol
{
    public class impostoDevol : impostoDevol<int>
    { }
    public class impostoDevol<TKey> : impostoDevol<TKey, IPI>
        where TKey : IComparable<TKey>
    { }
    public class impostoDevol<TKey, TIPI> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey detId { get; set; }
        public double pDevol { get; set; }
        public TIPI IPI { get; set; }
    }
}
