﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PATITAS.Datos;

#nullable disable

namespace PATITAS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231116030653_calidad_s")]
    partial class calidad_s
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PATITAS.Models.Cita", b =>
                {
                    b.Property<int>("Cita_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cita_Id"));

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<int?>("Diagnostico_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mascota_Id")
                        .HasColumnType("int");

                    b.Property<string>("NombreCita")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cita_Id");

                    b.HasIndex("Diagnostico_Id")
                        .IsUnique()
                        .HasFilter("[Diagnostico_Id] IS NOT NULL");

                    b.HasIndex("Mascota_Id");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("PATITAS.Models.Cliente", b =>
                {
                    b.Property<int>("Cliente_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cliente_Id"));

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Cliente_Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PATITAS.Models.Descripcion", b =>
                {
                    b.Property<int>("Descripcion_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Descripcion_Id"));

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Descripcion_Id");

                    b.ToTable("Descripcion");
                });

            modelBuilder.Entity("PATITAS.Models.Diagnostico", b =>
                {
                    b.Property<int>("Diagnostico_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Diagnostico_Id"));

                    b.Property<string>("DiagnosticoFinal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicamentos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sintomas")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Diagnostico_Id");

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("PATITAS.Models.Mascota", b =>
                {
                    b.Property<int>("Mascota_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Mascota_Id"));

                    b.Property<int>("Cliente_Id")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Descripcion_Id")
                        .HasColumnType("int");

                    b.Property<string>("Esterilizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMascota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<string>("Raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Mascota_Id");

                    b.HasIndex("Cliente_Id");

                    b.HasIndex("Descripcion_Id")
                        .IsUnique()
                        .HasFilter("[Descripcion_Id] IS NOT NULL");

                    b.ToTable("Mascota");
                });

            modelBuilder.Entity("PATITAS.Models.Producto", b =>
                {
                    b.Property<int>("Producto_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Producto_Id"));

                    b.Property<double>("Costo_Unitario")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Producto_Id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("PATITAS.Models.Trabajador", b =>
                {
                    b.Property<int>("Trabajador_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Trabajador_Id"));

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Trabajador_Id");

                    b.ToTable("Trabajador");
                });

            modelBuilder.Entity("PATITAS.Models.Venta", b =>
                {
                    b.Property<int>("Venta_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Venta_Id"));

                    b.Property<int>("Cliente_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Trabajador_Id")
                        .HasColumnType("int");

                    b.HasKey("Venta_Id");

                    b.HasIndex("Cliente_Id");

                    b.HasIndex("Trabajador_Id")
                        .IsUnique();

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("PATITAS.Models.VentaProducto", b =>
                {
                    b.Property<int>("Venta_Id")
                        .HasColumnType("int");

                    b.Property<int>("Producto_Id")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("Venta_Id", "Producto_Id");

                    b.HasIndex("Producto_Id");

                    b.ToTable("VentaProducto");
                });

            modelBuilder.Entity("PATITAS.Models.AppTrabajador", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AppTrabajador");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PATITAS.Models.Cita", b =>
                {
                    b.HasOne("PATITAS.Models.Diagnostico", "Diagnostico")
                        .WithOne("Cita")
                        .HasForeignKey("PATITAS.Models.Cita", "Diagnostico_Id");

                    b.HasOne("PATITAS.Models.Mascota", "Mascota")
                        .WithMany("Cita")
                        .HasForeignKey("Mascota_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnostico");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PATITAS.Models.Mascota", b =>
                {
                    b.HasOne("PATITAS.Models.Cliente", "Cliente")
                        .WithMany("Mascota")
                        .HasForeignKey("Cliente_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PATITAS.Models.Descripcion", "Descripcion")
                        .WithOne("Mascota")
                        .HasForeignKey("PATITAS.Models.Mascota", "Descripcion_Id");

                    b.Navigation("Cliente");

                    b.Navigation("Descripcion");
                });

            modelBuilder.Entity("PATITAS.Models.Venta", b =>
                {
                    b.HasOne("PATITAS.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Cliente_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PATITAS.Models.Trabajador", "Trabajador")
                        .WithOne("Venta")
                        .HasForeignKey("PATITAS.Models.Venta", "Trabajador_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("PATITAS.Models.VentaProducto", b =>
                {
                    b.HasOne("PATITAS.Models.Producto", "Producto")
                        .WithMany("VentaProducto")
                        .HasForeignKey("Producto_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PATITAS.Models.Venta", "Venta")
                        .WithMany("VentaProducto")
                        .HasForeignKey("Venta_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("PATITAS.Models.Cliente", b =>
                {
                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PATITAS.Models.Descripcion", b =>
                {
                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PATITAS.Models.Diagnostico", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("PATITAS.Models.Mascota", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("PATITAS.Models.Producto", b =>
                {
                    b.Navigation("VentaProducto");
                });

            modelBuilder.Entity("PATITAS.Models.Trabajador", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("PATITAS.Models.Venta", b =>
                {
                    b.Navigation("VentaProducto");
                });
#pragma warning restore 612, 618
        }
    }
}