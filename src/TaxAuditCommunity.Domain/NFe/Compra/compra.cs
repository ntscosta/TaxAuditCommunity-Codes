using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Compra
{
    public class compra : compra<string>
    { }
    public class compra<TKey> : compra<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class compra<TKey, TintId> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string xNEmp { get; set; }
        public string xPed { get; set; }
        public string xCont { get; set; }
    }
}
