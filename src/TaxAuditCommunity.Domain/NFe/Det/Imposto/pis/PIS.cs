using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.pis
{
    public class PIS : PIS<int>
    { }
    public class PIS<TKey> : PIS<TKey, PISAliq, PISQtde, PISNT, PISOutr>
        where TKey : IComparable<TKey>
    { }
    public class PIS<TKey, TPISAliq, TPISQtde, TPISNT, TPISOutr> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public TPISAliq PISAliq { get; set; }
        public TPISQtde PISQtde { get; set; }
        public TPISNT PISNT { get; set; }
        public TPISOutr PISOutr { get; set; }
    }
}
