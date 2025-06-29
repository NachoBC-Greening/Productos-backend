﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PedidosAPI.Data;

#nullable disable

namespace PedidosAPI.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PedidosAPI.Models.LineaPedido", b =>
                {
                    b.Property<int>("lineaPedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lineaPedidoId"));

                    b.Property<int>("cantidadProductos")
                        .HasColumnType("int");

                    b.Property<int?>("idPedido")
                        .HasColumnType("int");

                    b.Property<int?>("pedidoId")
                        .HasColumnType("int");

                    b.Property<decimal?>("precioTotalLinea")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("precioUnitario")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("productoId")
                        .HasColumnType("int");

                    b.Property<decimal?>("taxUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("lineaPedidoId");

                    b.HasIndex("pedidoId");

                    b.HasIndex("productoId");

                    b.ToTable("LineaPedido");
                });

            modelBuilder.Entity("PedidosAPI.Models.Pedido", b =>
                {
                    b.Property<int>("pedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pedidoId"));

                    b.Property<decimal>("precioTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("pedidoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("PedidosAPI.Models.Producto", b =>
                {
                    b.Property<int>("productoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productoId"));

                    b.Property<string>("nombre")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("precio")
                        .HasPrecision(10, 8)
                        .HasColumnType("decimal(10,8)");

                    b.Property<decimal?>("tax")
                        .HasPrecision(10, 8)
                        .HasColumnType("decimal(10,8)");

                    b.HasKey("productoId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("PedidosAPI.Models.LineaPedido", b =>
                {
                    b.HasOne("PedidosAPI.Models.Pedido", null)
                        .WithMany("lineasPedido")
                        .HasForeignKey("pedidoId");

                    b.HasOne("PedidosAPI.Models.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoId");

                    b.Navigation("producto");
                });

            modelBuilder.Entity("PedidosAPI.Models.Pedido", b =>
                {
                    b.Navigation("lineasPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
