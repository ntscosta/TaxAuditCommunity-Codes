using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class comb : comb<int>
    { }
    public class comb<TKey> : comb<TKey, CIDE, encerrante>
        where TKey : IComparable<TKey>
    { }
    public class comb<TKey, TcIDE, TEncerrante> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey prodId { get; set; }
        public string cProdANP { get; set; }
        public string descANP { get; set; }
        public double pGLP { get; set; }
        public double pGNn { get; set; }
        public double pGNi { get; set; }
        public double vPart { get; set; }
        public string CODIF { get; set; }
        public double qTemp { get; set; }
        public string UFCons { get; set; }
        public TcIDE CIDE { get; set; }
        public TEncerrante encerrante { get; set; }
    }
}