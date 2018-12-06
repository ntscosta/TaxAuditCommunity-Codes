using System;

namespace TaxAuditCommunity.Domain.NFe.Pag
{
    public class card : card<int>
    { }
    public class card<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey detPagId { get; set; }
        public int tpIntegra { get; set; }
        public string CNPJ { get; set; }
        public string tBand { get; set; }
        public int cAut { get; set; }
    }
}