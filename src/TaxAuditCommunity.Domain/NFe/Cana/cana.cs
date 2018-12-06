using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAuditCommunity.Domain.NFe.Cana
{
    public class cana : cana<string>
    { }
    public class cana<TKey> : cana<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class cana<TKey, TintId> : cana<TKey, TintId, forDia, deduc>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class cana<TKey, TintId, TforDia, Tdeduc> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public string safra { get; set; }
        public string _ref { get; set; }
        public ICollection<TforDia> forDia { get; set; } 
        public double qTotMes { get; set; }
        public double qTotAnt { get; set; }
        public double qTotGer { get; set; }
        public ICollection<Tdeduc> deduc { get; set; }
        public double vFor { get; set; }
        public double vTotDed { get; set; }
        public double vLiqFor { get; set; }
    }
}
