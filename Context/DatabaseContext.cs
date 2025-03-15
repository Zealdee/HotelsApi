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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Barangay>(entity =>
        {
            entity.HasKey(e => e.BarangayId).HasName("PRIMARY");

            entity.ToTable("Barangay");

            entity.Property(e => e.BarangayId).HasColumnName("barangayId");
            entity.Property(e => e.BarangayName)
                .HasMaxLength(255)
                .HasColumnName("barangayName");
            entity.Property(e => e.PostalCode).HasColumnName("postalCode");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.CityCode).HasColumnName("cityCode");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .HasColumnName("cityName");
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

            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.HotelCode).HasColumnName("hotelCode");
            entity.Property(e => e.HotelDescription)
                .HasMaxLength(255)
                .HasColumnName("hotelDescription");
            entity.Property(e => e.HotelName)
                .HasMaxLength(255)
                .HasColumnName("hotelName");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PRIMARY");

            entity.ToTable("State");

            entity.Property(e => e.StateId).HasColumnName("stateId");
            entity.Property(e => e.StateCode).HasColumnName("stateCode");
            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .HasColumnName("stateName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
