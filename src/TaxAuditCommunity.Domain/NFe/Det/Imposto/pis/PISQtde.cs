using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.pis
{
    public class PISQtde : PISQtde<int>
    { }
    public class PISQtde<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey PISId { get; set; }
        public string CST { get; set; }
        public double qBCProd { get; set; }
        public double vAliqProd { get; set; }
        public double vPIS { get; set; }
    }
}