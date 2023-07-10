using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublishActivity.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalyticalBase",
                columns: table => new
                {
                    idABase = table.Column<int>(name: "id_ABase", type: "int", nullable: false),
                    NameABase = table.Column<string>(name: "Name_ABase", type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AnalyticalBase_PK", x => x.idABase);
                });

            migrationBuilder.CreateTable(
                name: "aut",
                columns: table => new
                {
                    idaut = table.Column<int>(name: "id_aut", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fam = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nam1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nam2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    idexp = table.Column<int>(name: "id_exp", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aut", x => x.idaut);
                });

            migrationBuilder.CreateTable(
                name: "dbo.tmp_table",
                columns: table => new
                {
                    idexport = table.Column<int>(name: "id_export", type: "int", nullable: false),
                    NameAuthorEN = table.Column<string>(name: "NameAuthor_EN", type: "nvarchar(max)", nullable: true),
                    NameAuthorRU = table.Column<string>(name: "NameAuthor_RU", type: "nvarchar(max)", nullable: true),
                    NameEdt = table.Column<string>(name: "Name_Edt", type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Release = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOIED = table.Column<string>(name: "DOI_ED", type: "nvarchar(max)", nullable: true),
                    URLISI = table.Column<string>(name: "URL_ISI", type: "nvarchar(max)", nullable: true),
                    NamePDO = table.Column<string>(name: "Name_PDO", type: "nvarchar(max)", nullable: true),
                    Namepart = table.Column<string>(name: "Name_part", type: "nvarchar(max)", nullable: true),
                    ISSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    languagepart = table.Column<string>(name: "language_part", type: "nvarchar(max)", nullable: true),
                    NameStruct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValumeUIA = table.Column<string>(name: "Valume_UIA", type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageBg = table.Column<int>(type: "int", nullable: true),
                    PageEnd = table.Column<int>(type: "int", nullable: true),
                    ValumeIndA = table.Column<int>(name: "Valume_IndA", type: "int", nullable: true),
                    NameABase = table.Column<string>(name: "Name_ABase", type: "nvarchar(max)", nullable: true),
                    dataexport = table.Column<DateTime>(name: "data_export", type: "datetime", nullable: true),
                    dataimport = table.Column<DateTime>(name: "data_import", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DS",
                columns: table => new
                {
                    DS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FIO = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    NS = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: true),
                    FIOtranslit = table.Column<string>(name: "FIO_translit", type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    idlanguage = table.Column<int>(name: "id_language", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namelang = table.Column<string>(name: "Name_lang", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Namelang1 = table.Column<string>(name: "Name_lang1", type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("language_PK", x => x.idlanguage);
                });

            migrationBuilder.CreateTable(
                name: "level_Edition",
                columns: table => new
                {
                    idedition = table.Column<int>(name: "id_edition", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamelevEdition = table.Column<string>(name: "Name_levEdition", type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("level_Edition_PK", x => x.idedition);
                });

            migrationBuilder.CreateTable(
                name: "Office_depart",
                columns: table => new
                {
                    kodoffice = table.Column<string>(name: "kod_office", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    kodparent = table.Column<string>(name: "kod_parent", type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Nameoffice = table.Column<string>(name: "Name_office", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    typeoffice = table.Column<int>(name: "type_office", type: "int", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Office_depart_PK", x => x.kodoffice);
                });

            migrationBuilder.CreateTable(
                name: "publishing_office",
                columns: table => new
                {
                    idPBO = table.Column<int>(name: "id_PBO", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePDO = table.Column<string>(name: "Name_PDO", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("publishing_office_PK", x => x.idPBO);
                });

            migrationBuilder.CreateTable(
                name: "Spr_formatInfo",
                columns: table => new
                {
                    TypeED = table.Column<int>(name: "Type_ED", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namenlnform = table.Column<string>(name: "Name_nlnform", type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Spr_formatInfo_PK", x => x.TypeED);
                });

            migrationBuilder.CreateTable(
                name: "Spr_heading",
                columns: table => new
                {
                    idheading = table.Column<int>(name: "id_heading", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameheading = table.Column<string>(name: "Name_heading", type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Spr_heading_PK", x => x.idheading);
                });

            migrationBuilder.CreateTable(
                name: "Spr_idAuthors",
                columns: table => new
                {
                    idIAS = table.Column<int>(name: "id_IAS", type: "int", nullable: false),
                    NameIAS = table.Column<string>(name: "Name_IAS", type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Spr_idAuthors_PK", x => x.idIAS);
                });

            migrationBuilder.CreateTable(
                name: "Spr_IdEdition",
                columns: table => new
                {
                    idUIA = table.Column<int>(name: "id_UIA", type: "int", nullable: false),
                    NameUIA = table.Column<string>(name: "Name_UIA", type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Spr_IdEdition_PK", x => x.idUIA);
                });

            migrationBuilder.CreateTable(
                name: "Spr_roles",
                columns: table => new
                {
                    idrole = table.Column<int>(name: "id_role", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namerole = table.Column<string>(name: "name_role", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spr_roles", x => x.idrole);
                });

            migrationBuilder.CreateTable(
                name: "Spr_structure",
                columns: table => new
                {
                    idTypePart = table.Column<int>(name: "id_TypePart", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePart = table.Column<string>(name: "Name_Part", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NamePart1 = table.Column<string>(name: "Name_Part1", type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Spr_structure_PK", x => x.idTypePart);
                });

            migrationBuilder.CreateTable(
                name: "tmp_export",
                columns: table => new
                {
                    idexport = table.Column<int>(name: "id_export", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAuthorEN = table.Column<string>(name: "NameAuthor_EN", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NameAuthorRU = table.Column<string>(name: "NameAuthor_RU", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NameEdt = table.Column<string>(name: "Name_Edt", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Release = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DOIED = table.Column<string>(name: "DOI_ED", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    URLISI = table.Column<string>(name: "URL_ISI", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NamePDO = table.Column<string>(name: "Name_PDO", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Namepart = table.Column<string>(name: "Name_part", type: "nvarchar(max)", nullable: true),
                    ISSN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    languagepart = table.Column<string>(name: "language_part", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NameStruct = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ValumeUIA = table.Column<string>(name: "Valume_UIA", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PageCount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PageBg = table.Column<int>(type: "int", nullable: true),
                    PageEnd = table.Column<int>(type: "int", nullable: true),
                    ValumeIndA = table.Column<int>(name: "Valume_IndA", type: "int", nullable: true),
                    NameABase = table.Column<string>(name: "Name_ABase", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    dataexport = table.Column<DateTime>(name: "data_export", type: "datetime", nullable: true),
                    dataimport = table.Column<DateTime>(name: "data_import", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tmp_export", x => x.idexport);
                });

            migrationBuilder.CreateTable(
                name: "tmp_export1",
                columns: table => new
                {
                    idexport = table.Column<int>(name: "id_export", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAuthorEN = table.Column<string>(name: "NameAuthor_EN", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NameAuthorRU = table.Column<string>(name: "NameAuthor_RU", type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    NameEdt = table.Column<string>(name: "Name_Edt", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Release = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DOIED = table.Column<string>(name: "DOI_ED", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    URLISI = table.Column<string>(name: "URL_ISI", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NamePDO = table.Column<string>(name: "Name_PDO", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Namepart = table.Column<string>(name: "Name_part", type: "nvarchar(max)", nullable: true),
                    ISSN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    languagepart = table.Column<string>(name: "language_part", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NameStruct = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ValumeUIA = table.Column<string>(name: "Valume_UIA", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PageCount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PageBg = table.Column<int>(type: "int", nullable: true),
                    PageEnd = table.Column<int>(type: "int", nullable: true),
                    ValumeIndA = table.Column<int>(name: "Valume_IndA", type: "int", nullable: true),
                    NameABase = table.Column<string>(name: "Name_ABase", type: "nvarchar(30)", maxLength: 30, nullable: true),
                    dataexport = table.Column<DateTime>(name: "data_export", type: "datetime", nullable: true),
                    dataimport = table.Column<DateTime>(name: "data_import", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tmp_export1", x => x.idexport);
                });

            migrationBuilder.CreateTable(
                name: "Ind_Journal",
                columns: table => new
                {
                    idIndJ = table.Column<int>(name: "id_IndJ", type: "int", nullable: false),
                    NameIndJ = table.Column<string>(name: "Name_IndJ", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnalyticalBaseidABase = table.Column<int>(name: "AnalyticalBase_id_ABase", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ind_Journal_PK", x => x.idIndJ);
                    table.ForeignKey(
                        name: "Ind_Journal_AnalyticalBase_FK",
                        column: x => x.AnalyticalBaseidABase,
                        principalTable: "AnalyticalBase",
                        principalColumn: "id_ABase");
                });

            migrationBuilder.CreateTable(
                name: "IndArticles",
                columns: table => new
                {
                    idIndPrt = table.Column<int>(name: "id_IndPrt", type: "int", nullable: false),
                    NameIndPrt = table.Column<string>(name: "Name_IndPrt", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnalyticalBaseidABase = table.Column<int>(name: "AnalyticalBase_id_ABase", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IndArticles_PK", x => x.idIndPrt);
                    table.ForeignKey(
                        name: "IndArticles_AnalyticalBase_FK",
                        column: x => x.AnalyticalBaseidABase,
                        principalTable: "AnalyticalBase",
                        principalColumn: "id_ABase");
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    JobName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone_Number", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Officedepartkodoffice = table.Column<string>(name: "Office_depart_kod_office", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Tabnum = table.Column<string>(name: "Tab_num", type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Yearbirth = table.Column<string>(name: "Year_birth", type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Author_PK", x => x.UID);
                    table.ForeignKey(
                        name: "Author_Office_depart_FK",
                        column: x => x.Officedepartkodoffice,
                        principalTable: "Office_depart",
                        principalColumn: "kod_office");
                });

            migrationBuilder.CreateTable(
                name: "edition",
                columns: table => new
                {
                    idEdt = table.Column<int>(name: "id_Edt", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EDNidPBO = table.Column<int>(name: "EDN_id_PBO", type: "int", nullable: false),
                    NameEdt = table.Column<string>(name: "Name_Edt", type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Regularity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TypeAccess = table.Column<string>(name: "Type_Access", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EDNidlanguage = table.Column<int>(name: "EDN_id_language", type: "int", nullable: true),
                    SprformatInfoTypeED = table.Column<int>(name: "Spr_formatInfo_Type_ED", type: "int", nullable: true),
                    idedition = table.Column<int>(name: "id_edition", type: "int", nullable: true),
                    EDNtypeed = table.Column<string>(name: "EDN_type_ed", type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DOIED = table.Column<string>(name: "DOI_ED", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    URLISI = table.Column<string>(name: "URL_ISI", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ISSN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ISSNO = table.Column<string>(name: "ISSN_O", type: "nvarchar(13)", maxLength: 13, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Release = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    Coverage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateEdit = table.Column<DateTime>(name: "Date_Edit", type: "date", nullable: true),
                    Userid = table.Column<string>(name: "User_id", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateExtract = table.Column<DateTime>(name: "Date_Extract", type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("edition_PK", x => x.idEdt);
                    table.ForeignKey(
                        name: "FK_edition_Spr_formatInfo",
                        column: x => x.SprformatInfoTypeED,
                        principalTable: "Spr_formatInfo",
                        principalColumn: "Type_ED");
                    table.ForeignKey(
                        name: "FK_edition_language",
                        column: x => x.EDNidlanguage,
                        principalTable: "language",
                        principalColumn: "id_language");
                    table.ForeignKey(
                        name: "FK_edition_level_Edition",
                        column: x => x.idedition,
                        principalTable: "level_Edition",
                        principalColumn: "id_edition");
                    table.ForeignKey(
                        name: "FK_edition_publishing_office",
                        column: x => x.EDNidPBO,
                        principalTable: "publishing_office",
                        principalColumn: "id_PBO");
                });

            migrationBuilder.CreateTable(
                name: "Spr_thematic",
                columns: table => new
                {
                    idthematic = table.Column<int>(name: "id_thematic", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namethematic = table.Column<string>(name: "Name_thematic", type: "nvarchar(150)", maxLength: 150, nullable: true),
                    idheading = table.Column<int>(name: "id_heading", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spr_thematic", x => x.idthematic);
                    table.ForeignKey(
                        name: "FK_Spr_thematic_Spr_heading",
                        column: x => x.idheading,
                        principalTable: "Spr_heading",
                        principalColumn: "id_heading");
                });

            migrationBuilder.CreateTable(
                name: "Spr_Users",
                columns: table => new
                {
                    idusers = table.Column<int>(name: "id_users", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    loginuser = table.Column<string>(name: "login_user", type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pwduser = table.Column<string>(name: "pwd_user", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    idrole = table.Column<int>(name: "id_role", type: "int", nullable: false),
                    UID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spr_Users", x => x.idusers);
                    table.ForeignKey(
                        name: "FK_Spr_Users_Spr_roles",
                        column: x => x.idrole,
                        principalTable: "Spr_roles",
                        principalColumn: "id_role");
                });

            migrationBuilder.CreateTable(
                name: "id_Author",
                columns: table => new
                {
                    AuthorUID = table.Column<int>(name: "Author_UID", type: "int", nullable: false),
                    SpridAuthorsidIAS = table.Column<int>(name: "Spr_idAuthors_id_IAS", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "id_Author_Author_FK",
                        column: x => x.AuthorUID,
                        principalTable: "Author",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "id_Author_Spr_idAuthors_FK",
                        column: x => x.SpridAuthorsidIAS,
                        principalTable: "Spr_idAuthors",
                        principalColumn: "id_IAS");
                });

            migrationBuilder.CreateTable(
                name: "Author_book",
                columns: table => new
                {
                    AuthorPartB = table.Column<string>(name: "Author_PartB", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EDNidEdt = table.Column<int>(name: "EDN_id_Edt", type: "int", nullable: false),
                    AuthorUID = table.Column<int>(name: "Author_UID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Author_book_Author_FK",
                        column: x => x.AuthorUID,
                        principalTable: "Author",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "FK_Author_book_edition",
                        column: x => x.EDNidEdt,
                        principalTable: "edition",
                        principalColumn: "id_Edt");
                });

            migrationBuilder.CreateTable(
                name: "category_edit",
                columns: table => new
                {
                    kodheading = table.Column<string>(name: "kod_heading", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Namearea = table.Column<string>(name: "Name_area", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    editionidEdt = table.Column<int>(name: "edition_id_Edt", type: "int", nullable: false),
                    Sprheadingidheading = table.Column<int>(name: "Spr_heading_id_heading", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_category_edit_edition",
                        column: x => x.editionidEdt,
                        principalTable: "edition",
                        principalColumn: "id_Edt");
                    table.ForeignKey(
                        name: "category_edit_Spr_heading_FK",
                        column: x => x.Sprheadingidheading,
                        principalTable: "Spr_heading",
                        principalColumn: "id_heading");
                });

            migrationBuilder.CreateTable(
                name: "reting_Journal",
                columns: table => new
                {
                    ValumeInd = table.Column<decimal>(name: "Valume_Ind", type: "decimal(5,4)", nullable: false),
                    Subjectarea = table.Column<string>(name: "Subject_area", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateEditJ = table.Column<DateTime>(name: "Date_EditJ", type: "date", nullable: true),
                    Userid = table.Column<int>(name: "User_id", type: "int", nullable: true),
                    IndJournalidIndJ = table.Column<int>(name: "Ind_Journal_id_IndJ", type: "int", nullable: false),
                    idEdt = table.Column<int>(name: "id_Edt", type: "int", nullable: true),
                    yearJ = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_reting_Journal_edition",
                        column: x => x.idEdt,
                        principalTable: "edition",
                        principalColumn: "id_Edt");
                    table.ForeignKey(
                        name: "reting_Journal_Ind_Journal_FK",
                        column: x => x.IndJournalidIndJ,
                        principalTable: "Ind_Journal",
                        principalColumn: "id_IndJ");
                });

            migrationBuilder.CreateTable(
                name: "structural_part",
                columns: table => new
                {
                    idpart = table.Column<int>(name: "id_part", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idlanguage = table.Column<int>(name: "id_language", type: "int", nullable: true),
                    Namepart = table.Column<string>(name: "Name_part", type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NumArticle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PageBg = table.Column<int>(type: "int", nullable: true),
                    PageEnd = table.Column<int>(type: "int", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    URLArt = table.Column<string>(name: "URL_Art", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DateIns = table.Column<DateTime>(name: "Date_Ins", type: "datetime", nullable: true),
                    UserIns = table.Column<int>(name: "User_Ins", type: "int", nullable: true),
                    Copyid = table.Column<int>(name: "Copy_id", type: "int", nullable: true),
                    DateEdA = table.Column<DateTime>(name: "Date_EdA", type: "datetime", nullable: true),
                    UserEdA = table.Column<int>(name: "User_EdA", type: "int", nullable: true),
                    DateExtractA = table.Column<DateTime>(name: "Date_ExtractA", type: "datetime", nullable: true),
                    editionidEdt = table.Column<int>(name: "edition_id_Edt", type: "int", nullable: false),
                    SprstructureidTypePart = table.Column<int>(name: "Spr_structure_id_TypePart", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("structural_part_PK", x => x.idpart);
                    table.ForeignKey(
                        name: "FK_structural_part_edition",
                        column: x => x.editionidEdt,
                        principalTable: "edition",
                        principalColumn: "id_Edt");
                    table.ForeignKey(
                        name: "FK_structural_part_language",
                        column: x => x.idlanguage,
                        principalTable: "language",
                        principalColumn: "id_language");
                    table.ForeignKey(
                        name: "structural_part_Spr_structure_FK",
                        column: x => x.SprstructureidTypePart,
                        principalTable: "Spr_structure",
                        principalColumn: "id_TypePart");
                });

            migrationBuilder.CreateTable(
                name: "Author_publ",
                columns: table => new
                {
                    AuthorsPartA = table.Column<string>(name: "Authors_PartA", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    structuralpartidpart = table.Column<int>(name: "structural_part_id_part", type: "int", nullable: false),
                    AuthorUID = table.Column<int>(name: "Author_UID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Author_publ_Author_FK",
                        column: x => x.AuthorUID,
                        principalTable: "Author",
                        principalColumn: "UID");
                    table.ForeignKey(
                        name: "Author_publ_structural_part_FK",
                        column: x => x.structuralpartidpart,
                        principalTable: "structural_part",
                        principalColumn: "id_part");
                });

            migrationBuilder.CreateTable(
                name: "indicat_articles",
                columns: table => new
                {
                    ValumeIndA = table.Column<int>(name: "Valume_IndA", type: "int", nullable: false),
                    DateEditA = table.Column<DateTime>(name: "Date_EditA", type: "date", nullable: true),
                    Userid = table.Column<int>(name: "User_id", type: "int", nullable: true),
                    structuralpartidpart = table.Column<int>(name: "structural_part_id_part", type: "int", nullable: false),
                    IndArticlesidIndPrt = table.Column<int>(name: "IndArticles_id_IndPrt", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "indicat_articles_IndArticles_FK",
                        column: x => x.IndArticlesidIndPrt,
                        principalTable: "IndArticles",
                        principalColumn: "id_IndPrt");
                    table.ForeignKey(
                        name: "indicat_articles_structural_part_FK",
                        column: x => x.structuralpartidpart,
                        principalTable: "structural_part",
                        principalColumn: "id_part");
                });

            migrationBuilder.CreateTable(
                name: "Subjects_head",
                columns: table => new
                {
                    structuralpartidpart = table.Column<int>(name: "structural_part_id_part", type: "int", nullable: false),
                    idthematic = table.Column<int>(name: "id_thematic", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Subjects_head_Spr_thematic",
                        column: x => x.idthematic,
                        principalTable: "Spr_thematic",
                        principalColumn: "id_thematic");
                    table.ForeignKey(
                        name: "Subjects_head_structural_part_FK",
                        column: x => x.structuralpartidpart,
                        principalTable: "structural_part",
                        principalColumn: "id_part");
                });

            migrationBuilder.CreateTable(
                name: "UIA_articles",
                columns: table => new
                {
                    ValumeUIA = table.Column<string>(name: "Valume_UIA", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    structuralpartidpart = table.Column<int>(name: "structural_part_id_part", type: "int", nullable: false),
                    SprIdEditionidUIA = table.Column<int>(name: "Spr_IdEdition_id_UIA", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "UIA_articles_Spr_IdEdition_FK",
                        column: x => x.SprIdEditionidUIA,
                        principalTable: "Spr_IdEdition",
                        principalColumn: "id_UIA");
                    table.ForeignKey(
                        name: "UIA_articles_structural_part_FK",
                        column: x => x.structuralpartidpart,
                        principalTable: "structural_part",
                        principalColumn: "id_part");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Office_depart_kod_office",
                table: "Author",
                column: "Office_depart_kod_office");

            migrationBuilder.CreateIndex(
                name: "IX_Author_book_Author_UID",
                table: "Author_book",
                column: "Author_UID");

            migrationBuilder.CreateIndex(
                name: "IX_Author_book_EDN_id_Edt",
                table: "Author_book",
                column: "EDN_id_Edt");

            migrationBuilder.CreateIndex(
                name: "IX_Author_publ_Author_UID",
                table: "Author_publ",
                column: "Author_UID");

            migrationBuilder.CreateIndex(
                name: "IX_Author_publ_structural_part_id_part",
                table: "Author_publ",
                column: "structural_part_id_part");

            migrationBuilder.CreateIndex(
                name: "IX_category_edit_edition_id_Edt",
                table: "category_edit",
                column: "edition_id_Edt");

            migrationBuilder.CreateIndex(
                name: "IX_category_edit_Spr_heading_id_heading",
                table: "category_edit",
                column: "Spr_heading_id_heading");

            migrationBuilder.CreateIndex(
                name: "IX_edition_EDN_id_language",
                table: "edition",
                column: "EDN_id_language");

            migrationBuilder.CreateIndex(
                name: "IX_edition_EDN_id_PBO",
                table: "edition",
                column: "EDN_id_PBO");

            migrationBuilder.CreateIndex(
                name: "IX_edition_id_edition",
                table: "edition",
                column: "id_edition");

            migrationBuilder.CreateIndex(
                name: "IX_edition_Spr_formatInfo_Type_ED",
                table: "edition",
                column: "Spr_formatInfo_Type_ED");

            migrationBuilder.CreateIndex(
                name: "IX_id_Author_Author_UID",
                table: "id_Author",
                column: "Author_UID");

            migrationBuilder.CreateIndex(
                name: "IX_id_Author_Spr_idAuthors_id_IAS",
                table: "id_Author",
                column: "Spr_idAuthors_id_IAS");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_Journal_AnalyticalBase_id_ABase",
                table: "Ind_Journal",
                column: "AnalyticalBase_id_ABase");

            migrationBuilder.CreateIndex(
                name: "IX_IndArticles_AnalyticalBase_id_ABase",
                table: "IndArticles",
                column: "AnalyticalBase_id_ABase");

            migrationBuilder.CreateIndex(
                name: "IX_indicat_articles_IndArticles_id_IndPrt",
                table: "indicat_articles",
                column: "IndArticles_id_IndPrt");

            migrationBuilder.CreateIndex(
                name: "IX_indicat_articles_structural_part_id_part",
                table: "indicat_articles",
                column: "structural_part_id_part");

            migrationBuilder.CreateIndex(
                name: "IX_reting_Journal_id_Edt",
                table: "reting_Journal",
                column: "id_Edt");

            migrationBuilder.CreateIndex(
                name: "IX_reting_Journal_Ind_Journal_id_IndJ",
                table: "reting_Journal",
                column: "Ind_Journal_id_IndJ");

            migrationBuilder.CreateIndex(
                name: "IX_Spr_thematic_id_heading",
                table: "Spr_thematic",
                column: "id_heading");

            migrationBuilder.CreateIndex(
                name: "IX_Spr_Users_id_role",
                table: "Spr_Users",
                column: "id_role");

            migrationBuilder.CreateIndex(
                name: "IX_structural_part_edition_id_Edt",
                table: "structural_part",
                column: "edition_id_Edt");

            migrationBuilder.CreateIndex(
                name: "IX_structural_part_id_language",
                table: "structural_part",
                column: "id_language");

            migrationBuilder.CreateIndex(
                name: "IX_structural_part_Spr_structure_id_TypePart",
                table: "structural_part",
                column: "Spr_structure_id_TypePart");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_head_id_thematic",
                table: "Subjects_head",
                column: "id_thematic");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_head_structural_part_id_part",
                table: "Subjects_head",
                column: "structural_part_id_part");

            migrationBuilder.CreateIndex(
                name: "IX_UIA_articles_Spr_IdEdition_id_UIA",
                table: "UIA_articles",
                column: "Spr_IdEdition_id_UIA");

            migrationBuilder.CreateIndex(
                name: "IX_UIA_articles_structural_part_id_part",
                table: "UIA_articles",
                column: "structural_part_id_part");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aut");

            migrationBuilder.DropTable(
                name: "Author_book");

            migrationBuilder.DropTable(
                name: "Author_publ");

            migrationBuilder.DropTable(
                name: "category_edit");

            migrationBuilder.DropTable(
                name: "dbo.tmp_table");

            migrationBuilder.DropTable(
                name: "DS");

            migrationBuilder.DropTable(
                name: "id_Author");

            migrationBuilder.DropTable(
                name: "indicat_articles");

            migrationBuilder.DropTable(
                name: "reting_Journal");

            migrationBuilder.DropTable(
                name: "Spr_Users");

            migrationBuilder.DropTable(
                name: "Subjects_head");

            migrationBuilder.DropTable(
                name: "tmp_export");

            migrationBuilder.DropTable(
                name: "tmp_export1");

            migrationBuilder.DropTable(
                name: "UIA_articles");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Spr_idAuthors");

            migrationBuilder.DropTable(
                name: "IndArticles");

            migrationBuilder.DropTable(
                name: "Ind_Journal");

            migrationBuilder.DropTable(
                name: "Spr_roles");

            migrationBuilder.DropTable(
                name: "Spr_thematic");

            migrationBuilder.DropTable(
                name: "Spr_IdEdition");

            migrationBuilder.DropTable(
                name: "structural_part");

            migrationBuilder.DropTable(
                name: "Office_depart");

            migrationBuilder.DropTable(
                name: "AnalyticalBase");

            migrationBuilder.DropTable(
                name: "Spr_heading");

            migrationBuilder.DropTable(
                name: "edition");

            migrationBuilder.DropTable(
                name: "Spr_structure");

            migrationBuilder.DropTable(
                name: "Spr_formatInfo");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "level_Edition");

            migrationBuilder.DropTable(
                name: "publishing_office");
        }
    }
}
