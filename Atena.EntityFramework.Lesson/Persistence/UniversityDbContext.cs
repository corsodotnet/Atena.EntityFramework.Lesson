using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Atena.EntityFramework.Lesson.Persistence
{
    public partial class UniversityDbContext : DbContext
    {

        public virtual DbSet<Corso> Corsos { get; set; }
        public virtual DbSet<Studente> Studentes { get; set; }


        public UniversityDbContext()
        {
        }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost;Database=UniversityDb; User id = sa ; password = Pass@word01;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Corso>(entity =>
            {
                entity.ToTable("Corso");
            });

            modelBuilder.Entity<Studente>(entity =>
            {
                entity.ToTable("Studente");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Corso)
                    .WithMany(p => p.Studentes)
                    .HasForeignKey(d => d.CorsoId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
