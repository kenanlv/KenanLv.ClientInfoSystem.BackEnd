using ClientInfoSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientInfoSystem.Infrastructure.Data
{
    public class ClientInfoSysDbContext : DbContext
    {
        public ClientInfoSysDbContext(DbContextOptions<ClientInfoSysDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>(ConfigureClients);
            modelBuilder.Entity<Employees>(ConfigureEmployees);
            modelBuilder.Entity<Interactions>(ConfigureInteractions);

        }
        private void ConfigureClients(EntityTypeBuilder<Clients> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Email).HasMaxLength(50);
            builder.Property(c => c.Phone).HasMaxLength(30);
            builder.Property(c => c.Address).HasMaxLength(100);
        }
        private void ConfigureEmployees(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(50);
            builder.Property(b => b.Password).HasMaxLength(10);
            builder.Property(b => b.Designation).HasMaxLength(50);
        }
        private void ConfigureInteractions(EntityTypeBuilder<Interactions> builder)
        {
            builder.ToTable("Interactions");
            builder.HasKey(i => i.Id);
            builder.
                HasOne(i => i.Clients).
                WithOne(c => c.Interactions).
                HasForeignKey<Interactions>(i => i.ClientId);
            builder.
                HasOne(i => i.Employees).
                WithOne(c => c.Interactions).
                HasForeignKey<Interactions>(i => i.EmpId);
            builder.Property(i => i.IntType).HasColumnType("char");
            builder.Property(i=>i.Remarks).HasMaxLength(500);
        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
    }
}
