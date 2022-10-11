namespace GradeTrackerAPI.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<EducationTypeGoal>? EducationTypeGoals { get; set; }
        public DbSet<EducationType>? EducationTypes { get; set; }
        public DbSet<CompetenceArea>? CompetenceAreas { get; set; }
        public DbSet<Module>? Modules { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<Mark>? Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<EducationType>().HasData(
                new EducationType
                {
                    Id = 1,
                    Name = "EFZ",
                    Calculation = 1.0
                },
                new EducationType
                {
                    Id = 2,
                    Name = "BMW",
                    Calculation = 1.0
                },
                new EducationType
                {
                    Id = 3,
                    Name = "IMS",
                    Calculation = 1.0
                }
                );

            builder.Entity<CompetenceArea>().HasData(
                new CompetenceArea
                {
                    Id = 1,
                    Name = "Fachkompetenz",
                    Weighting = 0.3
                },
                new CompetenceArea
                {
                    Id=2,
                    Name = "Erweiterte Grundkompetenzen",
                    Weighting = 0.1
                },
                new CompetenceArea
                {
                    Id = 3,
                    Name = "Allgemeinbildung",
                    Weighting = 0.2
                }
                );

            builder.Entity<CompetenceAreaEducationType>()
                .HasKey(ce => new { ce.CompetenceAreaId, ce.EducationTypeId });
            builder.Entity<CompetenceAreaEducationType>()
                .HasOne<CompetenceArea>(ca => ca.CompetenceArea)
                .WithMany(ce => ce.CompetenceAreaEducationTypes)
                .HasForeignKey(ca => ca.CompetenceAreaId);

            builder.Entity<CompetenceAreaEducationType>()
                .HasOne<EducationType>(et => et.EducationType)
                .WithMany(ce => ce.CompetenceAreaEducationTypes)
                .HasForeignKey(et => et.EducationTypeId);

            builder.Entity<CompetenceAreaEducationType>()
                .HasData(
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 1,
                    EducationTypeId = 1,
                },
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 2,
                    EducationTypeId = 1,
                },
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 3,
                    EducationTypeId = 1,
                },
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 2,
                    EducationTypeId = 2,
                },
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 3,
                    EducationTypeId = 2,
                },
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 1,
                    EducationTypeId = 3,
                },
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 2,
                    EducationTypeId = 3,
                },
                new CompetenceAreaEducationType
                {
                    CompetenceAreaId = 3,
                    EducationTypeId = 3,
                }
                );
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity => { entity.Property(e => e.Id).IsRequired(); });

            modelBuilder.Entity<EducationType>().HasData(
                new EducationType
                {
                    Id = 1,
                    Name = "Eidgenössisches Berufsattest (EBA)",
                    Calculation = 1.0
                },
                new EducationType
                {
                    Id = 2,
                    Name = "Eidgenössisches Fachzertifikat (EFZ)",
                    Calculation = 1.0
                },
                new EducationType
                {
                    Id = 3,
                    Name = "Berufsmatura (BMS)",
                    Calculation = 1.0
                },
                new EducationType
                {
                    Id = 4,
                    Name = "IMS",
                    Calculation = 1.0
                }
                );

            modelBuilder.Entity<CompetenceArea>().HasData(
                new CompetenceArea
                {
                    Id = 1,
                    Name = "Fachkompetenzen",
                    EducationTypeId = 2,
                },
                new CompetenceArea
                {
                    Id = 2,
                    Name = "Erweiterte Kompetenzen",
                    EducationTypeId = 3,
                },
                new CompetenceArea
                {
                    Id = 3,
                    Name = "Allgemeinbildung",
                    EducationTypeId = 1,
                }
                );

            modelBuilder.Entity<CompetenceArea>(
                entity =>
                {
                    entity.HasOne(et => et.EducationType)
                    .WithMany(ca => ca.CompetenceAreas)
                    .HasForeignKey(ca => ca.EducationTypeId);
                });

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Roland Bucher"
                },
                new Teacher
                {
                    Id = 2,
                    Name = "Fritz Kempf"
                },
                new Teacher
                {
                    Id = 3,
                    Name = "Marcel Schorno"
                }
                );

            modelBuilder.Entity<Module>(
                entity =>
                {
                    entity.HasOne(ca => ca.CompetenceArea)
                    .WithMany(m => m.Modules)
                    .HasForeignKey(m => m.CompetenceAreaId);
                    entity.HasOne(t => t.Teacher)
                    .WithMany(m => m.Modules)
                    .HasForeignKey(m => m.TeacherId);
                });

            modelBuilder.Entity<Module>().HasData(
                new Module
                {
                    Id = 1,
                    Name = "INF 226B",
                    ShowOnDashboard = true,
                    TeacherId = 1,
                },
                new Module
                {
                    Id = 2,
                    Name = "Mathematik",
                    TeacherId = 2,
                },
                new Module
                {
                    Id = 3,
                    Name = "Sprache und Kommunikation",
                    TeacherId = 3,
                }
                );
        }*/
    }
}
