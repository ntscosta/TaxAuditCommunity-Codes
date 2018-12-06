﻿using System;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProtNFe
{
    public class infProt : infProt<int>
    { }
    public class infProt<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey protNFeId { get; set; }
        public TAmb tpAmb { get; set; }
        public string verAplic { get; set; }
        public string chNFe { get; set; }
        public DateTime dhRecibo { get; set; }
        public string nProt { get; set; }
        public string digVal { get; set; }
        public string cStat { get; set; }
        public string xMotivo { get; set; }
        public string versao { get; set; }
    }
}