using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.cofins
{
    public class COFINSQtde : COFINSQtde<int>
    { }
    public class COFINSQtde<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey COFINSId { get; set; }
        public string CST { get; set; }
        public double qBCProd { get; set; }
        public double vAliqProd { get; set; }
        public double vCOFINS { get; set; }
    }
}