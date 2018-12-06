using System;
using System.Collections.Generic;
using TaxAuditCommunity.Domain.NFe.AutXML;
using TaxAuditCommunity.Domain.NFe.Avulsa;
using TaxAuditCommunity.Domain.NFe.Cana;
using TaxAuditCommunity.Domain.NFe.Cobr;
using TaxAuditCommunity.Domain.NFe.Compra;
using TaxAuditCommunity.Domain.NFe.Dest;
using TaxAuditCommunity.Domain.NFe.Det;
using TaxAuditCommunity.Domain.NFe.Det.Prod;
using TaxAuditCommunity.Domain.NFe.Emit;
using TaxAuditCommunity.Domain.NFe.Entrega;
using TaxAuditCommunity.Domain.NFe.Exporta;
using TaxAuditCommunity.Domain.NFe.Ide;
using TaxAuditCommunity.Domain.NFe.InfAdic;
using TaxAuditCommunity.Domain.NFe.Pag;
using TaxAuditCommunity.Domain.NFe.Retirada;
using TaxAuditCommunity.Domain.NFe.Total;
using TaxAuditCommunity.Domain.NFe.Transp;

namespace TaxAuditCommunity.Domain.NFe
{
    public class infNFe : infNFe<string>
    {
    }
    public class infNFe<TKey> : infNFe<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class infNFe<TKey, TintId> : 
        infNFe<TKey, TintId, 
            ide, 
            emit,
            dest,
            avulsa,
            retirada,
            entrega,
            autXML,
            det,
            total,
            transp,
            cobr,
            pag,
            infAdic,
            exporta,
            compra,
            cana>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    /// <summary>
    /// Informações da Nota Fiscal Eletrônica
    /// </summary>
    public class infNFe<TKey, TintId, Tide, TEmit, TDest, Tavulsa, TRetirada, TEntrega, TautXML, Tdet, Ttotal, Ttransp, Tcobr, Tpag, TinfAdic, Texporta, Tcompra, Tcana> : NodeBase<TKey, TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey NFeId { get; set; }
        public string versao { get; set; }
        public Tide ide { get; set; }
        public TEmit emit { get; set; }
        public Tavulsa avulsa { get; set; }
        public TDest dest { get; set; }
        public TRetirada retirada { get; set; }
        public TEntrega entrega { get; set; }
        /// <summary>
        /// Lista os CPF/CNPJ autorizados a fazer o download do xml
        /// Tag inserida a partir da versão 3.10
        /// </summary>
        public ICollection<TautXML> autXML { get; set; }
        public ICollection<Tdet> det { get; set; } 
        public Ttotal total { get; set; }
        public Ttransp transp { get; set; }
        public Tcobr cobr { get; set; }
        public Tpag pag { get; set; } 
        public TinfAdic infAdic { get; set; }
        public Texporta exporta { get; set; }
        public Tcompra compra { get; set; }
        public Tcana cana { get; set; }
    }
}
