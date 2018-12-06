using System;

namespace TaxAuditCommunity.Domain.NFe.Cana
{
    public class forDia : forDia<int>
    { }
    public class forDia<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey canaId { get; set; }
        public int dia { get; set; }
        public double qtde { get; set; }
    }
}