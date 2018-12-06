﻿using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMSSN900 : ICMSSN900<int>
    { }
    public class ICMSSN900<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CSOSN { get; set; }
        public byte modBC { get; set; }
        public double vBC { get; set; }
        public double pRedBC { get; set; }
        public double pICMS { get; set; }
        public double vICMS { get; set; }
        public byte modBCST { get; set; }
        public double pMVAST { get; set; }
        public double pRedBCST { get; set; }
        public double vBCST { get; set; }
        public double pICMSST { get; set; }
        public double vICMSST { get; set; }
        public double vBCFCPST { get; set; }
        public double pFCPST { get; set; }
        public double vFCPST { get; set; }
        public double pCredSN { get; set; }
        public double vCredICMSSN { get; set; }
    }
}