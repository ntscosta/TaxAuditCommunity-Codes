using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Total
{
    public class total : total<string>
    { }
    public class total<TKey> : total<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class total<TKey, TintId> : total<TKey, TintId, ICMSTot, ISSQNTot, retTrib>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class total<TKey, TintId, TICMSTot, TISSQNTot, TretTrib> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public TICMSTot ICMSTot { get; set; }
        public TISSQNTot ISSQNTot { get; set; }
        public TretTrib retTrib { get; set; }
    }
}
