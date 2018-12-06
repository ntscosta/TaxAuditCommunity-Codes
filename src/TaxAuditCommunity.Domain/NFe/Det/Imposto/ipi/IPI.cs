using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.ipi
{
    public class IPI : IPI<int>
    { }
    public class IPI<TKey> : IPI<TKey, IPITrib, IPINT>
        where TKey : IComparable<TKey>
    { }
    public class IPI<TKey, TIPITrib, TIPINT> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public string cIEnq { get; set; }
        public string CNPJProd { get; set; }
        public string cSelo { get; set; }
        public int qSelo { get; set; }
        public string cEnq { get; set; }
        public TIPITrib IPITrib { get; set; }
        public TIPINT IPINT { get; set; }
    }
}
