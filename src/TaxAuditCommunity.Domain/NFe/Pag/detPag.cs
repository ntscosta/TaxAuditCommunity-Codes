using System;

namespace TaxAuditCommunity.Domain.NFe.Pag
{
    public class detPag : detPag<int>
    { }
    public class detPag<TKey> : detPag<TKey, card>
        where TKey : IComparable<TKey>
    { }
    public class detPag<TKey, Tcard> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey pagId { get; set; }
        public byte indPag { get; set; }
        public string tPag { get; set; }
        public double vPag { get; set; }
        public Tcard card { get; set; }
    }
}