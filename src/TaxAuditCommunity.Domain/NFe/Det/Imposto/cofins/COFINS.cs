using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.cofins
{
    public class COFINS : COFINS<int>
    { }
    public class COFINS<TKey> : COFINS<TKey, COFINSAliq, COFINSQtde, COFINSNT, COFINSOutr>
        where TKey : IComparable<TKey>
    { }
    public class COFINS<TKey, TCOFINSAliq, TCOFINSQtde, TCOFINSNT, TCOFINSOutr> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public TCOFINSAliq COFINSAliq { get; set; }
        public TCOFINSQtde COFINSQtde { get; set; }
        public TCOFINSNT COFINSNT { get; set; }
        public TCOFINSOutr COFINSOutr { get; set; }
    }
}
