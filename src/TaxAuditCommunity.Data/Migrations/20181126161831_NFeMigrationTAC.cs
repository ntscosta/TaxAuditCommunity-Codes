using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxAuditCommunity.Data.Migrations
{
    public partial class NFeMigrationTAC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NFe",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 44, nullable: false),
                    Hash = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tprodutoBases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cProd = table.Column<string>(nullable: true),
                    cEAN = table.Column<string>(nullable: true),
                    xProd = table.Column<string>(nullable: true),
                    NCM = table.Column<string>(nullable: true),
                    NVE = table.Column<string>(nullable: true),
                    CEST = table.Column<string>(nullable: true),
                    indEscala = table.Column<int>(nullable: false),
                    CNPJFab = table.Column<string>(nullable: true),
                    cBenef = table.Column<string>(nullable: true),
                    EXTIPI = table.Column<string>(nullable: true),
                    genero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tprodutoBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "infNFe",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 44, nullable: false),
                    NFeId = table.Column<string>(nullable: true),
                    versao = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infNFe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_infNFe_NFe_NFeId",
                        column: x => x.NFeId,
                        principalTable: "NFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "infNFeSupl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NFeId = table.Column<string>(nullable: true),
                    qrCode = table.Column<string>(maxLength: 600, nullable: true),
                    urlChave = table.Column<string>(maxLength: 85, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infNFeSupl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_infNFeSupl_NFe_NFeId",
                        column: x => x.NFeId,
                        principalTable: "NFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "xmlNFe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NFeId = table.Column<string>(maxLength: 44, nullable: false),
                    DhChange = table.Column<DateTime>(nullable: false),
                    FileNFe = table.Column<string>(type: "xml", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xmlNFe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_xmlNFe_NFe_NFeId",
                        column: x => x.NFeId,
                        principalTable: "NFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "autXML",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autXML", x => x.Id);
                    table.ForeignKey(
                        name: "FK_autXML_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avulsa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    xOrgao = table.Column<string>(maxLength: 60, nullable: false),
                    matr = table.Column<string>(maxLength: 60, nullable: false),
                    xAgente = table.Column<string>(maxLength: 60, nullable: false),
                    fone = table.Column<string>(maxLength: 14, nullable: true),
                    UF = table.Column<int>(nullable: false),
                    nDAR = table.Column<int>(maxLength: 60, nullable: false),
                    dEmi = table.Column<DateTime>(nullable: false),
                    vDAR = table.Column<double>(nullable: false),
                    repEmit = table.Column<string>(maxLength: 60, nullable: true),
                    dPag = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avulsa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_avulsa_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cana",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    safra = table.Column<string>(maxLength: 9, nullable: false),
                    _ref = table.Column<string>(maxLength: 5, nullable: false),
                    qTotMes = table.Column<double>(nullable: false),
                    qTotAnt = table.Column<double>(nullable: false),
                    qTotGer = table.Column<double>(nullable: false),
                    vFor = table.Column<double>(nullable: false),
                    vTotDed = table.Column<double>(nullable: false),
                    vLiqFor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cana", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cana_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cobr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cobr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cobr_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    xNEmp = table.Column<string>(maxLength: 22, nullable: true),
                    xPed = table.Column<string>(maxLength: 60, nullable: true),
                    xCont = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compra_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    idEstrangeiro = table.Column<string>(maxLength: 20, nullable: true),
                    xNome = table.Column<string>(maxLength: 60, nullable: true),
                    indIEDest = table.Column<int>(nullable: false),
                    IE = table.Column<string>(maxLength: 14, nullable: true),
                    ISUF = table.Column<string>(maxLength: 9, nullable: true),
                    IM = table.Column<string>(maxLength: 15, nullable: true),
                    email = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dest_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "det",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    infAdProd = table.Column<string>(maxLength: 500, nullable: true),
                    nItem = table.Column<int>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_det", x => x.Id);
                    table.ForeignKey(
                        name: "FK_det_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    xNome = table.Column<string>(maxLength: 60, nullable: false),
                    xFant = table.Column<string>(maxLength: 60, nullable: true),
                    IE = table.Column<string>(maxLength: 14, nullable: false),
                    IEST = table.Column<string>(maxLength: 14, nullable: true),
                    IM = table.Column<string>(maxLength: 15, nullable: true),
                    CNAE = table.Column<string>(maxLength: 7, nullable: true),
                    CRT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emit_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entrega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    xLgr = table.Column<string>(maxLength: 60, nullable: false),
                    nro = table.Column<string>(maxLength: 60, nullable: false),
                    xCpl = table.Column<string>(maxLength: 60, nullable: true),
                    xBairro = table.Column<string>(maxLength: 60, nullable: false),
                    cMun = table.Column<int>(maxLength: 7, nullable: false),
                    xMun = table.Column<string>(maxLength: 60, nullable: false),
                    UF = table.Column<int>(nullable: false),
                    infNFeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entrega_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exporta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    UFSaidaPais = table.Column<int>(nullable: false),
                    xLocExporta = table.Column<string>(maxLength: 60, nullable: false),
                    xLocDespacho = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exporta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exporta_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ide",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    cUF = table.Column<int>(nullable: false),
                    cNF = table.Column<int>(nullable: false),
                    natOp = table.Column<string>(maxLength: 60, nullable: false),
                    indPag = table.Column<int>(nullable: false),
                    mod = table.Column<int>(nullable: false),
                    serie = table.Column<int>(nullable: false),
                    nNF = table.Column<int>(maxLength: 9, nullable: false),
                    dhEmi = table.Column<DateTime>(nullable: false),
                    dSaiEnt = table.Column<DateTime>(nullable: false),
                    dhSaiEnt = table.Column<DateTime>(nullable: false),
                    hSaiEnt = table.Column<TimeSpan>(nullable: false),
                    tpNF = table.Column<int>(nullable: false),
                    idDest = table.Column<int>(nullable: false),
                    cMunFG = table.Column<int>(maxLength: 7, nullable: false),
                    tpImp = table.Column<int>(nullable: false),
                    tpEmis = table.Column<int>(nullable: false),
                    cDV = table.Column<int>(maxLength: 1, nullable: false),
                    tpAmb = table.Column<int>(nullable: false),
                    finNFe = table.Column<int>(nullable: false),
                    indFinal = table.Column<int>(nullable: false),
                    indPres = table.Column<int>(nullable: false),
                    procEmi = table.Column<int>(nullable: false),
                    verProc = table.Column<string>(maxLength: 20, nullable: false),
                    dhCont = table.Column<DateTime>(nullable: false),
                    xJust = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ide_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "infAdic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    infAdFisco = table.Column<string>(maxLength: 2000, nullable: true),
                    infCpl = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infAdic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_infAdic_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    vTroco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pag_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retirada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    xLgr = table.Column<string>(maxLength: 60, nullable: false),
                    nro = table.Column<string>(maxLength: 60, nullable: false),
                    xCpl = table.Column<string>(maxLength: 60, nullable: true),
                    xBairro = table.Column<string>(maxLength: 60, nullable: false),
                    cMun = table.Column<int>(maxLength: 7, nullable: false),
                    xMun = table.Column<string>(maxLength: 60, nullable: false),
                    UF = table.Column<int>(nullable: false),
                    infNFeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retirada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retirada_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "total",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_total", x => x.Id);
                    table.ForeignKey(
                        name: "FK_total_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infNFeId = table.Column<string>(nullable: true),
                    modFrete = table.Column<byte>(nullable: false),
                    vagao = table.Column<int>(maxLength: 20, nullable: false),
                    balsa = table.Column<int>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transp_infNFe_infNFeId",
                        column: x => x.infNFeId,
                        principalTable: "infNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retConsSitNFe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    XmlNFeId = table.Column<int>(nullable: false),
                    tpAmb = table.Column<int>(nullable: false),
                    verAplic = table.Column<string>(maxLength: 20, nullable: true),
                    cStat = table.Column<string>(maxLength: 3, nullable: true),
                    xMotivo = table.Column<string>(maxLength: 255, nullable: true),
                    cUF = table.Column<int>(nullable: false),
                    dhRecibo = table.Column<DateTime>(nullable: false),
                    chNFe = table.Column<string>(maxLength: 44, nullable: true),
                    versao = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retConsSitNFe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retConsSitNFe_xmlNFe_XmlNFeId",
                        column: x => x.XmlNFeId,
                        principalTable: "xmlNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deduc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    canaId = table.Column<int>(nullable: false),
                    xDed = table.Column<string>(nullable: true),
                    vDed = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deduc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deduc_cana_canaId",
                        column: x => x.canaId,
                        principalTable: "cana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forDia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    canaId = table.Column<int>(nullable: false),
                    dia = table.Column<int>(nullable: false),
                    qtde = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forDia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_forDia_cana_canaId",
                        column: x => x.canaId,
                        principalTable: "cana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cobrId = table.Column<int>(nullable: false),
                    nDup = table.Column<string>(maxLength: 60, nullable: true),
                    dVenc = table.Column<DateTime>(nullable: false),
                    vDup = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dup_cobr_cobrId",
                        column: x => x.cobrId,
                        principalTable: "cobr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cobrId = table.Column<int>(nullable: false),
                    nFat = table.Column<string>(maxLength: 60, nullable: true),
                    vOrig = table.Column<double>(nullable: false),
                    vDesc = table.Column<double>(nullable: false),
                    vLiq = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fat_cobr_cobrId",
                        column: x => x.cobrId,
                        principalTable: "cobr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enderDest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    xLgr = table.Column<string>(maxLength: 60, nullable: false),
                    nro = table.Column<string>(maxLength: 60, nullable: false),
                    xCpl = table.Column<string>(maxLength: 60, nullable: true),
                    xBairro = table.Column<string>(maxLength: 60, nullable: false),
                    cMun = table.Column<int>(maxLength: 7, nullable: false),
                    xMun = table.Column<string>(maxLength: 60, nullable: false),
                    UF = table.Column<int>(nullable: false),
                    emitId = table.Column<int>(nullable: false),
                    destId = table.Column<int>(nullable: false),
                    CEP = table.Column<string>(maxLength: 60, nullable: true),
                    cPais = table.Column<int>(maxLength: 60, nullable: false),
                    xPais = table.Column<string>(maxLength: 60, nullable: true),
                    fone = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderDest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enderDest_dest_destId",
                        column: x => x.destId,
                        principalTable: "dest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "imposto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    detId = table.Column<int>(nullable: false),
                    vTotTrib = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imposto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imposto_det_detId",
                        column: x => x.detId,
                        principalTable: "det",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "impostoDevol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    detId = table.Column<int>(nullable: false),
                    pDevol = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_impostoDevol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_impostoDevol_det_detId",
                        column: x => x.detId,
                        principalTable: "det",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cProd = table.Column<string>(maxLength: 60, nullable: false),
                    cEAN = table.Column<string>(maxLength: 14, nullable: true),
                    xProd = table.Column<string>(nullable: true),
                    NCM = table.Column<string>(maxLength: 8, nullable: false),
                    NVE = table.Column<string>(maxLength: 6, nullable: true),
                    CEST = table.Column<string>(maxLength: 7, nullable: true),
                    indEscala = table.Column<int>(nullable: false),
                    CNPJFab = table.Column<string>(maxLength: 14, nullable: true),
                    cBenef = table.Column<string>(maxLength: 10, nullable: true),
                    EXTIPI = table.Column<string>(maxLength: 3, nullable: true),
                    genero = table.Column<string>(nullable: true),
                    detId = table.Column<int>(nullable: false),
                    TProdutoId = table.Column<int>(nullable: false),
                    CFOP = table.Column<string>(maxLength: 4, nullable: false),
                    uCom = table.Column<string>(nullable: false),
                    qCom = table.Column<double>(nullable: false),
                    vUnCom = table.Column<double>(nullable: false),
                    vProd = table.Column<double>(nullable: false),
                    cEANTrib = table.Column<string>(nullable: true),
                    uTrib = table.Column<string>(maxLength: 6, nullable: false),
                    qTrib = table.Column<double>(nullable: false),
                    vUnTrib = table.Column<double>(nullable: false),
                    vFrete = table.Column<double>(nullable: false),
                    vSeg = table.Column<double>(nullable: false),
                    vDesc = table.Column<double>(nullable: false),
                    vOutro = table.Column<double>(nullable: false),
                    indTot = table.Column<int>(nullable: false),
                    xPed = table.Column<string>(maxLength: 15, nullable: true),
                    nItemPed = table.Column<int>(maxLength: 6, nullable: false),
                    nFCI = table.Column<string>(maxLength: 36, nullable: true),
                    nRECOPI = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prod_det_detId",
                        column: x => x.detId,
                        principalTable: "det",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enderEmit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    xLgr = table.Column<string>(maxLength: 60, nullable: false),
                    nro = table.Column<string>(maxLength: 60, nullable: false),
                    xCpl = table.Column<string>(maxLength: 60, nullable: true),
                    xBairro = table.Column<string>(maxLength: 60, nullable: false),
                    cMun = table.Column<int>(maxLength: 7, nullable: false),
                    xMun = table.Column<string>(maxLength: 60, nullable: false),
                    UF = table.Column<int>(nullable: false),
                    emitId = table.Column<int>(nullable: false),
                    destId = table.Column<int>(nullable: false),
                    CEP = table.Column<string>(maxLength: 60, nullable: true),
                    cPais = table.Column<int>(maxLength: 60, nullable: false),
                    xPais = table.Column<string>(maxLength: 60, nullable: true),
                    fone = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderEmit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enderEmit_emit_emitId",
                        column: x => x.emitId,
                        principalTable: "emit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NFref",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ideId = table.Column<int>(nullable: false),
                    refNFe = table.Column<string>(maxLength: 44, nullable: true),
                    refCTe = table.Column<string>(maxLength: 44, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NFref_ide_ideId",
                        column: x => x.ideId,
                        principalTable: "ide",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obsCont",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infAdicId = table.Column<int>(nullable: false),
                    xCampo = table.Column<string>(maxLength: 20, nullable: false),
                    xTexto = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obsCont", x => x.Id);
                    table.ForeignKey(
                        name: "FK_obsCont_infAdic_infAdicId",
                        column: x => x.infAdicId,
                        principalTable: "infAdic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obsFisco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infAdicId = table.Column<int>(nullable: false),
                    xCampo = table.Column<string>(maxLength: 20, nullable: false),
                    xTexto = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obsFisco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_obsFisco_infAdic_infAdicId",
                        column: x => x.infAdicId,
                        principalTable: "infAdic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "procRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    infAdicId = table.Column<int>(nullable: false),
                    nProc = table.Column<string>(maxLength: 60, nullable: false),
                    indProc = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_procRef_infAdic_infAdicId",
                        column: x => x.infAdicId,
                        principalTable: "infAdic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detPag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pagId = table.Column<int>(nullable: false),
                    indPag = table.Column<byte>(nullable: false),
                    tPag = table.Column<string>(maxLength: 2, nullable: false),
                    vPag = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detPag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detPag_pag_pagId",
                        column: x => x.pagId,
                        principalTable: "pag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSTot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    totalId = table.Column<int>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    vICMSDeson = table.Column<double>(nullable: false),
                    vFCPUFDest = table.Column<double>(nullable: false),
                    vICMSUFDest = table.Column<double>(nullable: false),
                    vICMSUFRemet = table.Column<double>(nullable: false),
                    vFCP = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    vST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false),
                    vFCPSTRet = table.Column<double>(nullable: false),
                    vProd = table.Column<double>(nullable: false),
                    vFrete = table.Column<double>(nullable: false),
                    vSeg = table.Column<double>(nullable: false),
                    vDesc = table.Column<double>(nullable: false),
                    vII = table.Column<double>(nullable: false),
                    vIPI = table.Column<double>(nullable: false),
                    vIPIDevol = table.Column<double>(nullable: false),
                    vPIS = table.Column<double>(nullable: false),
                    vCOFINS = table.Column<double>(nullable: false),
                    vOutro = table.Column<double>(nullable: false),
                    vNF = table.Column<double>(nullable: false),
                    vTotTrib = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSTot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSTot_total_totalId",
                        column: x => x.totalId,
                        principalTable: "total",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISSQNTot",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    totalId = table.Column<int>(nullable: false),
                    vServ = table.Column<double>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    vISS = table.Column<double>(nullable: false),
                    vPIS = table.Column<double>(nullable: false),
                    vCOFINS = table.Column<double>(nullable: false),
                    dCompet = table.Column<DateTime>(nullable: false),
                    vDeducao = table.Column<double>(nullable: false),
                    vOutro = table.Column<double>(nullable: false),
                    vDescIncond = table.Column<double>(nullable: false),
                    vDescCond = table.Column<double>(nullable: false),
                    vISSRet = table.Column<double>(nullable: false),
                    cRegTrib = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISSQNTot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISSQNTot_total_totalId",
                        column: x => x.totalId,
                        principalTable: "total",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retTrib",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    totalId = table.Column<int>(nullable: false),
                    vRetPIS = table.Column<double>(nullable: false),
                    vRetCOFINS = table.Column<double>(nullable: false),
                    vRetCSLL = table.Column<double>(nullable: false),
                    vBCIRRF = table.Column<double>(nullable: false),
                    vIRRF = table.Column<double>(nullable: false),
                    vBCRetPrev = table.Column<double>(nullable: false),
                    vRetPrev = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retTrib", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retTrib_total_totalId",
                        column: x => x.totalId,
                        principalTable: "total",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reboque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    placa = table.Column<string>(maxLength: 7, nullable: false),
                    UF = table.Column<int>(nullable: false),
                    RNTC = table.Column<string>(maxLength: 20, nullable: true),
                    transpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reboque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reboque_transp_transpId",
                        column: x => x.transpId,
                        principalTable: "transp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retTransp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transpId = table.Column<int>(nullable: false),
                    vServ = table.Column<double>(nullable: false),
                    vBCRet = table.Column<double>(nullable: false),
                    pICMSRet = table.Column<double>(nullable: false),
                    vICMSRet = table.Column<double>(nullable: false),
                    CFOP = table.Column<string>(maxLength: 4, nullable: false),
                    cMunFG = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retTransp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retTransp_transp_transpId",
                        column: x => x.transpId,
                        principalTable: "transp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transporta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transpId = table.Column<int>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    xNome = table.Column<string>(maxLength: 60, nullable: true),
                    IE = table.Column<string>(maxLength: 14, nullable: true),
                    xEnder = table.Column<string>(maxLength: 60, nullable: true),
                    xMun = table.Column<string>(maxLength: 60, nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transporta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transporta_transp_transpId",
                        column: x => x.transpId,
                        principalTable: "transp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "veicTransp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    placa = table.Column<string>(maxLength: 7, nullable: false),
                    UF = table.Column<int>(nullable: false),
                    RNTC = table.Column<string>(maxLength: 20, nullable: true),
                    transpId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veicTransp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_veicTransp_transp_transpId",
                        column: x => x.transpId,
                        principalTable: "transp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    transpId = table.Column<int>(nullable: false),
                    qVol = table.Column<int>(maxLength: 15, nullable: false),
                    esp = table.Column<string>(maxLength: 60, nullable: true),
                    marca = table.Column<string>(maxLength: 60, nullable: true),
                    nVol = table.Column<string>(maxLength: 60, nullable: true),
                    pesoL = table.Column<double>(nullable: false),
                    pesoB = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vol_transp_transpId",
                        column: x => x.transpId,
                        principalTable: "transp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "procEventoNFe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    retConsSitNFeId = table.Column<int>(nullable: false),
                    versao = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procEventoNFe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_procEventoNFe_retConsSitNFe_retConsSitNFeId",
                        column: x => x.retConsSitNFeId,
                        principalTable: "retConsSitNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "protNFe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    retConsSitNFeId = table.Column<int>(nullable: false),
                    versao = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_protNFe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_protNFe_retConsSitNFe_retConsSitNFeId",
                        column: x => x.retConsSitNFeId,
                        principalTable: "retConsSitNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retCancNFe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    retConsSitNFeId = table.Column<int>(nullable: false),
                    versao = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retCancNFe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retCancNFe_retConsSitNFe_retConsSitNFeId",
                        column: x => x.retConsSitNFeId,
                        principalTable: "retConsSitNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COFINS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COFINS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COFINS_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COFINSST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pCOFINS = table.Column<double>(nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vCOFINS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COFINSST", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COFINSST_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSUFDest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false),
                    vBCUFDest = table.Column<double>(nullable: false),
                    vBCFCPUFdest = table.Column<double>(nullable: false),
                    pFCPUFdest = table.Column<double>(nullable: false),
                    pICMSUFDest = table.Column<double>(nullable: false),
                    pICMSInter = table.Column<double>(nullable: false),
                    pICMSInterPart = table.Column<double>(nullable: false),
                    vFCUFdest = table.Column<double>(nullable: false),
                    vICMSUFDest = table.Column<double>(nullable: false),
                    vICMSUFRemet = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSUFDest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSUFDest_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "II",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    vDespAdu = table.Column<double>(nullable: false),
                    vII = table.Column<double>(nullable: false),
                    vIOF = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_II", x => x.Id);
                    table.ForeignKey(
                        name: "FK_II_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false),
                    cIEnq = table.Column<string>(nullable: true),
                    CNPJProd = table.Column<string>(maxLength: 14, nullable: true),
                    cSelo = table.Column<string>(maxLength: 60, nullable: true),
                    qSelo = table.Column<int>(maxLength: 12, nullable: false),
                    cEnq = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPI_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISSQN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    vAliq = table.Column<double>(nullable: false),
                    vISSQN = table.Column<double>(nullable: false),
                    cMunFG = table.Column<int>(nullable: false),
                    cListServ = table.Column<string>(maxLength: 5, nullable: false),
                    vDeducao = table.Column<double>(nullable: false),
                    vOutro = table.Column<double>(nullable: false),
                    vDescIncond = table.Column<double>(nullable: false),
                    vDescCond = table.Column<double>(nullable: false),
                    vISSRet = table.Column<double>(nullable: false),
                    indISS = table.Column<byte>(nullable: false),
                    cServico = table.Column<string>(maxLength: 20, nullable: true),
                    cMun = table.Column<int>(nullable: false),
                    cPais = table.Column<int>(nullable: false),
                    nProcesso = table.Column<string>(maxLength: 30, nullable: true),
                    indIncentivo = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISSQN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISSQN_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PIS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PIS_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PISST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoId = table.Column<int>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pPIS = table.Column<double>(nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vPIS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PISST", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PISST_imposto_impostoId",
                        column: x => x.impostoId,
                        principalTable: "imposto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IPIDevol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    impostoDevolId = table.Column<int>(nullable: false),
                    vIPIDevol = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPIDevol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPIDevol_impostoDevol_impostoDevolId",
                        column: x => x.impostoDevolId,
                        principalTable: "impostoDevol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "arma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prodId = table.Column<int>(nullable: false),
                    tpArma = table.Column<byte>(maxLength: 1, nullable: false),
                    nSerie = table.Column<string>(maxLength: 15, nullable: false),
                    nCano = table.Column<string>(maxLength: 15, nullable: false),
                    descr = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_arma_prod_prodId",
                        column: x => x.prodId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prodId = table.Column<int>(nullable: false),
                    cProdANP = table.Column<string>(maxLength: 9, nullable: false),
                    descANP = table.Column<string>(nullable: true),
                    pGLP = table.Column<double>(nullable: false),
                    pGNn = table.Column<double>(nullable: false),
                    pGNi = table.Column<double>(nullable: false),
                    vPart = table.Column<double>(nullable: false),
                    CODIF = table.Column<string>(maxLength: 21, nullable: true),
                    qTemp = table.Column<double>(nullable: false),
                    UFCons = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comb_prod_prodId",
                        column: x => x.prodId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detExport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prodId = table.Column<int>(nullable: false),
                    nDraw = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detExport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detExport_prod_prodId",
                        column: x => x.prodId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prodId = table.Column<int>(nullable: false),
                    nDI = table.Column<string>(maxLength: 12, nullable: false),
                    dDI = table.Column<DateTime>(nullable: false),
                    xLocDesemb = table.Column<string>(maxLength: 60, nullable: false),
                    UFDesemb = table.Column<int>(nullable: false),
                    dDesemb = table.Column<DateTime>(nullable: false),
                    tpViaTransp = table.Column<int>(nullable: false),
                    vAFRMM = table.Column<double>(nullable: false),
                    tpIntermedio = table.Column<byte>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    UFTerceiro = table.Column<string>(nullable: true),
                    cExportador = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DI_prod_prodId",
                        column: x => x.prodId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "med",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prodId = table.Column<int>(nullable: false),
                    nLote = table.Column<string>(maxLength: 20, nullable: true),
                    qLote = table.Column<double>(nullable: false),
                    dFab = table.Column<DateTime>(nullable: false),
                    dVal = table.Column<DateTime>(nullable: false),
                    cProdANVISA = table.Column<string>(maxLength: 13, nullable: true),
                    vPMC = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_med", x => x.Id);
                    table.ForeignKey(
                        name: "FK_med_prod_prodId",
                        column: x => x.prodId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rastro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prodId = table.Column<int>(nullable: false),
                    nLote = table.Column<int>(maxLength: 20, nullable: false),
                    qLote = table.Column<double>(nullable: false),
                    dFab = table.Column<DateTime>(nullable: false),
                    dVal = table.Column<DateTime>(nullable: false),
                    cAgreg = table.Column<int>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rastro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rastro_prod_prodId",
                        column: x => x.prodId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "veicProd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    prodId = table.Column<int>(nullable: false),
                    tpOp = table.Column<int>(nullable: false),
                    chassi = table.Column<string>(maxLength: 17, nullable: false),
                    cCor = table.Column<string>(maxLength: 4, nullable: false),
                    xCor = table.Column<string>(maxLength: 40, nullable: false),
                    pot = table.Column<string>(maxLength: 4, nullable: false),
                    cilin = table.Column<string>(maxLength: 4, nullable: false),
                    pesoL = table.Column<double>(maxLength: 9, nullable: false),
                    pesoB = table.Column<double>(maxLength: 9, nullable: false),
                    nSerie = table.Column<string>(maxLength: 9, nullable: false),
                    tpComb = table.Column<string>(maxLength: 2, nullable: false),
                    nMotor = table.Column<string>(maxLength: 21, nullable: false),
                    CMT = table.Column<double>(maxLength: 9, nullable: false),
                    dist = table.Column<string>(maxLength: 4, nullable: false),
                    anoMod = table.Column<int>(maxLength: 4, nullable: false),
                    anoFab = table.Column<int>(maxLength: 4, nullable: false),
                    tpPint = table.Column<byte>(maxLength: 1, nullable: false),
                    tpVeic = table.Column<string>(maxLength: 2, nullable: false),
                    espVeic = table.Column<byte>(maxLength: 1, nullable: false),
                    VIN = table.Column<byte>(maxLength: 1, nullable: false),
                    condVeic = table.Column<byte>(maxLength: 1, nullable: false),
                    cMod = table.Column<string>(maxLength: 6, nullable: false),
                    cCorDENATRAN = table.Column<string>(maxLength: 2, nullable: false),
                    lota = table.Column<int>(maxLength: 3, nullable: false),
                    tpRest = table.Column<byte>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veicProd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_veicProd_prod_prodId",
                        column: x => x.prodId,
                        principalTable: "prod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refECF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NFrefId = table.Column<int>(nullable: false),
                    mod = table.Column<string>(maxLength: 2, nullable: false),
                    nECF = table.Column<int>(nullable: false),
                    nCOO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refECF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refECF_NFref_NFrefId",
                        column: x => x.NFrefId,
                        principalTable: "NFref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refNF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NFrefId = table.Column<int>(nullable: false),
                    cUF = table.Column<int>(maxLength: 7, nullable: false),
                    AAMM = table.Column<string>(maxLength: 4, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    mod = table.Column<string>(nullable: false),
                    serie = table.Column<string>(maxLength: 2, nullable: false),
                    nNF = table.Column<int>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refNF", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refNF_NFref_NFrefId",
                        column: x => x.NFrefId,
                        principalTable: "NFref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refNFP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NFrefId = table.Column<int>(nullable: false),
                    cUF = table.Column<int>(maxLength: 7, nullable: false),
                    AAMM = table.Column<string>(maxLength: 4, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    IE = table.Column<string>(nullable: true),
                    mod = table.Column<string>(nullable: false),
                    serie = table.Column<string>(maxLength: 2, nullable: false),
                    nNF = table.Column<int>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refNFP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refNFP_NFref_NFrefId",
                        column: x => x.NFrefId,
                        principalTable: "NFref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    detPagId = table.Column<int>(nullable: false),
                    tpIntegra = table.Column<int>(maxLength: 1, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    tBand = table.Column<string>(maxLength: 2, nullable: true),
                    cAut = table.Column<int>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_card_detPag_detPagId",
                        column: x => x.detPagId,
                        principalTable: "detPag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lacres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    volId = table.Column<int>(nullable: false),
                    nLacre = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lacres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lacres_vol_volId",
                        column: x => x.volId,
                        principalTable: "vol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    procEventoNFeId = table.Column<int>(nullable: false),
                    versao = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evento_procEventoNFe_procEventoNFeId",
                        column: x => x.procEventoNFeId,
                        principalTable: "procEventoNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retEvento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    procEventoNFeId = table.Column<int>(nullable: false),
                    versao = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retEvento_procEventoNFe_procEventoNFeId",
                        column: x => x.procEventoNFeId,
                        principalTable: "procEventoNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "infProt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    protNFeId = table.Column<int>(nullable: false),
                    tpAmb = table.Column<int>(nullable: false),
                    verAplic = table.Column<string>(maxLength: 20, nullable: true),
                    chNFe = table.Column<string>(maxLength: 44, nullable: true),
                    dhRecibo = table.Column<DateTime>(nullable: false),
                    nProt = table.Column<string>(maxLength: 15, nullable: true),
                    digVal = table.Column<string>(nullable: true),
                    cStat = table.Column<string>(maxLength: 3, nullable: true),
                    xMotivo = table.Column<string>(maxLength: 255, nullable: true),
                    versao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infProt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_infProt_protNFe_protNFeId",
                        column: x => x.protNFeId,
                        principalTable: "protNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "infCanc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    retCancNFeId = table.Column<int>(nullable: false),
                    tpAmb = table.Column<int>(nullable: false),
                    verAplic = table.Column<string>(maxLength: 4, nullable: true),
                    cStat = table.Column<string>(maxLength: 3, nullable: true),
                    xMotivo = table.Column<string>(maxLength: 255, nullable: true),
                    cUF = table.Column<int>(nullable: false),
                    chNFe = table.Column<string>(maxLength: 44, nullable: true),
                    dhRecibo = table.Column<DateTime>(nullable: false),
                    nProt = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infCanc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_infCanc_retCancNFe_retCancNFeId",
                        column: x => x.retCancNFeId,
                        principalTable: "retCancNFe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COFINSAliq",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COFINSId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pCOFINS = table.Column<double>(nullable: false),
                    vCOFINS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COFINSAliq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COFINSAliq_COFINS_COFINSId",
                        column: x => x.COFINSId,
                        principalTable: "COFINS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COFINSNT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COFINSId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pCOFINS = table.Column<double>(nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vCOFINS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COFINSNT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COFINSNT_COFINS_COFINSId",
                        column: x => x.COFINSId,
                        principalTable: "COFINS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COFINSOutr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COFINSId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pCOFINS = table.Column<double>(nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vCOFINS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COFINSOutr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COFINSOutr_COFINS_COFINSId",
                        column: x => x.COFINSId,
                        principalTable: "COFINS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COFINSQtde",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COFINSId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vCOFINS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COFINSQtde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COFINSQtde_COFINS_COFINSId",
                        column: x => x.COFINSId,
                        principalTable: "COFINS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS00",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    pFCP = table.Column<double>(nullable: false),
                    vFCP = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS00", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS00_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS10",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    vBCFCP = table.Column<double>(nullable: false),
                    pFCP = table.Column<double>(nullable: false),
                    vFCP = table.Column<double>(nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    vBCFCPST = table.Column<double>(nullable: false),
                    pFCPST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS10", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS10_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS20",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    pRedBC = table.Column<double>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    vBCFCP = table.Column<double>(nullable: false),
                    pFCP = table.Column<double>(nullable: false),
                    vFCP = table.Column<double>(nullable: false),
                    vICMSDeson = table.Column<double>(nullable: false),
                    motDesICMS = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS20", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS20_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS30",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    vBCFCPST = table.Column<double>(nullable: false),
                    pFCPST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false),
                    vICMSDeson = table.Column<double>(nullable: false),
                    motDesICMS = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS30", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS30_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS40",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vICMSDeson = table.Column<double>(nullable: false),
                    motDesICMS = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS40", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS40_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS51",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    pRedBC = table.Column<double>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMSOp = table.Column<double>(nullable: false),
                    pDif = table.Column<double>(nullable: false),
                    pICMSDif = table.Column<double>(nullable: false),
                    vICMSDif = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    vBCFCP = table.Column<double>(nullable: false),
                    pFCP = table.Column<double>(nullable: false),
                    vFCP = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS51", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS51_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS60",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBCSTRet = table.Column<double>(nullable: false),
                    pST = table.Column<double>(nullable: false),
                    vICMSSTRet = table.Column<double>(nullable: false),
                    vBCSFCPSTRet = table.Column<double>(nullable: false),
                    pFCPSTRet = table.Column<double>(nullable: false),
                    vFCPSTRet = table.Column<double>(nullable: false),
                    pRedBCEfet = table.Column<double>(nullable: false),
                    vBCEfet = table.Column<double>(nullable: false),
                    pICMSEfet = table.Column<double>(nullable: false),
                    vICMSEfet = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS60", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS60_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS70",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    pRedBC = table.Column<double>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    vBCFCP = table.Column<double>(nullable: false),
                    pFCP = table.Column<double>(nullable: false),
                    vFCP = table.Column<double>(nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    vBCFCPST = table.Column<double>(nullable: false),
                    pFCPST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false),
                    vICMSDeson = table.Column<double>(nullable: false),
                    motDesICMS = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS70", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS70_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMS90",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pRedBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    vBCFCP = table.Column<double>(nullable: false),
                    pFCP = table.Column<double>(nullable: false),
                    vFCP = table.Column<double>(nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    vBCFCPST = table.Column<double>(nullable: false),
                    pFCPST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false),
                    vICMSDeson = table.Column<double>(nullable: false),
                    motDesICMS = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMS90", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMS90_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSPart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pRedBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    pBCOp = table.Column<double>(nullable: false),
                    UFST = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSPart_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSSN101",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CSOSN = table.Column<string>(maxLength: 3, nullable: false),
                    pCredSN = table.Column<double>(nullable: false),
                    vCredICMSSN = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSSN101", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSSN101_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSSN102",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CSOSN = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSSN102", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSSN102_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSSN201",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CSOSN = table.Column<string>(maxLength: 3, nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    vBCFCPST = table.Column<double>(nullable: false),
                    pFCPST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false),
                    pCredSN = table.Column<double>(nullable: false),
                    vCredICMSSN = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSSN201", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSSN201_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSSN202",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CSOSN = table.Column<string>(maxLength: 3, nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    vBCFCPST = table.Column<double>(nullable: false),
                    pFCPST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSSN202", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSSN202_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSSN500",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CSOSN = table.Column<string>(maxLength: 3, nullable: false),
                    vBCSTRet = table.Column<double>(nullable: false),
                    pST = table.Column<double>(nullable: false),
                    vICMSSTRet = table.Column<double>(nullable: false),
                    vBCSFCPSTRet = table.Column<double>(nullable: false),
                    pFCPSTRet = table.Column<double>(nullable: false),
                    vFCPSTRet = table.Column<double>(nullable: false),
                    pRedBCEfet = table.Column<double>(nullable: false),
                    vBCEfet = table.Column<double>(nullable: false),
                    pICMSEfet = table.Column<double>(nullable: false),
                    vICMSEfet = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSSN500", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSSN500_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSSN900",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CSOSN = table.Column<string>(maxLength: 3, nullable: false),
                    modBC = table.Column<byte>(nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pRedBC = table.Column<double>(nullable: false),
                    pICMS = table.Column<double>(nullable: false),
                    vICMS = table.Column<double>(nullable: false),
                    modBCST = table.Column<byte>(nullable: false),
                    pMVAST = table.Column<double>(nullable: false),
                    pRedBCST = table.Column<double>(nullable: false),
                    vBCST = table.Column<double>(nullable: false),
                    pICMSST = table.Column<double>(nullable: false),
                    vICMSST = table.Column<double>(nullable: false),
                    vBCFCPST = table.Column<double>(nullable: false),
                    pFCPST = table.Column<double>(nullable: false),
                    vFCPST = table.Column<double>(nullable: false),
                    pCredSN = table.Column<double>(nullable: false),
                    vCredICMSSN = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSSN900", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSSN900_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ICMSST",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ICMSId = table.Column<int>(nullable: false),
                    orig = table.Column<byte>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBCSTRet = table.Column<double>(nullable: false),
                    vICMSSTRet = table.Column<double>(nullable: false),
                    vBCSTDest = table.Column<double>(nullable: false),
                    vICMSSTDest = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICMSST", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICMSST_ICMS_ICMSId",
                        column: x => x.ICMSId,
                        principalTable: "ICMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IPINT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IPIId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPINT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPINT_IPI_IPIId",
                        column: x => x.IPIId,
                        principalTable: "IPI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IPITrib",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IPIId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pIPI = table.Column<double>(nullable: false),
                    qUnid = table.Column<double>(nullable: false),
                    vUnid = table.Column<double>(nullable: false),
                    vIPI = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPITrib", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IPITrib_IPI_IPIId",
                        column: x => x.IPIId,
                        principalTable: "IPI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PISAliq",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PISId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pPIS = table.Column<double>(nullable: false),
                    vPIS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PISAliq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PISAliq_PIS_PISId",
                        column: x => x.PISId,
                        principalTable: "PIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PISNT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PISId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pPIS = table.Column<double>(nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vPIS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PISNT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PISNT_PIS_PISId",
                        column: x => x.PISId,
                        principalTable: "PIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PISOutr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PISId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    vBC = table.Column<double>(nullable: false),
                    pPIS = table.Column<double>(nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vPIS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PISOutr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PISOutr_PIS_PISId",
                        column: x => x.PISId,
                        principalTable: "PIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PISQtde",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PISId = table.Column<int>(nullable: false),
                    CST = table.Column<string>(maxLength: 2, nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vPIS = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PISQtde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PISQtde_PIS_PISId",
                        column: x => x.PISId,
                        principalTable: "PIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CIDE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    compId = table.Column<int>(nullable: false),
                    qBCProd = table.Column<double>(nullable: false),
                    vAliqProd = table.Column<double>(nullable: false),
                    vCIDE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIDE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CIDE_comb_compId",
                        column: x => x.compId,
                        principalTable: "comb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "encerrante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    compId = table.Column<int>(nullable: false),
                    nBico = table.Column<string>(maxLength: 3, nullable: false),
                    nBomba = table.Column<string>(maxLength: 3, nullable: true),
                    nTanque = table.Column<string>(maxLength: 3, nullable: false),
                    vEncIni = table.Column<double>(nullable: false),
                    vEncFin = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_encerrante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_encerrante_comb_compId",
                        column: x => x.compId,
                        principalTable: "comb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exportInd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    detExportId = table.Column<int>(nullable: false),
                    nRE = table.Column<string>(maxLength: 12, nullable: false),
                    chNFe = table.Column<string>(maxLength: 44, nullable: false),
                    qExport = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exportInd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exportInd_detExport_detExportId",
                        column: x => x.detExportId,
                        principalTable: "detExport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DIid = table.Column<int>(nullable: false),
                    nAdicao = table.Column<int>(nullable: false),
                    nSeqAdic = table.Column<int>(nullable: false),
                    cFabricante = table.Column<string>(maxLength: 60, nullable: false),
                    vDescDI = table.Column<double>(nullable: false),
                    nDraw = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adi_DI_DIid",
                        column: x => x.DIid,
                        principalTable: "DI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "infEvento",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    eventoId = table.Column<int>(nullable: false),
                    cOrgao = table.Column<string>(maxLength: 2, nullable: true),
                    tpAmb = table.Column<int>(nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    chNFe = table.Column<string>(maxLength: 44, nullable: true),
                    dhEvento = table.Column<DateTime>(nullable: false),
                    tpEvento = table.Column<string>(maxLength: 6, nullable: true),
                    nSeqEvento = table.Column<string>(maxLength: 2, nullable: true),
                    verEvento = table.Column<string>(nullable: true),
                    detEvento = table.Column<string>(type: "xml", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_infEvento_evento_eventoId",
                        column: x => x.eventoId,
                        principalTable: "evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "retinfEvento",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    retEventoId = table.Column<int>(nullable: false),
                    tpAmb = table.Column<int>(nullable: false),
                    verAplic = table.Column<string>(maxLength: 20, nullable: true),
                    cOrgao = table.Column<string>(maxLength: 2, nullable: true),
                    cStat = table.Column<string>(maxLength: 3, nullable: true),
                    xMotivo = table.Column<string>(maxLength: 255, nullable: true),
                    chNFe = table.Column<string>(maxLength: 44, nullable: true),
                    tpEvento = table.Column<string>(maxLength: 6, nullable: true),
                    xEvento = table.Column<string>(maxLength: 60, nullable: true),
                    nSeqEvento = table.Column<string>(maxLength: 2, nullable: true),
                    CNPJDest = table.Column<string>(maxLength: 14, nullable: true),
                    CPFDest = table.Column<string>(maxLength: 11, nullable: true),
                    emailDest = table.Column<string>(maxLength: 60, nullable: true),
                    dhRegEvento = table.Column<DateTime>(nullable: false),
                    nProt = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retinfEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_retinfEvento_retEvento_retEventoId",
                        column: x => x.retEventoId,
                        principalTable: "retEvento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adi_DIid",
                table: "adi",
                column: "DIid");

            migrationBuilder.CreateIndex(
                name: "IX_arma_prodId",
                table: "arma",
                column: "prodId");

            migrationBuilder.CreateIndex(
                name: "IX_autXML_CNPJ",
                table: "autXML",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_autXML_CPF",
                table: "autXML",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_autXML_infNFeId",
                table: "autXML",
                column: "infNFeId");

            migrationBuilder.CreateIndex(
                name: "IX_avulsa_CNPJ",
                table: "avulsa",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_avulsa_infNFeId",
                table: "avulsa",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_avulsa_xAgente",
                table: "avulsa",
                column: "xAgente");

            migrationBuilder.CreateIndex(
                name: "IX_avulsa_xOrgao",
                table: "avulsa",
                column: "xOrgao");

            migrationBuilder.CreateIndex(
                name: "IX_cana_infNFeId",
                table: "cana",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_card_detPagId",
                table: "card",
                column: "detPagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CIDE_compId",
                table: "CIDE",
                column: "compId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cobr_infNFeId",
                table: "cobr",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_COFINS_impostoId",
                table: "COFINS",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COFINSAliq_COFINSId",
                table: "COFINSAliq",
                column: "COFINSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COFINSNT_COFINSId",
                table: "COFINSNT",
                column: "COFINSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COFINSOutr_COFINSId",
                table: "COFINSOutr",
                column: "COFINSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COFINSQtde_COFINSId",
                table: "COFINSQtde",
                column: "COFINSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COFINSST_impostoId",
                table: "COFINSST",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comb_prodId",
                table: "comb",
                column: "prodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_compra_infNFeId",
                table: "compra",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_deduc_canaId",
                table: "deduc",
                column: "canaId");

            migrationBuilder.CreateIndex(
                name: "IX_dest_CNPJ",
                table: "dest",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_dest_CPF",
                table: "dest",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_dest_infNFeId",
                table: "dest",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dest_xNome",
                table: "dest",
                column: "xNome");

            migrationBuilder.CreateIndex(
                name: "IX_det_infNFeId",
                table: "det",
                column: "infNFeId");

            migrationBuilder.CreateIndex(
                name: "IX_detExport_prodId",
                table: "detExport",
                column: "prodId");

            migrationBuilder.CreateIndex(
                name: "IX_detPag_pagId",
                table: "detPag",
                column: "pagId");

            migrationBuilder.CreateIndex(
                name: "IX_DI_prodId",
                table: "DI",
                column: "prodId");

            migrationBuilder.CreateIndex(
                name: "IX_dup_cobrId",
                table: "dup",
                column: "cobrId");

            migrationBuilder.CreateIndex(
                name: "IX_emit_CNPJ",
                table: "emit",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_emit_CPF",
                table: "emit",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_emit_infNFeId",
                table: "emit",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_emit_xFant",
                table: "emit",
                column: "xFant");

            migrationBuilder.CreateIndex(
                name: "IX_emit_xNome",
                table: "emit",
                column: "xNome");

            migrationBuilder.CreateIndex(
                name: "IX_encerrante_compId",
                table: "encerrante",
                column: "compId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_enderDest_UF",
                table: "enderDest",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_enderDest_cMun",
                table: "enderDest",
                column: "cMun");

            migrationBuilder.CreateIndex(
                name: "IX_enderDest_destId",
                table: "enderDest",
                column: "destId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_enderDest_nro",
                table: "enderDest",
                column: "nro");

            migrationBuilder.CreateIndex(
                name: "IX_enderDest_xBairro",
                table: "enderDest",
                column: "xBairro");

            migrationBuilder.CreateIndex(
                name: "IX_enderDest_xLgr",
                table: "enderDest",
                column: "xLgr");

            migrationBuilder.CreateIndex(
                name: "IX_enderDest_xMun",
                table: "enderDest",
                column: "xMun");

            migrationBuilder.CreateIndex(
                name: "IX_enderEmit_UF",
                table: "enderEmit",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_enderEmit_cMun",
                table: "enderEmit",
                column: "cMun");

            migrationBuilder.CreateIndex(
                name: "IX_enderEmit_emitId",
                table: "enderEmit",
                column: "emitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_enderEmit_nro",
                table: "enderEmit",
                column: "nro");

            migrationBuilder.CreateIndex(
                name: "IX_enderEmit_xBairro",
                table: "enderEmit",
                column: "xBairro");

            migrationBuilder.CreateIndex(
                name: "IX_enderEmit_xLgr",
                table: "enderEmit",
                column: "xLgr");

            migrationBuilder.CreateIndex(
                name: "IX_enderEmit_xMun",
                table: "enderEmit",
                column: "xMun");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_UF",
                table: "entrega",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_cMun",
                table: "entrega",
                column: "cMun");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_infNFeId",
                table: "entrega",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_xBairro",
                table: "entrega",
                column: "xBairro");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_xLgr",
                table: "entrega",
                column: "xLgr");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_xMun",
                table: "entrega",
                column: "xMun");

            migrationBuilder.CreateIndex(
                name: "IX_evento_procEventoNFeId",
                table: "evento",
                column: "procEventoNFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_exporta_infNFeId",
                table: "exporta",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_exportInd_detExportId",
                table: "exportInd",
                column: "detExportId");

            migrationBuilder.CreateIndex(
                name: "IX_fat_cobrId",
                table: "fat",
                column: "cobrId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_forDia_canaId",
                table: "forDia",
                column: "canaId");

            migrationBuilder.CreateIndex(
                name: "IX_ICMS_impostoId",
                table: "ICMS",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS00_ICMSId",
                table: "ICMS00",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS10_ICMSId",
                table: "ICMS10",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS20_ICMSId",
                table: "ICMS20",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS30_ICMSId",
                table: "ICMS30",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS40_ICMSId",
                table: "ICMS40",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS51_ICMSId",
                table: "ICMS51",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS60_ICMSId",
                table: "ICMS60",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS70_ICMSId",
                table: "ICMS70",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMS90_ICMSId",
                table: "ICMS90",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSPart_ICMSId",
                table: "ICMSPart",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSSN101_ICMSId",
                table: "ICMSSN101",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSSN102_ICMSId",
                table: "ICMSSN102",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSSN201_ICMSId",
                table: "ICMSSN201",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSSN202_ICMSId",
                table: "ICMSSN202",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSSN500_ICMSId",
                table: "ICMSSN500",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSSN900_ICMSId",
                table: "ICMSSN900",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSST_ICMSId",
                table: "ICMSST",
                column: "ICMSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSTot_totalId",
                table: "ICMSTot",
                column: "totalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICMSUFDest_impostoId",
                table: "ICMSUFDest",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ide_cMunFG",
                table: "ide",
                column: "cMunFG");

            migrationBuilder.CreateIndex(
                name: "IX_ide_cUF",
                table: "ide",
                column: "cUF");

            migrationBuilder.CreateIndex(
                name: "IX_ide_finNFe",
                table: "ide",
                column: "finNFe");

            migrationBuilder.CreateIndex(
                name: "IX_ide_idDest",
                table: "ide",
                column: "idDest");

            migrationBuilder.CreateIndex(
                name: "IX_ide_indFinal",
                table: "ide",
                column: "indFinal");

            migrationBuilder.CreateIndex(
                name: "IX_ide_infNFeId",
                table: "ide",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ide_nNF",
                table: "ide",
                column: "nNF");

            migrationBuilder.CreateIndex(
                name: "IX_II_impostoId",
                table: "II",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_imposto_detId",
                table: "imposto",
                column: "detId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_impostoDevol_detId",
                table: "impostoDevol",
                column: "detId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_infAdic_infNFeId",
                table: "infAdic",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_infCanc_retCancNFeId",
                table: "infCanc",
                column: "retCancNFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_infEvento_eventoId",
                table: "infEvento",
                column: "eventoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_infNFe_NFeId",
                table: "infNFe",
                column: "NFeId",
                unique: true,
                filter: "[NFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_infNFe_versao",
                table: "infNFe",
                column: "versao");

            migrationBuilder.CreateIndex(
                name: "IX_infNFeSupl_NFeId",
                table: "infNFeSupl",
                column: "NFeId",
                unique: true,
                filter: "[NFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_infProt_protNFeId",
                table: "infProt",
                column: "protNFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IPI_impostoId",
                table: "IPI",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IPIDevol_impostoDevolId",
                table: "IPIDevol",
                column: "impostoDevolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IPINT_IPIId",
                table: "IPINT",
                column: "IPIId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IPITrib_IPIId",
                table: "IPITrib",
                column: "IPIId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ISSQN_impostoId",
                table: "ISSQN",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ISSQNTot_totalId",
                table: "ISSQNTot",
                column: "totalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lacres_volId",
                table: "lacres",
                column: "volId");

            migrationBuilder.CreateIndex(
                name: "IX_med_prodId",
                table: "med",
                column: "prodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NFe_Hash",
                table: "NFe",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NFref_ideId",
                table: "NFref",
                column: "ideId");

            migrationBuilder.CreateIndex(
                name: "IX_obsCont_infAdicId",
                table: "obsCont",
                column: "infAdicId");

            migrationBuilder.CreateIndex(
                name: "IX_obsFisco_infAdicId",
                table: "obsFisco",
                column: "infAdicId");

            migrationBuilder.CreateIndex(
                name: "IX_pag_infNFeId",
                table: "pag",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PIS_impostoId",
                table: "PIS",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PISAliq_PISId",
                table: "PISAliq",
                column: "PISId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PISNT_PISId",
                table: "PISNT",
                column: "PISId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PISOutr_PISId",
                table: "PISOutr",
                column: "PISId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PISQtde_PISId",
                table: "PISQtde",
                column: "PISId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PISST_impostoId",
                table: "PISST",
                column: "impostoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_procEventoNFe_retConsSitNFeId",
                table: "procEventoNFe",
                column: "retConsSitNFeId");

            migrationBuilder.CreateIndex(
                name: "IX_procRef_infAdicId",
                table: "procRef",
                column: "infAdicId");

            migrationBuilder.CreateIndex(
                name: "IX_prod_CEST",
                table: "prod",
                column: "CEST");

            migrationBuilder.CreateIndex(
                name: "IX_prod_NCM",
                table: "prod",
                column: "NCM");

            migrationBuilder.CreateIndex(
                name: "IX_prod_cProd",
                table: "prod",
                column: "cProd");

            migrationBuilder.CreateIndex(
                name: "IX_prod_detId",
                table: "prod",
                column: "detId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prod_xProd",
                table: "prod",
                column: "xProd");

            migrationBuilder.CreateIndex(
                name: "IX_protNFe_retConsSitNFeId",
                table: "protNFe",
                column: "retConsSitNFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rastro_prodId",
                table: "rastro",
                column: "prodId");

            migrationBuilder.CreateIndex(
                name: "IX_reboque_transpId",
                table: "reboque",
                column: "transpId");

            migrationBuilder.CreateIndex(
                name: "IX_refECF_NFrefId",
                table: "refECF",
                column: "NFrefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refNF_NFrefId",
                table: "refNF",
                column: "NFrefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refNFP_NFrefId",
                table: "refNFP",
                column: "NFrefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_retCancNFe_retConsSitNFeId",
                table: "retCancNFe",
                column: "retConsSitNFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_retConsSitNFe_XmlNFeId",
                table: "retConsSitNFe",
                column: "XmlNFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_retEvento_procEventoNFeId",
                table: "retEvento",
                column: "procEventoNFeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_retinfEvento_retEventoId",
                table: "retinfEvento",
                column: "retEventoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_retirada_UF",
                table: "retirada",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_retirada_cMun",
                table: "retirada",
                column: "cMun");

            migrationBuilder.CreateIndex(
                name: "IX_retirada_infNFeId",
                table: "retirada",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_retirada_xBairro",
                table: "retirada",
                column: "xBairro");

            migrationBuilder.CreateIndex(
                name: "IX_retirada_xLgr",
                table: "retirada",
                column: "xLgr");

            migrationBuilder.CreateIndex(
                name: "IX_retirada_xMun",
                table: "retirada",
                column: "xMun");

            migrationBuilder.CreateIndex(
                name: "IX_retTransp_transpId",
                table: "retTransp",
                column: "transpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_retTrib_totalId",
                table: "retTrib",
                column: "totalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_total_infNFeId",
                table: "total",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_transp_infNFeId",
                table: "transp",
                column: "infNFeId",
                unique: true,
                filter: "[infNFeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_transporta_transpId",
                table: "transporta",
                column: "transpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_veicProd_prodId",
                table: "veicProd",
                column: "prodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_veicTransp_transpId",
                table: "veicTransp",
                column: "transpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vol_transpId",
                table: "vol",
                column: "transpId");

            migrationBuilder.CreateIndex(
                name: "IX_xmlNFe_DhChange",
                table: "xmlNFe",
                column: "DhChange");

            migrationBuilder.CreateIndex(
                name: "IX_xmlNFe_NFeId",
                table: "xmlNFe",
                column: "NFeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adi");

            migrationBuilder.DropTable(
                name: "arma");

            migrationBuilder.DropTable(
                name: "autXML");

            migrationBuilder.DropTable(
                name: "avulsa");

            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "CIDE");

            migrationBuilder.DropTable(
                name: "COFINSAliq");

            migrationBuilder.DropTable(
                name: "COFINSNT");

            migrationBuilder.DropTable(
                name: "COFINSOutr");

            migrationBuilder.DropTable(
                name: "COFINSQtde");

            migrationBuilder.DropTable(
                name: "COFINSST");

            migrationBuilder.DropTable(
                name: "compra");

            migrationBuilder.DropTable(
                name: "deduc");

            migrationBuilder.DropTable(
                name: "dup");

            migrationBuilder.DropTable(
                name: "encerrante");

            migrationBuilder.DropTable(
                name: "enderDest");

            migrationBuilder.DropTable(
                name: "enderEmit");

            migrationBuilder.DropTable(
                name: "entrega");

            migrationBuilder.DropTable(
                name: "exporta");

            migrationBuilder.DropTable(
                name: "exportInd");

            migrationBuilder.DropTable(
                name: "fat");

            migrationBuilder.DropTable(
                name: "forDia");

            migrationBuilder.DropTable(
                name: "ICMS00");

            migrationBuilder.DropTable(
                name: "ICMS10");

            migrationBuilder.DropTable(
                name: "ICMS20");

            migrationBuilder.DropTable(
                name: "ICMS30");

            migrationBuilder.DropTable(
                name: "ICMS40");

            migrationBuilder.DropTable(
                name: "ICMS51");

            migrationBuilder.DropTable(
                name: "ICMS60");

            migrationBuilder.DropTable(
                name: "ICMS70");

            migrationBuilder.DropTable(
                name: "ICMS90");

            migrationBuilder.DropTable(
                name: "ICMSPart");

            migrationBuilder.DropTable(
                name: "ICMSSN101");

            migrationBuilder.DropTable(
                name: "ICMSSN102");

            migrationBuilder.DropTable(
                name: "ICMSSN201");

            migrationBuilder.DropTable(
                name: "ICMSSN202");

            migrationBuilder.DropTable(
                name: "ICMSSN500");

            migrationBuilder.DropTable(
                name: "ICMSSN900");

            migrationBuilder.DropTable(
                name: "ICMSST");

            migrationBuilder.DropTable(
                name: "ICMSTot");

            migrationBuilder.DropTable(
                name: "ICMSUFDest");

            migrationBuilder.DropTable(
                name: "II");

            migrationBuilder.DropTable(
                name: "infCanc");

            migrationBuilder.DropTable(
                name: "infEvento");

            migrationBuilder.DropTable(
                name: "infNFeSupl");

            migrationBuilder.DropTable(
                name: "infProt");

            migrationBuilder.DropTable(
                name: "IPIDevol");

            migrationBuilder.DropTable(
                name: "IPINT");

            migrationBuilder.DropTable(
                name: "IPITrib");

            migrationBuilder.DropTable(
                name: "ISSQN");

            migrationBuilder.DropTable(
                name: "ISSQNTot");

            migrationBuilder.DropTable(
                name: "lacres");

            migrationBuilder.DropTable(
                name: "med");

            migrationBuilder.DropTable(
                name: "obsCont");

            migrationBuilder.DropTable(
                name: "obsFisco");

            migrationBuilder.DropTable(
                name: "PISAliq");

            migrationBuilder.DropTable(
                name: "PISNT");

            migrationBuilder.DropTable(
                name: "PISOutr");

            migrationBuilder.DropTable(
                name: "PISQtde");

            migrationBuilder.DropTable(
                name: "PISST");

            migrationBuilder.DropTable(
                name: "procRef");

            migrationBuilder.DropTable(
                name: "rastro");

            migrationBuilder.DropTable(
                name: "reboque");

            migrationBuilder.DropTable(
                name: "refECF");

            migrationBuilder.DropTable(
                name: "refNF");

            migrationBuilder.DropTable(
                name: "refNFP");

            migrationBuilder.DropTable(
                name: "retinfEvento");

            migrationBuilder.DropTable(
                name: "retirada");

            migrationBuilder.DropTable(
                name: "retTransp");

            migrationBuilder.DropTable(
                name: "retTrib");

            migrationBuilder.DropTable(
                name: "tprodutoBases");

            migrationBuilder.DropTable(
                name: "transporta");

            migrationBuilder.DropTable(
                name: "veicProd");

            migrationBuilder.DropTable(
                name: "veicTransp");

            migrationBuilder.DropTable(
                name: "DI");

            migrationBuilder.DropTable(
                name: "detPag");

            migrationBuilder.DropTable(
                name: "COFINS");

            migrationBuilder.DropTable(
                name: "comb");

            migrationBuilder.DropTable(
                name: "dest");

            migrationBuilder.DropTable(
                name: "emit");

            migrationBuilder.DropTable(
                name: "detExport");

            migrationBuilder.DropTable(
                name: "cobr");

            migrationBuilder.DropTable(
                name: "cana");

            migrationBuilder.DropTable(
                name: "ICMS");

            migrationBuilder.DropTable(
                name: "retCancNFe");

            migrationBuilder.DropTable(
                name: "evento");

            migrationBuilder.DropTable(
                name: "protNFe");

            migrationBuilder.DropTable(
                name: "impostoDevol");

            migrationBuilder.DropTable(
                name: "IPI");

            migrationBuilder.DropTable(
                name: "vol");

            migrationBuilder.DropTable(
                name: "PIS");

            migrationBuilder.DropTable(
                name: "infAdic");

            migrationBuilder.DropTable(
                name: "NFref");

            migrationBuilder.DropTable(
                name: "retEvento");

            migrationBuilder.DropTable(
                name: "total");

            migrationBuilder.DropTable(
                name: "pag");

            migrationBuilder.DropTable(
                name: "prod");

            migrationBuilder.DropTable(
                name: "transp");

            migrationBuilder.DropTable(
                name: "imposto");

            migrationBuilder.DropTable(
                name: "ide");

            migrationBuilder.DropTable(
                name: "procEventoNFe");

            migrationBuilder.DropTable(
                name: "det");

            migrationBuilder.DropTable(
                name: "retConsSitNFe");

            migrationBuilder.DropTable(
                name: "infNFe");

            migrationBuilder.DropTable(
                name: "xmlNFe");

            migrationBuilder.DropTable(
                name: "NFe");
        }
    }
}
