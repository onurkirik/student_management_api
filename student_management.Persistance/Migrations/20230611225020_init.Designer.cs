﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using student_management.Persistance.Context;

#nullable disable

namespace student_management.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230611225020_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("student_management.Domain.Entities.Adress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhysicalAdress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PostalAdress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Adress");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b8bf0b78-0202-4883-ab4d-6d57832a1046"),
                            PhysicalAdress = "Altındağ/Ankara",
                            PostalAdress = "Türkiye"
                        });
                });

            modelBuilder.Entity("student_management.Domain.Entities.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            Id = new Guid("41607d57-e74e-40c4-afbf-bed0476c3ba8"),
                            Description = "Erkek"
                        },
                        new
                        {
                            Id = new Guid("e4a62a5f-1222-4f9d-9404-c6e691d7a4bf"),
                            Description = "Kadın"
                        });
                });

            modelBuilder.Entity("student_management.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.HasIndex("GenderId");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9650103c-8f99-4a39-83da-70459bff90ba"),
                            AdressId = new Guid("b8bf0b78-0202-4883-ab4d-6d57832a1046"),
                            BirthDate = new DateTime(2023, 6, 12, 1, 50, 20, 384, DateTimeKind.Local).AddTicks(3796),
                            Email = "kirikonurr@gmail.com",
                            FirstName = "Onur",
                            GenderId = new Guid("41607d57-e74e-40c4-afbf-bed0476c3ba8"),
                            LastName = "KIRIK",
                            Phone = "5423815262",
                            ProfileImageUrl = "fjdksajf"
                        });
                });

            modelBuilder.Entity("student_management.Domain.Entities.Student", b =>
                {
                    b.HasOne("student_management.Domain.Entities.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("student_management.Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");

                    b.Navigation("Gender");
                });
#pragma warning restore 612, 618
        }
    }
}
