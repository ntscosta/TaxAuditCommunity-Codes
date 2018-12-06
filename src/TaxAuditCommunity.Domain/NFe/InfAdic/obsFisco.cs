using System;

namespace TaxAuditCommunity.Domain.NFe.InfAdic
{
    public class obsFisco : obsFisco<int>
    { }
    public class obsFisco<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey infAdicId { get; set; }
        public string xCampo { get; set; }
        public string xTexto { get; set; }
    }
}