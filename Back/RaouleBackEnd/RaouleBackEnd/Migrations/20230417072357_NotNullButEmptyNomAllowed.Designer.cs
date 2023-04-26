﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Repositories;

#nullable disable

namespace RaouleBackEnd.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230417072357_NotNullButEmptyNomAllowed")]
    partial class NotNullButEmptyNomAllowed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.LieuObservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<GeometryCollection>("Localisations")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.HasKey("Id");

                    b.ToTable("LieuxObservations");
                });

            modelBuilder.Entity("Entities.Observation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("LieuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OiseauId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LieuId");

                    b.HasIndex("OiseauId");

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("Entities.Oiseau", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NomVernaculaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Oiseaux");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3990c71a-5dff-4b11-8664-256e00646741"),
                            Nom = "Merle noir",
                            NomVernaculaire = "Turdus merula"
                        },
                        new
                        {
                            Id = new Guid("3990c71a-5dff-4b11-8664-256e00646742"),
                            Nom = "Gris du Gabon",
                            NomVernaculaire = "Psitacus erithacus"
                        },
                        new
                        {
                            Id = new Guid("3990c71a-5dff-4b11-8664-256e00646743"),
                            Nom = "Grive musicienne",
                            NomVernaculaire = "Turdus philomelos"
                        });
                });

            modelBuilder.Entity("Entities.TypePaysage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid?>("LieuObservationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LieuObservationId");

                    b.ToTable("TypePaysage");
                });

            modelBuilder.Entity("Entities.Observation", b =>
                {
                    b.HasOne("Entities.LieuObservation", "Lieu")
                        .WithMany()
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Oiseau", "Oiseau")
                        .WithMany()
                        .HasForeignKey("OiseauId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lieu");

                    b.Navigation("Oiseau");
                });

            modelBuilder.Entity("Entities.TypePaysage", b =>
                {
                    b.HasOne("Entities.LieuObservation", null)
                        .WithMany("TypePaysages")
                        .HasForeignKey("LieuObservationId");
                });

            modelBuilder.Entity("Entities.LieuObservation", b =>
                {
                    b.Navigation("TypePaysages");
                });
#pragma warning restore 612, 618
        }
    }
}
