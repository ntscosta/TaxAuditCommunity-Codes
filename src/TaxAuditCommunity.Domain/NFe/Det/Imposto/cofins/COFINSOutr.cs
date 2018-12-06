using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.cofins
{
    public class COFINSOutr : COFINSOutr<int>
    { }
    public class COFINSOutr<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey COFINSId { get; set; }
        public string CST { get; set; }
        public double vBC { get; set; }
        public double pCOFINS { get; set; }
        public double qBCProd { get; set; }
        public double vAliqProd { get; set; }
        public double vCOFINS { get; set; }
    }
}