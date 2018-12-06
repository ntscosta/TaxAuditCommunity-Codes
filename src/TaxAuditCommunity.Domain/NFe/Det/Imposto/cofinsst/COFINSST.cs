using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.cofinsst
{
    public class COFINSST : COFINSST<int>
    { }
    public class COFINSST<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public double vBC { get; set; }
        public double pCOFINS { get; set; }
        public double qBCProd { get; set; }
        public double vAliqProd { get; set; }
        public double vCOFINS { get; set; }
    }
}
