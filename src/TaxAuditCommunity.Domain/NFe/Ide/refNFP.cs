using System;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Ide
{
    public class refNFP : refNFP<int>
    { }
    public class refNFP<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey NFrefId { get; set; }
        public TCodUfIBGE cUF { get; set; }
        public string AAMM { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string IE { get; set; }
        public string mod { get; set; }
        public string serie { get; set; }
        public int nNF { get; set; }
    }
}