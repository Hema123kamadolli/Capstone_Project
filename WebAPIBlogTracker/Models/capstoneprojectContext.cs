using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIBlogTracker.Models
{
    public partial class capstoneprojectContext : DbContext
    {
        public capstoneprojectContext()
        {
        }

        public capstoneprojectContext(DbContextOptions<capstoneprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminInfo> AdminInfos { get; set; } = null!;
        public virtual DbSet<BlogInfo> BlogInfos { get; set; } = null!;
        public virtual DbSet<EmpInfo> EmpInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-KP6PKP4L;database=capstoneproject;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminInfo>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__AdminInf__7ED91ACFC4E06703");

                entity.ToTable("AdminInfo");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<BlogInfo>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                    .HasName("PK__BlogInfo__54379E308DF814BB");

                entity.ToTable("BlogInfo");

                entity.Property(e => e.BlogId).ValueGeneratedNever();

                entity.Property(e => e.BlogUrl).HasMaxLength(50);

                entity.Property(e => e.DateOfCreation).HasColumnType("datetime");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Subject).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.BlogInfos)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("FK__BlogInfo__EmailI__3B75D760");
            });

            modelBuilder.Entity<EmpInfo>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__EmpInfo__7ED91ACFDCCFE5A5");

                entity.ToTable("EmpInfo");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.DateOfJoining).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PassCode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
