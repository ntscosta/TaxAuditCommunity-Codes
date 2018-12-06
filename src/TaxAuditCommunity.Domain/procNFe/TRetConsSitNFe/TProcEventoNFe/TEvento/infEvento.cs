using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TEvento
{
    public class infEvento: infEvento<int>
    {
    }
    public class infEvento<TKey> : Nodebase
        where TKey : IComparable<TKey>
    {
        public string Id { get; set; }
        public TKey eventoId { get; set; }
        public string cOrgao { get; set; }
        public TAmb tpAmb { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string chNFe { get; set; }
        public DateTime dhEvento { get; set; }
        public string tpEvento { get; set; }
        public string nSeqEvento { get; set; }
        public string verEvento { get; set; }
        public string detEvento { get; set; }

        [NotMapped]
        public XElement XmlDocument
        {
            get { return XElement.Parse(detEvento); }
            set { detEvento = value.ToString(); }
        }
    }
}