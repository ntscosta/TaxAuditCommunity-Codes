using System;
using System.Collections.Generic;

namespace TaxAuditCommunity.Domain.NFe.Transp
{
    public class vol : vol<int>
    { }
    public class vol<TKey> : vol<TKey, lacres>
        where TKey : IComparable<TKey>
    { }
    public class vol<TKey, Tlacres> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey transpId { get; set; }
        public int qVol { get; set; }
        public string esp { get; set; }
        public string marca { get; set; }
        public string nVol { get; set; }
        public double pesoL { get; set; }
        public double pesoB { get; set; }
        public ICollection<Tlacres> lacres { get; set; }
    }
}