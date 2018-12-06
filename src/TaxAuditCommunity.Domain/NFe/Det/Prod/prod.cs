using System;
using System.Collections.Generic;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class prod : prod<int>
    { }
    public class prod<TKey> : prod<TKey, DI, detExport, rastro, veicProd, med, arma, comb>
        where TKey : IComparable<TKey>
    { }
    public class prod<TKey, TDI, TDetExport, TRastro, TVeicProd, TMed, TArma, TComb> : TProduto<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey detId { get; set; }
        public TKey TProdutoId { get; set; }
        public string CFOP { get; set; }
        public string uCom { get; set; }
        public double qCom { get; set; }
        public double vUnCom { get; set; }
        public double vProd { get; set; }
        public string cEANTrib { get; set; }
        public string uTrib { get; set; }
        public double qTrib { get; set; }
        public double vUnTrib { get; set; }
        public double vFrete { get; set; }
        public double vSeg { get; set; }
        public double vDesc { get; set; }
        public double vOutro { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 2.00
        /// </summary>
        public TindTot indTot { get; set; }
        public ICollection<TDI> DI { get; set; }
        /// <summary>
        /// Tag inserida a partir da versão 3.10
        /// </summary>
        public ICollection<TDetExport> detExport { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 2.00
        /// </summary>
        public string xPed { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 2.00
        /// </summary>
        public int nItemPed { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 2.00
        /// </summary>
        public string nFCI { get; set; }
        public ICollection<TRastro> rastro { get; set; }
        public TVeicProd veicProd { get; set; }
        public TMed med { get; set; }
        public ICollection<TArma> arma { get; set; }
        public TComb comb { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public string nRECOPI { get; set; }
    }
}