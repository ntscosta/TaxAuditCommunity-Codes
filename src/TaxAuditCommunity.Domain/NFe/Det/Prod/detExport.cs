using System;
using System.Collections.Generic;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class detExport : detExport<int>
    { }
    public class detExport<TKey> : detExport<TKey, exportInd>
        where TKey : IComparable<TKey>
    { }
    public class detExport<TKey, TexportInd> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey prodId { get; set; }
        public string nDraw { get; set; }
        public ICollection<TexportInd> exportInd { get; set; }
    }
}