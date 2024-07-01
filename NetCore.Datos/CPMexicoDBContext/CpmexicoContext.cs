using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NetCore.Datos;
using NetCore.Entidades;

namespace NetCore.Datos.CPMexicoDBContext;

public partial class CpmexicoContext : DbContext
{
    public CpmexicoContext()
    {
    }

    public CpmexicoContext(DbContextOptions<CpmexicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aguascaliente> Aguascalientes { get; set; }

    public virtual DbSet<Asentamiento> Asentamientos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseSqlServer("Data Source=172.19.3.170;initial Catalog=CPMexico;user id=sa;password=dbadmin;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aguascaliente>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CCp)
                .HasMaxLength(255)
                .HasColumnName("c_CP");
            entity.Property(e => e.CCveCiudad)
                .HasMaxLength(255)
                .HasColumnName("c_cve_ciudad");
            entity.Property(e => e.CEstado)
                .HasMaxLength(255)
                .HasColumnName("c_estado");
            entity.Property(e => e.CMnpio)
                .HasMaxLength(255)
                .HasColumnName("c_mnpio");
            entity.Property(e => e.COficina)
                .HasMaxLength(255)
                .HasColumnName("c_oficina");
            entity.Property(e => e.CTipoAsenta)
                .HasMaxLength(255)
                .HasColumnName("c_tipo_asenta");
            entity.Property(e => e.DAsenta)
                .HasMaxLength(255)
                .HasColumnName("d_asenta");
            entity.Property(e => e.DCiudad)
                .HasMaxLength(255)
                .HasColumnName("d_ciudad");
            entity.Property(e => e.DCodigo)
                .HasMaxLength(255)
                .HasColumnName("d_codigo");
            entity.Property(e => e.DCp)
                .HasMaxLength(255)
                .HasColumnName("d_CP");
            entity.Property(e => e.DEstado)
                .HasMaxLength(255)
                .HasColumnName("d_estado");
            entity.Property(e => e.DMnpio)
                .HasMaxLength(255)
                .HasColumnName("D_mnpio");
            entity.Property(e => e.DTipoAsenta)
                .HasMaxLength(255)
                .HasColumnName("d_tipo_asenta");
            entity.Property(e => e.DZona)
                .HasMaxLength(255)
                .HasColumnName("d_zona");
            entity.Property(e => e.IdAsentaCpcons)
                .HasMaxLength(255)
                .HasColumnName("id_asenta_cpcons");
        });

        modelBuilder.Entity<Asentamiento>(entity =>
        {
            entity.HasKey(e => e.IdAsentamiento).HasName("PK__Asentami__E6BF45EC08B3FA56");

            entity.Property(e => e.IdAsentamiento).HasColumnName("id_asentamiento");
            entity.Property(e => e.ClaveCiudad)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("clave_ciudad");
            entity.Property(e => e.ClaveTipoAsentamiento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("clave_tipo_asentamiento");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.DescripcionZona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion_zona");
            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdentificadorAsentamiento)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("identificador_asentamiento");
            entity.Property(e => e.NombreAsentamiento)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("nombre_asentamiento");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("nombre_ciudad");
            entity.Property(e => e.TipoAsentamiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_asentamiento");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Asentamientos)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asentamie__id_mu__09746778");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estados__86989FB23CE35879");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.ClaveEstado)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("clave_estado");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_estado");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__01C9EB9958C47B82");

            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.ClaveMunicipio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("clave_municipio");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_municipio");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Municipio__clave__7B264821");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
