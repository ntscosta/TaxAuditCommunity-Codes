using Microsoft.EntityFrameworkCore;
using System;
using TaxAuditCommunity.Domain.NFe;
using TaxAuditCommunity.Domain.NFe.AutXML;
using TaxAuditCommunity.Domain.NFe.Avulsa;
using TaxAuditCommunity.Domain.NFe.Cana;
using TaxAuditCommunity.Domain.NFe.Cobr;
using TaxAuditCommunity.Domain.NFe.Compra;
using TaxAuditCommunity.Domain.NFe.Dest;
using TaxAuditCommunity.Domain.NFe.Det;
using TaxAuditCommunity.Domain.NFe.Det.Imposto;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.cofins;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.cofinsst;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.icms;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.icmsufdest;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.ii;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.ipi;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.issqn;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.pis;
using TaxAuditCommunity.Domain.NFe.Det.Imposto.pisst;
using TaxAuditCommunity.Domain.NFe.Det.ImpostoDevol;
using TaxAuditCommunity.Domain.NFe.Det.Prod;
using TaxAuditCommunity.Domain.NFe.Emit;
using TaxAuditCommunity.Domain.NFe.Entrega;
using TaxAuditCommunity.Domain.NFe.Exporta;
using TaxAuditCommunity.Domain.NFe.Ide;
using TaxAuditCommunity.Domain.NFe.InfAdic;
using TaxAuditCommunity.Domain.NFe.Pag;
using TaxAuditCommunity.Domain.NFe.Retirada;
using TaxAuditCommunity.Domain.NFe.TiposBasicos;
using TaxAuditCommunity.Domain.NFe.Total;
using TaxAuditCommunity.Domain.NFe.Transp;
using TaxAuditCommunity.Domain.procNFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TEvento;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TRetEvento;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TProtNFe;
using TaxAuditCommunity.Domain.procNFe.TRetConsSitNFe.TRetCancNFe;
using TaxAuditCommunity.Domain.Prosoft;

namespace TaxAuditCommunity.Data
{
    public class NFeDbContext : NFeDbContext<string, int>
    {
        public NFeDbContext()
        { }
        public NFeDbContext(string conn) : base(conn)
        {

        }
    }
    public class NFeDbContext<TKey, TIntId> : NFeDbContext<TKey, TIntId, NFe, infNFe, infNFeSupl, XmlNFe,
                                                           retConsSitNFe, protNFe, retCancNFe, procEventoNFe,infProt,
                                                           infCanc, evento, retEvento, 
                                                           Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TEvento.infEvento, 
                                                           Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TRetEvento.infEvento,
                                                           ide, emit, infAdic, obsCont,
                                                           obsFisco, procRef, enderEmit, enderDest, entrega, exporta,
                                                           NFref, refECF, refNF, refNFP, autXML, avulsa, cana, deduc, forDia, cobr, dup,
                                                           fat, compra, dest, det, prod, DI, adi, detExport, exportInd, rastro, veicProd, med, arma, comb, CIDE, encerrante,
                                                           imposto, COFINS, COFINSAliq, COFINSNT, COFINSOutr, COFINSQtde, COFINSST, PIS,
                                                           PISAliq, PISNT, PISOutr, PISQtde, PISST, ICMS, ICMS00, ICMS10, ICMS20, ICMS30,
                                                           ICMS40, ICMS51, ICMS60, ICMS70, ICMS90, ICMSPart, ICMSSN101, ICMSSN102,
                                                           ICMSSN201, ICMSSN202, ICMSSN500, ICMSSN900, ICMSST, ICMSUFDest, II, 
                                                           Domain.NFe.Det.Imposto.ipi.IPI, IPINT, IPITrib, ISSQN, impostoDevol,
                                                           Domain.NFe.Det.ImpostoDevol.IPI, pag, card, detPag, retirada, total, ICMSTot, ISSQNTot,
                                                           retTrib, transp, lacres, reboque, retTransp, transporta, veicTransp, vol, TProduto,
                                                           Empresas>
        where TKey : IEquatable<TKey>
        where TIntId : IComparable<TIntId>
    {
        public NFeDbContext()
        { }
        public NFeDbContext(string conn) : base(conn)
        {

        }
    }
    public class NFeDbContext<TKey, TIntId, TNFe, 
                              TInfNFe, TInfNFeSupl, TXmlNFe,
                              TRetConsSitNFe, TProtNFe, TRetCancNFe, TProcEventoNFe,
                              TInfProt, TInfCanc, TEvento, TRetEvento, TInfEvento, TinfEvento,
                              TIde, TEmit, TInfAdic, TObsCont, TObsFisco, TProcRef,
                              TEnderEmit, TEnderDest, TEntrega, TExporta,
                              TNFref, TRefECF, TRefNF, TRefNFP,
                              TAutXML, TAvulsa, TCana, TDeduc, TForDia, TCobr, TDup, TFat, TCompra, TDest, TDet, 
                              TProd, TdI, TAdi, TDetExport, TExportInd, TRastro, TVeicProd, TMed, TArma, TComb, TcIDE, TEncerrante, TImposto,
                              TcOFINS, TcOFINSAliq, TcOFINSNT, TcOFINSOutr, TcOFINSQtde, TcOFINSST,
                              TpIS, TpISAliq, TpISNT, TpISOutr, TpISQtde, TpISST,
                              TiCMS, TiCMS00, TiCMS10, TiCMS20, TiCMS30, TiCMS40, TiCMS51, TiCMS60, TiCMS70, TiCMS90,
                              TiCMSPart, TiCMSSN101, TiCMSSN102, TiCMSSN201, TiCMSSN202, TiCMSSN500, TiCMSSN900, TiCMSST, TiCMSUFDest,
                              TiI, TiPI, TiPINT, TiPITrib, TiSSQN, TImpostoDevol, TiPIDevol,
                              TPag, TCard, TDetPag, TRetirada,
                              TTotal, TiCMSTot, TiSSQNTot, TRetTrib,
                              TTransp, TLacres, TReboque, TRetTransp, TTransporta, TVeicTransp, TVol, TprodutoBase,
                              TEmpresas> : DbContext
        where TKey : IEquatable<TKey>
        where TIntId : IComparable<TIntId>

        where TNFe : NFe
        where TInfNFe : infNFe

        where TIde : ide
            where TNFref : NFref
                where TRefNF : refNF
                where TRefNFP : refNFP
                where TRefECF : refECF

        where TEmit : emit

        where TAvulsa : avulsa

        where TDest : dest

        where TRetirada : retirada

        where TEntrega : entrega

        where TAutXML : autXML

        where TDet : det
            where TProd : prod
                where TdI : DI
                    where TAdi : adi
                where TDetExport : detExport
                    where TExportInd : exportInd
                
                where TRastro : rastro
                where TVeicProd : veicProd
                where TMed : med
                where TArma : arma
                where TComb : comb
                    where TcIDE : CIDE
                    where TEncerrante : encerrante


            where TImposto : imposto
                where TiCMS : ICMS
                    where TiCMS00 : ICMS00
                    where TiCMS10 : ICMS10
                    where TiCMS20 : ICMS20
                    where TiCMS30 : ICMS30
                    where TiCMS40 : ICMS40
                    where TiCMS51 : ICMS51
                    where TiCMS60 : ICMS60
                    where TiCMS70 : ICMS70
                    where TiCMS90 : ICMS90
                    where TiCMSPart : ICMSPart
                    where TiCMSST : ICMSST
                    where TiCMSSN101 : ICMSSN101
                    where TiCMSSN102 : ICMSSN102
                    where TiCMSSN201 : ICMSSN201
                    where TiCMSSN202 : ICMSSN202
                    where TiCMSSN500 : ICMSSN500
                    where TiCMSSN900 : ICMSSN900
            
                where TiPI : Domain.NFe.Det.Imposto.ipi.IPI
                    where TiPINT : IPINT
                    where TiPITrib : IPITrib
                
                where TiI : II
                
                where TiSSQN : ISSQN

                where TpIS : PIS
                    where TpISAliq : PISAliq
                    where TpISQtde : PISQtde
                    where TpISNT : PISNT
                    where TpISOutr : PISOutr
                
                where TpISST : PISST
                
                where TcOFINS : COFINS
                     where TcOFINSAliq : COFINSAliq
                     where TcOFINSQtde : COFINSQtde
                     where TcOFINSNT : COFINSNT
                     where TcOFINSOutr : COFINSOutr

                where TcOFINSST : COFINSST

                where TiCMSUFDest : ICMSUFDest

            where TImpostoDevol : impostoDevol
                
                where TiPIDevol : Domain.NFe.Det.ImpostoDevol.IPI

