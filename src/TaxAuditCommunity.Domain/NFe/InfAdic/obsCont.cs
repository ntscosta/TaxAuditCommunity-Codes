using System;

namespace TaxAuditCommunity.Domain.NFe.InfAdic
{
    public class obsCont : obsCont<int>
    { }
    public class obsCont<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey infAdicId { get; set; }
        public string xCampo { get; set; }
        public string xTexto { get; set; }
    }
}