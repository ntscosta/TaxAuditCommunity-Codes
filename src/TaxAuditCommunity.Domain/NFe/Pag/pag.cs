using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Pag
{
    public class pag : pag<string>
    { }
    public class pag<TKey> : pag<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class pag<TKey, TintId> : pag<TKey, TintId, detPag>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class pag<TKey, TintId, TdetPag> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
        where TdetPag : detPag
    {
        public TKey infNFeId { get; set; }
        public ICollection<TdetPag> detPag { get; set; }
        public double vTroco { get; set; }
    }
}
