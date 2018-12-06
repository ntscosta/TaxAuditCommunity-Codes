using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.Entrega;
using TaxAuditCommunity.Domain.NFe.Retirada;

namespace TaxAuditCommunity.Domain.NFe.TiposBasicos
{
    public class TLocal : TLocal<int>
    { }
    public abstract class TLocal<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public string xLgr { get; set; }
        public string nro { get; set; }
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public int cMun { get; set; }
        public string xMun { get; set; }
        public TUf UF { get; set; }
    }
}
