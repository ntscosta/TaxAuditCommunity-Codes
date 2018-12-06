using System;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;

namespace TaxAuditCommunity.Domain.NFe.Det.Prod
{
    public class veicProd : veicProd<int>
    { }
    public class veicProd<TKey> : NodeBase<TKey>
        where TKey : IComparable<TKey>
    {
        public TKey prodId { get; set; }
        public tpOp tpOp { get; set; }
        public string chassi { get; set; }
        public string cCor { get; set; }
        public string xCor { get; set; }
        public string pot { get; set; }
        public string cilin { get; set; }
        public double pesoL { get; set; }
        public double pesoB { get; set; }
        public string nSerie { get; set; }
        public string tpComb { get; set; }
        public string nMotor { get; set; }
        public double CMT { get; set; }
        public string dist { get; set; }
        public int anoMod { get; set; }
        public int anoFab { get; set; }
        public byte tpPint { get; set; }
        public string tpVeic { get; set; }
        public byte espVeic { get; set; }
        public byte VIN { get; set; }
        public byte condVeic { get; set; }
        public string cMod { get; set; }
        public string cCorDENATRAN { get; set; }
        public int lota { get; set; }
        public byte tpRest { get; set; }
    }
}