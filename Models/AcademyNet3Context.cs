using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDb.Models;

public partial class AcademyNet3Context : DbContext
{
    public AcademyNet3Context()
    {
    }

    public AcademyNet3Context(DbContextOptions<AcademyNet3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<CopyEmployee> CopyEmployees { get; set; }

    public virtual DbSet<Copycalendar> Copycalendars { get; set; }

    public virtual DbSet<Copyemp> Copyemps { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Hobby> Hobbies { get; set; }

    public virtual DbSet<ViewEmployeCal> ViewEmployeCals { get; set; }

    public virtual DbSet<ViewEmployee> ViewEmployees { get; set; }

    public virtual DbSet<ViewFrancesco> ViewFrancescos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PAGNOZ\\SQLEXPRESS;Initial Catalog=AcademyNet3;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.ToTable("Calendar");

            entity.Property(e => e.Activity).HasMaxLength(25);
            entity.Property(e => e.DateActivity).HasColumnType("datetime");
            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();

            entity.HasOne(d => d.EmployeeEnrolNumberNavigation).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.EmployeeEnrolNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendar_Employee");
        });

        modelBuilder.Entity<CopyEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CopyEmployee");

            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.EmployeeJob).HasMaxLength(30);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Copycalendar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COPYCALENDAR");

            entity.Property(e => e.Activity).HasMaxLength(25);
            entity.Property(e => e.DateActivity).HasColumnType("datetime");
            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Copyemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COPYEMP");

            entity.Property(e => e.EmployeeDepartment).HasMaxLength(50);
            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.EmployeeJob).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeEnrolNumber).HasName("PK_Employee_1");

            entity.ToTable("Employee", tb => tb.HasTrigger("trInsertCalendarRow"));

            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.EmployeeDepartment).HasMaxLength(50);
            entity.Property(e => e.EmployeeJob).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Hobby>(entity =>
        {
            entity.ToTable("Hobby");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.HobbyDescription).HasMaxLength(50);
            entity.Property(e => e.InsertDate).HasColumnType("date");

            entity.HasOne(d => d.EmployeeEnrolNumberNavigation).WithMany(p => p.Hobbies)
                .HasForeignKey(d => d.EmployeeEnrolNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hobby_Employee");
        });

        modelBuilder.Entity<ViewEmployeCal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewEmployeCal");

            entity.Property(e => e.Activity).HasMaxLength(25);
            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ViewEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewEmployee");

            entity.Property(e => e.Activity).HasMaxLength(25);
            entity.Property(e => e.DateActivity).HasColumnType("datetime");
            entity.Property(e => e.EmployeeDepartment).HasMaxLength(50);
            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.EmployeeJob).HasMaxLength(30);
            entity.Property(e => e.HobbyDescription).HasMaxLength(50);
            entity.Property(e => e.InsertDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ViewFrancesco>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewFrancesco");

            entity.Property(e => e.Activity).HasMaxLength(25);
            entity.Property(e => e.DateActivity).HasColumnType("datetime");
            entity.Property(e => e.EmployeeEnrolNumber)
                .HasMaxLength(4)
                .IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
