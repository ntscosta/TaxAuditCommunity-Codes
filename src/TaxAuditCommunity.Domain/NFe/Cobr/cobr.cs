using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Cobr
{
    public class cobr : cobr<string>
    { }
    public class cobr<TKey> : cobr<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class cobr<TKey, TintId> : cobr<TKey, TintId, fat, dup>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class cobr<TKey, TintId, Tfat, Tdup> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public Tfat fat { get; set; }
        public ICollection<Tdup> dup { get; set; }
    }
}
