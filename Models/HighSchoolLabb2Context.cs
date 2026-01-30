using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_DanielNilsson.Models;

public partial class HighSchoolLabb2Context : DbContext
{
    internal object studentsorter;

    public HighSchoolLabb2Context()
    {
    }

    public HighSchoolLabb2Context(DbContextOptions<HighSchoolLabb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Betyg> Betygs { get; set; }

    public virtual DbSet<Klasser> Klassers { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Studenter> Studenters { get; set; }

    public virtual DbSet<Yrkestitel> Yrkestitels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=HighSchool_Labb2;Trusted_Connection=True; Trust server certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betyg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Betyg__3214EC078EB41B93");

            entity.ToTable("Betyg");

            entity.Property(e => e.Betyg1)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Betyg");
            entity.Property(e => e.Datum).HasColumnType("datetime");
            entity.Property(e => e.LärarId).HasColumnName("Lärar_Id");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            entity.Property(e => e.Ämne)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Lärar).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.LärarId)
                .HasConstraintName("FK__Betyg__Lärar_Id__72C60C4A");

            entity.HasOne(d => d.Student).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Betyg__Student_I__73BA3083");
        });

        modelBuilder.Entity<Klasser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Klasser__3214EC07011ACE03");

            entity.ToTable("Klasser");

            entity.Property(e => e.MentorId).HasColumnName("Mentor_Id");
            entity.Property(e => e.Namn)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Mentor).WithMany(p => p.Klassers)
                .HasForeignKey(d => d.MentorId)
                .HasConstraintName("FK__Klasser__Mentor___6D0D32F4");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3214EC075F2459D7");

            entity.ToTable("Personal");

            entity.Property(e => e.Efternamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Förnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YrkesId).HasColumnName("yrkesId");

            entity.HasOne(d => d.Yrkes).WithMany(p => p.Personals)
                .HasForeignKey(d => d.YrkesId)
                .HasConstraintName("FK__Personal__yrkesI__787EE5A0");
        });

        modelBuilder.Entity<Studenter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Studente__3214EC07FF94C3DF");

            entity.ToTable("Studenter");

            entity.Property(e => e.Efternamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Förnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KlassId).HasColumnName("Klass_ID");
            entity.Property(e => e.Personnummer)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.HasOne(d => d.Klass).WithMany(p => p.Studenters)
                .HasForeignKey(d => d.KlassId)
                .HasConstraintName("FK__Studenter__Klass__6FE99F9F");
        });

        modelBuilder.Entity<Yrkestitel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Yrkestit__3214EC07422BCF24");

            entity.ToTable("Yrkestitel");

            entity.Property(e => e.Titel)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
