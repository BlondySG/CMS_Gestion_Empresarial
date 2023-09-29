﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(GestionBuenCosermuContext))]
    [Migration("20221123011648_MigracionBD")]
    partial class MigracionBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.TbArticulo", b =>
                {
                    b.Property<int>("IdArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticulo"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("CostoArticulo")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("FechaFinGarantia")
                        .HasColumnType("datetime");

                    b.Property<int>("Idproveedor")
                        .HasColumnType("int");

                    b.Property<string>("NombreArticulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NumParte")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NumPlaca")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NumSerie")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("PuntoReorden")
                        .HasColumnType("int");

                    b.Property<DateTime>("VidaUtil")
                        .HasColumnType("datetime");

                    b.HasKey("IdArticulo")
                        .HasName("PK_IdArticulo");

                    b.HasIndex("Idproveedor");

                    b.HasIndex(new[] { "IdArticulo", "NumSerie", "NumParte" }, "AK_Articulo_NumSerie_NumParte")
                        .IsUnique()
                        .HasFilter("[NumSerie] IS NOT NULL");

                    b.ToTable("tbArticulo", (string)null);
                });

            modelBuilder.Entity("Entities.TbBitacora", b =>
                {
                    b.Property<int>("IdBitacora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBitacora"), 1L, 1);

                    b.Property<int>("CodError")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2500)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("Origen")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("IdBitacora")
                        .HasName("PK_IdBitacora");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex(new[] { "IdBitacora" }, "AK_IdBitacora")
                        .IsUnique();

                    b.ToTable("tbBitacora", (string)null);
                });

            modelBuilder.Entity("Entities.TbCliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("CorreoCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DireccionCliente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("PersonaContacto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TelefonoCliente")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.HasKey("IdCliente")
                        .HasName("PK_IdCliente");

                    b.HasIndex(new[] { "IdCliente" }, "AK_IdCliente")
                        .IsUnique();

                    b.ToTable("tbCliente", (string)null);
                });

            modelBuilder.Entity("Entities.TbDatosCompra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCompra"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<decimal>("ImpuestoCompra")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("NumFacturaCompra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("SubTotalCompra")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalCompra")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdCompra")
                        .HasName("PK_IdCompra");

                    b.HasIndex("IdArticulo");

                    b.HasIndex("IdProveedor");

                    b.HasIndex(new[] { "IdCompra" }, "AK_IdCompra")
                        .IsUnique();

                    b.ToTable("tbDatosCompra", (string)null);
                });

            modelBuilder.Entity("Entities.TbDatosVenta", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenta"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCompra")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<decimal>("ImpuestoVenta")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("NumFacturaVenta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("SubTotalVenta")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalVenta")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdVenta")
                        .HasName("PK_IdVenta");

                    b.HasIndex("IdArticulo");

                    b.HasIndex("IdCliente");

                    b.HasIndex(new[] { "IdVenta" }, "AK_IdVenta")
                        .IsUnique();

                    b.ToTable("tbDatosVenta", (string)null);
                });

            modelBuilder.Entity("Entities.TbEmpleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("CorreoEmpleado")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("image");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NombreContacto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TelefonoContacto")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("TelefonoEmpleado")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.HasKey("IdEmpleado")
                        .HasName("PK_IdEmpleado");

                    b.HasIndex("IdRol");

                    b.HasIndex(new[] { "Cedula" }, "AK_Cedula")
                        .IsUnique();

                    b.ToTable("tbEmpleado", (string)null);
                });

            modelBuilder.Entity("Entities.TbEmpleadoSoporte", b =>
                {
                    b.Property<int>("IdEmpleadoSoporte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleadoSoporte"), 1L, 1);

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdSoporte")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleadoSoporte")
                        .HasName("PK__tbEmplea__17881CD6081BED5D");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdSoporte");

                    b.HasIndex(new[] { "IdEmpleadoSoporte" }, "AK_IdEmpleadoSoporte")
                        .IsUnique();

                    b.ToTable("tbEmpleadoSoporte", (string)null);
                });

            modelBuilder.Entity("Entities.TbProveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProveedor"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("CorreoProveedor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DireccionProveedor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NombreContacto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("ProductoProveedor")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("TelefonoProveedor")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.HasKey("IdProveedor")
                        .HasName("PK_IdProveedor");

                    b.HasIndex(new[] { "IdProveedor" }, "AK_IdProveedor")
                        .IsUnique();

                    b.ToTable("tbProveedor", (string)null);
                });

            modelBuilder.Entity("Entities.TbRol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("IdRol")
                        .HasName("PK__tbRol__2A49584C67CBF7E9");

                    b.HasIndex(new[] { "IdRol" }, "AK_IdRol")
                        .IsUnique();

                    b.ToTable("tbRol", (string)null);
                });

            modelBuilder.Entity("Entities.TbSoporte", b =>
                {
                    b.Property<int>("IdSoporte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSoporte"), 1L, 1);

                    b.Property<string>("DescripcionSoporte")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("FechaAgendada")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaCierreSoporte")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdTipo")
                        .HasColumnType("int");

                    b.HasKey("IdSoporte")
                        .HasName("PK_IdSoporte");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdTipo");

                    b.HasIndex(new[] { "IdSoporte" }, "AK_Soporte")
                        .IsUnique();

                    b.ToTable("tbSoporte", (string)null);
                });

            modelBuilder.Entity("Entities.TbSoporteCliente", b =>
                {
                    b.Property<int>("IdSoporteCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSoporteCliente"), 1L, 1);

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdSoporte")
                        .HasColumnType("int");

                    b.HasKey("IdSoporteCliente")
                        .HasName("PK_IdSoporteCliente");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdSoporte");

                    b.HasIndex(new[] { "IdSoporteCliente" }, "AK_IdSoporteCliente")
                        .IsUnique();

                    b.ToTable("tbSoporteCliente", (string)null);
                });

            modelBuilder.Entity("Entities.TbTipo", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipo"), 1L, 1);

                    b.Property<string>("NombreSoporte")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdTipo")
                        .HasName("PK_IdTipo");

                    b.HasIndex(new[] { "IdTipo" }, "AK_Tipo")
                        .IsUnique();

                    b.ToTable("tbTipo", (string)null);
                });

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.TbArticulo", b =>
                {
                    b.HasOne("Entities.TbProveedor", "IdProveedorNavigation")
                        .WithMany("TbArticulos")
                        .HasForeignKey("Idproveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Proveedor");

                    b.Navigation("IdProveedorNavigation");
                });

            modelBuilder.Entity("Entities.TbBitacora", b =>
                {
                    b.HasOne("Entities.TbEmpleado", "IdEmpleadoNavigation")
                        .WithMany("TbBitacoras")
                        .HasForeignKey("IdEmpleado")
                        .IsRequired()
                        .HasConstraintName("FK_Empleado");

                    b.Navigation("IdEmpleadoNavigation");
                });

            modelBuilder.Entity("Entities.TbDatosCompra", b =>
                {
                    b.HasOne("Entities.TbArticulo", "IdArticuloNavigation")
                        .WithMany("TbDatosCompras")
                        .HasForeignKey("IdArticulo")
                        .IsRequired()
                        .HasConstraintName("FK_Compra_Articulo");

                    b.HasOne("Entities.TbProveedor", "IdProveedorNavigation")
                        .WithMany("TbDatosCompras")
                        .HasForeignKey("IdProveedor")
                        .IsRequired()
                        .HasConstraintName("FK_Compra_Proveedor");

                    b.Navigation("IdArticuloNavigation");

                    b.Navigation("IdProveedorNavigation");
                });

            modelBuilder.Entity("Entities.TbDatosVenta", b =>
                {
                    b.HasOne("Entities.TbArticulo", "IdArticuloNavigation")
                        .WithMany("TbDatosVenta")
                        .HasForeignKey("IdArticulo")
                        .IsRequired()
                        .HasConstraintName("FK_Venta_Articulo");

                    b.HasOne("Entities.TbCliente", "IdClienteNavigation")
                        .WithMany("TbDatosVenta")
                        .HasForeignKey("IdCliente")
                        .IsRequired()
                        .HasConstraintName("FK_Venta_Cliente");

                    b.Navigation("IdArticuloNavigation");

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("Entities.TbEmpleado", b =>
                {
                    b.HasOne("Entities.TbRol", "IdRolNavigation")
                        .WithMany("TbEmpleados")
                        .HasForeignKey("IdRol")
                        .IsRequired()
                        .HasConstraintName("FK_Empleado_Rol");

                    b.Navigation("IdRolNavigation");
                });

            modelBuilder.Entity("Entities.TbEmpleadoSoporte", b =>
                {
                    b.HasOne("Entities.TbEmpleado", "IdEmpleadoNavigation")
                        .WithMany("TbEmpleadoSoportes")
                        .HasForeignKey("IdEmpleado")
                        .IsRequired()
                        .HasConstraintName("PK_EmpleadoSoporte_Empleado");

                    b.HasOne("Entities.TbSoporte", "IdSoporteNavigation")
                        .WithMany("TbEmpleadoSoportes")
                        .HasForeignKey("IdSoporte")
                        .IsRequired()
                        .HasConstraintName("PK_EmpleadoSoporte_Soporte");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdSoporteNavigation");
                });

            modelBuilder.Entity("Entities.TbSoporte", b =>
                {
                    b.HasOne("Entities.TbCliente", "IdClienteNavigation")
                        .WithMany("TbSoportes")
                        .HasForeignKey("IdCliente")
                        .IsRequired()
                        .HasConstraintName("FK_Soporte_Cliente");

                    b.HasOne("Entities.TbEmpleado", "IdEmpleadoNavigation")
                        .WithMany("TbSoportes")
                        .HasForeignKey("IdEmpleado")
                        .IsRequired()
                        .HasConstraintName("PK_Soporte_Empleado");

                    b.HasOne("Entities.TbTipo", "IdTipoNavigation")
                        .WithMany("TbSoportes")
                        .HasForeignKey("IdTipo")
                        .IsRequired()
                        .HasConstraintName("PK_Soporte_Tipo");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdTipoNavigation");
                });

            modelBuilder.Entity("Entities.TbSoporteCliente", b =>
                {
                    b.HasOne("Entities.TbCliente", "IdClienteNavigation")
                        .WithMany("TbSoporteClientes")
                        .HasForeignKey("IdCliente")
                        .IsRequired()
                        .HasConstraintName("FK_SoporteCliente_Cliente");

                    b.HasOne("Entities.TbSoporte", "IdSoporteNavigation")
                        .WithMany("TbSoporteClientes")
                        .HasForeignKey("IdSoporte")
                        .IsRequired()
                        .HasConstraintName("FK_SoporteCliente_Soporte");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdSoporteNavigation");
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

            modelBuilder.Entity("Entities.TbArticulo", b =>
                {
                    b.Navigation("TbDatosCompras");

                    b.Navigation("TbDatosVenta");
                });

            modelBuilder.Entity("Entities.TbCliente", b =>
                {
                    b.Navigation("TbDatosVenta");

                    b.Navigation("TbSoporteClientes");

                    b.Navigation("TbSoportes");
                });

            modelBuilder.Entity("Entities.TbEmpleado", b =>
                {
                    b.Navigation("TbBitacoras");

                    b.Navigation("TbEmpleadoSoportes");

                    b.Navigation("TbSoportes");
                });

            modelBuilder.Entity("Entities.TbProveedor", b =>
                {
                    b.Navigation("TbArticulos");

                    b.Navigation("TbDatosCompras");
                });

            modelBuilder.Entity("Entities.TbRol", b =>
                {
                    b.Navigation("TbEmpleados");
                });

            modelBuilder.Entity("Entities.TbSoporte", b =>
                {
                    b.Navigation("TbEmpleadoSoportes");

                    b.Navigation("TbSoporteClientes");
                });

            modelBuilder.Entity("Entities.TbTipo", b =>
                {
                    b.Navigation("TbSoportes");
                });
#pragma warning restore 612, 618
        }
    }
}
