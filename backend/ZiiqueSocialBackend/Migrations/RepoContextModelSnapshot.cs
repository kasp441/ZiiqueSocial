﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repo;

#nullable disable

namespace ZiiqueSocialBackend.Migrations
{
    [DbContext(typeof(RepoContext))]
    partial class RepoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Follows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("followsGuid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("profileGuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("followsGuid");

                    b.HasIndex("profileGuid");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("Domain.Profile", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("authId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("displayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("profileIcon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Guid");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Domain.Follows", b =>
                {
                    b.HasOne("Domain.Profile", "follows")
                        .WithMany()
                        .HasForeignKey("followsGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Profile", "profile")
                        .WithMany()
                        .HasForeignKey("profileGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("follows");

                    b.Navigation("profile");
                });
#pragma warning restore 612, 618
        }
    }
}
