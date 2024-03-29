﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tournaments_api.Repository;

namespace tournaments_api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210531195245_AddedNewFieldToTeam")]
    partial class AddedNewFieldToTeam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportUser", b =>
                {
                    b.Property<int>("FavoriteSportsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FavoriteSportsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("SportUser");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("SportId");

                    b.ToTable("Matches");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Match");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("SportId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Tournaments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tournament");
                });

            modelBuilder.Entity("tournaments_api.DBModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tournaments_api.DBModels.MatchPlayers", b =>
                {
                    b.HasBaseType("tournaments_api.DBModels.Match");

                    b.Property<string>("FirstPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FirstPlayerScore")
                        .HasColumnType("int");

                    b.Property<int?>("GymId")
                        .HasColumnType("int");

                    b.Property<string>("SecondPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SecondPlayerScore")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<string>("WinnerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("FirstPlayerId");

                    b.HasIndex("GymId");

                    b.HasIndex("SecondPlayerId");

                    b.HasIndex("TournamentId");

                    b.HasDiscriminator().HasValue("MatchPlayers");
                });

            modelBuilder.Entity("tournaments_api.DBModels.MatchTeams", b =>
                {
                    b.HasBaseType("tournaments_api.DBModels.Match");

                    b.Property<int?>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<int>("FirstTeamScore")
                        .HasColumnType("int");

                    b.Property<int?>("GymId")
                        .HasColumnType("int")
                        .HasColumnName("MatchTeams_GymId");

                    b.Property<int?>("SecondTeamId")
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamScore")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int")
                        .HasColumnName("MatchTeams_TournamentId");

                    b.Property<string>("WinnerId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MatchTeams_WinnerId");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("GymId");

                    b.HasIndex("SecondTeamId");

                    b.HasIndex("TournamentId");

                    b.HasDiscriminator().HasValue("MatchTeams");
                });

            modelBuilder.Entity("tournaments_api.DBModels.TournamentPlayers", b =>
                {
                    b.HasBaseType("tournaments_api.DBModels.Tournament");

                    b.Property<int?>("GymId")
                        .HasColumnType("int");

                    b.HasIndex("GymId");

                    b.HasDiscriminator().HasValue("TournamentPlayers");
                });

            modelBuilder.Entity("tournaments_api.DBModels.TournamentTeams", b =>
                {
                    b.HasBaseType("tournaments_api.DBModels.Tournament");

                    b.Property<int?>("GymId")
                        .HasColumnType("int")
                        .HasColumnName("TournamentTeams_GymId");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasIndex("GymId");

                    b.HasDiscriminator().HasValue("TournamentTeams");
                });

            modelBuilder.Entity("SportUser", b =>
                {
                    b.HasOne("tournaments_api.DBModels.Sport", null)
                        .WithMany()
                        .HasForeignKey("FavoriteSportsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tournaments_api.DBModels.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tournaments_api.DBModels.Club", b =>
                {
                    b.HasOne("tournaments_api.DBModels.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Gym", b =>
                {
                    b.HasOne("tournaments_api.DBModels.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Match", b =>
                {
                    b.HasOne("tournaments_api.DBModels.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Team", b =>
                {
                    b.HasOne("tournaments_api.DBModels.Club", "Club")
                        .WithMany("Teams")
                        .HasForeignKey("ClubId");

                    b.HasOne("tournaments_api.DBModels.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("tournaments_api.DBModels.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId");

                    b.Navigation("Club");

                    b.Navigation("Owner");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("tournaments_api.DBModels.User", b =>
                {
                    b.HasOne("tournaments_api.DBModels.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("tournaments_api.DBModels.MatchPlayers", b =>
                {
                    b.HasOne("tournaments_api.DBModels.User", "FirstPlayer")
                        .WithMany()
                        .HasForeignKey("FirstPlayerId");

                    b.HasOne("tournaments_api.DBModels.Gym", "Gym")
                        .WithMany("MatchesPlayers")
                        .HasForeignKey("GymId");

                    b.HasOne("tournaments_api.DBModels.User", "SecondPlayer")
                        .WithMany()
                        .HasForeignKey("SecondPlayerId");

                    b.HasOne("tournaments_api.DBModels.TournamentPlayers", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");

                    b.Navigation("FirstPlayer");

                    b.Navigation("Gym");

                    b.Navigation("SecondPlayer");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("tournaments_api.DBModels.MatchTeams", b =>
                {
                    b.HasOne("tournaments_api.DBModels.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId");

                    b.HasOne("tournaments_api.DBModels.Gym", "Gym")
                        .WithMany("MatchesTeams")
                        .HasForeignKey("GymId");

                    b.HasOne("tournaments_api.DBModels.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId");

                    b.HasOne("tournaments_api.DBModels.TournamentTeams", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");

                    b.Navigation("FirstTeam");

                    b.Navigation("Gym");

                    b.Navigation("SecondTeam");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("tournaments_api.DBModels.TournamentPlayers", b =>
                {
                    b.HasOne("tournaments_api.DBModels.Gym", null)
                        .WithMany("TournamentsPlayers")
                        .HasForeignKey("GymId");
                });

            modelBuilder.Entity("tournaments_api.DBModels.TournamentTeams", b =>
                {
                    b.HasOne("tournaments_api.DBModels.Gym", null)
                        .WithMany("TournamentsTeams")
                        .HasForeignKey("GymId");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Club", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Gym", b =>
                {
                    b.Navigation("MatchesPlayers");

                    b.Navigation("MatchesTeams");

                    b.Navigation("TournamentsPlayers");

                    b.Navigation("TournamentsTeams");
                });

            modelBuilder.Entity("tournaments_api.DBModels.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("tournaments_api.DBModels.TournamentPlayers", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("tournaments_api.DBModels.TournamentTeams", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
