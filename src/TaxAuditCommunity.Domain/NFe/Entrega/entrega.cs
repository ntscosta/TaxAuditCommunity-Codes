using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Entrega
{
    public class entrega : entrega<string>
    { }
    public class entrega<TKey> : TLocal
        where TKey : IEquatable<TKey>
    {
        public TKey infNFeId { get; set; }
    }
}
