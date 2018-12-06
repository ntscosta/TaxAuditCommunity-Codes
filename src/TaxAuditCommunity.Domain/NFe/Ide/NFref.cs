using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxAuditCommunity.Domain.NFe.Ide
{
    public class NFref : NFref<int>
    { }
    public class NFref<TKey> : NFref<TKey, refNF, refNFP, refECF>
        where TKey : IComparable<TKey>
    { }
    public class NFref<TKey, TrefNF, TrefNFP, TrefECF> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ideId { get; set; }
        public string refNFe { get; set; }
        /// <summary>
        /// Tag inserida a partir da versão 2.00
        /// </summary>
        public string refCTe { get; set; }
        public TrefNF refNF { get; set; }
        /// <summary>
        /// Tag inserida a partir da versão 2.00
        /// </summary>
        public TrefNFP refNFP { get; set; }
        /// <summary>
        /// Tag inserida a partir da versão 2.00
        /// </summary>
        public TrefECF refECF { get; set; }
    }
}