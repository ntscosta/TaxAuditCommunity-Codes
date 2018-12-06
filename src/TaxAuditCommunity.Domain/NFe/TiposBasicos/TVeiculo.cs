using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxAuditCommunity.Domain.NFe.Transp;

namespace TaxAuditCommunity.Domain.NFe.TiposBasicos
{
    [NotMapped]
    public class TVeiculo : TVeiculo<int>
    { }
    public class TVeiculo<TKey> : TVeiculo<TKey, veicTransp, reboque>
        where TKey : IComparable<TKey>
    { }
    public class TVeiculo<TKey, TVeicTransp, TReboque> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public string placa { get; set; }
        public TUf UF { get; set; }
        public string RNTC { get; set; }
    }
}
