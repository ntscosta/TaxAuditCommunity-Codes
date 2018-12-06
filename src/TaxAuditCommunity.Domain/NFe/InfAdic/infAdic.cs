using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.InfAdic
{
    public class infAdic : infAdic<string>
    { }
    public class infAdic<TKey> : infAdic<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class infAdic<TKey, TintId> : infAdic<TKey, TintId, obsCont, obsFisco, procRef>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class infAdic<TKey, TintId, TobsCont, TobsFisco, TprocRef> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string infAdFisco { get; set; }
        public string infCpl { get; set; }
        public ICollection<TobsCont> obsCont { get; set; } 
        public ICollection<TobsFisco> obsFisco { get; set; } 
        public ICollection<TprocRef> procRef { get; set; } 
    }
}
