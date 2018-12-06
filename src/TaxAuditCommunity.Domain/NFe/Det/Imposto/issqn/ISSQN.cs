using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.issqn
{
    public class ISSQN : ISSQN<int>
    { }
    public class ISSQN<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public double vBC { get; set; }
        public double vAliq { get; set; }
        public double vISSQN { get; set; }
        public int cMunFG { get; set; }
        public string cListServ { get; set; }
        public double vDeducao { get; set; }
        public double vOutro { get; set; }
        public double vDescIncond { get; set; }
        public double vDescCond { get; set; }
        public double vISSRet { get; set; }
        public byte indISS { get; set; }
        public string cServico { get; set; }
        public int cMun { get; set; }
        public int cPais { get; set; }
        public string nProcesso { get; set; }
        public byte indIncentivo { get; set; }
    }
}
