using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

public partial class Almacen : DbContext
{
    public Almacen()
    {
    }

    public Almacen(DbContextOptions<Almacen> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacenistum> Almacenista { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Coordinador> Coordinadors { get; set; }

    public virtual DbSet<DescPedido> DescPedidos { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Plantel> Plantels { get; set; }

    public virtual DbSet<Semestre> Semestres { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Filename=Almacen.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacenistum>(entity =>
        {
            entity.HasOne(d => d.Plantel).WithMany(p => p.Almacenista).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.Property(e => e.CategoriaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Coordinador>(entity =>
        {
            entity.HasOne(d => d.Plantel).WithMany(p => p.Coordinadors).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Coordinadors).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DescPedido>(entity =>
        {
            entity.Property(e => e.DescPedidoId).ValueGeneratedNever();

            entity.HasOne(d => d.Material).WithMany(p => p.DescPedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Pedido).WithMany(p => p.DescPedidos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasOne(d => d.Plantel).WithMany(p => p.Docentes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Docentes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasOne(d => d.Grupo).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Plantel).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Semestre).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.Property(e => e.MantenimientoId).ValueGeneratedNever();

            entity.HasOne(d => d.Material).WithMany(p => p.Mantenimientos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tipo).WithMany(p => p.Mantenimientos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.MaterialId).ValueGeneratedNever();

            entity.HasOne(d => d.Categoria).WithMany(p => p.Materials).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Marca).WithMany(p => p.Materials).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Modelo).WithMany(p => p.Materials).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(e => e.PedidoId).ValueGeneratedNever();

            entity.HasOne(d => d.Docente).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Laboratorio).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.Property(e => e.TipoId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
