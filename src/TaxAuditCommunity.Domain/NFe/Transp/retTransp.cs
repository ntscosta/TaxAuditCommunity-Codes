using System;

namespace TaxAuditCommunity.Domain.NFe.Transp
{
    public class retTransp : retTransp<int>
    { }
    public class retTransp<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey transpId { get; set; }
        public double vServ { get; set; }
        public double vBCRet { get; set; }
        public double pICMSRet { get; set; }
        public double vICMSRet { get; set; }
        public string CFOP { get; set; }
        public int cMunFG { get; set; }
    }
}