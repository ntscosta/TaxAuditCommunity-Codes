using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Retirada
{
    public class retirada : retirada<string>
    { }
    public class retirada<TKey> : TLocal
        where TKey : IEquatable<TKey>
    {
        public TKey infNFeId { get; set; }
    }
}
