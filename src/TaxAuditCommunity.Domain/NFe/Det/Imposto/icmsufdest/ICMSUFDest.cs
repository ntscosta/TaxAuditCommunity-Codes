using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icmsufdest
{
    public class ICMSUFDest : ICMSUFDest<int>
    { }
    public class ICMSUFDest<TKey> : NodeBase<TKey>
     where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public double vBCUFDest { get; set; }
        public double vBCFCPUFdest { get; set; }
        public double pFCPUFdest { get; set; }
        public double pICMSUFDest { get; set; }
        public double pICMSInter { get; set; }
        public double pICMSInterPart { get; set; }
        public double vFCUFdest { get; set; }
        public double vICMSUFDest { get; set; }
        public double vICMSUFRemet { get; set; }
    }
}
