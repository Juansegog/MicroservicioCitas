﻿// <auto-generated />
using System;
using GestionPersonas.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCitas.Infraestructura.Migrations
{
    [DbContext(typeof(AplicacionDbContext))]
    partial class AplicacionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionCitas.Domain.Entities.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadoActualCita")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Medico")
                        .HasColumnType("int");

                    b.Property<int>("Paciente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Citas", (string)null);
                });

            modelBuilder.Entity("GestionCitas.Domain.Entities.Cita", b =>
                {
                    b.OwnsOne("GestionCitas.Domain.ValueObjects.Lugar", "Lugar", b1 =>
                        {
                            b1.Property<int>("CitaId")
                                .HasColumnType("int");

                            b1.Property<string>("NombreIps")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("NombreIps");

                            b1.HasKey("CitaId");

                            b1.ToTable("Citas");

                            b1.WithOwner()
                                .HasForeignKey("CitaId");

                            b1.OwnsOne("GestionPersonas.Domain.ValueObjects.Direccion", "Direccion", b2 =>
                                {
                                    b2.Property<int>("LugarCitaId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Barrio")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)")
                                        .HasColumnName("Barrio");

                                    b2.Property<string>("Calle")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)")
                                        .HasColumnName("Calle");

                                    b2.Property<string>("Departamento")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)")
                                        .HasColumnName("Departamento");

                                    b2.Property<string>("Municipio")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)")
                                        .HasColumnName("Municipio");

                                    b2.HasKey("LugarCitaId");

                                    b2.ToTable("Citas");

                                    b2.WithOwner()
                                        .HasForeignKey("LugarCitaId");
                                });

                            b1.Navigation("Direccion")
                                .IsRequired();
                        });

                    b.Navigation("Lugar")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
