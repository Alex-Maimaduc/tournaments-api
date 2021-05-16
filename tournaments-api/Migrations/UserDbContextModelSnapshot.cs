﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tournaments_api.Repository;

namespace tournaments_api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("tournaments_api.Models.Club", b =>
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

            modelBuilder.Entity("tournaments_api.Models.Match", b =>
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

            modelBuilder.Entity("tournaments_api.Models.Sport", b =>
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

            modelBuilder.Entity("tournaments_api.Models.Team", b =>
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

            modelBuilder.Entity("tournaments_api.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
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

            modelBuilder.Entity("tournaments_api.Models.MatchPlayers", b =>
                {
                    b.HasBaseType("tournaments_api.Models.Match");

                    b.Property<string>("FirstPlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecondPlyaerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("FirstPlayerId");

                    b.HasIndex("SecondPlyaerId");

                    b.HasDiscriminator().HasValue("MatchPlayers");
                });

            modelBuilder.Entity("tournaments_api.Models.MatchTeams", b =>
                {
                    b.HasBaseType("tournaments_api.Models.Match");

                    b.Property<int?>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTeamId")
                        .HasColumnType("int");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("SecondTeamId");

                    b.HasDiscriminator().HasValue("MatchTeams");
                });

            modelBuilder.Entity("SportUser", b =>
                {
                    b.HasOne("tournaments_api.Models.Sport", null)
                        .WithMany()
                        .HasForeignKey("FavoriteSportsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tournaments_api.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tournaments_api.Models.Club", b =>
                {
                    b.HasOne("tournaments_api.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("tournaments_api.Models.Match", b =>
                {
                    b.HasOne("tournaments_api.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("tournaments_api.Models.Team", b =>
                {
                    b.HasOne("tournaments_api.Models.Club", null)
                        .WithMany("Teams")
                        .HasForeignKey("ClubId");

                    b.HasOne("tournaments_api.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("tournaments_api.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId");

                    b.Navigation("Owner");

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("tournaments_api.Models.User", b =>
                {
                    b.HasOne("tournaments_api.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("tournaments_api.Models.MatchPlayers", b =>
                {
                    b.HasOne("tournaments_api.Models.User", "FirstPlayer")
                        .WithMany()
                        .HasForeignKey("FirstPlayerId");

                    b.HasOne("tournaments_api.Models.User", "SecondPlyaer")
                        .WithMany()
                        .HasForeignKey("SecondPlyaerId");

                    b.Navigation("FirstPlayer");

                    b.Navigation("SecondPlyaer");
                });

            modelBuilder.Entity("tournaments_api.Models.MatchTeams", b =>
                {
                    b.HasOne("tournaments_api.Models.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId");

                    b.HasOne("tournaments_api.Models.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId");

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("tournaments_api.Models.Club", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("tournaments_api.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
