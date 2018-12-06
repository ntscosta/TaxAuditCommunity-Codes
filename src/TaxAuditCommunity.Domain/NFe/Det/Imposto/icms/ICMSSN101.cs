using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMSSN101 : ICMSSN101<int>
    { }
    public class ICMSSN101<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CSOSN { get; set; }
        public double pCredSN { get; set; }
        public double vCredICMSSN { get; set; }
    }
}