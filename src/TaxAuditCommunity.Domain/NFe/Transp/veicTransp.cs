using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Transp
{
    public class veicTransp : veicTransp<int>
    { }
    public class veicTransp<TKey> : TVeiculo
        where TKey : IComparable<TKey>
    {
        public TKey transpId { get; set; }
    }
}
