using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class exportInd : exportInd<int>
    { }
    public class exportInd<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey detExportId { get; set; }
        public string nRE { get; set; }
        public string chNFe { get; set; }
        public double qExport { get; set; }
    }
}