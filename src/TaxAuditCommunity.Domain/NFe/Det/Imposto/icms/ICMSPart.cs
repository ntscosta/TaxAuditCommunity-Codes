using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMSPart : ICMSPart<int>
    { }
    public class ICMSPart<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey ICMSId { get; set; }
        public byte orig { get; set; }
        public string CST { get; set; }
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
        public double pBCOp { get; set; }
        public string UFST { get; set; }
    }
}