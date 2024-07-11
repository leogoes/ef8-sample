﻿// <auto-generated />
using System;
using EfCore.Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCore.Core.Migrations
{
    [DbContext(typeof(CustomContext))]
    [Migration("20240706170848_initial_migration")]
    partial class initial_migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EfCore.Core.Enities.Dream", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool?>("CanPunch")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Theme")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Dreams");
                });

            modelBuilder.Entity("EfCore.Core.Enities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DreamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DreamId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("EfCore.Core.Enities.Sleep", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("SleptAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("WokeupAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Sleeps");
                });

            modelBuilder.Entity("EfCore.Core.Enities.Person", b =>
                {
                    b.HasOne("EfCore.Core.Enities.Dream", "Dream")
                        .WithMany("Peoples")
                        .HasForeignKey("DreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dream");
                });

            modelBuilder.Entity("EfCore.Core.Enities.Sleep", b =>
                {
                    b.HasOne("EfCore.Core.Enities.Person", "Person")
                        .WithMany("Sleeps")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("EfCore.Core.Enities.Sheep", "CountOfSheeps", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("char(36)");

                            b1.Property<uint>("Name")
                                .HasColumnType("int unsigned")
                                .HasColumnName("SheepName");

                            b1.Property<uint>("Number")
                                .HasColumnType("int unsigned")
                                .HasColumnName("SheepNumber");

                            b1.Property<Guid>("SleepId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("SleepId");

                            b1.ToTable("Sheep");

                            b1.WithOwner()
                                .HasForeignKey("SleepId");
                        });

                    b.OwnsOne("EfCore.Core.Entities.NoiseDuringSleep", "Noise", b1 =>
                        {
                            b1.Property<Guid>("SleepId")
                                .HasColumnType("char(36)");

                            b1.Property<bool>("HasNoiseAtKitchen")
                                .HasColumnType("tinyint(1)");

                            b1.HasKey("SleepId");

                            b1.ToTable("Sleeps");

                            b1.WithOwner()
                                .HasForeignKey("SleepId");
                        });

                    b.Navigation("CountOfSheeps");

                    b.Navigation("Noise");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EfCore.Core.Enities.Dream", b =>
                {
                    b.Navigation("Peoples");
                });

            modelBuilder.Entity("EfCore.Core.Enities.Person", b =>
                {
                    b.Navigation("Sleeps");
                });
#pragma warning restore 612, 618
        }
    }
}
