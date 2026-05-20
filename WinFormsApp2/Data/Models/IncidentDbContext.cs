using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp2.Data.Models;

public partial class IncidentDbContext : DbContext
{
    public IncidentDbContext()
    {
    }

    public IncidentDbContext(DbContextOptions<IncidentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentTechnician> DepartmentTechnicians { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<IncidentType> IncidentTypes { get; set; }

    public virtual DbSet<Technician> Technicians { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IncidentSystemDB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC27EFA19265");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(64);
        });

        modelBuilder.Entity<DepartmentTechnician>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC27DE74F249");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.TechnicianId).HasColumnName("TechnicianID");

            entity.HasOne(d => d.Department).WithMany(p => p.DepartmentTechnicians)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentID");

            entity.HasOne(d => d.Technician).WithMany(p => p.DepartmentTechnicians)
                .HasForeignKey(d => d.TechnicianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TechnicianID");
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Incident__3214EC278DF48020");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(64);

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Incidents)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Incidents_Type");
        });

        modelBuilder.Entity<IncidentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Incident__3214EC276FD90775");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Type).HasMaxLength(64);
        });

        modelBuilder.Entity<Technician>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Technici__3214EC2740E4E2D8");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(32);

            entity.HasOne(d => d.TypeSpecialisedNavigation).WithMany(p => p.Technicians)
                .HasForeignKey(d => d.TypeSpecialised)
                .HasConstraintName("FK_Technicians_TypeSpecialised");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2748AFFE2F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(32);
            entity.Property(e => e.Password).HasMaxLength(16);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
