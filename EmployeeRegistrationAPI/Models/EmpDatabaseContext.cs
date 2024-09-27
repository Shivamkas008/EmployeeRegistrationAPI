using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationAPI.Models;

public partial class EmpDatabaseContext : DbContext
{
    public EmpDatabaseContext()
    {
    }

    public EmpDatabaseContext(DbContextOptions<EmpDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Salutation> Salutations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=EmpDatabase; User Id=sa; Password=123456; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED18088A81");

            entity.ToTable("Department");

            entity.HasIndex(e => e.DepartmentName, "UQ__Departme__D949CC349FD52FD3").IsUnique();

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11855C1B87");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.EmployeeCode, "UQ__Employee__1F64254806CD623F").IsUnique();

            entity.HasIndex(e => e.Panno, "UQ__Employee__2C9A485F29E52391").IsUnique();

            entity.HasIndex(e => e.Aadharno, "UQ__Employee__C2ACA1919D87900F").IsUnique();

            entity.Property(e => e.Aadharno)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("AADHARNo");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DisplayName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Doj)
                .HasColumnType("datetime")
                .HasColumnName("DOJ");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasComputedColumnSql("('EMP'+right('0000'+CONVERT([varchar](6),[EmployeeId]),(6)))", true);
            entity.Property(e => e.FatherName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Panno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PANNo");
            entity.Property(e => e.SpouseName)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Department");

            entity.HasOne(d => d.Gender).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Gender");

            entity.HasOne(d => d.Salutation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SalutationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Salutation");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PK__Gender__4E24E9F7C47CFCD5");

            entity.ToTable("Gender");

            entity.HasIndex(e => e.GenderName, "UQ__Gender__F7C177157F3BB6B7").IsUnique();

            entity.Property(e => e.GenderName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Salutation>(entity =>
        {
            entity.HasKey(e => e.SalutationId).HasName("PK__Salutati__562AE14FB601F450");

            entity.ToTable("Salutation");

            entity.HasIndex(e => e.SalutationName, "UQ__Salutati__140A3371F5EF533A").IsUnique();

            entity.Property(e => e.SalutationName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
