﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20220225094229_cityid")]
    partial class cityid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Common.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Common.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Common.Models.Nation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NationCapitalId")
                        .HasColumnType("int");

                    b.Property<int?>("NationRulerId")
                        .HasColumnType("int");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NationCapitalId");

                    b.HasIndex("NationRulerId");

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("Common.Models.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("Common.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Birthplace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CityId1")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRuler")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OccupationId")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CityId1");

                    b.HasIndex("OccupationId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Common.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NationId")
                        .HasColumnType("int");

                    b.Property<int?>("RegionCapitalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NationId");

                    b.HasIndex("RegionCapitalId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Common.Models.District", b =>
                {
                    b.HasOne("Common.Models.City", null)
                        .WithMany("Districts")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("Common.Models.Nation", b =>
                {
                    b.HasOne("Common.Models.City", "NationCapital")
                        .WithMany()
                        .HasForeignKey("NationCapitalId");

                    b.HasOne("Common.Models.Person", "NationRuler")
                        .WithMany()
                        .HasForeignKey("NationRulerId");

                    b.Navigation("NationCapital");

                    b.Navigation("NationRuler");
                });

            modelBuilder.Entity("Common.Models.Person", b =>
                {
                    b.HasOne("Common.Models.City", null)
                        .WithOne("CityRuler")
                        .HasForeignKey("Common.Models.Person", "CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Models.Occupation", "Occupation")
                        .WithMany()
                        .HasForeignKey("OccupationId");

                    b.Navigation("City");

                    b.Navigation("Occupation");
                });

            modelBuilder.Entity("Common.Models.Region", b =>
                {
                    b.HasOne("Common.Models.Nation", null)
                        .WithMany("Regions")
                        .HasForeignKey("NationId");

                    b.HasOne("Common.Models.City", "RegionCapital")
                        .WithMany()
                        .HasForeignKey("RegionCapitalId");

                    b.Navigation("RegionCapital");
                });

            modelBuilder.Entity("Common.Models.City", b =>
                {
                    b.Navigation("CityRuler");

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Common.Models.Nation", b =>
                {
                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}
