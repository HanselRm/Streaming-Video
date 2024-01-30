﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Database.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos", (string)null);
                });

            modelBuilder.Entity("Database.Models.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Imagenes", (string)null);
                });

            modelBuilder.Entity("Database.Models.Productora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Productoras", (string)null);
                });

            modelBuilder.Entity("Database.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Enlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdGeneroPrimario")
                        .HasColumnType("int");

                    b.Property<int?>("IdGeneroSecundario")
                        .HasColumnType("int");

                    b.Property<int>("IdImagen")
                        .HasColumnType("int");

                    b.Property<int>("IdProductora")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdGeneroPrimario");

                    b.HasIndex("IdGeneroSecundario");

                    b.HasIndex("IdImagen");

                    b.HasIndex("IdProductora");

                    b.ToTable("Series", (string)null);
                });

            modelBuilder.Entity("Database.Models.Serie", b =>
                {
                    b.HasOne("Database.Models.Genero", "GeneroPrimario")
                        .WithMany("SeriesPrimarias")
                        .HasForeignKey("IdGeneroPrimario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Database.Models.Genero", "GeneroSecundario")
                        .WithMany("SeriesSecundarias")
                        .HasForeignKey("IdGeneroSecundario")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Database.Models.Imagen", "Imagen")
                        .WithMany()
                        .HasForeignKey("IdImagen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Productora", "productora")
                        .WithMany("Series")
                        .HasForeignKey("IdProductora")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GeneroPrimario");

                    b.Navigation("GeneroSecundario");

                    b.Navigation("Imagen");

                    b.Navigation("productora");
                });

            modelBuilder.Entity("Database.Models.Genero", b =>
                {
                    b.Navigation("SeriesPrimarias");

                    b.Navigation("SeriesSecundarias");
                });

            modelBuilder.Entity("Database.Models.Productora", b =>
                {
                    b.Navigation("Series");
                });
#pragma warning restore 612, 618
        }
    }
}