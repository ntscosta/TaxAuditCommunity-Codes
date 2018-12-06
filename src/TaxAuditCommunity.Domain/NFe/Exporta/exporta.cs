using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Exporta
{
    public class exporta : exporta<string>
    { }
    public class exporta<TKey> : exporta<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class exporta<TKey, TintId> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public TUf UFSaidaPais { get; set; }
        public string xLocExporta { get; set; }
        public string xLocDespacho { get; set; }
    }
}
