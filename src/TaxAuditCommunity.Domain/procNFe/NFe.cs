using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe;

namespace TaxAuditCommunity.Domain.procNFe
{
    public class NFe : NFe<string>
    {
    }
    public class NFe<TKey> : NFe<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class NFe<TKey, TIntId> : NFe<TKey, TIntId, infNFe, infNFeSupl, XmlNFe>
        where TKey : IEquatable<TKey>
        where TIntId : IComparable<TIntId>
    { }
    public class NFe<TKey, TIntId, TinfNFe, TinfNFeSupl, TXmlNFe> : NodeBase<TKey, TIntId>
        where TKey : IEquatable<TKey>
        where TIntId : IComparable<TIntId>
        where TinfNFe : infNFe
        where TinfNFeSupl : infNFeSupl
        where TXmlNFe : XmlNFe
    {

        public TinfNFe infNFe { get; set; }
        public byte[] Hash { get; set; }
        public TinfNFeSupl infNFeSupl { get; set; }
        public TXmlNFe XmlNFe { get; set; }
    }
}
