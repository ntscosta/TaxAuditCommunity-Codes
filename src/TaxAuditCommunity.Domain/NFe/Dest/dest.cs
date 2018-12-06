using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Dest
{
    public class dest : dest<string>
    { }
    public class dest<TKey> : dest<TKey, int, enderDest>
        where TKey : IEquatable<TKey>
    { }
    public class dest<TKey, TintId, TEnderDest> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string idEstrangeiro { get; set; }
        public string xNome { get; set; }
        public TEnderDest enderDest { get; set; }
        public TindIEDest indIEDest { get; set; }
        public string IE { get; set; }
        public string ISUF { get; set; }
        public string IM { get; set; }
        public string email { get; set; }
    }
}
