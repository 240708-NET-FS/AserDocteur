﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingApp.Entities;

#nullable disable

namespace VotingApp.Migrations
{
    [DbContext(typeof(DbContextEF))]
    [Migration("20240728042943_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VotingApp.Entities.President", b =>
                {
                    b.Property<int>("PresidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PresidentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Party")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresidentId");

                    b.ToTable("President");
                });

            modelBuilder.Entity("VotingApp.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PresidentId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("PresidentId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("VotingApp.Entities.User", b =>
                {
                    b.HasOne("VotingApp.Entities.President", "President")
                        .WithMany("Users")
                        .HasForeignKey("PresidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("President");
                });

            modelBuilder.Entity("VotingApp.Entities.President", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
