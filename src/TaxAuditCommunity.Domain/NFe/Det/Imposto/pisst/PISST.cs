using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.pisst
{
    public class PISST : PISST<int>
    { }
    public class PISST<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public double vBC { get; set; }
        public double pPIS { get; set; }
        public double qBCProd { get; set; }
        public double vAliqProd { get; set; }
        public double vPIS { get; set; }
    }
}
