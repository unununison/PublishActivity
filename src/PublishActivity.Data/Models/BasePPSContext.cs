using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PublishActivity.Data.Models;

public partial class BasePpsContext : DbContext
{
    public BasePpsContext()
    {
    }

    public BasePpsContext(DbContextOptions<BasePpsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnalyticalBase> AnalyticalBases { get; set; }

    public virtual DbSet<Aut> Auts { get; set; }

    public virtual DbSet<AutStructurPart> AutStructurParts { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorBook> AuthorBooks { get; set; }

    public virtual DbSet<AuthorPubl> AuthorPubls { get; set; }

    public virtual DbSet<AuthorStructPub> AuthorStructPubs { get; set; }

    public virtual DbSet<CategoryEdit> CategoryEdits { get; set; }

    public virtual DbSet<D> Ds { get; set; }

    public virtual DbSet<DboTmpTable> DboTmpTables { get; set; }

    public virtual DbSet<Edition> Editions { get; set; }

    public virtual DbSet<IdAuthor> IdAuthors { get; set; }

    public virtual DbSet<IndArticle> IndArticles { get; set; }

    public virtual DbSet<IndJournal> IndJournals { get; set; }

    public virtual DbSet<IndicatArticle> IndicatArticles { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LevelEdition> LevelEditions { get; set; }

    public virtual DbSet<OfficeDepart> OfficeDeparts { get; set; }

    public virtual DbSet<PublishingOffice> PublishingOffices { get; set; }

    public virtual DbSet<RetingJournal> RetingJournals { get; set; }

    public virtual DbSet<SprFormatInfo> SprFormatInfos { get; set; }

    public virtual DbSet<SprHeading> SprHeadings { get; set; }

    public virtual DbSet<SprIdAuthor> SprIdAuthors { get; set; }

    public virtual DbSet<SprIdEdition> SprIdEditions { get; set; }

    public virtual DbSet<SprRole> SprRoles { get; set; }

    public virtual DbSet<SprStructure> SprStructures { get; set; }

    public virtual DbSet<SprThematic> SprThematics { get; set; }

    public virtual DbSet<SprUser> SprUsers { get; set; }

    public virtual DbSet<StructuralPart> StructuralParts { get; set; }

    public virtual DbSet<SubjectsHead> SubjectsHeads { get; set; }

    public virtual DbSet<TmpExport> TmpExports { get; set; }

    public virtual DbSet<TmpExport1> TmpExport1s { get; set; }

    public virtual DbSet<UiaArticle> UiaArticles { get; set; }

    public virtual DbSet<VOfficeDepart> VOfficeDeparts { get; set; }

    public virtual DbSet<VShtat> VShtats { get; set; }

    public virtual DbSet<ViewEdition> ViewEditions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(@"Data Source=host.docker.internal;Database=BasePPS;User ID=SA;Password=123QWEasd;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnalyticalBase>(entity =>
        {
            entity.HasKey(e => e.IdAbase).HasName("AnalyticalBase_PK");

            entity.ToTable("AnalyticalBase");

            entity.Property(e => e.IdAbase)
                .ValueGeneratedNever()
                .HasColumnName("id_ABase");
            entity.Property(e => e.NameAbase)
                .HasMaxLength(30)
                .HasColumnName("Name_ABase");
        });

        modelBuilder.Entity<Aut>(entity =>
        {
            entity.HasKey(e => e.IdAut);

            entity.ToTable("aut");

            entity.Property(e => e.IdAut).HasColumnName("id_aut");
            entity.Property(e => e.Fam).HasMaxLength(30);
            entity.Property(e => e.IdExp).HasColumnName("id_exp");
            entity.Property(e => e.Nam1).HasMaxLength(30);
            entity.Property(e => e.Nam2).HasMaxLength(30);
        });

        modelBuilder.Entity<AutStructurPart>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Aut_structurPart");

            entity.Property(e => e.AuthorUid).HasColumnName("Author_UID");
            entity.Property(e => e.EditionIdEdt).HasColumnName("edition_id_Edt");
            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.JobName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.NameOffice)
                .HasMaxLength(250)
                .HasColumnName("Name_office");
            entity.Property(e => e.NamePart)
                .HasMaxLength(300)
                .HasColumnName("Name_part");
            entity.Property(e => e.OfficeDepartKodOffice)
                .HasMaxLength(10)
                .HasColumnName("Office_depart_kod_office");
            entity.Property(e => e.Patronymic).HasMaxLength(25);
            entity.Property(e => e.StructuralPartIdPart).HasColumnName("structural_part_id_part");
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("Author_PK");

            entity.ToTable("Author");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.Country).HasMaxLength(30);
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.JobName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.OfficeDepartKodOffice)
                .HasMaxLength(10)
                .HasColumnName("Office_depart_kod_office");
            entity.Property(e => e.Patronymic).HasMaxLength(25);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.TabNum)
                .HasMaxLength(9)
                .HasColumnName("Tab_num");
            entity.Property(e => e.YearBirth)
                .HasMaxLength(4)
                .HasColumnName("Year_birth");

            entity.HasOne(d => d.OfficeDepartKodOfficeNavigation).WithMany(p => p.Authors)
                .HasForeignKey(d => d.OfficeDepartKodOffice)
                .HasConstraintName("Author_Office_depart_FK");
        });

        modelBuilder.Entity<AuthorBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Author_book");

            entity.Property(e => e.AuthorPartB)
                .HasMaxLength(50)
                .HasColumnName("Author_PartB");
            entity.Property(e => e.AuthorUid).HasColumnName("Author_UID");
            entity.Property(e => e.EdnIdEdt).HasColumnName("EDN_id_Edt");

            entity.HasOne(d => d.AuthorU).WithMany()
                .HasForeignKey(d => d.AuthorUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Author_book_Author_FK");

            entity.HasOne(d => d.EdnIdEdtNavigation).WithMany()
                .HasForeignKey(d => d.EdnIdEdt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Author_book_edition");
        });

        modelBuilder.Entity<AuthorPubl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Author_publ");

            entity.Property(e => e.AuthorUid).HasColumnName("Author_UID");
            entity.Property(e => e.AuthorsPartA)
                .HasMaxLength(100)
                .HasColumnName("Authors_PartA");
            entity.Property(e => e.StructuralPartIdPart).HasColumnName("structural_part_id_part");

            entity.HasOne(d => d.AuthorU).WithMany()
                .HasForeignKey(d => d.AuthorUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Author_publ_Author_FK");

            entity.HasOne(d => d.StructuralPartIdPartNavigation).WithMany()
                .HasForeignKey(d => d.StructuralPartIdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Author_publ_structural_part_FK");
        });

        modelBuilder.Entity<AuthorStructPub>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Author_struct_pub");

            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.NamePart)
                .HasMaxLength(300)
                .HasColumnName("Name_part");
            entity.Property(e => e.OfficeDepartKodOffice)
                .HasMaxLength(10)
                .HasColumnName("Office_depart_kod_office");
            entity.Property(e => e.Patronymic).HasMaxLength(25);
            entity.Property(e => e.Uid).HasColumnName("uid");
        });

        modelBuilder.Entity<CategoryEdit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("category_edit");

            entity.Property(e => e.EditionIdEdt).HasColumnName("edition_id_Edt");
            entity.Property(e => e.KodHeading)
                .HasMaxLength(50)
                .HasColumnName("kod_heading");
            entity.Property(e => e.NameArea)
                .HasMaxLength(50)
                .HasColumnName("Name_area");
            entity.Property(e => e.SprHeadingIdHeading).HasColumnName("Spr_heading_id_heading");

            entity.HasOne(d => d.EditionIdEdtNavigation).WithMany()
                .HasForeignKey(d => d.EditionIdEdt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_category_edit_edition");

            entity.HasOne(d => d.SprHeadingIdHeadingNavigation).WithMany()
                .HasForeignKey(d => d.SprHeadingIdHeading)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("category_edit_Spr_heading_FK");
        });

        modelBuilder.Entity<D>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DS");

            entity.Property(e => e.Ds)
                .HasMaxLength(15)
                .HasColumnName("DS");
            entity.Property(e => e.Fio)
                .HasMaxLength(60)
                .HasColumnName("FIO");
            entity.Property(e => e.FioTranslit)
                .HasMaxLength(60)
                .HasColumnName("FIO_translit");
            entity.Property(e => e.Ns)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("NS");
        });

        modelBuilder.Entity<DboTmpTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo.tmp_table");

            entity.Property(e => e.DataExport)
                .HasColumnType("datetime")
                .HasColumnName("data_export");
            entity.Property(e => e.DataImport)
                .HasColumnType("datetime")
                .HasColumnName("data_import");
            entity.Property(e => e.DoiEd).HasColumnName("DOI_ED");
            entity.Property(e => e.IdExport).HasColumnName("id_export");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.Issn).HasColumnName("ISSN");
            entity.Property(e => e.LanguagePart).HasColumnName("language_part");
            entity.Property(e => e.NameAbase).HasColumnName("Name_ABase");
            entity.Property(e => e.NameAuthorEn).HasColumnName("NameAuthor_EN");
            entity.Property(e => e.NameAuthorRu).HasColumnName("NameAuthor_RU");
            entity.Property(e => e.NameEdt).HasColumnName("Name_Edt");
            entity.Property(e => e.NamePart).HasColumnName("Name_part");
            entity.Property(e => e.NamePdo).HasColumnName("Name_PDO");
            entity.Property(e => e.UrlIsi).HasColumnName("URL_ISI");
            entity.Property(e => e.ValumeIndA).HasColumnName("Valume_IndA");
            entity.Property(e => e.ValumeUia).HasColumnName("Valume_UIA");
        });

        modelBuilder.Entity<Edition>(entity =>
        {
            entity.HasKey(e => e.IdEdt).HasName("edition_PK");

            entity.ToTable("edition");

            entity.Property(e => e.IdEdt).HasColumnName("id_Edt");
            entity.Property(e => e.Coverage).HasMaxLength(200);
            entity.Property(e => e.DateEdit)
                .HasColumnType("date")
                .HasColumnName("Date_Edit");
            entity.Property(e => e.DateExtract)
                .HasColumnType("date")
                .HasColumnName("Date_Extract");
            entity.Property(e => e.DoiEd)
                .HasMaxLength(50)
                .HasColumnName("DOI_ED");
            entity.Property(e => e.EdnIdLanguage).HasColumnName("EDN_id_language");
            entity.Property(e => e.EdnIdPbo).HasColumnName("EDN_id_PBO");
            entity.Property(e => e.EdnTypeEd)
                .HasMaxLength(6)
                .HasColumnName("EDN_type_ed");
            entity.Property(e => e.IdEdition).HasColumnName("id_edition");
            entity.Property(e => e.Isbn)
                .HasMaxLength(300)
                .HasColumnName("ISBN");
            entity.Property(e => e.Issn)
                .HasMaxLength(30)
                .HasColumnName("ISSN");
            entity.Property(e => e.IssnO)
                .HasMaxLength(13)
                .HasColumnName("ISSN_O");
            entity.Property(e => e.NameEdt)
                .HasMaxLength(200)
                .HasColumnName("Name_Edt");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Region).HasMaxLength(100);
            entity.Property(e => e.Regularity).HasMaxLength(30);
            entity.Property(e => e.Release).HasMaxLength(20);
            entity.Property(e => e.SprFormatInfoTypeEd).HasColumnName("Spr_formatInfo_Type_ED");
            entity.Property(e => e.Town).HasMaxLength(200);
            entity.Property(e => e.TypeAccess)
                .HasMaxLength(20)
                .HasColumnName("Type_Access");
            entity.Property(e => e.UrlIsi)
                .HasMaxLength(300)
                .HasColumnName("URL_ISI");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("User_id");
            entity.Property(e => e.Year).HasMaxLength(4);

            entity.HasOne(d => d.EdnIdLanguageNavigation).WithMany(p => p.Editions)
                .HasForeignKey(d => d.EdnIdLanguage)
                .HasConstraintName("FK_edition_language");

            entity.HasOne(d => d.EdnIdPboNavigation).WithMany(p => p.Editions)
                .HasForeignKey(d => d.EdnIdPbo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_edition_publishing_office");

            entity.HasOne(d => d.IdEditionNavigation).WithMany(p => p.Editions)
                .HasForeignKey(d => d.IdEdition)
                .HasConstraintName("FK_edition_level_Edition");

            entity.HasOne(d => d.SprFormatInfoTypeEdNavigation).WithMany(p => p.Editions)
                .HasForeignKey(d => d.SprFormatInfoTypeEd)
                .HasConstraintName("FK_edition_Spr_formatInfo");
        });

        modelBuilder.Entity<IdAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("id_Author");

            entity.Property(e => e.AuthorUid).HasColumnName("Author_UID");
            entity.Property(e => e.SprIdAuthorsIdIas).HasColumnName("Spr_idAuthors_id_IAS");

            entity.HasOne(d => d.AuthorU).WithMany()
                .HasForeignKey(d => d.AuthorUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_Author_Author_FK");

            entity.HasOne(d => d.SprIdAuthorsIdIasNavigation).WithMany()
                .HasForeignKey(d => d.SprIdAuthorsIdIas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_Author_Spr_idAuthors_FK");
        });

        modelBuilder.Entity<IndArticle>(entity =>
        {
            entity.HasKey(e => e.IdIndPrt).HasName("IndArticles_PK");

            entity.Property(e => e.IdIndPrt)
                .ValueGeneratedNever()
                .HasColumnName("id_IndPrt");
            entity.Property(e => e.AnalyticalBaseIdAbase).HasColumnName("AnalyticalBase_id_ABase");
            entity.Property(e => e.NameIndPrt)
                .HasMaxLength(50)
                .HasColumnName("Name_IndPrt");

            entity.HasOne(d => d.AnalyticalBaseIdAbaseNavigation).WithMany(p => p.IndArticles)
                .HasForeignKey(d => d.AnalyticalBaseIdAbase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IndArticles_AnalyticalBase_FK");
        });

        modelBuilder.Entity<IndJournal>(entity =>
        {
            entity.HasKey(e => e.IdIndJ).HasName("Ind_Journal_PK");

            entity.ToTable("Ind_Journal");

            entity.Property(e => e.IdIndJ)
                .ValueGeneratedNever()
                .HasColumnName("id_IndJ");
            entity.Property(e => e.AnalyticalBaseIdAbase).HasColumnName("AnalyticalBase_id_ABase");
            entity.Property(e => e.NameIndJ)
                .HasMaxLength(50)
                .HasColumnName("Name_IndJ");

            entity.HasOne(d => d.AnalyticalBaseIdAbaseNavigation).WithMany(p => p.IndJournals)
                .HasForeignKey(d => d.AnalyticalBaseIdAbase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ind_Journal_AnalyticalBase_FK");
        });

        modelBuilder.Entity<IndicatArticle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("indicat_articles");

            entity.Property(e => e.DateEditA)
                .HasColumnType("date")
                .HasColumnName("Date_EditA");
            entity.Property(e => e.IndArticlesIdIndPrt).HasColumnName("IndArticles_id_IndPrt");
            entity.Property(e => e.StructuralPartIdPart).HasColumnName("structural_part_id_part");
            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.ValumeIndA).HasColumnName("Valume_IndA");

            entity.HasOne(d => d.IndArticlesIdIndPrtNavigation).WithMany()
                .HasForeignKey(d => d.IndArticlesIdIndPrt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("indicat_articles_IndArticles_FK");

            entity.HasOne(d => d.StructuralPartIdPartNavigation).WithMany()
                .HasForeignKey(d => d.StructuralPartIdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("indicat_articles_structural_part_FK");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.IdLanguage).HasName("language_PK");

            entity.ToTable("language");

            entity.Property(e => e.IdLanguage).HasColumnName("id_language");
            entity.Property(e => e.NameLang)
                .HasMaxLength(50)
                .HasColumnName("Name_lang");
            entity.Property(e => e.NameLang1)
                .HasMaxLength(50)
                .HasColumnName("Name_lang1");
        });

        modelBuilder.Entity<LevelEdition>(entity =>
        {
            entity.HasKey(e => e.IdEdition).HasName("level_Edition_PK");

            entity.ToTable("level_Edition");

            entity.Property(e => e.IdEdition).HasColumnName("id_edition");
            entity.Property(e => e.NameLevEdition)
                .HasMaxLength(50)
                .HasColumnName("Name_levEdition");
        });

        modelBuilder.Entity<OfficeDepart>(entity =>
        {
            entity.HasKey(e => e.KodOffice).HasName("Office_depart_PK");

            entity.ToTable("Office_depart");

            entity.Property(e => e.KodOffice)
                .HasMaxLength(10)
                .HasColumnName("kod_office");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.KodParent)
                .HasMaxLength(3)
                .HasColumnName("kod_parent");
            entity.Property(e => e.NameOffice)
                .HasMaxLength(250)
                .HasColumnName("Name_office");
            entity.Property(e => e.TypeOffice).HasColumnName("type_office");
        });

        modelBuilder.Entity<PublishingOffice>(entity =>
        {
            entity.HasKey(e => e.IdPbo).HasName("publishing_office_PK");

            entity.ToTable("publishing_office");

            entity.Property(e => e.IdPbo).HasColumnName("id_PBO");
            entity.Property(e => e.NamePdo)
                .HasMaxLength(200)
                .HasColumnName("Name_PDO");
            entity.Property(e => e.Region).HasMaxLength(50);
            entity.Property(e => e.Town).HasMaxLength(50);
        });

        modelBuilder.Entity<RetingJournal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("reting_Journal");

            entity.Property(e => e.DateEditJ)
                .HasColumnType("date")
                .HasColumnName("Date_EditJ");
            entity.Property(e => e.IdEdt).HasColumnName("id_Edt");
            entity.Property(e => e.IndJournalIdIndJ).HasColumnName("Ind_Journal_id_IndJ");
            entity.Property(e => e.SubjectArea)
                .HasMaxLength(50)
                .HasColumnName("Subject_area");
            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.ValumeInd)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("Valume_Ind");
            entity.Property(e => e.YearJ)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("yearJ");

            entity.HasOne(d => d.IdEdtNavigation).WithMany()
                .HasForeignKey(d => d.IdEdt)
                .HasConstraintName("FK_reting_Journal_edition");

            entity.HasOne(d => d.IndJournalIdIndJNavigation).WithMany()
                .HasForeignKey(d => d.IndJournalIdIndJ)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reting_Journal_Ind_Journal_FK");
        });

        modelBuilder.Entity<SprFormatInfo>(entity =>
        {
            entity.HasKey(e => e.TypeEd).HasName("Spr_formatInfo_PK");

            entity.ToTable("Spr_formatInfo");

            entity.Property(e => e.TypeEd).HasColumnName("Type_ED");
            entity.Property(e => e.NameNlnform)
                .HasMaxLength(50)
                .HasColumnName("Name_nlnform");
        });

        modelBuilder.Entity<SprHeading>(entity =>
        {
            entity.HasKey(e => e.IdHeading).HasName("Spr_heading_PK");

            entity.ToTable("Spr_heading");

            entity.Property(e => e.IdHeading).HasColumnName("id_heading");
            entity.Property(e => e.NameHeading)
                .HasMaxLength(50)
                .HasColumnName("Name_heading");
        });

        modelBuilder.Entity<SprIdAuthor>(entity =>
        {
            entity.HasKey(e => e.IdIas).HasName("Spr_idAuthors_PK");

            entity.ToTable("Spr_idAuthors");

            entity.Property(e => e.IdIas)
                .ValueGeneratedNever()
                .HasColumnName("id_IAS");
            entity.Property(e => e.NameIas)
                .HasMaxLength(50)
                .HasColumnName("Name_IAS");
        });

        modelBuilder.Entity<SprIdEdition>(entity =>
        {
            entity.HasKey(e => e.IdUia).HasName("Spr_IdEdition_PK");

            entity.ToTable("Spr_IdEdition");

            entity.Property(e => e.IdUia)
                .ValueGeneratedNever()
                .HasColumnName("id_UIA");
            entity.Property(e => e.NameUia)
                .HasMaxLength(50)
                .HasColumnName("Name_UIA");
        });

        modelBuilder.Entity<SprRole>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Spr_roles");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .HasColumnName("name_role");
            entity.Property(e => e.Note).HasMaxLength(100);
        });

        modelBuilder.Entity<SprStructure>(entity =>
        {
            entity.HasKey(e => e.IdTypePart).HasName("Spr_structure_PK");

            entity.ToTable("Spr_structure");

            entity.Property(e => e.IdTypePart).HasColumnName("id_TypePart");
            entity.Property(e => e.NamePart)
                .HasMaxLength(30)
                .HasColumnName("Name_Part");
            entity.Property(e => e.NamePart1)
                .HasMaxLength(30)
                .HasColumnName("Name_Part1");
        });

        modelBuilder.Entity<SprThematic>(entity =>
        {
            entity.HasKey(e => e.IdThematic);

            entity.ToTable("Spr_thematic");

            entity.Property(e => e.IdThematic).HasColumnName("id_thematic");
            entity.Property(e => e.IdHeading).HasColumnName("id_heading");
            entity.Property(e => e.NameThematic)
                .HasMaxLength(150)
                .HasColumnName("Name_thematic");

            entity.HasOne(d => d.IdHeadingNavigation).WithMany(p => p.SprThematics)
                .HasForeignKey(d => d.IdHeading)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spr_thematic_Spr_heading");
        });

        modelBuilder.Entity<SprUser>(entity =>
        {
            entity.HasKey(e => e.IdUsers);

            entity.ToTable("Spr_Users");

            entity.Property(e => e.IdUsers).HasColumnName("id_users");
            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.LoginUser)
                .HasMaxLength(15)
                .HasColumnName("login_user");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.Patronymic).HasMaxLength(25);
            entity.Property(e => e.PwdUser)
                .HasMaxLength(10)
                .HasColumnName("pwd_user");
            entity.Property(e => e.Uid).HasColumnName("UID");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.SprUsers)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Spr_Users_Spr_roles");
        });

        modelBuilder.Entity<StructuralPart>(entity =>
        {
            entity.HasKey(e => e.IdPart).HasName("structural_part_PK");

            entity.ToTable("structural_part");

            entity.Property(e => e.IdPart).HasColumnName("id_part");
            entity.Property(e => e.CopyId).HasColumnName("Copy_id");
            entity.Property(e => e.DateEdA)
                .HasColumnType("datetime")
                .HasColumnName("Date_EdA");
            entity.Property(e => e.DateExtractA)
                .HasColumnType("datetime")
                .HasColumnName("Date_ExtractA");
            entity.Property(e => e.DateIns)
                .HasColumnType("datetime")
                .HasColumnName("Date_Ins");
            entity.Property(e => e.EditionIdEdt).HasColumnName("edition_id_Edt");
            entity.Property(e => e.IdLanguage).HasColumnName("id_language");
            entity.Property(e => e.NamePart)
                .HasMaxLength(300)
                .HasColumnName("Name_part");
            entity.Property(e => e.NumArticle).HasMaxLength(50);
            entity.Property(e => e.SprStructureIdTypePart).HasColumnName("Spr_structure_id_TypePart");
            entity.Property(e => e.UrlArt)
                .HasMaxLength(300)
                .HasColumnName("URL_Art");
            entity.Property(e => e.UserEdA).HasColumnName("User_EdA");
            entity.Property(e => e.UserIns).HasColumnName("User_Ins");

            entity.HasOne(d => d.EditionIdEdtNavigation).WithMany(p => p.StructuralParts)
                .HasForeignKey(d => d.EditionIdEdt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_structural_part_edition");

            entity.HasOne(d => d.IdLanguageNavigation).WithMany(p => p.StructuralParts)
                .HasForeignKey(d => d.IdLanguage)
                .HasConstraintName("FK_structural_part_language");

            entity.HasOne(d => d.SprStructureIdTypePartNavigation).WithMany(p => p.StructuralParts)
                .HasForeignKey(d => d.SprStructureIdTypePart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("structural_part_Spr_structure_FK");
        });

        modelBuilder.Entity<SubjectsHead>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Subjects_head");

            entity.Property(e => e.IdThematic).HasColumnName("id_thematic");
            entity.Property(e => e.StructuralPartIdPart).HasColumnName("structural_part_id_part");

            entity.HasOne(d => d.IdThematicNavigation).WithMany()
                .HasForeignKey(d => d.IdThematic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subjects_head_Spr_thematic");

            entity.HasOne(d => d.StructuralPartIdPartNavigation).WithMany()
                .HasForeignKey(d => d.StructuralPartIdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Subjects_head_structural_part_FK");
        });

        modelBuilder.Entity<TmpExport>(entity =>
        {
            entity.HasKey(e => e.IdExport);

            entity.ToTable("tmp_export", tb => tb.HasTrigger("tmp_export_INSERT"));

            entity.Property(e => e.IdExport).HasColumnName("id_export");
            entity.Property(e => e.DataExport)
                .HasColumnType("datetime")
                .HasColumnName("data_export");
            entity.Property(e => e.DataImport)
                .HasColumnType("datetime")
                .HasColumnName("data_import");
            entity.Property(e => e.DoiEd)
                .HasMaxLength(50)
                .HasColumnName("DOI_ED");
            entity.Property(e => e.Isbn)
                .HasMaxLength(300)
                .HasColumnName("ISBN");
            entity.Property(e => e.Issn)
                .HasMaxLength(30)
                .HasColumnName("ISSN");
            entity.Property(e => e.LanguagePart)
                .HasMaxLength(30)
                .HasColumnName("language_part");
            entity.Property(e => e.NameAbase)
                .HasMaxLength(30)
                .HasColumnName("Name_ABase");
            entity.Property(e => e.NameAuthorEn)
                .HasMaxLength(2000)
                .HasColumnName("NameAuthor_EN");
            entity.Property(e => e.NameAuthorRu)
                .HasMaxLength(2000)
                .HasColumnName("NameAuthor_RU");
            entity.Property(e => e.NameEdt)
                .HasMaxLength(200)
                .HasColumnName("Name_Edt");
            entity.Property(e => e.NamePart).HasColumnName("Name_part");
            entity.Property(e => e.NamePdo)
                .HasMaxLength(200)
                .HasColumnName("Name_PDO");
            entity.Property(e => e.NameStruct).HasMaxLength(30);
            entity.Property(e => e.PageCount).HasMaxLength(10);
            entity.Property(e => e.Release).HasMaxLength(20);
            entity.Property(e => e.UrlIsi)
                .HasMaxLength(300)
                .HasColumnName("URL_ISI");
            entity.Property(e => e.ValumeIndA).HasColumnName("Valume_IndA");
            entity.Property(e => e.ValumeUia)
                .HasMaxLength(30)
                .HasColumnName("Valume_UIA");
            entity.Property(e => e.Year).HasMaxLength(4);
        });

        modelBuilder.Entity<TmpExport1>(entity =>
        {
            entity.HasKey(e => e.IdExport);

            entity.ToTable("tmp_export1");

            entity.Property(e => e.IdExport).HasColumnName("id_export");
            entity.Property(e => e.DataExport)
                .HasColumnType("datetime")
                .HasColumnName("data_export");
            entity.Property(e => e.DataImport)
                .HasColumnType("datetime")
                .HasColumnName("data_import");
            entity.Property(e => e.DoiEd)
                .HasMaxLength(50)
                .HasColumnName("DOI_ED");
            entity.Property(e => e.Isbn)
                .HasMaxLength(300)
                .HasColumnName("ISBN");
            entity.Property(e => e.Issn)
                .HasMaxLength(30)
                .HasColumnName("ISSN");
            entity.Property(e => e.LanguagePart)
                .HasMaxLength(30)
                .HasColumnName("language_part");
            entity.Property(e => e.NameAbase)
                .HasMaxLength(30)
                .HasColumnName("Name_ABase");
            entity.Property(e => e.NameAuthorEn)
                .HasMaxLength(2000)
                .HasColumnName("NameAuthor_EN");
            entity.Property(e => e.NameAuthorRu)
                .HasMaxLength(2000)
                .HasColumnName("NameAuthor_RU");
            entity.Property(e => e.NameEdt)
                .HasMaxLength(200)
                .HasColumnName("Name_Edt");
            entity.Property(e => e.NamePart).HasColumnName("Name_part");
            entity.Property(e => e.NamePdo)
                .HasMaxLength(200)
                .HasColumnName("Name_PDO");
            entity.Property(e => e.NameStruct).HasMaxLength(30);
            entity.Property(e => e.PageCount).HasMaxLength(10);
            entity.Property(e => e.Release).HasMaxLength(20);
            entity.Property(e => e.UrlIsi)
                .HasMaxLength(300)
                .HasColumnName("URL_ISI");
            entity.Property(e => e.ValumeIndA).HasColumnName("Valume_IndA");
            entity.Property(e => e.ValumeUia)
                .HasMaxLength(30)
                .HasColumnName("Valume_UIA");
            entity.Property(e => e.Year).HasMaxLength(4);
        });

        modelBuilder.Entity<UiaArticle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UIA_articles");

            entity.Property(e => e.SprIdEditionIdUia).HasColumnName("Spr_IdEdition_id_UIA");
            entity.Property(e => e.StructuralPartIdPart).HasColumnName("structural_part_id_part");
            entity.Property(e => e.ValumeUia)
                .HasMaxLength(30)
                .HasColumnName("Valume_UIA");

            entity.HasOne(d => d.SprIdEditionIdUiaNavigation).WithMany()
                .HasForeignKey(d => d.SprIdEditionIdUia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UIA_articles_Spr_IdEdition_FK");

            entity.HasOne(d => d.StructuralPartIdPartNavigation).WithMany()
                .HasForeignKey(d => d.StructuralPartIdPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UIA_articles_structural_part_FK");
        });

        modelBuilder.Entity<VOfficeDepart>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Office_depart");

            entity.Property(e => e.KodOffice)
                .HasMaxLength(10)
                .HasColumnName("kod_office");
            entity.Property(e => e.KodParent)
                .HasMaxLength(5)
                .HasColumnName("kod_parent");
            entity.Property(e => e.NameOffice)
                .HasMaxLength(200)
                .HasColumnName("Name_office");
        });

        modelBuilder.Entity<VShtat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Shtat");

            entity.Property(e => e.Academic)
                .HasMaxLength(40)
                .HasColumnName("ACADEMIC");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("Date_start");
            entity.Property(e => e.Fam)
                .HasMaxLength(30)
                .HasColumnName("FAM");
            entity.Property(e => e.Fio)
                .HasMaxLength(60)
                .HasColumnName("FIO");
            entity.Property(e => e.FlagIn).HasColumnName("Flag_in");
            entity.Property(e => e.FlagOsn).HasColumnName("Flag_osn");
            entity.Property(e => e.FlagOut).HasColumnName("Flag_out");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KodAGr)
                .HasMaxLength(10)
                .HasColumnName("Kod_aGr");
            entity.Property(e => e.KodDep)
                .HasMaxLength(5)
                .HasColumnName("Kod_Dep");
            entity.Property(e => e.Kval)
                .HasMaxLength(60)
                .HasColumnName("kval");
            entity.Property(e => e.Mgtucategory)
                .HasMaxLength(60)
                .HasColumnName("MGTUCategory");
            entity.Property(e => e.MgtucategoryCode)
                .HasMaxLength(4)
                .HasColumnName("MGTUCategoryCode");
            entity.Property(e => e.Nam1)
                .HasMaxLength(30)
                .HasColumnName("NAM1");
            entity.Property(e => e.Nam2)
                .HasMaxLength(30)
                .HasColumnName("NAM2");
            entity.Property(e => e.NameDep)
                .HasMaxLength(200)
                .HasColumnName("Name_Dep");
            entity.Property(e => e.NameGr).HasMaxLength(200);
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Scstatus)
                .HasMaxLength(30)
                .HasColumnName("SCSTATUS");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .HasColumnName("sex");
            entity.Property(e => e.ShifrSotr)
                .HasMaxLength(9)
                .HasColumnName("SHIFR_SOTR");
            entity.Property(e => e.ShtatName)
                .HasMaxLength(100)
                .HasColumnName("shtat_name");
            entity.Property(e => e.YearBirth)
                .HasMaxLength(4)
                .HasColumnName("Year_birth");
        });

        modelBuilder.Entity<ViewEdition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_edition");

            entity.Property(e => e.Coverage).HasMaxLength(200);
            entity.Property(e => e.DateEdit)
                .HasColumnType("date")
                .HasColumnName("Date_Edit");
            entity.Property(e => e.DateExtract)
                .HasColumnType("date")
                .HasColumnName("Date_Extract");
            entity.Property(e => e.DoiEd)
                .HasMaxLength(50)
                .HasColumnName("DOI_ED");
            entity.Property(e => e.EdnTypeEd)
                .HasMaxLength(6)
                .HasColumnName("EDN_type_ed");
            entity.Property(e => e.IdEdt).HasColumnName("id_Edt");
            entity.Property(e => e.Isbn)
                .HasMaxLength(300)
                .HasColumnName("ISBN");
            entity.Property(e => e.Issn)
                .HasMaxLength(30)
                .HasColumnName("ISSN");
            entity.Property(e => e.IssnO)
                .HasMaxLength(13)
                .HasColumnName("ISSN_O");
            entity.Property(e => e.NameEdt)
                .HasMaxLength(200)
                .HasColumnName("Name_Edt");
            entity.Property(e => e.NameLang)
                .HasMaxLength(50)
                .HasColumnName("Name_lang");
            entity.Property(e => e.NameLevEdition)
                .HasMaxLength(50)
                .HasColumnName("Name_levEdition");
            entity.Property(e => e.NameNlnform)
                .HasMaxLength(50)
                .HasColumnName("Name_nlnform");
            entity.Property(e => e.NamePdo)
                .HasMaxLength(200)
                .HasColumnName("Name_PDO");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PublOffRegion)
                .HasMaxLength(50)
                .HasColumnName("PublOff_Region");
            entity.Property(e => e.PublOffTown)
                .HasMaxLength(50)
                .HasColumnName("PublOff_Town");
            entity.Property(e => e.Region).HasMaxLength(100);
            entity.Property(e => e.Regularity).HasMaxLength(30);
            entity.Property(e => e.Release).HasMaxLength(20);
            entity.Property(e => e.Town).HasMaxLength(200);
            entity.Property(e => e.TypeAccess)
                .HasMaxLength(20)
                .HasColumnName("Type_Access");
            entity.Property(e => e.UrlIsi)
                .HasMaxLength(300)
                .HasColumnName("URL_ISI");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("User_id");
            entity.Property(e => e.Year).HasMaxLength(4);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
