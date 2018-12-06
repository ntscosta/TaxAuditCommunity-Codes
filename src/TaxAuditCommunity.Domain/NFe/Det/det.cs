using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.Det.Imposto;
using TaxAuditCommunity.Domain.NFe.Det.ImpostoDevol;
using TaxAuditCommunity.Domain.NFe.Det.Prod;

namespace TaxAuditCommunity.Domain.NFe.Det
{
    public class det : det<string>
    { }
    public class det<TKey> : det<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class det<TKey, TintId> : det<TKey, TintId, prod, imposto, impostoDevol>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class det<TKey, TintId, TProd, TImposto, TImpostoDevol> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string infAdProd { get; set; }
        public int nItem { get; set; }
        public TProd prod { get; set; }
        public TImposto imposto { get; set; }
        public TImpostoDevol impostoDevol { get; set; }
    }
}
