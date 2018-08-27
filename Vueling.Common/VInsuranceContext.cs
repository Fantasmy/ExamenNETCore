using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vueling.Infrastructure.Model;

namespace Vueling.Common
{
    public partial class VInsuranceContext : DbContext
    {
        public VInsuranceContext()
        {
        }

        public VInsuranceContext(DbContextOptions<VInsuranceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=VInsurance;User ID=sa; Pwd=Amaris2018;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InceptionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policies_Clients");
            });
        }
    }
}
