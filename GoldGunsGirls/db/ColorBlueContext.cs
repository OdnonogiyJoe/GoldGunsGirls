using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoldGunsGirls.db
{
    public partial class ColorBlueContext : DbContext
    {
        public ColorBlueContext()
        {
        }

        public ColorBlueContext(DbContextOptions<ColorBlueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; } = null!;
        public virtual DbSet<ApartmentType> ApartmentTypes { get; set; } = null!;
        public virtual DbSet<BalconyOrLoggium> BalconyOrLoggia { get; set; } = null!;
        public virtual DbSet<Bathroom> Bathrooms { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Elevator> Elevators { get; set; } = null!;
        public virtual DbSet<HouseType> HouseTypes { get; set; } = null!;
        public virtual DbSet<Parking> Parkings { get; set; } = null!;
        public virtual DbSet<Repair> Repairs { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Window> Windows { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TT2NO1K;Initial Catalog=ColorBlue;Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("Announcement");

                entity.Property(e => e.FloorsInTheApartment).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TotalArea).HasMaxLength(50);

                entity.HasOne(d => d.ApartmentType)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.ApartmentTypeId)
                    .HasConstraintName("FK_Announcement_ApartmentType");

                entity.HasOne(d => d.BalconyOrLoggia)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.BalconyOrLoggiaId)
                    .HasConstraintName("FK_Announcement_BalconyOrLoggia");

                entity.HasOne(d => d.Bathroom)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.BathroomId)
                    .HasConstraintName("FK_Announcement_Bathroom");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Announcement_City");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Announcement_District");

                entity.HasOne(d => d.Elevator)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.ElevatorId)
                    .HasConstraintName("FK_Announcement_Elevator");

                entity.HasOne(d => d.HouseType)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.HouseTypeId)
                    .HasConstraintName("FK_Announcement_HouseType");

                entity.HasOne(d => d.Parking)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.ParkingId)
                    .HasConstraintName("FK_Announcement_Parking");

                entity.HasOne(d => d.Repair)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.RepairId)
                    .HasConstraintName("FK_Announcement_Repair");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Announcement_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Announcement_User");

                entity.HasOne(d => d.Window)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.WindowId)
                    .HasConstraintName("FK_Announcement_Windows");
            });

            modelBuilder.Entity<ApartmentType>(entity =>
            {
                entity.ToTable("ApartmentType");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<BalconyOrLoggium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Bathroom>(entity =>
            {
                entity.ToTable("Bathroom");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");

                entity.Property(e => e.Title)
                    .HasMaxLength(14)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("Elevator");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<HouseType>(entity =>
            {
                entity.ToTable("HouseType");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Parking>(entity =>
            {
                entity.ToTable("Parking");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.ToTable("Repair");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Window>(entity =>
            {
                entity.ToTable("Window");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
