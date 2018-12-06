using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class adi : adi<int>
    { }
    public class adi<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey DIid { get; set; }
        public int nAdicao { get; set; }
        public int nSeqAdic { get; set; }
        public string cFabricante { get; set; }
        public double vDescDI { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public string nDraw { get; set; }
    }
}