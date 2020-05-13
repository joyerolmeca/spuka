using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpukaAp.Models
{
    public partial class spukaContext : DbContext
    {
        public spukaContext()
        {
        }

        public spukaContext(DbContextOptions<spukaContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }




        public virtual DbSet<TAdressen> TAdressen { get; set; }
        public virtual DbSet<TAdressenTyp> TAdressenTyp { get; set; }
        public virtual DbSet<TAnrede> TAnrede { get; set; }
        public virtual DbSet<TBegStatus> TBegStatus { get; set; }
        public virtual DbSet<TBeguenstigte> TBeguenstigte { get; set; }
        public virtual DbSet<TEinrichtung> TEinrichtung { get; set; }
        public virtual DbSet<TEinrichtungTypen> TEinrichtungTypen { get; set; }
        public virtual DbSet<TMandanten> TMandanten { get; set; }
        public virtual DbSet<TMitglieder> TMitglieder { get; set; }
        public virtual DbSet<TVereinbarLeistgruppen> TVereinbarLeistgruppen { get; set; }
        public virtual DbSet<TVereinbarungen> TVereinbarungen { get; set; }
        public virtual DbSet<TVereinbarungenDetails> TVereinbarungenDetails { get; set; }
        public virtual DbSet<TVersorgungstypen> TVersorgungstypen { get; set; }
        public virtual DbSet<TZusagen> TZusagen { get; set; }
        public virtual DbSet<TZusagenDetails> TZusagenDetails { get; set; }
        public virtual DbSet<TZusagenStatus> TZusagenStatus { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   //Enabling LazyLoading it with a call to UseLazyLoadingProxies.
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()

                // .UseSqlServer("Server=localhost;Database=spuka;Trusted_Connection=True;");  //funcional con base de datos de microsoft

                //   Server = localhost\\SQLEXPRESS; database = spuka; Integrated Security = true"

                //@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SpukaBD01;"
                //  .UseSqlServer(@"Server=tcp:estserver02.database.windows.net,1433;Initial Catalog=DB02ets;Persist Security Info=False;User ID=acm0107;Password=pp102##!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

              .UseSqlServer (@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SpukaBD01;");   //Funcional:
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TAdressen>(entity =>     //TAdressen
            {
                entity.HasKey(e => e.AdrAdresse)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_Adressen");

                entity.Property(e => e.AdrAdresse)
                    .HasColumnName("adrAdresse")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AdrAnrede).HasColumnName("adrAnrede");

                entity.Property(e => e.AdrGdatum)
                    .HasColumnName("adrGDatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.AdrMandant)
                    .IsRequired()
                    .HasColumnName("adrMandant")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdrName)
                    .IsRequired()
                    .HasColumnName("adrName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdrOrt)
                    .HasColumnName("adrOrt")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdrPlz)
                    .HasColumnName("adrPLZ")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdrStrasse)
                    .HasColumnName("adrStrasse")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdrTitel)
                    .HasColumnName("adrTitel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdrTyp).HasColumnName("adrTyp");

                entity.Property(e => e.AdrVorname)
                    .HasColumnName("adrVorname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdrAnredeNavigation)
                    .WithMany(p => p.TAdressen)
                    .HasForeignKey(d => d.AdrAnrede)
                    .HasConstraintName("FK_Adressen_hat_die_Anrede");

                entity.HasOne(d => d.AdrTypNavigation)
                    .WithMany(p => p.TAdressen)
                    .HasForeignKey(d => d.AdrTyp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adressen_hat_AdrTyp");
            });

            modelBuilder.Entity<TAdressenTyp>(entity =>
            {
                entity.HasKey(e => e.AdtTyp)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_AdressenTyp");

                entity.Property(e => e.AdtTyp)
                    .HasColumnName("adtTyp")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdtBezeichnung)
                    .IsRequired()
                    .HasColumnName("adtBezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TAnrede>(entity =>
            {
                entity.HasKey(e => e.AnrAnredeId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_Anrede");

                entity.Property(e => e.AnrAnredeId)
                    .HasColumnName("anrAnredeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnrAnrede)
                    .IsRequired()
                    .HasColumnName("anrAnrede")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AnrJnperson).HasColumnName("anrJNPerson");
            });

            modelBuilder.Entity<TBegStatus>(entity =>
            {
                entity.HasKey(e => e.BstStatus)
                    .HasName("PK_t_BeguenstigtenStatus")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_BegStatus");

                entity.Property(e => e.BstStatus)
                    .HasColumnName("bstStatus")
                    .ValueGeneratedNever();

                entity.Property(e => e.BstBezeichnung)
                    .IsRequired()
                    .HasColumnName("bstBezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TBeguenstigte>(entity =>   //TBeguenstigte
            {
                entity.HasKey(e => e.BegBeguenstigter);
                   // .ForSqlServerIsClustered(false);

                entity.ToTable("t_Beguenstigte");

                entity.Property(e => e.BegBeguenstigter)
                    .HasColumnName("begBeguenstigter")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BegAdresse)
                    .IsRequired()
                    .HasColumnName("begAdresse")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BegEintrittsdatum)
                    .HasColumnName("begEintrittsdatum")
                    .HasColumnType("datetime");

                entity.Property(e => e.BegMitglied)
                    .IsRequired()
                    .HasColumnName("begMitglied")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BegPersonalNr)
                    .HasColumnName("begPersonalNr")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BegStatus).HasColumnName("begStatus");

                entity.HasOne(d => d.BegAdresseNavigation)
                    .WithMany(p => p.TBeguenstigte)
                    .HasForeignKey(d => d.BegAdresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Begungstigte_hat_die_Adresse");

                entity.HasOne(d => d.BegMitgliedNavigation)
                    .WithMany(p => p.TBeguenstigte)
                    .HasForeignKey(d => d.BegMitglied)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Begungstigte_hat_Mitglieder");

                entity.HasOne(d => d.BegStatusNavigation)
                    .WithMany(p => p.TBeguenstigte)
                    .HasForeignKey(d => d.BegStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Begungstigte_hat_Status");
            });

            modelBuilder.Entity<TEinrichtung>(entity =>  //TEinrichtung
            {
                entity.HasKey(e => e.EinId);

                entity.ToTable("t_Einrichtung");

                entity.Property(e => e.EinId)
                    .HasColumnName("einID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EinAdresse)
                    .HasColumnName("einAdresse")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EinBezeichnung)
                    .HasColumnName("einBezeichnung")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EinTyp).HasColumnName("einTyp");

                entity.HasOne(d => d.EinAdresseNavigation)
                    .WithMany(p => p.TEinrichtung)
                    .HasForeignKey(d => d.EinAdresse)
                    .HasConstraintName("FK_Einrichtung_hat_die_Adresse");

                entity.HasOne(d => d.EinTypNavigation)
                    .WithMany(p => p.TEinrichtung)
                    .HasForeignKey(d => d.EinTyp)
                    .HasConstraintName("FK_Einrichtung_ist_vom_Typ");
            });

            modelBuilder.Entity<TEinrichtungTypen>(entity =>
            {
                entity.HasKey(e => e.EitTyp)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_EinrichtungTypen");

                entity.Property(e => e.EitTyp).HasColumnName("eitTyp");

                entity.Property(e => e.EitBezeichnung)
                    .IsRequired()
                    .HasColumnName("eitBezeichnung")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TMandanten>(entity =>
            {
                entity.HasKey(e => e.ManMandant)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_Mandanten");

                entity.Property(e => e.ManMandant)
                    .HasColumnName("manMandant")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ManAdresse)
                    .HasColumnName("manAdresse")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ManBezeichnung)
                    .IsRequired()
                    .HasColumnName("manBezeichnung")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManEinrichtung)
                    .IsRequired()
                    .HasColumnName("manEinrichtung")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ManEinrichtungNavigation)
                    .WithMany(p => p.TMandanten)
                    .HasForeignKey(d => d.ManEinrichtung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mandanten_hat_Einrichtung");
            });

            modelBuilder.Entity<TMitglieder>(entity =>
            {
                entity.HasKey(e => e.MitMitglied)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_Mitglieder");

                entity.Property(e => e.MitMitglied)
                    .HasColumnName("mitMitglied")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MitAdresse)
                    .IsRequired()
                    .HasColumnName("mitAdresse")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MitMandant)
                    .HasColumnName("mitMandant")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.MitAdresseNavigation)
                    .WithMany(p => p.TMitglieder)
                    .HasForeignKey(d => d.MitAdresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mitglieder_hat_die_Adresse");

                entity.HasOne(d => d.MitMandantNavigation)
                    .WithMany(p => p.TMitglieder)
                    .HasForeignKey(d => d.MitMandant)
                    .HasConstraintName("FK_Mitglieder_ist_vom_Mandant");
            });

            modelBuilder.Entity<TVereinbarLeistgruppen>(entity =>
            {
                entity.HasKey(e => e.VlgLeistungsgruppe)
                    .HasName("PK_t_VereinbarungenLeistungsgruppen")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_VereinbarLeistgruppen");

                entity.Property(e => e.VlgLeistungsgruppe)
                    .HasColumnName("vlgLeistungsgruppe")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.VlgAv).HasColumnName("vlgAV");

                entity.Property(e => e.VlgBezeichnung)
                    .IsRequired()
                    .HasColumnName("vlgBezeichnung")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VlgInvaliditaet).HasColumnName("vlgInvaliditaet");

                entity.Property(e => e.VlgTodesfall).HasColumnName("vlgTodesfall");

                entity.Property(e => e.VlgVereinbarung)
                    .IsRequired()
                    .HasColumnName("vlgVereinbarung")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VlgWuWrente).HasColumnName("vlgWuWRente");

                entity.HasOne(d => d.VlgVereinbarungNavigation)
                    .WithMany(p => p.TVereinbarLeistgruppen)
                    .HasForeignKey(d => d.VlgVereinbarung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VereinbarLeistgruppen_hat_Vereinbarung");
            });

            modelBuilder.Entity<TVereinbarungen>(entity =>
            {
                entity.HasKey(e => e.VerVereinbarung)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_Vereinbarungen");

                entity.Property(e => e.VerVereinbarung)
                    .HasColumnName("verVereinbarung")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.VerBezeichnung)
                    .HasColumnName("verBezeichnung")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VerGueltigAb)
                    .HasColumnName("verGueltigAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.VerGueltigBis)
                    .HasColumnName("verGueltigBis")
                    .HasColumnType("datetime");

                entity.Property(e => e.VerMitglied)
                    .IsRequired()
                    .HasColumnName("verMitglied")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.VerMitgliedNavigation)
                    .WithMany(p => p.TVereinbarungen)
                    .HasForeignKey(d => d.VerMitglied)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vereinbarungen_hat_Mitglied");
            });

            modelBuilder.Entity<TVereinbarungenDetails>(entity =>
            {
                entity.HasKey(e => e.VedId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_VereinbarungenDetails");

                entity.Property(e => e.VedId)
                    .HasColumnName("vedID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.VedLeistungsgruppe)
                    .IsRequired()
                    .HasColumnName("vedLeistungsgruppe")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VedVersorgungstyp).HasColumnName("vedVersorgungstyp");

                entity.HasOne(d => d.VedVersorgungstypNavigation)
                    .WithMany(p => p.TVereinbarungenDetails)
                    .HasForeignKey(d => d.VedVersorgungstyp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VereinbarungenDetails_hat_Typen");
            });

            modelBuilder.Entity<TVersorgungstypen>(entity =>
            {
                entity.HasKey(e => e.VetTyp)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_Versorgungstypen");

                entity.Property(e => e.VetTyp).HasColumnName("vetTyp");

                entity.Property(e => e.VetBezeichnung)
                    .IsRequired()
                    .HasColumnName("vetBezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TZusagen>(entity =>
            {
                entity.HasKey(e => e.ZusZusage)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_Zusagen");

                entity.Property(e => e.ZusZusage)
                    .HasColumnName("zusZusage")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ZusBeguenstigter)
                    .IsRequired()
                    .HasColumnName("zusBeguenstigter")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZusGueltigAb)
                    .HasColumnName("zusGueltigAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZusLeistungsgruppe)
                    .IsRequired()
                    .HasColumnName("zusLeistungsgruppe")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ZusBeguenstigterNavigation)
                    .WithMany(p => p.TZusagen)
                    .HasForeignKey(d => d.ZusBeguenstigter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zusagen_hat_Beguenstigte");

                entity.HasOne(d => d.ZusLeistungsgruppeNavigation)
                    .WithMany(p => p.TZusagen)
                    .HasForeignKey(d => d.ZusLeistungsgruppe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zusagen_hat_VerLeistunGrup");
            });

            modelBuilder.Entity<TZusagenDetails>(entity =>
            {
                entity.HasKey(e => e.ZudId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_ZusagenDetails");

                entity.Property(e => e.ZudId)
                    .HasColumnName("zudID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ZudGueltigAb)
                    .HasColumnName("zudGueltigAb")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZudStatus).HasColumnName("zudStatus");

                entity.Property(e => e.ZudVersorgungstyp).HasColumnName("zudVersorgungstyp");

                entity.Property(e => e.ZudWertAus)
                    .HasColumnName("zudWertAus")
                    .HasColumnType("money");

                entity.Property(e => e.ZudWertEin)
                    .HasColumnName("zudWertEin")
                    .HasColumnType("money");

                entity.Property(e => e.ZudZusage)
                    .IsRequired()
                    .HasColumnName("zudZusage")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ZudStatusNavigation)
                    .WithMany(p => p.TZusagenDetails)
                    .HasForeignKey(d => d.ZudStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZusagenDetails_hat_Status");

                entity.HasOne(d => d.ZudVersorgungstypNavigation)
                    .WithMany(p => p.TZusagenDetails)
                    .HasForeignKey(d => d.ZudVersorgungstyp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZusagenDetails_zum_versorgTyp");

                entity.HasOne(d => d.ZudZusageNavigation)
                    .WithMany(p => p.TZusagenDetails)
                    .HasForeignKey(d => d.ZudZusage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ZusagenDetails_kpmm_von_Zug");
            });

            modelBuilder.Entity<TZusagenStatus>(entity =>
            {
                entity.HasKey(e => e.ZstStatus)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("t_ZusagenStatus");

                entity.Property(e => e.ZstStatus).HasColumnName("zstStatus");

                entity.Property(e => e.ZstBezeichnung)
                    .IsRequired()
                    .HasColumnName("zstBezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
