using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.AutXML
{
    public class autXML : autXML<string>
    { }
    public class autXML<TKey> : autXML<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class autXML<TKey, TintId> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
    }
}
