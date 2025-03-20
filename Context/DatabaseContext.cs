using System;
using System.Collections.Generic;
using HotelsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace HotelsApi.Context;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barangay> Barangays { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=HotelsApi;user=root;password=123456789;sslmode=Required;allow user variables=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Barangay>(entity =>
        {
            entity.HasKey(e => e.BarangayId).HasName("PRIMARY");

            entity.ToTable("Barangay");

            entity.HasIndex(e => e.CountryId, "Barangay_Country_FK");

            entity.Property(e => e.BarangayId).HasColumnName("barangayId");
            entity.Property(e => e.BarangayName)
                .HasMaxLength(255)
                .HasColumnName("barangayName");
            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.PostalCode).HasColumnName("postalCode");

            entity.HasOne(d => d.Country).WithMany(p => p.Barangays)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("Barangay_Country_FK");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("City");

            entity.HasIndex(e => e.StateId, "City_State_FK");

            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.CityCode).HasColumnName("cityCode");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .HasColumnName("cityName");
            entity.Property(e => e.StateId).HasColumnName("stateId");

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("City_State_FK");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.CountryCode).HasColumnName("countryCode");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .HasColumnName("countryName");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PRIMARY");

            entity.ToTable("Hotel");

            entity.HasIndex(e => e.BarangayId, "Hotel_Barangay_FK");

            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.BarangayId).HasColumnName("barangayId");
            entity.Property(e => e.HotelCode).HasColumnName("hotelCode");
            entity.Property(e => e.HotelDescription)
                .HasMaxLength(255)
                .HasColumnName("hotelDescription");
            entity.Property(e => e.HotelName)
                .HasMaxLength(255)
                .HasColumnName("hotelName");

            entity.HasOne(d => d.Barangay).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.BarangayId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Hotel_Barangay_FK");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PRIMARY");

            entity.ToTable("State");

            entity.HasIndex(e => e.CountryId, "State_Country_FK");

            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.StateCode).HasColumnName("stateCode");
            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .HasColumnName("stateName");

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("State_Country_FK");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.HotelId, "Transaction_Hotel_FK");

            entity.Property(e => e.TransactionId).HasColumnName("transactionId");
            entity.Property(e => e.DateFrom)
                .HasColumnType("timestamp")
                .HasColumnName("dateFrom");
            entity.Property(e => e.DateTo)
                .HasColumnType("timestamp")
                .HasColumnName("dateTo");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .HasColumnName("emailAddress");
            entity.Property(e => e.FullNamer)
                .HasMaxLength(255)
                .HasColumnName("fullNamer");
            entity.Property(e => e.HotelCode)
                .HasMaxLength(255)
                .HasColumnName("hotelCode");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.HotelName)
                .HasMaxLength(255)
                .HasColumnName("hotelName");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("Transaction_Hotel_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
