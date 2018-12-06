using System;
using System.Collections.Generic;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class DI : DI<int>
    { }
    public class DI<TKey> : DI<TKey, adi>
        where TKey : IComparable<TKey>
    { }
    public class DI<TKey, Tadi> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey prodId { get; set; }
        public string nDI { get; set; }
        public DateTime dDI { get; set; }
        public string xLocDesemb { get; set; }
        public TUf UFDesemb { get; set; }
        public DateTime dDesemb { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public int tpViaTransp { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public double vAFRMM { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public byte tpIntermedio { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public string CNPJ { get; set; }
        /// <summary>
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public string UFTerceiro { get; set; }
        public string cExportador { get; set; }
        public ICollection<Tadi> adi { get; set; } = new List<Tadi>();
    }
}