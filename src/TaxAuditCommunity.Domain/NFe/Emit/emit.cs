using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Emit
{
    public class emit : emit<string>
    {
    }
    public class emit<TKey> : emit<TKey, int, enderEmit>
        where TKey : IEquatable<TKey>
    { }
    public class emit<TKey, TintId, TEnderEmit> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string xNome { get; set; }
        public string xFant { get; set; }
        public TEnderEmit enderEmit { get; set; }
        public string IE { get; set; }
        public string IEST { get; set; }
        public string IM { get; set; }
        public string CNAE { get; set; }
        public TCRT CRT { get; set; }
    }
}
