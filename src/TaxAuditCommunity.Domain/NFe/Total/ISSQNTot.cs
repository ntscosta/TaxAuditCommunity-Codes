using System;

namespace TaxAuditCommunity.Domain.NFe.Total
{
    public class ISSQNTot : ISSQNTot<int>
    { }
    public class ISSQNTot<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey totalId { get; set; }
        public double vServ { get; set; }
        public double vBC { get; set; }
        public double vISS { get; set; }
        public double vPIS { get; set; }
        public double vCOFINS { get; set; }
        public DateTime dCompet { get; set; }
        public double vDeducao { get; set; }
        public double vOutro { get; set; }
        public double vDescIncond { get; set; }
        public double vDescCond { get; set; }
        public double vISSRet { get; set; }
        public byte cRegTrib { get; set; }
    }
}