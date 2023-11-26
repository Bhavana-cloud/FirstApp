using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbFirstEF.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Many> Manys { get; set; } = null!;
        public virtual DbSet<One> Ones { get; set; } = null!;
        public virtual DbSet<Parent> Parents { get; set; } = null!;
        public virtual DbSet<ToOne> ToOnes { get; set; } = null!;
        public virtual DbSet<TooMany1> TooMany1s { get; set; } = null!;
        public virtual DbSet<TooMany2> TooMany2s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=TestDb;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Many>(entity =>
            {
                entity.HasMany(d => d.TooMany2s)
                    .WithMany(p => p.Manys)
                    .UsingEntity<Dictionary<string, object>>(
                        "ManyTooMany2",
                        l => l.HasOne<TooMany2>().WithMany().HasForeignKey("TooMany2sId"),
                        r => r.HasOne<Many>().WithMany().HasForeignKey("ManysId"),
                        j =>
                        {
                            j.HasKey("ManysId", "TooMany2sId");

                            j.ToTable("ManyTooMany2");

                            j.HasIndex(new[] { "TooMany2sId" }, "IX_ManyTooMany2_TooMany2sId");
                        });
            });

            modelBuilder.Entity<One>(entity =>
            {
                entity.HasIndex(e => e.TooMany1Id, "IX_Ones_TooMany1Id");

                entity.HasOne(d => d.TooMany1)
                    .WithMany(p => p.Ones)
                    .HasForeignKey(d => d.TooMany1Id);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.ParentKey);

                entity.Property(e => e.Hobbies).HasColumnName("hobbies");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ToOne>(entity =>
            {
                entity.HasIndex(e => e.RelatedToOneId, "IX_ToOnes_RelatedToOneId");

                entity.HasOne(d => d.RelatedToOne)
                    .WithMany(p => p.ToOnes)
                    .HasForeignKey(d => d.RelatedToOneId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
