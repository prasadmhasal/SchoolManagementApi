﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementApi.Context;

#nullable disable

namespace SchoolManagementApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240909080010_s")]
    partial class s
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolManagementApi.Model.StudentRequest", b =>
                {
                    b.Property<int>("studentRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("studentRequestId"));

                    b.Property<long>("Contect")
                        .HasColumnType("bigint");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("standard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentRequestId");

                    b.ToTable("studentRequests");
                });
#pragma warning restore 612, 618
        }
    }
}