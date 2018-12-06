using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe
{
    public class infNFeSupl : infNFeSupl<string>
    { }
    public class infNFeSupl<TKey> : infNFeSupl<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class infNFeSupl<TKey, TintId> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey NFeId { get; set; }
        public string qrCode { get; set; }
        public string urlChave { get; set; }
    }
}
