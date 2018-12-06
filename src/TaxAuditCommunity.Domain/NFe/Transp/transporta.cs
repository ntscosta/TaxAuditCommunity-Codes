using System;

namespace TaxAuditCommunity.Domain.NFe.Transp
{
    public class transporta : transporta<int>
    { }
    public class transporta<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey transpId { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string xNome { get; set; }
        public string IE { get; set; }
        public string xEnder { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
    }
}