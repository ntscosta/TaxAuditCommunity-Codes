﻿using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMSSN202 : ICMSSN202<int>
    { }
    public class ICMSSN202<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CSOSN { get; set; }
        public byte modBCST { get; set; }
        public double pMVAST { get; set; }
        public double pRedBCST { get; set; }
        public double vBCST { get; set; }
        public double pICMSST { get; set; }
        public double vICMSST { get; set; }
        public double vBCFCPST { get; set; }
        public double pFCPST { get; set; }
        public double vFCPST { get; set; }
    }
}