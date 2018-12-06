using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Avulsa
{
    public class avulsa : avulsa<string>
    { }
    public class avulsa<TKey> : avulsa<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class avulsa<TKey, TintId> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string CNPJ { get; set; }
        public string xOrgao { get; set; }
        public string matr { get; set; }
        public string xAgente { get; set; }
        public string fone { get; set; }
        public TUf UF { get; set; }
        public int nDAR { get; set; }
        public DateTime dEmi { get; set; }
        public double vDAR { get; set; }
        public string repEmit { get; set; }
        public DateTime dPag { get; set; }
    }
}
