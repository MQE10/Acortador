using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcortadorApi.Models
{
    public partial class AcortadorContext : DbContext
    {
        public AcortadorContext()
        {
        }

        public AcortadorContext(DbContextOptions<AcortadorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<enlace> enlace { get; set; } = null!;
        public virtual DbSet<plataforma> plataforma { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=172.16.248.33; Database=Acortador; User=Practicante; Password=Pr4ct1c4nt3*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<enlace>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__enlace__06370DADD5531554");

                entity.Property(e => e.Codigo).HasMaxLength(30);

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Enlace1)
                    .HasColumnType("text")
                    .HasColumnName("Enlace");

                entity.Property(e => e.Titulo).HasMaxLength(20);

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.enlace)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("fk_enlace");
            });

            modelBuilder.Entity<plataforma>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
