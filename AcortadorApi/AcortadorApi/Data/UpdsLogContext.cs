using AcortadorApi.ModelsLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace AcortadorApi.Data
{
    public partial class UpdsLogContext : DbContext
    {
        public UpdsLogContext()
        {
        }

        public UpdsLogContext(DbContextOptions<UpdsLogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogApiSaad> LogApiSaads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Log");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogApiSaad>(entity =>
            {
                entity.ToTable("LogApiSAADS");

                entity.Property(e => e.IpsClient)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Method)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Payload).IsUnicode(false);

                entity.Property(e => e.Project).HasMaxLength(200);

                entity.Property(e => e.QueryString)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedOn).HasColumnType("datetime");

                entity.Property(e => e.RespondedOn).HasColumnType("datetime");

                entity.Property(e => e.Response).IsUnicode(false);

                entity.Property(e => e.ResponseCode)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
