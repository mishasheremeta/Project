using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace logic.Models;

public partial class LogicContext : DbContext
{
    public LogicContext()
    {
    }

    public LogicContext(DbContextOptions<LogicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=logic;user=root;password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cargos");

            entity.HasIndex(e => e.CustomerId, "customer_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CargoCode).HasColumnName("cargo_code");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .HasColumnName("destination");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .HasColumnName("origin");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Weight)
                .HasMaxLength(20)
                .HasColumnName("weight");

            entity.HasOne(d => d.Customer).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("cargos_ibfk_1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("company_name");
            entity.Property(e => e.Contact)
                .HasMaxLength(50)
                .HasColumnName("contact");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("drivers");

            entity.HasIndex(e => e.TransportId, "transport_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TransportId).HasColumnName("transport_id");

            entity.HasOne(d => d.Transport).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.TransportId)
                .HasConstraintName("drivers_ibfk_1");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GosNumber)
                .HasMaxLength(20)
                .HasColumnName("gos_number");
            entity.Property(e => e.IdTrakera).HasColumnName("id_trakera");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
