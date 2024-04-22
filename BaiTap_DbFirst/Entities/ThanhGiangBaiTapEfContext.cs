using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaiTap_DbFirst.Entities;

public partial class ThanhGiangBaiTapEfContext : DbContext
{
    public ThanhGiangBaiTapEfContext()
    {
    }

    public ThanhGiangBaiTapEfContext(DbContextOptions<ThanhGiangBaiTapEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-9TOR6RJG;Initial Catalog=ThanhGiang_BaiTap_EF;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__Faculty__306F630E51CBD964");

            entity.ToTable("Faculty");

            entity.Property(e => e.FacultyId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.FacultyName).HasMaxLength(200);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B991A332AB0");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FacultyId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.StudentName).HasMaxLength(100);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Students)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Student__Faculty__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
