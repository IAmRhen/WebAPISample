using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplicationPAS.Models;

namespace WebApplicationPAS.Data;

public partial class PasContext : DbContext
{
    public PasContext()
    {
    }

    public PasContext(DbContextOptions<PasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customeraccount> Customeraccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=PASDb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Customeraccount>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customeraccount");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
