using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TaxAuditCommunity.Domain.NFe.TiposBasicos
{

    /// <summary>
    /// Produção = 1;
    /// Homologação = 2
    /// </summary>
    public enum TAmb
    {
        Homologação = 2,
        Produção = 1
    }

    public enum TCodUfIBGE
    {
        [System.Xml.Serialization.XmlEnum("11")]
        Rondonia = 11,
        [System.Xml.Serialization.XmlEnum("12")]
        Acre = 12,
        [System.Xml.Serialization.XmlEnum("13")]
        Amazonas = 13,
        [System.Xml.Serialization.XmlEnum("14")]
        Roraima = 14,
        [System.Xml.Serialization.XmlEnum("15")]
        Para = 15,
        [System.Xml.Serialization.XmlEnum("16")]
        Amapa = 16,
        [System.Xml.Serialization.XmlEnum("17")]
        Tocantis = 17,
        [System.Xml.Serialization.XmlEnum("21")]
        Maranhao = 21,
        [System.Xml.Serialization.XmlEnum("22")]
        Piaui = 22,
        [System.Xml.Serialization.XmlEnum("23")]
        Ceara = 23,
        [System.Xml.Serialization.XmlEnum("24")]
        RioGrandeDoNorte = 24,
        [System.Xml.Serialization.XmlEnum("25")]
        Paraiba = 25,
        [System.Xml.Serialization.XmlEnum("26")]
        Pernambuco = 26,
        [System.Xml.Serialization.XmlEnum("27")]
        Alagoas = 27,
        [System.Xml.Serialization.XmlEnum("28")]
        Sergipe = 28,
        [System.Xml.Serialization.XmlEnum("29")]
        Bahia = 29,
        [System.Xml.Serialization.XmlEnum("31")]
        MinasGerais = 31,
        [System.Xml.Serialization.XmlEnum("32")]
        EspiritoSanto = 32,
        [System.Xml.Serialization.XmlEnum("33")]
        RioDeJaneiro = 33,
        [System.Xml.Serialization.XmlEnum("35")]
        SaoPaulo = 35,
        [System.Xml.Serialization.XmlEnum("41")]
        Parana = 41,
        [System.Xml.Serialization.XmlEnum("42")]
        SantaCatarina = 42,
        [System.Xml.Serialization.XmlEnum("43")]
        RioGrandeDoSul = 43,
        [System.Xml.Serialization.XmlEnum("50")]
        MatoGrossoDoSul = 50,
        [System.Xml.Serialization.XmlEnum("51")]
        MatoGrosso = 51,
        [System.Xml.Serialization.XmlEnum("52")]
        Goias = 52,
        [System.Xml.Serialization.XmlEnum("53")]
        DistritoFederal = 53,
        [System.Xml.Serialization.XmlEnum("91")]
        Exterior = 91,
    }

    public enum TUf
    {
        AC,
        AL,
        AM,
        AP,
        BA,
        CE,
        DF,
        ES,
        GO,
        MA,
        MG,
        MS,
        MT,
        PA,
        PB,
        PE,
        PI,
        PR,
        RJ,
        RN,
        RO,
        RR,
        RS,
        SC,
        SE,
        SP,
        TO,
        EX,
    }

    public enum TMod
    {
        [System.Xml.Serialization.XmlEnum("55")]
        NotaFiscalEletronica = 55
    }
    /// <summary>
    /// Entrada = 0
    /// Saida = 1
    /// </summary>
    public enum TtpNF
    {
        Entrada = 0,
        Saida = 1
    }

    public enum TidDest
    {
        Interna = 1,
        Interestadual = 2,
        Exterior = 3
    }

    public enum TtpImp
    {
        /// <summary>
        /// Inserido a partir da versão 3.10
        /// </summary>
        [Display(Name = "Sem DANFe")]
        SemDANFe = 0,
        [Display(Name = "DANFe Retrato")]
        DANFeRetrato = 1,
        [Display(Name = "DANFe Paisagem")]
        DANFePaisagem = 2,
        /// <summary>
        /// Inserido a partir da versão 3.10
        /// </summary>
        [Display(Name = "DANFe Simplificado")]
        DANFeSimplificado = 3,
        /// <summary>
        /// Inserido a partir da versão 3.10
        /// </summary>
        [Display(Name = "DANFe NFC-e")]
        DANFeNFCe = 4,
        /// <summary>
        /// Inserido a partir da versão 3.10
        /// </summary>
        [Display(Name = "DANFe NFC-e em mensagem eletrônica")]
        DANFeNFCeEmMensagemEletronica = 5
    }

    public enum TtpEmis
    {
        [Display(Name = "1 - Normal")]
        Normal = 1,
        [Display(Name = "2 - Contingência FS")]
        ContingênciaFS = 2,
        [Display(Name = "3 - Contingência SCAN")]
        ContingênciaSCAN = 3,
        [Display(Name = "4 - Contingência DPEC")]
        ContingênciaDPEC = 4,
        [Display(Name = "5 - Contingência FSDA")]
        ContingênciaFSDA = 5,
        /// <summary>
        /// Inserido a partir da versão 2.00
        /// </summary>
        [Display(Name = "6 - Contingência SVC - AN")]
        ContingênciaSVC_AN = 6,
        /// <summary>
        /// Inserido a partir da versão 2.00
        /// </summary>
        [Display(Name = "7 - Contingência SVC - RS")]
        ContingênciaSVC_RS = 7,
        /// <summary>
        /// Inserido a partir da versão 3.10
        /// </summary>
        [Display(Name = "9 - Contingência off-line NFC-e")]
        ContingênciaOffLineNFCe = 9
    }

    public enum TfinNFe
    {
        [Display(Name = "NFe Normal")]
        NFeNormal = 1,
        [Display(Name = "NFe Complementar")]
        NFeComplementar = 2,
        [Display(Name = "NFe de Ajuste")]
        NFeAjuste = 3,
        /// <summary>
        /// Inserido a partir da versão 3.10
        /// </summary>
        [Display(Name = "Devolução/Retorno")]
        NFeDevoluçãoRetorno = 4
    }

    public enum TindFinal
    {
        [Display(Name = "Não")]
        Não = 0,
        [Display(Name = "Consumidor Final")]
        ConsumidorFinal = 1
    }

    public enum TindPres
    {
        [Display(Name = "0-Não se aplica (ex.: Nota Fiscal complementar ou de ajuste")]
        Não_se_aplica = 0,
        [Display(Name = "1-Operação presencial")]
        Operação_presencial = 1,
        [Display(Name = "2-Não presencial, internet")]
        Não_presencial_internet = 2,
        [Display(Name = "3-Não presencial, teleatendimento")]
        Não_presencial_teleatendiamento = 3,
        [Display(Name = "4-NFC-e entrega em domicílio")]
        NFCe_entrega_em_dominilio = 4,
        [Display(Name = "5-Operação presencial, fora do estabelecimento")]
        Operação_presencial_fora_do_estabelefimento = 5,
        [Display(Name = "9-Não presencial, outros")]
        Não_presencial_outros = 9
    }

    public enum TprocEmi
    {
        [Display(Name = "0 - emissão de NF-e com aplicativo do contribuinte;")]
        emissão_de_NFe_com_aplicativo_do_contribuinte = 0,
        [Display(Name = "1 - emissão de NF-e avulsa pelo Fisco;")]
        emissão_de_NFe_avulsa_pelo_Fisco = 1,
        [Display(Name = "2 - emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;")]
        emissão_de_NFe_avulsa_pelo_contribuinte_com_seu_certificado_digital_através_do_site_do_Fisco = 2,
        [Display(Name = "3- emissão de NF-e pelo contribuinte com aplicativo fornecido pelo Fisco")]
        emissão_de_NFe_pelo_contribuinte_com_aplicativo_fornecido_pelo_Fisco = 3
    }

    public enum TindIEDest
    {
        [Display(Name = "1 – Contribuinte ICMS pagamento à vista")]
        Contribuinte_ICMS_pagamento_à_vista = 1,
        [Display(Name = "2 – Contribuinte isento de inscrição")]
        Contribuinte_isento_de_inscrição = 2,
        [Display(Name = "9 – Não Contribuinte")]
        Não_Contribuinte = 9
    }

    public enum TindTot
    {
        [Display(Name = "0 – o valor do item (vProd) não compõe o valor total da NF-e (vProd)")]
        o_valor_do_item_vProd_não_compõe_o_valor_total_da_NFe_vProd = 0,
        [Display(Name = "1  – o valor do item (vProd) compõe o valor total da NF-e (vProd)")]
        o_valor_do_item_vProd_compõe_o_valor_total_da_NFe_vProd = 1
    }

    public enum TindEscala
    {
        S = 0,
        N = 1
    }

    public enum TCRT
    {
        [Display(Name = "Simples Nacional")]
        Simples_Nacional = 1,
        [Display(Name = "Simples Nacional – excesso de sublimite de receita bruta")]
        Simples_Nacional_excesso_de_sublimite_de_receita_bruta = 2,
        [Display(Name = "Regime Normal")]
        Regime_Normal = 3
    }
    /// <summary>
    /// Indicador de industrializador
    /// </summary>
    public enum IndFab
    {
        Industrializador = 0,
        Revendedor = 1
    }

    public enum tpOp
    {
        [Display(Name = "Venda concessioária")]
        Venda_Concessionária = 1,
        [Display(Name = "Faturamento direto")]
        Faturamento_direto = 2,
        [Display(Name = "Venda direta")]
        Venda_direta = 3,
        [Display(Name = "Outros")]
        Outros = 0
    }
}
