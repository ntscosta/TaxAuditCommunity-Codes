using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Ide
{
    public class ide : ide<string>
    { }
    public class ide<TKey> : ide<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class ide<TKey, TintId> : ide<TKey, TintId, NFref>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class ide<TKey, TintId, TNFref> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
        where TNFref : NFref
    {
        public TKey infNFeId { get; set; }
        public TCodUfIBGE cUF { get; set; }
        public int cNF { get; set; }
        public string natOp { get; set; }
        /// <summary>
        /// Tag extinta pelo layout 4.00
        /// </summary>
        public int indPag { get; set; }
        public TMod mod { get; set; }
        public int serie { get; set; }
        public int nNF { get; set; }
        public DateTime dhEmi { get; set; }
        /// <summary>
        /// Campo utilizado somente na versão 2.00
        /// </summary>
        public DateTime dSaiEnt { get; set; }
        /// <summary>
        /// Campo valido nas versões 1.10, 3.10 e 4.00
        /// </summary>
        public DateTime dhSaiEnt { get; set; }
        /// <summary>
        /// Campo utilizado somente na versão 2.00
        /// </summary>
        public TimeSpan hSaiEnt { get; set; }
        public TtpNF tpNF { get; set; }
        /// <summary>
        /// Indicação de operação interna, interestadual ou exterior
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public TidDest idDest { get; set; }
        public int cMunFG { get; set; }
        public TtpImp tpImp { get; set; }
        public TtpEmis tpEmis { get; set; }
        public int cDV { get; set; }
        public TAmb tpAmb { get; set; }
        public TfinNFe finNFe { get; set; }
        /// <summary>
        /// Indicador de consumidor final
        /// indispensável para o Difal
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public TindFinal indFinal { get; set; }
        /// <summary>
        /// Indicador de compra presencial ou não presencial
        /// indispensável para o Difal
        /// Campo inserido a partir da versão 3.10
        /// </summary>
        public TindPres indPres { get; set; }
        public TprocEmi procEmi { get; set; }
        public string verProc { get; set; }
        /// <summary>
        /// Data e hora de entrada em contingência
        /// Campo inserido a partir da versão 2.00
        /// </summary>
        public DateTime dhCont { get; set; }
        /// <summary>
        /// Justificativa para entrada em contingência
        /// Campo inserido a partir da versão 2.00
        /// </summary>
        public string xJust { get; set; }
        public ICollection<TNFref> NFref { get; set; }
    }
}
