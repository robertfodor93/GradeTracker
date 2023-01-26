using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<EducationTypeGoal>? EducationTypeGoals { get; set; }
        public DbSet<EducationType>? EducationTypes { get; set; }
        public DbSet<CompetenceArea>? CompetenceAreas { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<Grade>? Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EducationType>()
                .HasMany(et => et.CompetenceAreas)
                .WithOne(ca => ca.EducationType);

            builder.Entity<CompetenceArea>()
                .HasOne(et => et.EducationType)
                .WithMany(ca => ca.CompetenceAreas);

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
                    Name = "BM",
                    Calculation = 1.0
                },
                new EducationType
                {
                    Id = 3,
                    Name = "MS",
                    Calculation = 1.0
                }
                );

            builder.Entity<CompetenceArea>().HasData(
                new CompetenceArea
                {
                    Id = 1,
                    Name = "Fachkompetenzen",
                    EducationTypeId = 1,
                },
                new CompetenceArea
                {
                    Id = 2,
                    Name = "Erweiterte Grundkompetenzen",
                    EducationTypeId = 1,
                },
                new CompetenceArea
                {
                    Id = 3,
                    Name = "Allgemeinbildung",
                    EducationTypeId = 1,
                },
                new CompetenceArea
                {
                    Id = 4,
                    Name = "ÜK",
                    EducationTypeId = 1,
                },
                new CompetenceArea
                {
                    Id = 5,
                    Name = "Erweiterte Grundkompetenzen",
                    EducationTypeId = 2,
                },
                new CompetenceArea
                {
                    Id = 6,
                    Name = "Erweiterte Allgemeinbildung",
                    EducationTypeId = 2,
                },
                new CompetenceArea
                {
                    Id = 7,
                    Name = "ÜK",
                    EducationTypeId = 2,
                },
                new CompetenceArea
                {
                    Id = 8,
                    Name = "Fachkompetenzen",
                    EducationTypeId = 3,
                },
                new CompetenceArea
                {
                    Id = 9,
                    Name = "Erweiterte Grundkompetenzen",
                    EducationTypeId = 3,
                },
                new CompetenceArea
                {
                    Id = 10,
                    Name = "Erweiterte Allgemeinbildung",
                    EducationTypeId = 3,
                },
                new CompetenceArea
                {
                    Id = 11,
                    Name = "ÜK",
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
