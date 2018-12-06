using System;
using System.Collections.Generic;
using System.Text;
using TaxAuditCommunity.Domain.NFe.Dest;
using TaxAuditCommunity.Domain.NFe.Emit;

namespace TaxAuditCommunity.Domain.NFe.TiposBasicos
{
    public class Tendereco : Tendereco<int>
    { }
    public class Tendereco<TKey> : Tendereco<TKey, emit, dest>
        where TKey : IComparable<TKey>
    { }
    public class Tendereco<TKey, TEmit, TDest> : TLocal<TKey>
        where TKey : IComparable<TKey>
    { 
        public TKey emitId { get; set; }
        public TKey destId { get; set; }
        public string CEP { get; set; }
        public int cPais { get; set; }
        public string xPais { get; set; }
        public string fone { get; set; }
    }
}
