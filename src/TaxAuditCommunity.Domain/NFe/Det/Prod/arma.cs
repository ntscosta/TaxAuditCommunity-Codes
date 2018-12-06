using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class arma : arma<int>
    { }
    public class arma<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey prodId { get; set; }
        public byte tpArma { get; set; }
        public string nSerie { get; set; }
        public string nCano { get; set; }
        public string descr { get; set; }
    }
}