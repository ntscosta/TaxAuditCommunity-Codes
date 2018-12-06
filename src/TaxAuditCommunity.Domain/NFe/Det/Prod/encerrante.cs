using System;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class encerrante : encerrante<int>
    { }
    public class encerrante<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey compId { get; set; }
        public string nBico { get; set; }
        public string nBomba { get; set; }
        public string nTanque { get; set; }
        public double vEncIni { get; set; }
        public double vEncFin { get; set; }
    }
}