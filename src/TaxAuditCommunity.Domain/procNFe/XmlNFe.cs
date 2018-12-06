using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Linq;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe;

namespace TaxAuditCommunity.Domain.procNFe
{
    public class XmlNFe : XmlNFe<string>
    { }
    public class XmlNFe<TKey> : XmlNFe<TKey, retConsSitNFe>
        where TKey : IEquatable<TKey>
    { }

    public class XmlNFe<TKey, TRetConsSitNFe>
        where TKey : IEquatable<TKey>
        where TRetConsSitNFe : retConsSitNFe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TKey NFeId { get; set; }
        public DateTime DhChange { get; set; }
        public string FileNFe { get; set; }
        public TRetConsSitNFe retConsSitNFe { get; set; }

        [NotMapped]
        public XElement XmlDocument
        {
            get { return XElement.Parse(FileNFe); }
            set { FileNFe = value.ToString(); }
        }
    }
}
