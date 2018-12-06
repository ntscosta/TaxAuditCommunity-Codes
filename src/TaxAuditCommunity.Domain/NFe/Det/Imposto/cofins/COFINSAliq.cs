using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.cofins
{
    public class COFINSAliq : COFINSAliq<int>
    { }
    public class COFINSAliq<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey COFINSId { get; set; }
        public string CST { get; set; }
        public double vBC { get; set; }
        public double pCOFINS { get; set; }
        public double vCOFINS { get; set; }
    }
}