        where TTotal : total
            where TiCMSTot : ICMSTot
            where TiSSQNTot : ISSQNTot
            where TRetTrib : retTrib

        where TTransp : transp
            where TTransporta : transporta
            where TRetTransp : retTransp
            where TReboque : reboque
            where TVeicTransp : veicTransp
            where TVol : vol
                where TLacres : lacres

        where TCobr : cobr
            where TFat : fat
            where TDup : dup

        where TPag : pag
            where TDetPag : detPag
                where TCard : card

        where TInfAdic : infAdic
            where TObsCont : obsCont
            where TObsFisco : obsFisco
            where TProcRef : procRef

        where TExporta : exporta

        where TCompra : compra

        where TCana : cana
            where TForDia : forDia
            where TDeduc : deduc

        where TEnderEmit : enderEmit
        where TEnderDest : enderDest
        where TprodutoBase : TProduto

        where TInfNFeSupl : infNFeSupl
        where TXmlNFe : XmlNFe

        where TRetConsSitNFe : retConsSitNFe
            where TProtNFe : protNFe
                where TInfProt : infProt
            where TRetCancNFe : retCancNFe
                where TInfCanc : infCanc
            where TProcEventoNFe : procEventoNFe
                where TEvento : evento
                    where TInfEvento : Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TEvento.infEvento
                where TRetEvento : retEvento
                    where TinfEvento : Domain.procNFe.TRetConsSitNFe.TProcEventoNFe.TRetEvento.infEvento

        where TEmpresas : Empresas

