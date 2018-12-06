using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.Det.Prod;

namespace TaxAuditCommunity.Domain.NFe.TiposBasicos
{
    /// <summary>
    /// Complemento do cadastro do produto
    /// </summary>
    public class TProduto : TProduto<int>
    {
        //public IndFab IndFab { get; set; }
        //public new string CNPJFab { get; set; }
        //public TUf UF { get; set; }

        //public ICollection<TProduto<int, prod>> Produto { get; set; }
    }
    /// <summary>
    /// Classe abstrata para criação da base de produtos geral
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class TProduto<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public string cProd { get; set; }
        public string cEAN { get; set; }
        public string xProd { get; set; }
        public string NCM { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public string NVE { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public string CEST { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 4.00
        /// </summary>
        public TindEscala indEscala { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 4.00
        /// </summary>
        public string CNPJFab { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 4.00
        /// </summary>
        public string cBenef { get; set; }
        public string EXTIPI { get; set; }
        /// <summary>
        /// Campo extinto a partir da versão 2.00
        /// </summary>
        public string genero { get; set; }
    }
}
