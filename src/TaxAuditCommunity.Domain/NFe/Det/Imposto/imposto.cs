using System;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.cofins;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.cofinsst;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.icms;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.icmsufdest;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.ii;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.ipi;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.issqn;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.pis;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.pisst;

namespace TaxAuditCommunity.Domain.NFe.Det.Imposto
{
    public class imposto : imposto<int>
    { }
    public class imposto<TKey> : imposto<TKey, ICMS, IPI, II, ISSQN, PIS, PISST, COFINS, COFINSST, ICMSUFDest>
        where TKey : IComparable<TKey>
    { }
    public class imposto<TKey, TICMS, TIPI, TII, TISSQN, TPIS, TPISST, TCOFINS, TCOFINSST, TICMSUFDest> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey detId { get; set; }
        public double vTotTrib { get; set; }
        public TICMS ICMS { get; set; }
        public TIPI IPI { get; set; }
        public TII II { get; set; }
        public TISSQN ISSQN { get; set; }
        public TPIS PIS { get; set; }
        public TPISST PISST { get; set; }
        public TCOFINS COFINS { get; set; }
        public TCOFINSST COFINSST { get; set; }
        public TICMSUFDest ICMSUFDest { get; set; }
    }
}