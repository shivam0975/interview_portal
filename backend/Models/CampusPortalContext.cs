using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class CampusPortalContext : DbContext
{
    public CampusPortalContext()
    {
    }

    public CampusPortalContext(DbContextOptions<CampusPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Drife> Drives { get; set; }

    public virtual DbSet<InterviewSlot> InterviewSlots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=campus_portal;Uid=root;Pwd=root@123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.CandidateId).HasName("PRIMARY");

            entity.ToTable("candidates");

            entity.HasIndex(e => e.DriveId, "fk_candidate_drive");

            entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
            entity.Property(e => e.College)
                .HasMaxLength(200)
                .HasColumnName("college");
            entity.Property(e => e.DriveId).HasColumnName("drive_id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.Drive).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.DriveId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_candidate_drive");
        });

        modelBuilder.Entity<Drife>(entity =>
        {
            entity.HasKey(e => e.DriveId).HasName("PRIMARY");

            entity.ToTable("drives");

            entity.HasIndex(e => e.CreatedBy, "fk_drive_user");

            entity.Property(e => e.DriveId).HasColumnName("drive_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DriveDate)
                .HasColumnType("date")
                .HasColumnName("drive_date");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Drives)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_drive_user");
        });

        modelBuilder.Entity<InterviewSlot>(entity =>
        {
            entity.HasKey(e => e.SlotId).HasName("PRIMARY");

            entity.ToTable("interview_slots");

            entity.HasIndex(e => e.CandidateId, "fk_slot_candidate");

            entity.HasIndex(e => e.DriveId, "fk_slot_drive");

            entity.HasIndex(e => e.PanelistId, "fk_slot_panelist");

            entity.Property(e => e.SlotId).HasColumnName("slot_id");
            entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
            entity.Property(e => e.DriveId).HasColumnName("drive_id");
            entity.Property(e => e.Feedback)
                .HasColumnType("text")
                .HasColumnName("feedback");
            entity.Property(e => e.PanelistId).HasColumnName("panelist_id");
            entity.Property(e => e.ScheduledTime)
                .HasColumnType("datetime")
                .HasColumnName("scheduled_time");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'SCHEDULED'")
                .HasColumnType("enum('SCHEDULED','IN_PROGRESS','SELECTED','REJECTED','ON_HOLD')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Candidate).WithMany(p => p.InterviewSlots)
                .HasForeignKey(d => d.CandidateId)
                .HasConstraintName("fk_slot_candidate");

            entity.HasOne(d => d.Drive).WithMany(p => p.InterviewSlots)
                .HasForeignKey(d => d.DriveId)
                .HasConstraintName("fk_slot_drive");

            entity.HasOne(d => d.Panelist).WithMany(p => p.InterviewSlots)
                .HasForeignKey(d => d.PanelistId)
                .HasConstraintName("fk_slot_panelist");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasColumnType("enum('RECRUITER','PANELIST')")
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
