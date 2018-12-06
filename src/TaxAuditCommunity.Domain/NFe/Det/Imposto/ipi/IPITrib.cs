using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.ipi
{
    public class IPITrib : IPITrib<int>
    { }
    public class IPITrib<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey IPIId { get; set; }
        public string CST { get; set; }
        public double vBC { get; set; }
        public double pIPI { get; set; }
        public double qUnid { get; set; }
        public double vUnid { get; set; }
        public double vIPI { get; set; }
    }
}