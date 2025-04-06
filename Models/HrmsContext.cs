using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HRMSystemWebAPI.Models;

public partial class HrmsContext : DbContext
{
    public HrmsContext()
    {
    }

    public HrmsContext(DbContextOptions<HrmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeJobHistory> EmployeeJobHistories { get; set; }

    public virtual DbSet<JobRole> JobRoles { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DONDAPATIRAO;Database=HRMS;Trusted_Connection=True; Trust Server Certificate=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status).HasDefaultValue(false);
        });

        modelBuilder.Entity<EmployeeJobHistory>(entity =>
        {
            entity.ToTable("EmployeeJobHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comments).HasColumnType("ntext");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.JobRoleId).HasColumnName("JobRoleID");
        });

        modelBuilder.Entity<JobRole>(entity =>
        {
            entity.ToTable("JobRole");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.TitleRole).HasMaxLength(100);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
