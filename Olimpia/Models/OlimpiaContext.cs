using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Olimpia.Models;

public partial class OlimpiaContext : DbContext
{
    public OlimpiaContext()
    {
    }

    public OlimpiaContext(DbContextOptions<OlimpiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Data> Datas { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=olimpia;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Data>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("datas");

            entity.HasIndex(e => e.PlayerId, "PlayerId");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Country)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.County)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.PlayerId).HasMaxLength(36);
            entity.Property(e => e.UpdatedTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Player).WithMany(p => p.Data)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("datas_ibfk_1");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("players");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Age)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CreatedTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("'current_timestamp()'")
                .HasColumnType("timestamp");
            entity.Property(e => e.Height)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Weight)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
