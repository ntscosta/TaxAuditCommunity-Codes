using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.ii
{
    public class II : II<int>
    { }
    public class II<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public double vBC { get; set; }
        public double vDespAdu { get; set; }
        public double vII { get; set; }
        public double vIOF { get; set; }

    }
}
