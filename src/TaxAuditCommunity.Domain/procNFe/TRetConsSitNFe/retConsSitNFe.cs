using System;
using System.Collections.Generic;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProtNFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TRetCancNFe;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe
{
    public class retConsSitNFe : retConsSitNFe<int>
    { }
    public class retConsSitNFe<TKey> : retConsSitNFe<TKey, protNFe, retCancNFe, procEventoNFe>
        where TKey : IComparable<TKey>
    { }
    public class retConsSitNFe<TKey, TProtNFe, TRetCancNFe, TProcEventoNFe> : NodeBase<TKey>
        where TKey : IComparable<TKey>
        where TProtNFe : protNFe
        where TRetCancNFe : retCancNFe
        where TProcEventoNFe : procEventoNFe
    {
        public TKey XmlNFeId { get; set; }
        public TAmb tpAmb { get; set; }
        public string verAplic { get; set; }
        public string cStat { get; set; }
        public string xMotivo { get; set; }
        public TCodUfIBGE cUF { get; set; }
        public DateTime dhRecibo { get; set; }
        public string chNFe { get; set; }
        public string versao { get; set; }

        public TProtNFe protNFe { get; set; }
        public TRetCancNFe retCancNFe { get; set; }
        public ICollection<TProcEventoNFe> procEventoNFe { get; set; }
    }
}