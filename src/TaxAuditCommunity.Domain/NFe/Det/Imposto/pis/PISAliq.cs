using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.pis
{
    public class PISAliq : PISAliq<int>
    { }
    public class PISAliq<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey PISId { get; set; }
        public string CST { get; set; }
        public double vBC { get; set; }
        public double pPIS { get; set; }
        public double vPIS { get; set; }
    }
}