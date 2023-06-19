using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_modelo_existente.Models;

public partial class SistemaFacturacionContext : DbContext
{
    public SistemaFacturacionContext()
    {
    }

    public SistemaFacturacionContext(DbContextOptions<SistemaFacturacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detalle> Detalles { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoCode> ProductoCodes { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__categori__DB875A4F19E26BCB");

            entity.ToTable("categoria");

            entity.Property(e => e.CategoriaId)
                .ValueGeneratedNever()
                .HasColumnName("categoria_id");
            entity.Property(e => e.CategoriaNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoria_nombre");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.CicloId).HasName("PK__ciclo__9B3F88DD6565B9BE");

            entity.ToTable("ciclo");

            entity.Property(e => e.CicloId)
                .ValueGeneratedNever()
                .HasColumnName("ciclo_id");
            entity.Property(e => e.CicloNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciclo_nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__cliente__47E34D6484D4DA95");

            entity.ToTable("cliente");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("cliente_id");
            entity.Property(e => e.ClienteDireccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cliente_direccion");
            entity.Property(e => e.ClienteNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente_nombre");
        });

        modelBuilder.Entity<Detalle>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__detalle__91B12E70A86CB27B");

            entity.ToTable("detalle");

            entity.Property(e => e.DetalleId)
                .ValueGeneratedNever()
                .HasColumnName("detalle_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");

            entity.HasOne(d => d.Factura).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("FK_Detalle_Factura");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK_Detalle_Producto");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__factura__D4782DA0F3C65685");

            entity.ToTable("factura");

            entity.Property(e => e.FacturaId)
                .ValueGeneratedNever()
                .HasColumnName("factura_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.VendedorId).HasColumnName("vendedor_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Factura_Cliente");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.VendedorId)
                .HasConstraintName("FK_Factura_Vendedor");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__producto__FB5CEEEC113B7F03");

            entity.ToTable("producto");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("producto_id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.ProductoNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("producto_nombre");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<ProductoCode>(entity =>
        {
            entity.HasKey(e => new { e.ProductoId, e.Codigo }).HasName("PK_ProductoCode");

            entity.ToTable("producto_code");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoCodes)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoCode_Producto");
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.VendedorId).HasName("PK__vendedor__9FB265DE4080CE95");

            entity.ToTable("vendedor");

            entity.Property(e => e.VendedorId)
                .ValueGeneratedNever()
                .HasColumnName("vendedor_id");
            entity.Property(e => e.VendedorNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vendedor_nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
