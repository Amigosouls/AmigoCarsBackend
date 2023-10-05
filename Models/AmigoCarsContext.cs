using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AmigoCars.Models;

public partial class AmigoCarsContext : DbContext
{
    public AmigoCarsContext()
    {
    }

    public AmigoCarsContext(DbContextOptions<AmigoCarsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<CarDetail> CarDetails { get; set; }

    public virtual DbSet<CarsDatum> CarsData { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Rto> Rtos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AJ_PC;Database=AmigoCars;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3213E83F3035351D");

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CircleName)
                .HasMaxLength(50)
                .HasColumnName("Circle_Name");
            entity.Property(e => e.Delivery).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.DivisionName)
                .HasMaxLength(50)
                .HasColumnName("Division_Name");
            entity.Property(e => e.OfficeName)
                .HasMaxLength(50)
                .HasColumnName("Office_Name");
            entity.Property(e => e.OfficeType).HasMaxLength(50);
            entity.Property(e => e.RegionName)
                .HasMaxLength(50)
                .HasColumnName("Region_Name");
            entity.Property(e => e.StateName).HasMaxLength(50);
        });

        modelBuilder.Entity<CarDetail>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__CarDetai__1436F1743C4FBFD5");

            entity.Property(e => e.CarId).HasColumnName("carId");
            entity.Property(e => e.Brand)
                .HasMaxLength(30)
                .HasColumnName("brand");
            entity.Property(e => e.CarImg).HasColumnName("carImg");
            entity.Property(e => e.CarLocation).HasColumnName("carLocation");
            entity.Property(e => e.FuelType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fuelType");
            entity.Property(e => e.KmDriven).HasColumnName("kmDriven");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasColumnType("smallmoney")
                .HasColumnName("price");
            entity.Property(e => e.RegistrationNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("registrationNo");
            entity.Property(e => e.RtoCircle).HasColumnName("rtoCircle");
            entity.Property(e => e.SellerId).HasColumnName("sellerId");
            entity.Property(e => e.Transmission)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("transmission");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.CarLocationNavigation).WithMany(p => p.CarDetails)
                .HasForeignKey(d => d.CarLocation)
                .HasConstraintName("FK__CarDetail__carLo__06CD04F7");

            entity.HasOne(d => d.RtoCircleNavigation).WithMany(p => p.CarDetails)
                .HasForeignKey(d => d.RtoCircle)
                .HasConstraintName("FK__CarDetail__rtoCi__05D8E0BE");

            entity.HasOne(d => d.Seller).WithMany(p => p.CarDetails)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__CarDetail__selle__07C12930");
        });

        modelBuilder.Entity<CarsDatum>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__CarsData__1436F174A9A76AC2");

            entity.Property(e => e.CarId)
                .ValueGeneratedNever()
                .HasColumnName("carId");
            entity.Property(e => e.FuelType)
                .HasMaxLength(20)
                .HasColumnName("fuelType");
            entity.Property(e => e.Make)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("make");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Variant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("variant");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__CD98462A0E222CC2");

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.RoleName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<Rto>(entity =>
        {
            entity.HasKey(e => e.RtoId).HasName("PK__Rto__E3A99E1CDF727FFB");

            entity.ToTable("Rto");

            entity.Property(e => e.RtoId).HasColumnName("rtoId");
            entity.Property(e => e.Place).HasMaxLength(200);
            entity.Property(e => e.RegNo).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFFCB092112");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.LastLogin)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lastLogin");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("roleId");
            entity.Property(e => e.UserAddress)
                .HasDefaultValueSql("((1))")
                .HasColumnName("userAddress");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .HasColumnName("userName");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__roleId__76969D2E");

            entity.HasOne(d => d.UserAddressNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserAddress)
                .HasConstraintName("FK__Users__userAddre__787EE5A0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
