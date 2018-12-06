using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class med : med<int>
    { }
    public class med<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey prodId { get; set; }
        /// <summary>
        /// Tag extinta na versão 4.00
        /// </summary>
        public string nLote { get; set; }
        /// <summary>
        /// Tag extinta na versão 4.00
        /// </summary>
        public double qLote { get; set; }
        /// <summary>
        /// Tag extinta na versão 4.00
        /// </summary>
        public DateTime dFab { get; set; }
        /// <summary>
        /// Tag extinta na versão 4.00
        /// </summary>
        public DateTime dVal { get; set; }
        /// <summary>
        /// Tag inserida na versao 4.00
        /// </summary>
        public string cProdANVISA { get; set; }
        public double vPMC { get; set; }
    }
}