    {
        public NFeDbContext()
        { }



        public NFeDbContext(string conn)
        {
            Connection = conn;
            //Database.Migrate();
        }

        protected readonly string Connection;

        public DbSet<TNFe> NFe { get; set; }
        public DbSet<TInfNFe> infNFe { get; set; }
        public DbSet<TIde> ide { get; set; }
        public DbSet<TNFref> NFref { get; set; }
        public DbSet<TRefNF> refNF { get; set; }
        public DbSet<TRefNFP> refNFP { get; set; }
        public DbSet<TRefECF> refECF { get; set; }
        public DbSet<TEmit> emit { get; set; }
        public DbSet<TEnderEmit> enderEmit { get; set; }
        public DbSet<TEnderDest> enderDest { get; set; }
        public DbSet<TAvulsa> avulsa { get; set; }
        public DbSet<TDest> dest { get; set; }
        public DbSet<TRetirada> retirada { get; set; }
        public DbSet<TEntrega> entrega { get; set; }
        public DbSet<TAutXML> autXML { get; set; }
        public DbSet<TDet> det { get; set; }
        public DbSet<TProd> prod { get; set; }
        public DbSet<TdI> DI { get; set; }
        public DbSet<TAdi> adi { get; set; }
        public DbSet<TDetExport> detExport { get; set; }
        public DbSet<TExportInd> exportInd { get; set; }
        public DbSet<TRastro> rastro { get; set; }
        public DbSet<TVeicProd> veicProd { get; set; }
        public DbSet<TMed> med { get; set; }
        public DbSet<TArma> arma { get; set; }
        public DbSet<TComb> comb { get; set; }
        public DbSet<TcIDE> CIDE { get; set; }
        public DbSet<TEncerrante> encerrante { get; set; }
        public DbSet<TImposto> imposto { get; set; }
        public DbSet<TiCMS> ICMS { get; set; }
        public DbSet<TiCMS00> ICMS00 { get; set; }
        public DbSet<TiCMS10> ICMS10 { get; set; }
        public DbSet<TiCMS20> ICMS20 { get; set; }
        public DbSet<TiCMS30> ICMS30 { get; set; }
        public DbSet<TiCMS40> ICMS40 { get; set; }
        public DbSet<TiCMS51> ICMS51 { get; set; }
        public DbSet<TiCMS60> ICMS60 { get; set; }
        public DbSet<TiCMS70> ICMS70 { get; set; }
        public DbSet<TiCMS90> ICMS90 { get; set; }
        public DbSet<TiCMSPart> ICMSPart { get; set; }
        public DbSet<TiCMSST> ICMSST { get; set; }
        public DbSet<TiCMSSN101> ICMSSN101 { get; set; }
        public DbSet<TiCMSSN102> ICMSSN102 { get; set; }
        public DbSet<TiCMSSN201> ICMSSN201 { get; set; }
        public DbSet<TiCMSSN202> ICMSSN202 { get; set; }
        public DbSet<TiCMSSN500> ICMSSN500 { get; set; }
        public DbSet<TiCMSSN900> ICMSSN900 { get; set; }
        public DbSet<TiPI> IPI { get; set; }
        public DbSet<TiPITrib> IPITrib { get; set; }
        public DbSet<TiPINT> IPINT { get; set; }
        public DbSet<TiI> II { get; set; }
        public DbSet<TiSSQN> ISSQN { get; set; }
        public DbSet<TpIS> PIS { get; set; }
        public DbSet<TpISAliq> PISAliq { get; set; }
        public DbSet<TpISQtde> PISQtde { get; set; }
        public DbSet<TpISNT> PISNT { get; set; }
        public DbSet<TpISOutr> PISOutr { get; set; }
        public DbSet<TpISST> PISST { get; set; }
        public DbSet<TpIS> COFINS { get; set; }
        public DbSet<TpISAliq> COFINSAliq { get; set; }
        public DbSet<TpISQtde> COFINSQtde { get; set; }
        public DbSet<TpISNT> COFINSNT { get; set; }
        public DbSet<TpISOutr> COFINSOutr { get; set; }
        public DbSet<TpISST> COFINSST { get; set; }
        public DbSet<TiCMSUFDest> ICMSUFDest { get; set; }
        public DbSet<TImpostoDevol> impostoDevol { get; set; }
        public DbSet<TiPIDevol> IPIDevol { get; set; }
        public DbSet<TTotal> total { get; set; }
        public DbSet<TiCMSTot> ICMSTot { get; set; }
        public DbSet<TiSSQNTot> ISSQNTot { get; set; }
        public DbSet<TRetTrib> retTrib { get; set; }
        public DbSet<TTransp> transp { get; set; }
        public DbSet<TTransporta> transporta { get; set; }
        public DbSet<TRetTransp> retTransp { get; set; }
        public DbSet<TVeicTransp> veicTransp { get; set; }
        public DbSet<TReboque> reboque { get; set; }
        public DbSet<TVol> vol { get; set; }
        public DbSet<TLacres> lacres { get; set; }
        public DbSet<TCobr> cobr { get; set; }
        public DbSet<TFat> fat { get; set; }
        public DbSet<TDup> dup { get; set; }
        public DbSet<TPag> pag { get; set; }
        public DbSet<TDetPag> detPag { get; set; }
        public DbSet<TCard> card { get; set; }
        public DbSet<TInfAdic> infAdic { get; set; }
        public DbSet<TObsCont> obsCont { get; set; }
        public DbSet<TObsFisco> obsFisco { get; set; }
        public DbSet<TProcRef> procRef { get; set; }
        public DbSet<TExporta> exporta { get; set; }
        public DbSet<TCompra> compra { get; set; }
        public DbSet<TCana> cana { get; set; }
        public DbSet<TForDia> forDia { get; set; }
        public DbSet<TDeduc> deduc { get; set; }

        public DbSet<TprodutoBase> tprodutoBases { get; set; }

        public DbSet<TInfNFeSupl> infNFeSupl { get; set; }
        public DbSet<TXmlNFe> xmlNFe { get; set; }


        public DbSet<TRetConsSitNFe> retConsSitNFe { get; set; }
        public DbSet<TProtNFe> protNFe { get; set; }
        public DbSet<TInfProt> infProt { get; set; }
        public DbSet<TRetCancNFe> retCancNFe { get; set; }
        public DbSet<TInfCanc> infCanc { get; set; }
        public DbSet<TProcEventoNFe> procEventoNFe { get; set; }
        public DbSet<TRetEvento> retEvento { get; set; }
        public DbSet<TinfEvento> infEvento { get; set; }
        public DbSet<TEvento> evento { get; set; }
        public DbSet<TInfEvento> InfEvento { get; set; }

        public DbSet<TEmpresas> Empresas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TNFe>(b =>
            {
                b.Property(n => n.Id).HasMaxLength(44).IsRequired();
                b.HasIndex(n => n.Hash).IsUnique();
                b.Property(n => n.Hash).IsRequired();

                b.HasOne(n => n.infNFe).WithOne().HasForeignKey<TInfNFe>(i => i.NFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(n => n.infNFeSupl).WithOne().HasForeignKey<TInfNFeSupl>(i => i.NFeId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TXmlNFe>(b =>
            {
                b.Property(x => x.Id);
                b.HasIndex(x => x.NFeId);
                b.HasIndex(x => x.DhChange);

                b.Property(x => x.NFeId).HasMaxLength(44).IsRequired();
                b.Property(x => x.FileNFe).HasColumnType("xml").IsRequired();

                b.HasOne(x => x.retConsSitNFe).WithOne().HasForeignKey<TRetConsSitNFe>(retconsitnfe => retconsitnfe.XmlNFeId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TRetConsSitNFe>(b =>
            {
                b.HasKey(r => r.Id);

                b.Property(r => r.tpAmb);
                b.Property(r => r.verAplic).HasMaxLength(20);
                b.Property(r => r.cStat).HasMaxLength(3);
                b.Property(r => r.xMotivo).HasMaxLength(255);
                b.Property(r => r.cUF);
                b.Property(r => r.dhRecibo);
                b.Property(r => r.chNFe).HasMaxLength(44);
                b.Property(r => r.versao).HasMaxLength(4);

                b.HasOne(r => r.protNFe).WithOne().HasForeignKey<TProtNFe>(protNFe => protNFe.retConsSitNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(r => r.retCancNFe).WithOne().HasForeignKey<TRetCancNFe>(retCancNFe => retCancNFe.retConsSitNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(r => r.procEventoNFe).WithOne().HasForeignKey(procEventoNFe => procEventoNFe.retConsSitNFeId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TProtNFe>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.versao).HasMaxLength(4);

                b.HasOne(p => p.infProt).WithOne().HasForeignKey<TInfProt>(infprot => infprot.protNFeId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TInfProt>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.tpAmb);
                b.Property(i => i.verAplic).HasMaxLength(20);
                b.Property(i => i.chNFe).HasMaxLength(44);
                b.Property(i => i.dhRecibo);
                b.Property(i => i.nProt).HasMaxLength(15);
                b.Property(i => i.digVal);
                b.Property(i => i.cStat).HasMaxLength(3);
                b.Property(i => i.xMotivo).HasMaxLength(255);
            });

            builder.Entity<TRetCancNFe>(b =>
            {
                b.HasKey(r => r.Id);

                b.Property(r => r.versao).HasMaxLength(4);

                b.HasOne(r => r.infCanc).WithOne().HasForeignKey<TInfCanc>(infcanc => infcanc.retCancNFeId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TInfCanc>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.tpAmb);
                b.Property(i => i.verAplic).HasMaxLength(4);
                b.Property(i => i.cStat).HasMaxLength(3);
                b.Property(i => i.xMotivo).HasMaxLength(255);
                b.Property(i => i.cUF);
                b.Property(i => i.chNFe).HasMaxLength(44);
                b.Property(i => i.dhRecibo);
                b.Property(i => i.nProt).HasMaxLength(15);
            });

            builder.Entity<TProcEventoNFe>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.versao).HasMaxLength(4);

                b.HasOne(p => p.evento).WithOne().HasForeignKey<TEvento>(evento => evento.procEventoNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.retEvento).WithOne().HasForeignKey<TRetEvento>(retevento => retevento.procEventoNFeId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TEvento>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.versao).HasMaxLength(4);

                b.HasOne(e => e.infEvento).WithOne().HasForeignKey<TInfEvento>(infevento => infevento.eventoId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TInfEvento>(b =>
            {
                b.ToTable("infEvento");
                b.HasKey(i => i.Id);

                b.Property(i => i.cOrgao).HasMaxLength(2);
                b.Property(i => i.tpAmb);
                b.Property(i => i.CNPJ).HasMaxLength(14);
                b.Property(i => i.CPF).HasMaxLength(11);
                b.Property(i => i.chNFe).HasMaxLength(44);
                b.Property(i => i.dhEvento);
                b.Property(i => i.tpEvento).HasMaxLength(6);
                b.Property(i => i.nSeqEvento).HasMaxLength(2);
                b.Property(i => i.verEvento);
                b.Property(i => i.detEvento).HasColumnType("xml");
            });

            builder.Entity<TRetEvento>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.versao).HasMaxLength(4);

                b.HasOne(e => e.infEvento).WithOne().HasForeignKey<TinfEvento>(infevento => infevento.retEventoId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TinfEvento>(b =>
            {
                b.ToTable("retinfEvento");
                b.HasKey(i => i.Id);

                b.Property(i => i.cOrgao).HasMaxLength(2);
                b.Property(i => i.tpAmb);
                b.Property(i => i.verAplic).HasMaxLength(20);
                b.Property(i => i.cOrgao).HasMaxLength(2);
                b.Property(i => i.cStat).HasMaxLength(3);
                b.Property(i => i.xMotivo).HasMaxLength(255);
                b.Property(i => i.chNFe).HasMaxLength(44);
                b.Property(i => i.tpEvento).HasMaxLength(6);
                b.Property(i => i.xEvento).HasMaxLength(60);
                b.Property(i => i.nSeqEvento).HasMaxLength(2);
                b.Property(i => i.CNPJDest).HasMaxLength(14);
                b.Property(i => i.CPFDest).HasMaxLength(11);
                b.Property(i => i.emailDest).HasMaxLength(60);
                b.Property(i => i.dhRegEvento);
                b.Property(i => i.nProt).HasMaxLength(15);
            });

            builder.Entity<TInfNFe>(b =>
            {
                b.HasKey(i => i.Id);

                b.HasIndex(i => i.versao);
                b.Property(i => i.Id).HasMaxLength(44);
                b.Property(i => i.versao).HasMaxLength(5).IsRequired();


                b.HasOne(i => i.ide).WithOne().HasForeignKey<TIde>(ide => ide.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.emit).WithOne().HasForeignKey<TEmit>(emit => emit.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.dest).WithOne().HasForeignKey<TDest>(dest => dest.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.avulsa).WithOne().HasForeignKey<TAvulsa>(avulsa => avulsa.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.retirada).WithOne().HasForeignKey<TRetirada>(retirada => retirada.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.entrega).WithOne().HasForeignKey<TEntrega>(entrega => entrega.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(i => i.autXML).WithOne().HasForeignKey(autxml => autxml.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(i => i.det).WithOne().HasForeignKey(det => det.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.total).WithOne().HasForeignKey<TTotal>(total => total.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.transp).WithOne().HasForeignKey<TTransp>(transp => transp.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.cobr).WithOne().HasForeignKey<TCobr>(cobr => cobr.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.pag).WithOne().HasForeignKey<TPag>(pag => pag.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.infAdic).WithOne().HasForeignKey<TInfAdic>(infAdic => infAdic.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.exporta).WithOne().HasForeignKey<TExporta>(exporta => exporta.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.compra).WithOne().HasForeignKey<TCompra>(compra => compra.infNFeId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.cana).WithOne().HasForeignKey<TCana>(cana => cana.infNFeId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TIde>(b =>
            {
                b.HasKey(i => i.Id);
                b.HasIndex(i => i.cUF);
                b.HasIndex(i => i.nNF);
                b.HasIndex(i => i.idDest);
                b.HasIndex(i => i.cMunFG);
                b.HasIndex(i => i.finNFe);
                b.HasIndex(i => i.indFinal);

                b.Property(i => i.cUF).IsRequired();
                b.Property(i => i.cNF).IsRequired();
                b.Property(i => i.natOp).HasMaxLength(60).IsRequired();
                b.Property(i => i.mod).IsRequired();
                b.Property(i => i.serie).IsRequired();
                b.Property(i => i.nNF).HasMaxLength(9).IsRequired();
                b.Property(i => i.dhEmi).IsRequired();
                b.Property(i => i.dhSaiEnt);
                b.Property(i => i.tpNF).IsRequired();
                b.Property(i => i.idDest).IsRequired();
                b.Property(i => i.cMunFG).HasMaxLength(7).IsRequired();
                b.Property(i => i.tpImp).IsRequired();
                b.Property(i => i.tpEmis).IsRequired();
                b.Property(i => i.cDV).HasMaxLength(1).IsRequired();
                b.Property(i => i.tpAmb).IsRequired();
                b.Property(i => i.finNFe).IsRequired();
                b.Property(i => i.indFinal).IsRequired();
                b.Property(i => i.indPres).IsRequired();
                b.Property(i => i.procEmi).IsRequired();
                b.Property(i => i.verProc).HasMaxLength(20).IsRequired();
                b.Property(i => i.dhCont);
                b.Property(i => i.xJust).HasMaxLength(256);

                b.HasMany(i => i.NFref).WithOne().HasForeignKey(NFref => NFref.ideId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TNFref>(b =>
            {
                b.HasKey(n => n.Id);

                b.Property(n => n.refNFe).HasMaxLength(44);
                b.Property(n => n.refCTe).HasMaxLength(44);

                b.HasOne(n => n.refNF).WithOne().HasForeignKey<TRefNF>(refNF => refNF.NFrefId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(n => n.refNFP).WithOne().HasForeignKey<TRefNFP>(refNFP => refNFP.NFrefId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(n => n.refECF).WithOne().HasForeignKey<TRefECF>(refECF => refECF.NFrefId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TRefNF>(b =>
            {
                b.HasKey(r => r.Id);

                b.Property(r => r.cUF).HasMaxLength(7).IsRequired();
                b.Property(r => r.AAMM).HasMaxLength(4).IsRequired();
                b.Property(r => r.CNPJ).HasMaxLength(14).IsRequired();
                b.Property(r => r.mod).IsRequired();
                b.Property(r => r.serie).HasMaxLength(2).IsRequired();
                b.Property(r => r.nNF).HasMaxLength(9).IsRequired();
            });
            builder.Entity<TRefNFP>(b =>
            {
                b.HasKey(r => r.Id);

                b.HasKey(r => r.Id);

                b.Property(r => r.cUF).HasMaxLength(7).IsRequired();
                b.Property(r => r.AAMM).HasMaxLength(4).IsRequired();
                b.Property(r => r.CNPJ).HasMaxLength(14);
                b.Property(r => r.CPF).HasMaxLength(11);
                b.Property(r => r.mod).IsRequired();
                b.Property(r => r.serie).HasMaxLength(2).IsRequired();
                b.Property(r => r.nNF).HasMaxLength(9).IsRequired();
            });
            builder.Entity<TRefECF>(b =>
            {
                b.HasKey(r => r.Id);

                b.Property(r => r.mod).HasMaxLength(2).IsRequired();
                b.Property(r => r.nECF).IsRequired();
                b.Property(r => r.nCOO).IsRequired();
            });

            builder.Entity<TEmit>(b =>
            {
                b.HasKey(e => e.Id);

                b.HasIndex(e => e.CNPJ);
                b.HasIndex(e => e.CPF);
                b.HasIndex(e => e.xNome);
                b.HasIndex(e => e.xFant);

                b.Property(e => e.CNPJ).HasMaxLength(14);
                b.Property(e => e.CPF).HasMaxLength(11);
                b.Property(e => e.xNome).HasMaxLength(60).IsRequired();
                b.Property(e => e.xFant).HasMaxLength(60);
                b.Property(e => e.IE).HasMaxLength(14).IsRequired();
                b.Property(e => e.IEST).HasMaxLength(14);
                b.Property(e => e.IM).HasMaxLength(15);
                b.Property(e => e.CNAE).HasMaxLength(7);
                b.Property(e => e.CRT).IsRequired();

                b.HasOne(e => e.enderEmit).WithOne().HasForeignKey<TEnderEmit>(enderemit => enderemit.emitId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TDest>(b =>
            {
                b.HasKey(d => d.Id);

                b.HasIndex(d => d.CNPJ);
                b.HasIndex(d => d.CPF);
                b.HasIndex(d => d.xNome);

                b.Property(d => d.CNPJ).HasMaxLength(14);
                b.Property(d => d.CPF).HasMaxLength(11);
                b.Property(d => d.idEstrangeiro).HasMaxLength(20);
                b.Property(d => d.xNome).HasMaxLength(60);
                b.Property(d => d.indIEDest).IsRequired();
                b.Property(d => d.IE).HasMaxLength(14);
                b.Property(d => d.ISUF).HasMaxLength(9);
                b.Property(d => d.IM).HasMaxLength(15);
                b.Property(d => d.email).HasMaxLength(60);

                b.HasOne(d => d.enderDest).WithOne().HasForeignKey<TEnderDest>(enderdest => enderdest.destId).OnDelete(DeleteBehavior.Cascade);

            });
            builder.Entity<TEnderEmit>(b =>
            {
                b.HasKey(e => e.Id);

                b.HasIndex(e => e.xLgr);
                b.HasIndex(e => e.nro);
                b.HasIndex(e => e.xBairro);
                b.HasIndex(e => e.cMun);
                b.HasIndex(e => e.xMun);
                b.HasIndex(e => e.UF);

                b.Property(e => e.xLgr).HasMaxLength(60).IsRequired();
                b.Property(e => e.nro).HasMaxLength(60).IsRequired();
                b.Property(e => e.xCpl).HasMaxLength(60);
                b.Property(e => e.xBairro).HasMaxLength(60).IsRequired();
                b.Property(e => e.cMun).HasMaxLength(7).IsRequired();
                b.Property(e => e.xMun).HasMaxLength(60).IsRequired();
                b.Property(e => e.UF).IsRequired();
                b.Property(e => e.CEP).HasMaxLength(60);
                b.Property(e => e.cPais).HasMaxLength(60);
                b.Property(e => e.xPais).HasMaxLength(60);
                b.Property(e => e.fone).HasMaxLength(60);
            });
            builder.Entity<TEnderDest>(b =>
            {
                b.HasKey(e => e.Id);

                b.HasIndex(e => e.xLgr);
                b.HasIndex(e => e.nro);
                b.HasIndex(e => e.xBairro);
                b.HasIndex(e => e.cMun);
                b.HasIndex(e => e.xMun);
                b.HasIndex(e => e.UF);

                b.Property(e => e.xLgr).HasMaxLength(60).IsRequired();
                b.Property(e => e.nro).HasMaxLength(60).IsRequired();
                b.Property(e => e.xCpl).HasMaxLength(60);
                b.Property(e => e.xBairro).HasMaxLength(60).IsRequired();
                b.Property(e => e.cMun).HasMaxLength(7).IsRequired();
                b.Property(e => e.xMun).HasMaxLength(60).IsRequired();
                b.Property(e => e.UF).IsRequired();
                b.Property(e => e.CEP).HasMaxLength(60);
                b.Property(e => e.cPais).HasMaxLength(60);
                b.Property(e => e.xPais).HasMaxLength(60);
                b.Property(e => e.fone).HasMaxLength(60);
            });
            builder.Entity<TAvulsa>(b =>
            {
                b.HasKey(a => a.Id);

                b.HasIndex(a => a.CNPJ);
                b.HasIndex(a => a.xAgente);
                b.HasIndex(a => a.xOrgao);

                b.Property(a => a.CNPJ).HasMaxLength(14).IsRequired();
                b.Property(a => a.xOrgao).HasMaxLength(60).IsRequired();
                b.Property(a => a.matr).HasMaxLength(60).IsRequired();
                b.Property(a => a.xAgente).HasMaxLength(60).IsRequired();
                b.Property(a => a.fone).HasMaxLength(14);
                b.Property(a => a.UF).IsRequired();
                b.Property(a => a.nDAR).HasMaxLength(60);
                b.Property(a => a.dEmi);
                b.Property(a => a.vDAR);
                b.Property(a => a.repEmit).HasMaxLength(60);
                b.Property(a => a.dPag);
            });

            builder.Entity<TRetirada>(b =>
            {
                b.HasKey(l => l.Id);

                b.HasIndex(e => e.xLgr);
                b.HasIndex(e => e.xBairro);
                b.HasIndex(e => e.cMun);
                b.HasIndex(e => e.xMun);
                b.HasIndex(e => e.UF);

                b.Property(e => e.xLgr).HasMaxLength(60).IsRequired();
                b.Property(e => e.nro).HasMaxLength(60).IsRequired();
                b.Property(e => e.xCpl).HasMaxLength(60);
                b.Property(e => e.xBairro).HasMaxLength(60).IsRequired();
                b.Property(e => e.cMun).HasMaxLength(7).IsRequired();
                b.Property(e => e.xMun).HasMaxLength(60).IsRequired();
                b.Property(e => e.UF).IsRequired();
            });

            builder.Entity<TEntrega>(b =>
            {
                b.HasKey(l => l.Id);

                b.HasIndex(e => e.xLgr);
                b.HasIndex(e => e.xBairro);
                b.HasIndex(e => e.cMun);
                b.HasIndex(e => e.xMun);
                b.HasIndex(e => e.UF);

                b.Property(e => e.xLgr).HasMaxLength(60).IsRequired();
                b.Property(e => e.nro).HasMaxLength(60).IsRequired();
                b.Property(e => e.xCpl).HasMaxLength(60);
                b.Property(e => e.xBairro).HasMaxLength(60).IsRequired();
                b.Property(e => e.cMun).HasMaxLength(7).IsRequired();
                b.Property(e => e.xMun).HasMaxLength(60).IsRequired();
                b.Property(e => e.UF).IsRequired();
            });

            builder.Entity<TAutXML>(b =>
            {
                b.HasKey(a => a.Id);
                b.HasIndex(a => a.CNPJ);
                b.HasIndex(a => a.CPF);

                b.Property(a => a.CNPJ).HasMaxLength(14);
                b.Property(a => a.CPF).HasMaxLength(11);
            });

            builder.Entity<TDet>(b =>
            {
                b.HasKey(d => d.Id);

                b.Property(d => d.nItem).HasMaxLength(3).IsRequired();
                b.Property(d => d.infAdProd).HasMaxLength(500);

                b.HasOne(d => d.prod).WithOne().HasForeignKey<TProd>(prod => prod.detId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(d => d.imposto).WithOne().HasForeignKey<TImposto>(imposto => imposto.detId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(d => d.impostoDevol).WithOne().HasForeignKey<TImpostoDevol>(impostoDevol => impostoDevol.detId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TProd>(b =>
            {
                b.HasKey(p => p.Id);

                b.HasIndex(p => p.cProd);
                b.HasIndex(p => p.xProd);
                b.HasIndex(p => p.NCM);
                b.HasIndex(p => p.CEST);

                b.Property(p => p.cProd).HasMaxLength(60).IsRequired();
                b.Property(p => p.cEAN).HasMaxLength(14);
                b.Property(p => p.NCM).HasMaxLength(8).IsRequired();
                b.Property(p => p.NVE).HasMaxLength(6);
                b.Property(p => p.CEST).HasMaxLength(7);
                b.Property(p => p.indEscala);
                b.Property(p => p.CNPJFab).HasMaxLength(14);
                b.Property(p => p.cBenef).HasMaxLength(10);
                b.Property(p => p.EXTIPI).HasMaxLength(3);
                b.Property(p => p.CFOP).HasMaxLength(4).IsRequired();
                b.Property(p => p.uCom).IsRequired();
                b.Property(p => p.qCom).IsRequired();
                b.Property(p => p.vUnCom).IsRequired();
                b.Property(p => p.vProd).IsRequired();
                b.Property(p => p.cEANTrib);
                b.Property(p => p.uTrib).HasMaxLength(6).IsRequired();
                b.Property(p => p.qTrib).IsRequired();
                b.Property(p => p.vUnTrib).IsRequired();
                b.Property(p => p.vFrete);
                b.Property(p => p.vSeg);
                b.Property(p => p.vDesc);
                b.Property(p => p.vOutro);
                b.Property(p => p.indTot).IsRequired();
                b.Property(p => p.xPed).HasMaxLength(15);
                b.Property(p => p.nItemPed).HasMaxLength(6);
                b.Property(p => p.nFCI).HasMaxLength(36);
                b.Property(p => p.nRECOPI).HasMaxLength(20);

                b.HasMany(p => p.DI).WithOne().HasForeignKey(di => di.prodId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.detExport).WithOne().HasForeignKey(detExport => detExport.prodId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.rastro).WithOne().HasForeignKey(rastro => rastro.prodId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.veicProd).WithOne().HasForeignKey<TVeicProd>(veicProd => veicProd.prodId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.med).WithOne().HasForeignKey<TMed>(med => med.prodId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.arma).WithOne().HasForeignKey(arma => arma.prodId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.comb).WithOne().HasForeignKey<TComb>(comb => comb.prodId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TdI>(b =>
            {
                b.HasKey(d => d.Id);

                b.Property(d => d.nDI).HasMaxLength(12).IsRequired();
                b.Property(d => d.dDI).IsRequired();
                b.Property(d => d.xLocDesemb).HasMaxLength(60).IsRequired();
                b.Property(d => d.UFDesemb).IsRequired();
                b.Property(d => d.tpViaTransp).IsRequired();
                b.Property(d => d.vAFRMM);
                b.Property(d => d.tpIntermedio).IsRequired();
                b.Property(d => d.CNPJ).HasMaxLength(14);
                b.Property(d => d.UFTerceiro);
                b.Property(d => d.cExportador).HasMaxLength(2).IsRequired();

                b.HasMany(d => d.adi).WithOne().HasForeignKey(adi => adi.DIid).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TAdi>(b =>
            {
                b.HasKey(a => a.Id);

                b.Property(a => a.nAdicao).IsRequired();
                b.Property(a => a.nSeqAdic).IsRequired();
                b.Property(a => a.cFabricante).HasMaxLength(60).IsRequired();
                b.Property(a => a.vDescDI);
                b.Property(a => a.nDraw).HasMaxLength(11);
            });
            builder.Entity<TDetExport>(b =>
            {
                b.HasKey(d => d.Id);

                b.Property(d => d.nDraw).HasMaxLength(11);

                b.HasMany(d => d.exportInd).WithOne().HasForeignKey(exportind => exportind.detExportId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TExportInd>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.nRE).HasMaxLength(12).IsRequired();
                b.Property(e => e.chNFe).HasMaxLength(44).IsRequired();
                b.Property(e => e.qExport).IsRequired();
            });
            builder.Entity<TRastro>(b =>
            {
                b.HasKey(r => r.Id);

                b.Property(r => r.nLote).HasMaxLength(20).IsRequired();
                b.Property(r => r.qLote).IsRequired();
                b.Property(r => r.dFab).IsRequired();
                b.Property(r => r.dVal).IsRequired();
                b.Property(r => r.cAgreg).HasMaxLength(20);
            });
            builder.Entity<TVeicProd>(b =>
            {
                b.HasKey(v => v.Id);

                b.Property(v => v.tpOp).IsRequired();
                b.Property(v => v.chassi).HasMaxLength(17).IsRequired();
                b.Property(v => v.cCor).HasMaxLength(4).IsRequired();
                b.Property(v => v.xCor).HasMaxLength(40).IsRequired();
                b.Property(v => v.pot).HasMaxLength(4).IsRequired();
                b.Property(v => v.cilin).HasMaxLength(4).IsRequired();
                b.Property(v => v.pesoL).HasMaxLength(9).IsRequired();
                b.Property(v => v.pesoB).HasMaxLength(9).IsRequired();
                b.Property(v => v.nSerie).HasMaxLength(9).IsRequired();
                b.Property(v => v.tpComb).HasMaxLength(2).IsRequired();
                b.Property(v => v.nMotor).HasMaxLength(21).IsRequired();
                b.Property(v => v.CMT).HasMaxLength(9).IsRequired();
                b.Property(v => v.dist).HasMaxLength(4).IsRequired();
                b.Property(v => v.anoMod).HasMaxLength(4).IsRequired();
                b.Property(v => v.anoFab).HasMaxLength(4).IsRequired();
                b.Property(v => v.tpPint).HasMaxLength(1).IsRequired();
                b.Property(v => v.tpVeic).HasMaxLength(2).IsRequired();
                b.Property(v => v.espVeic).HasMaxLength(1).IsRequired();
                b.Property(v => v.VIN).HasMaxLength(1).IsRequired();
                b.Property(v => v.condVeic).HasMaxLength(1).IsRequired();
                b.Property(v => v.cMod).HasMaxLength(6).IsRequired();
                b.Property(v => v.cCorDENATRAN).HasMaxLength(2).IsRequired();
                b.Property(v => v.lota).HasMaxLength(3).IsRequired();
                b.Property(v => v.tpRest).HasMaxLength(1).IsRequired();
            });
            builder.Entity<TMed>(b =>
            {
                b.HasKey(m => m.Id);

                b.Property(m => m.nLote).HasMaxLength(20);
                b.Property(m => m.qLote);
                b.Property(m => m.dFab);
                b.Property(m => m.dVal);

                b.Property(m => m.cProdANVISA).HasMaxLength(13);
                b.Property(m => m.vPMC);
            });
            builder.Entity<TArma>(b =>
            {
                b.HasKey(a => a.Id);

                b.Property(a => a.tpArma).HasMaxLength(1).IsRequired();
                b.Property(a => a.nSerie).HasMaxLength(15).IsRequired();
                b.Property(a => a.nCano).HasMaxLength(15).IsRequired();
                b.Property(a => a.descr).IsRequired();
            });
            builder.Entity<TComb>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.cProdANP).HasMaxLength(9).IsRequired();
                b.Property(c => c.pGLP);
                b.Property(c => c.pGNn);
                b.Property(c => c.pGNi);
                b.Property(c => c.vPart);
                b.Property(c => c.CODIF).HasMaxLength(21);
                b.Property(c => c.qTemp);
                b.Property(c => c.UFCons).IsRequired();

                b.HasOne(c => c.CIDE).WithOne().HasForeignKey<TcIDE>(cide => cide.compId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(c => c.encerrante).WithOne().HasForeignKey<TEncerrante>(encerrante => encerrante.compId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TcIDE>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.qBCProd).IsRequired();
                b.Property(c => c.vAliqProd).IsRequired();
                b.Property(c => c.vCIDE).IsRequired();
            });
            builder.Entity<TEncerrante>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.nBico).HasMaxLength(3).IsRequired();
                b.Property(e => e.nBomba).HasMaxLength(3);
                b.Property(e => e.nTanque).HasMaxLength(3).IsRequired();
                b.Property(e => e.vEncIni).IsRequired();
                b.Property(e => e.vEncFin).IsRequired();
            });

            builder.Entity<TImposto>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.vTotTrib).IsRequired();

                b.HasOne(i => i.ICMS).WithOne().HasForeignKey<TiCMS>(icms => icms.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.IPI).WithOne().HasForeignKey<TiPI>(ipi => ipi.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.II).WithOne().HasForeignKey<TiI>(ii => ii.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ISSQN).WithOne().HasForeignKey<TiSSQN>(issqn => issqn.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.PIS).WithOne().HasForeignKey<TpIS>(pis => pis.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.PISST).WithOne().HasForeignKey<TpISST>(pisst => pisst.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.COFINS).WithOne().HasForeignKey<TcOFINS>(cofins => cofins.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.COFINSST).WithOne().HasForeignKey<TcOFINSST>(cofinsst => cofinsst.impostoId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSUFDest).WithOne().HasForeignKey<TiCMSUFDest>(icmsufdest => icmsufdest.impostoId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TiCMS>(b =>
            {
                b.HasKey(i => i.Id);

                b.HasOne(i => i.ICMS00).WithOne().HasForeignKey<TiCMS00>(icms00 => icms00.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS10).WithOne().HasForeignKey<TiCMS10>(icms10 => icms10.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS20).WithOne().HasForeignKey<TiCMS20>(icms20 => icms20.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS30).WithOne().HasForeignKey<TiCMS30>(icms30 => icms30.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS40).WithOne().HasForeignKey<TiCMS40>(icms40 => icms40.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS51).WithOne().HasForeignKey<TiCMS51>(icms51 => icms51.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS60).WithOne().HasForeignKey<TiCMS60>(icms60 => icms60.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS70).WithOne().HasForeignKey<TiCMS70>(icms70 => icms70.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMS90).WithOne().HasForeignKey<TiCMS90>(icms90 => icms90.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSPart).WithOne().HasForeignKey<TiCMSPart>(icmsPart => icmsPart.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSST).WithOne().HasForeignKey<TiCMSST>(icmsST => icmsST.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSSN101).WithOne().HasForeignKey<TiCMSSN101>(icmsSN101 => icmsSN101.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSSN102).WithOne().HasForeignKey<TiCMSSN102>(icmsSN102 => icmsSN102.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSSN201).WithOne().HasForeignKey<TiCMSSN201>(icmsSN201 => icmsSN201.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSSN202).WithOne().HasForeignKey<TiCMSSN202>(icmsSN202 => icmsSN202.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSSN500).WithOne().HasForeignKey<TiCMSSN500>(icmsSN500 => icmsSN500.ICMSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.ICMSSN900).WithOne().HasForeignKey<TiCMSSN900>(icmsSN900 => icmsSN900.ICMSId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TiCMS00>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.pFCP).IsRequired();
                b.Property(i => i.vFCP).IsRequired();
            });
            builder.Entity<TiCMS10>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.vBCFCP).IsRequired();
                b.Property(i => i.pFCP).IsRequired();
                b.Property(i => i.vFCP).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.vBCFCPST).IsRequired();
                b.Property(i => i.pFCPST).IsRequired();
                b.Property(i => i.vFCPST).IsRequired();
            });
            builder.Entity<TiCMS20>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.pRedBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.vBCFCP).IsRequired();
                b.Property(i => i.pFCP).IsRequired();
                b.Property(i => i.vFCP).IsRequired();
                b.Property(i => i.vICMSDeson).IsRequired();
                b.Property(i => i.motDesICMS).IsRequired();
            });
            builder.Entity<TiCMS30>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.vBCFCPST).IsRequired();
                b.Property(i => i.pFCPST).IsRequired();
                b.Property(i => i.vFCPST).IsRequired();
                b.Property(i => i.vICMSDeson).IsRequired();
                b.Property(i => i.motDesICMS).IsRequired();
            });
            builder.Entity<TiCMS40>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.vICMSDeson).IsRequired();
                b.Property(i => i.motDesICMS).IsRequired();
            });
            builder.Entity<TiCMS51>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.pRedBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.pDif).IsRequired();
                b.Property(i => i.vICMSDif).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.vBCFCP).IsRequired();
                b.Property(i => i.pFCP).IsRequired();
                b.Property(i => i.vFCP).IsRequired();
            });
            builder.Entity<TiCMS60>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.vBCSTRet).IsRequired();
                b.Property(i => i.pST).IsRequired();
                b.Property(i => i.vICMSSTRet).IsRequired();
                b.Property(i => i.vBCSFCPSTRet).IsRequired();
                b.Property(i => i.pFCPSTRet).IsRequired();
                b.Property(i => i.vFCPSTRet).IsRequired();
                b.Property(i => i.pRedBCEfet).IsRequired();
                b.Property(i => i.vBCEfet).IsRequired();
                b.Property(i => i.pICMSEfet).IsRequired();
                b.Property(i => i.vICMSEfet).IsRequired();
            });
            builder.Entity<TiCMS70>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.pRedBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.vBCFCP).IsRequired();
                b.Property(i => i.pFCP).IsRequired();
                b.Property(i => i.vFCP).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.vBCFCPST).IsRequired();
                b.Property(i => i.pFCPST).IsRequired();
                b.Property(i => i.vFCPST).IsRequired();
                b.Property(i => i.vICMSDeson).IsRequired();
                b.Property(i => i.motDesICMS).IsRequired();
            });
            builder.Entity<TiCMS90>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.pRedBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.vBCFCP).IsRequired();
                b.Property(i => i.pFCP).IsRequired();
                b.Property(i => i.vFCP).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.vBCFCPST).IsRequired();
                b.Property(i => i.pFCPST).IsRequired();
                b.Property(i => i.vFCPST).IsRequired();
                b.Property(i => i.vICMSDeson).IsRequired();
                b.Property(i => i.motDesICMS).IsRequired();
            });
            builder.Entity<TiCMSPart>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pRedBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.pBCOp).IsRequired();
                b.Property(i => i.UFST).IsRequired();
            });
            builder.Entity<TiCMSST>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.vBCSTRet).IsRequired();
                b.Property(i => i.vICMSSTRet).IsRequired();
                b.Property(i => i.vBCSTDest).IsRequired();
                b.Property(i => i.vICMSSTDest).IsRequired();
            });
            builder.Entity<TiCMSSN101>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CSOSN).HasMaxLength(3).IsRequired();
                b.Property(i => i.pCredSN).IsRequired();
                b.Property(i => i.vCredICMSSN).IsRequired();
            });
            builder.Entity<TiCMSSN102>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CSOSN).HasMaxLength(3).IsRequired();
            });
            builder.Entity<TiCMSSN201>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CSOSN).HasMaxLength(3).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.vBCFCPST).IsRequired();
                b.Property(i => i.pFCPST).IsRequired();
                b.Property(i => i.vFCPST).IsRequired(); ;
                b.Property(i => i.pCredSN).IsRequired();
                b.Property(i => i.vCredICMSSN).IsRequired();
            });
            builder.Entity<TiCMSSN202>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CSOSN).HasMaxLength(3).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.vBCFCPST).IsRequired();
                b.Property(i => i.pFCPST).IsRequired();
                b.Property(i => i.vFCPST).IsRequired(); 
            });
            builder.Entity<TiCMSSN500>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CSOSN).HasMaxLength(3).IsRequired();
                b.Property(i => i.vBCSTRet).IsRequired();
                b.Property(i => i.pST).IsRequired();
                b.Property(i => i.vICMSSTRet).IsRequired();
                b.Property(i => i.vBCSFCPSTRet).IsRequired();
                b.Property(i => i.pFCPSTRet).IsRequired();
                b.Property(i => i.vFCPSTRet).IsRequired();
                b.Property(i => i.pRedBCEfet).IsRequired();
                b.Property(i => i.vBCEfet).IsRequired();
                b.Property(i => i.pICMSEfet).IsRequired();
                b.Property(i => i.vICMSEfet).IsRequired();
            });
            builder.Entity<TiCMSSN900>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.orig).IsRequired();
                b.Property(i => i.CSOSN).HasMaxLength(3).IsRequired();
                b.Property(i => i.modBC).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pRedBC).IsRequired();
                b.Property(i => i.pICMS).IsRequired();
                b.Property(i => i.vICMS).IsRequired();
                b.Property(i => i.modBCST).IsRequired();
                b.Property(i => i.pMVAST).IsRequired();
                b.Property(i => i.pRedBCST).IsRequired();
                b.Property(i => i.vBCST).IsRequired();
                b.Property(i => i.pICMSST).IsRequired();
                b.Property(i => i.vICMSST).IsRequired();
                b.Property(i => i.vBCFCPST).IsRequired();
                b.Property(i => i.pFCPST).IsRequired();
                b.Property(i => i.vFCPST).IsRequired();
                b.Property(i => i.pCredSN).IsRequired();
                b.Property(i => i.vCredICMSSN).IsRequired();
            });

            builder.Entity<TiPI>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.CNPJProd).HasMaxLength(14);
                b.Property(i => i.cSelo).HasMaxLength(60);
                b.Property(i => i.qSelo).HasMaxLength(12);
                b.Property(i => i.cEnq).HasMaxLength(3);

                b.HasOne(i => i.IPITrib).WithOne().HasForeignKey<TiPITrib>(ipitrib => ipitrib.IPIId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(i => i.IPINT).WithOne().HasForeignKey<TiPINT>(ipitrib => ipitrib.IPIId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TiPITrib>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.pIPI).IsRequired();
                b.Property(i => i.qUnid).IsRequired();
                b.Property(i => i.vUnid).IsRequired();
                b.Property(i => i.vIPI).IsRequired();
            });
            builder.Entity<TiPINT>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.CST).HasMaxLength(2).IsRequired();
            });

            builder.Entity<TiI>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.vDespAdu).IsRequired();
                b.Property(i => i.vII).IsRequired();
                b.Property(i => i.vIOF).IsRequired();
            });

            builder.Entity<TiSSQN>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.vBC).IsRequired();
                b.Property(i => i.vAliq).IsRequired();
                b.Property(i => i.vISSQN).IsRequired();
                b.Property(i => i.cMunFG).IsRequired();
                b.Property(i => i.cListServ).HasMaxLength(5).IsRequired();
                b.Property(i => i.vDeducao);
                b.Property(i => i.vOutro);
                b.Property(i => i.vDescIncond);
                b.Property(i => i.vDescCond);
                b.Property(i => i.vISSRet);
                b.Property(i => i.indISS).IsRequired();
                b.Property(i => i.cServico).HasMaxLength(20);
                b.Property(i => i.cMun);
                b.Property(i => i.cPais);
                b.Property(i => i.nProcesso).HasMaxLength(30);
                b.Property(i => i.indIncentivo);
            });

            builder.Entity<TpIS>(b =>
            {
                b.HasKey(p => p.Id);

                b.HasOne(p => p.PISAliq).WithOne().HasForeignKey<TpISAliq>(pisaliq => pisaliq.PISId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.PISQtde).WithOne().HasForeignKey<TpISQtde>(pisqtde => pisqtde.PISId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.PISNT).WithOne().HasForeignKey<TpISNT>(pisnt => pisnt.PISId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.PISOutr).WithOne().HasForeignKey<TpISOutr>(pisoutr => pisoutr.PISId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TpISAliq>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
                b.Property(p => p.vBC).IsRequired();
                b.Property(p => p.pPIS).IsRequired();
                b.Property(p => p.vPIS).IsRequired();
            });
            builder.Entity<TpISQtde>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
                b.Property(p => p.qBCProd).IsRequired();
                b.Property(p => p.vAliqProd).IsRequired();
                b.Property(p => p.vPIS).IsRequired();
            });
            builder.Entity<TpISNT>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
            });
            builder.Entity<TpISOutr>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
                b.Property(p => p.vBC).IsRequired();
                b.Property(p => p.pPIS).IsRequired();
                b.Property(p => p.qBCProd).IsRequired();
                b.Property(p => p.vAliqProd).IsRequired();
                b.Property(p => p.vPIS).IsRequired();
            });
            builder.Entity<TpISST>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.vBC).IsRequired();
                b.Property(p => p.pPIS).IsRequired();
                b.Property(p => p.qBCProd).IsRequired();
                b.Property(p => p.vAliqProd).IsRequired();
                b.Property(p => p.vPIS).IsRequired();
            });

            builder.Entity<TcOFINS>(b =>
            {
                b.HasKey(p => p.Id);

                b.HasOne(p => p.COFINSAliq).WithOne().HasForeignKey<TcOFINSAliq>(pisaliq => pisaliq.COFINSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.COFINSQtde).WithOne().HasForeignKey<TcOFINSQtde>(pisqtde => pisqtde.COFINSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.COFINSNT).WithOne().HasForeignKey<TcOFINSNT>(pisnt => pisnt.COFINSId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.COFINSOutr).WithOne().HasForeignKey<TcOFINSOutr>(pisoutr => pisoutr.COFINSId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TcOFINSAliq>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
                b.Property(p => p.vBC).IsRequired();
                b.Property(p => p.pCOFINS).IsRequired();
                b.Property(p => p.vCOFINS).IsRequired();
            });
            builder.Entity<TcOFINSQtde>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
                b.Property(p => p.qBCProd).IsRequired();
                b.Property(p => p.vAliqProd).IsRequired();
                b.Property(p => p.vCOFINS).IsRequired();
            });
            builder.Entity<TcOFINSNT>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
            });
            builder.Entity<TcOFINSOutr>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.CST).HasMaxLength(2).IsRequired();
                b.Property(p => p.vBC).IsRequired();
                b.Property(p => p.pCOFINS).IsRequired();
                b.Property(p => p.qBCProd).IsRequired();
                b.Property(p => p.vAliqProd).IsRequired();
                b.Property(p => p.vCOFINS).IsRequired();
            });
            builder.Entity<TcOFINSST>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.vBC).IsRequired();
                b.Property(p => p.pCOFINS).IsRequired();
                b.Property(p => p.qBCProd).IsRequired();
                b.Property(p => p.vAliqProd).IsRequired();
                b.Property(p => p.vCOFINS).IsRequired();
            });

            builder.Entity<TiCMSUFDest>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.vBCUFDest).IsRequired();
                b.Property(i => i.vBCFCPUFdest);
                b.Property(i => i.pFCPUFdest).IsRequired();
                b.Property(i => i.pICMSUFDest).IsRequired();
                b.Property(i => i.pICMSInter).IsRequired();
                b.Property(i => i.pICMSInterPart).IsRequired();
                b.Property(i => i.vFCUFdest);
                b.Property(i => i.vICMSUFDest).IsRequired();
                b.Property(i => i.vICMSUFRemet).IsRequired();
            });

            builder.Entity<TImpostoDevol>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.pDevol).IsRequired();

                b.HasOne(i => i.IPI).WithOne().HasForeignKey<TiPIDevol>(ipi => ipi.impostoDevolId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TiPIDevol>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.vIPIDevol).IsRequired();
            });

            builder.Entity<TTotal>(b =>
            {
                b.HasKey(t => t.Id);

                b.HasOne(t => t.ICMSTot).WithOne().HasForeignKey<TiCMSTot>(icmstot => icmstot.totalId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(t => t.ISSQNTot).WithOne().HasForeignKey<TiSSQNTot>(issqntot => issqntot.totalId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(t => t.retTrib).WithOne().HasForeignKey<TRetTrib>(rettrib => rettrib.totalId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TiCMSTot>(b =>
            {
                b.HasKey(t => t.Id);

                b.Property(t => t.vBC).IsRequired();
                b.Property(t => t.vICMS).IsRequired();
                b.Property(t => t.vICMSDeson).IsRequired();
                b.Property(t => t.vFCPUFDest);
                b.Property(t => t.vICMSUFDest);
                b.Property(t => t.vICMSUFRemet);
                b.Property(t => t.vFCP).IsRequired();
                b.Property(t => t.vBCST).IsRequired();
                b.Property(t => t.vST).IsRequired();
                b.Property(t => t.vFCPST).IsRequired();
                b.Property(t => t.vFCPSTRet).IsRequired();
                b.Property(t => t.vProd).IsRequired();
                b.Property(t => t.vFrete).IsRequired();
                b.Property(t => t.vSeg).IsRequired();
                b.Property(t => t.vDesc).IsRequired();
                b.Property(t => t.vII).IsRequired();
                b.Property(t => t.vIPI).IsRequired();
                b.Property(t => t.vIPIDevol).IsRequired();
                b.Property(t => t.vPIS).IsRequired();
                b.Property(t => t.vCOFINS).IsRequired();
                b.Property(t => t.vOutro).IsRequired();
                b.Property(t => t.vNF).IsRequired();
                b.Property(t => t.vTotTrib).IsRequired();
            });
            builder.Entity<TiSSQNTot>(b =>
            {
                b.HasKey(t => t.Id);

                b.Property(t => t.vServ);
                b.Property(t => t.vBC);
                b.Property(t => t.vISS);
                b.Property(t => t.vPIS);
                b.Property(t => t.vCOFINS);
                b.Property(t => t.dCompet).IsRequired();
                b.Property(t => t.vDeducao);
                b.Property(t => t.vOutro);
                b.Property(t => t.vDescIncond);
                b.Property(t => t.vDescCond);
                b.Property(t => t.vISSRet);
                b.Property(t => t.cRegTrib);
            });
            builder.Entity<TRetTrib>(b =>
            {
                b.HasKey(t => t.Id);

                b.Property(t => t.vRetPIS);
                b.Property(t => t.vRetCOFINS);
                b.Property(t => t.vRetCSLL);
                b.Property(t => t.vBCIRRF);
                b.Property(t => t.vIRRF);
                b.Property(t => t.vBCRetPrev);
                b.Property(t => t.vRetPrev);
            });
            builder.Entity<TTransp>(b =>
            {
                b.HasKey(t => t.Id);

                b.Property(t => t.modFrete).IsRequired();
                b.Property(t => t.vagao).HasMaxLength(20);
                b.Property(t => t.balsa).HasMaxLength(20);

                b.HasOne(t => t.transporta).WithOne().HasForeignKey<TTransporta>(transporta => transporta.transpId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(t => t.retTransp).WithOne().HasForeignKey<TRetTransp>(rettransp => rettransp.transpId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(t => t.veicTransp).WithOne().HasForeignKey<TVeicTransp>(veictransp => veictransp.transpId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(t => t.reboque).WithOne().HasForeignKey(reboque => reboque.transpId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(t => t.vol).WithOne().HasForeignKey(vol => vol.transpId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TTransporta>(b =>
            {
                b.HasKey(t => t.Id);

                b.Property(t => t.CNPJ).HasMaxLength(14);
                b.Property(t => t.CPF).HasMaxLength(11);
                b.Property(t => t.xNome).HasMaxLength(60);
                b.Property(t => t.IE).HasMaxLength(14);
                b.Property(t => t.xEnder).HasMaxLength(60);
                b.Property(t => t.xMun).HasMaxLength(60);
                b.Property(t => t.UF);
            });
            builder.Entity<TRetTransp>(b =>
            {
                b.HasKey(t => t.Id);

                b.Property(t => t.vServ).IsRequired();
                b.Property(t => t.vBCRet).IsRequired();
                b.Property(t => t.pICMSRet).IsRequired();
                b.Property(t => t.vICMSRet).IsRequired();
                b.Property(t => t.CFOP).HasMaxLength(4).IsRequired();
                b.Property(t => t.cMunFG).IsRequired();
            });
            builder.Entity<TVeicTransp>(b =>
            {
                b.Property(v => v.placa).HasMaxLength(7).IsRequired();
                b.Property(v => v.UF).IsRequired();
                b.Property(v => v.RNTC).HasMaxLength(20);
            });
            builder.Entity<TReboque>(b =>
            {
                b.Property(r => r.placa).HasMaxLength(7).IsRequired();
                b.Property(r => r.UF).IsRequired();
                b.Property(r => r.RNTC).HasMaxLength(20);
            });
            builder.Entity<TVol>(b =>
            {
                b.HasKey(v => v.Id);

                b.Property(v => v.qVol).HasMaxLength(15);
                b.Property(v => v.esp).HasMaxLength(60);
                b.Property(v => v.marca).HasMaxLength(60);
                b.Property(v => v.nVol).HasMaxLength(60);
                b.Property(v => v.pesoL);
                b.Property(v => v.pesoB);

                b.HasMany(v => v.lacres).WithOne().HasForeignKey(lacres => lacres.volId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TLacres>(b =>
            {
                b.HasKey(v => v.Id);

                b.Property(l => l.nLacre).HasMaxLength(60).IsRequired();
            });

            builder.Entity<TCobr>(b =>
            {
                b.HasKey(c => c.Id);

                b.HasOne(c => c.fat).WithOne().HasForeignKey<TFat>(fat => fat.cobrId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(c => c.dup).WithOne().HasForeignKey(dup => dup.cobrId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TFat>(b =>
            {
                b.HasKey(f => f.Id);

                b.Property(f => f.nFat).HasMaxLength(60);
                b.Property(f => f.vOrig);
                b.Property(f => f.vDesc);
                b.Property(f => f.vLiq);
            });
            builder.Entity<TDup>(b =>
            {
                b.HasKey(d => d.Id);

                b.Property(f => f.nDup).HasMaxLength(60);
                b.Property(f => f.dVenc);
                b.Property(f => f.vDup);
            });

            builder.Entity<TPag>(b =>
            {
                b.HasKey(p => p.Id);

                b.Property(p => p.vTroco);

                b.HasMany(p => p.detPag).WithOne().HasForeignKey(detpag => detpag.pagId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TDetPag>(b =>
            {
                b.HasKey(d => d.Id);

                b.Property(d => d.indPag);
                b.Property(d => d.tPag).HasMaxLength(2).IsRequired();
                b.Property(d => d.vPag).IsRequired();

                b.HasOne(d => d.card).WithOne().HasForeignKey<TCard>(card => card.detPagId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TCard>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.tpIntegra).HasMaxLength(1).IsRequired();
                b.Property(c => c.CNPJ).HasMaxLength(14);
                b.Property(c => c.tBand).HasMaxLength(2);
                b.Property(c => c.cAut).HasMaxLength(20);
            });

            builder.Entity<TInfAdic>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.infAdFisco).HasMaxLength(2000);
                b.Property(i => i.infCpl).HasMaxLength(5000);

                b.HasMany(i => i.obsCont).WithOne().HasForeignKey(obscont => obscont.infAdicId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(i => i.obsFisco).WithOne().HasForeignKey(obsfisco => obsfisco.infAdicId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(i => i.procRef).WithOne().HasForeignKey(procref => procref.infAdicId).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<TObsCont>(b =>
            {
                b.HasKey(o => o.Id);

                b.Property(o => o.xTexto).HasMaxLength(60).IsRequired();
                b.Property(o => o.xCampo).HasMaxLength(20).IsRequired();
            });
            builder.Entity<TObsFisco>(b =>
            {
                b.HasKey(o => o.Id);

                b.Property(o => o.xTexto).HasMaxLength(60).IsRequired();
                b.Property(o => o.xCampo).HasMaxLength(20).IsRequired();
            });
            builder.Entity<TProcRef>(b =>
            {
                b.HasKey(o => o.Id);

                b.Property(o => o.nProc).HasMaxLength(60).IsRequired();
                b.Property(o => o.indProc).IsRequired();
            });

            builder.Entity<TExporta>(b =>
            {
                b.HasKey(e => e.Id);

                b.Property(e => e.UFSaidaPais).IsRequired();
                b.Property(e => e.xLocExporta).HasMaxLength(60).IsRequired();
                b.Property(e => e.xLocDespacho).HasMaxLength(60);
            });

            builder.Entity<TCompra>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.xNEmp).HasMaxLength(22);
                b.Property(c => c.xPed).HasMaxLength(60);
                b.Property(c => c.xCont).HasMaxLength(60);
            });

            builder.Entity<TCana>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.safra).HasMaxLength(9).IsRequired();
                b.Property(c => c._ref).HasMaxLength(5).IsRequired();
                b.Property(c => c.qTotMes).IsRequired();
                b.Property(c => c.qTotAnt).IsRequired();
                b.Property(c => c.qTotGer).IsRequired();
                b.Property(c => c.vFor).IsRequired();
                b.Property(c => c.vTotDed).IsRequired();
                b.Property(c => c.vLiqFor).IsRequired();

                b.HasMany(c => c.forDia).WithOne().HasForeignKey(fordia => fordia.canaId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(c => c.deduc).WithOne().HasForeignKey(deduc => deduc.canaId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TInfNFeSupl>(b =>
            {
                b.HasKey(i => i.Id);
                b.Property(i => i.qrCode).HasMaxLength(600);
                b.Property(i => i.urlChave).HasMaxLength(85);
            });

            builder.Entity<TEmpresas>(b =>
            {
                b.HasKey(e => e.Codigo);
                b.HasIndex(e => e.CNPJ);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(string.IsNullOrEmpty(Connection) ?
                @"Server=NATHANAEL-PC;Database=TaxAuditCommunityDB;User Id=sa;Password=ns151232;" :
                Connection);
        }
    }
}
