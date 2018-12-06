using System;

namespace TaxAuditCommunity.Domain.NFe.Cana
{
    public class deduc : deduc<int>
    { }
    public class deduc<Tkey> : NodeBase<Tkey>
        where Tkey : IComparable<Tkey>
    {
        public Tkey canaId { get; set; }
        public string xDed { get; set; }
        public double vDed { get; set; }
    }
}