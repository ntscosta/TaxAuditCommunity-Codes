using System;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Ide
{
    public class refNF : refNF<int>
    { }
    public class refNF<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey NFrefId { get; set; }
        public TCodUfIBGE cUF { get; set; }
        public string AAMM { get; set; }
        public string CNPJ { get; set; }
        public string mod { get; set; }
        public string serie { get; set; }
        public int nNF { get; set; }
    }
}