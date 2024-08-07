﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class NotnimYadContext : DbContext
{
    public NotnimYadContext(DbContextOptions<NotnimYadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    public virtual DbSet<VolunteeringTask> VolunteeringTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC07EDD0D093");

            entity.ToTable("Address");

            entity.Property(e => e.Building)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Children__3214EC07B2E3D58A");

            entity.Property(e => e.Id).HasMaxLength(10);
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Challenge)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Comments).HasMaxLength(4000);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(10);

            entity.HasOne(d => d.Address).WithMany(p => p.Children)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChildrenAddress");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07BB4842C1");

            entity.Property(e => e.ChildId)
                .HasMaxLength(10)
                .HasColumnName("ChildID");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.VolunteerId)
                .HasMaxLength(10)
                .HasColumnName("VolunteerID");

            entity.HasOne(d => d.Child).WithMany(p => p.Users)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("FK_UsersChilds");

            entity.HasOne(d => d.Volunteer).WithMany(p => p.Users)
                .HasForeignKey(d => d.VolunteerId)
                .HasConstraintName("FK_UsersVolunteers");
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voluntee__3214EC073BE7623F");

            entity.Property(e => e.Id).HasMaxLength(10);
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Comments).HasMaxLength(4000);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(10);

            entity.HasOne(d => d.Address).WithMany(p => p.Volunteers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VolunteersAddress");
        });

        modelBuilder.Entity<VolunteeringTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voluntee__3214EC07773FBCFE");

            entity.Property(e => e.ChildId)
                .HasMaxLength(10)
                .HasColumnName("ChildID");
            entity.Property(e => e.Comments).HasMaxLength(4000);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.End).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.VolunteerId)
                .HasMaxLength(10)
                .HasColumnName("VolunteerID");

            entity.HasOne(d => d.Child).WithMany(p => p.VolunteeringTasks)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("FK_VolunteeringTasksChildren");

            entity.HasOne(d => d.Volunteer).WithMany(p => p.VolunteeringTasks)
                .HasForeignKey(d => d.VolunteerId)
                .HasConstraintName("FK_VolenteeringTasksVolunteers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
