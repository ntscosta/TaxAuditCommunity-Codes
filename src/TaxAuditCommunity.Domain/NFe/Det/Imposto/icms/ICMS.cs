using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto.icms
{
    public class ICMS : ICMS<int>
    { }
    public class ICMS<TKey> : ICMS<TKey, ICMS00, ICMS10, ICMS20, ICMS30, ICMS40, ICMS51, ICMS60, ICMS70, ICMS90,
                                         ICMSPart, ICMSST, ICMSSN101, ICMSSN102, ICMSSN201, ICMSSN202, ICMSSN500, ICMSSN900>
        where TKey : IComparable<TKey>
    { }
    public class ICMS<TKey, TICMS00, TICMS10, TICMS20, TICMS30, TICMS40, TICMS51, TICMS60, TICMS70, TICMS90,
                            TICMSPart, TICMSST, TICMSSN101, TICMSSN102, TICMSSN201, TICMSSN202, TICMSSN500, TICMSSN900>
        : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey impostoId { get; set; }
        public TICMS00 ICMS00 { get; set; }
        public TICMS10 ICMS10 { get; set; }
        public TICMS20 ICMS20 { get; set; }
        public TICMS30 ICMS30 { get; set; }
        public TICMS40 ICMS40 { get; set; }
        public TICMS51 ICMS51 { get; set; }
        public TICMS60 ICMS60 { get; set; }
        public TICMS70 ICMS70 { get; set; }
        public TICMS90 ICMS90 { get; set; }
        public TICMSPart ICMSPart { get; set; }
        public TICMSST ICMSST { get; set; }
        public TICMSSN101 ICMSSN101 { get; set; }
        public TICMSSN102 ICMSSN102 { get; set; }
        public TICMSSN201 ICMSSN201 { get; set; }
        public TICMSSN202 ICMSSN202 { get; set; }
        public TICMSSN500 ICMSSN500 { get; set; }
        public TICMSSN900 ICMSSN900 { get; set; }
    }
}
