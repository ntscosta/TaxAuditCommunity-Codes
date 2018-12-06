using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Transp
{
    public class transp : transp<string>
    { }
    public class transp<TKey> : transp<TKey, int>
        where TKey : IEquatable<TKey>
    { }
    public class transp<TKey, TintId> : transp<TKey, TintId, transporta, retTransp, veicTransp, reboque, vol>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    { }
    public class transp<TKey, TintId, Ttranporta, TretTransp, TveicTransp, Treboque, Tvol> : NodeBase<TintId>
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public TKey infNFeId { get; set; }
        public byte modFrete { get; set; }
        public Ttranporta transporta { get; set; }
        public TretTransp retTransp { get; set; }
        public TveicTransp veicTransp { get; set; }
        public ICollection<Treboque> reboque { get; set; }
        public int vagao { get; set; }
        public int balsa { get; set; }
        public ICollection<Tvol> vol { get; set; }
    }
}
