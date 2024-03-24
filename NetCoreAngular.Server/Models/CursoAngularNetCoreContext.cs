using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAngular.Server.Models;

public partial class CursoAngularNetCoreContext : DbContext
{
    public CursoAngularNetCoreContext()
    {
    }

    public CursoAngularNetCoreContext(DbContextOptions<CursoAngularNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Lineaspedido> Lineaspedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<UsuariosApi> UsuariosApis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-JHAVKCT;Database=CursoAngularNetCore;User Id=sa;Password=Test@123;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("CLIENTES");

            entity.HasIndex(e => e.Email, "IX_CLIENTES").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        modelBuilder.Entity<Lineaspedido>(entity =>
        {
            entity.ToTable("LINEASPEDIDOS");

            entity.Property(e => e.ImporteUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Lineaspedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LINEASPEDIDOS_PEDIDOS");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Lineaspedidos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LINEASPEDIDOS_PRODUCTOS");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("PEDIDOS");

            entity.Property(e => e.FechaPedido).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDOS_CLIENTES");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<UsuariosApi>(entity =>
        {
            entity.ToTable("USUARIOS_API");

            entity.HasIndex(e => e.Id, "IX_USUARIOS_API");

            entity.HasIndex(e => e.Email, "IX_USUARIOS_API_1").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
