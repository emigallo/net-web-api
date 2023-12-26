﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231219224148_MigrateData")]
    partial class MigrateData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPartners")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StadiumName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("StandingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumName")
                        .IsUnique()
                        .HasFilter("[StadiumName] IS NOT NULL");

                    b.HasIndex("StandingId");

                    b.ToTable("Clubs", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalClubId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("VisitingClubId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalClubId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("VisitingClubId");

                    b.ToTable("Matchs", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Players", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Stadium", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Stadiums", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Standing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId")
                        .IsUnique();

                    b.ToTable("Standings", "dbo");
                });

            modelBuilder.Entity("Model.Entities.StandingClub", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("Draw")
                        .HasColumnType("int");

                    b.Property<int>("Loss")
                        .HasColumnType("int");

                    b.Property<int>("MatchsPlayed")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Scoring")
                        .HasColumnType("int");

                    b.Property<int>("Win")
                        .HasColumnType("int");

                    b.HasKey("Id", "ClubId");

                    b.HasIndex("ClubId")
                        .IsUnique();

                    b.ToTable("StandingClubs", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tournaments", "dbo");
                });

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.HasOne("Model.Entities.Stadium", "Stadium")
                        .WithOne("Club")
                        .HasForeignKey("Model.Entities.Club", "StadiumName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Model.Entities.Standing", null)
                        .WithMany("Clubs")
                        .HasForeignKey("StandingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("Model.Entities.Match", b =>
                {
                    b.HasOne("Model.Entities.Club", "LocalClub")
                        .WithMany()
                        .HasForeignKey("LocalClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Model.Entities.Tournament", null)
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");

                    b.HasOne("Model.Entities.Club", "VisitingClub")
                        .WithMany()
                        .HasForeignKey("VisitingClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LocalClub");

                    b.Navigation("VisitingClub");
                });

            modelBuilder.Entity("Model.Entities.Player", b =>
                {
                    b.HasOne("Model.Entities.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Model.Entities.Standing", b =>
                {
                    b.HasOne("Model.Entities.Tournament", "Tournament")
                        .WithOne("Standing")
                        .HasForeignKey("Model.Entities.Standing", "TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Model.Entities.StandingClub", b =>
                {
                    b.HasOne("Model.Entities.Club", "Club")
                        .WithOne()
                        .HasForeignKey("Model.Entities.StandingClub", "ClubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Model.Entities.Club", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Model.Entities.Stadium", b =>
                {
                    b.Navigation("Club")
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Standing", b =>
                {
                    b.Navigation("Clubs");
                });

            modelBuilder.Entity("Model.Entities.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Standing")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}