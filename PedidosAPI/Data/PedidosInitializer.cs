using Microsoft.EntityFrameworkCore;
using PedidosAPI.Models;

namespace PedidosAPI.Data
{
    public static class ProductoInitializer
    {
        public static void Seed(ProductContext context)
        {            
            var productos = new List<Producto>
            {
                new Producto{
                    productoId = 1,
                    nombre="Pollo", 
                    precio=4.95m, 
                    tax=21
                },
                new Producto{
                    productoId = 2,
                    nombre="Curry", 
                    precio=1.09m, 
                    tax=21
                },
                new Producto{
                    productoId = 3,
                    nombre="Papel higienico", 
                    precio=1.26m, 
                    tax=3
                }
            };

            context.Producto.AddRange(productos);
            context.SaveChangesAsync();
        }
    }

    public static class LineaPedidoInitializer
    {
        public static void Seed(ProductContext context)
        {
            var productos = context.Producto.FirstOrDefault();
            if (productos == null)
            {
                ProductoInitializer.Seed(context);
            }


            var lineasPedido = new List<LineaPedido>
            {
                new LineaPedido{
                    lineaPedidoId = 1,
                    idPedido=1,
                    producto=new Producto{
                        productoId = 1,
                        nombre="Pollo",
                        precio=4.95m,
                        tax=21
                    },
                    cantidadProductos=3,
                    precioUnitario=4.95m,
                    taxUnitario=21,
                    precioTotalLinea=17.97m
                },
                new LineaPedido{
                    lineaPedidoId = 2,
                    idPedido=1,
                    producto=new Producto{
                        productoId = 2,
                        nombre="Curry",
                        precio=1.09m,
                        tax=21
                    },
                    cantidadProductos=2,
                    precioUnitario=1.09m,
                    taxUnitario=21,
                    precioTotalLinea=2.64m
                },
                new LineaPedido{
                    lineaPedidoId = 3,
                    idPedido=2,
                    producto=new Producto{
                        productoId = 3,
                        nombre="Papel higienico",
                        precio=1.26m,
                        tax=3
                    },
                    cantidadProductos=4,
                    precioUnitario=1.26m,
                    taxUnitario=3,
                    precioTotalLinea=5.19m
                }
            };

            context.LineaPedido.AddRange(lineasPedido);
            context.SaveChangesAsync();
        }
        
    }

    public static class PedidoInitializer
    {
        public static void Seed(ProductContext context)
        {
            var pedidosExist = context.Pedido.FirstOrDefault();
            if (pedidosExist != null)
            {
                Console.WriteLine("Ya extisten pedidos");
            }
            else
            {
                var lineasPedido = context.LineaPedido.FirstOrDefault();
                if (lineasPedido == null)
                {
                    LineaPedidoInitializer.Seed(context);
                }

                var pedidos = new List<Pedido>
                {
                    new Pedido
                    {
                        pedidoId = 1,
                        lineasPedido = new List<LineaPedido> {
                            new LineaPedido {
                                lineaPedidoId = 1,
                                idPedido=1,
                                producto=new Producto{
                                    productoId = 1,
                                    nombre="Pollo",
                                    precio=4.95m,
                                    tax=21
                                },
                                cantidadProductos=3,
                                precioUnitario=4.95m,
                                taxUnitario=21,
                                precioTotalLinea=17.97m
                            },
                            new LineaPedido {
                                lineaPedidoId = 2,
                                idPedido=1,
                                producto=new Producto{
                                    productoId = 2,
                                    nombre="Curry",
                                    precio=1.09m,
                                    tax=21
                                },
                                cantidadProductos=2,
                                precioUnitario=1.09m,
                                taxUnitario=21,
                                precioTotalLinea=2.64m
                            }
                        },
                        precioTotal= 20.61m,
                    },
                    new Pedido
                    {
                        pedidoId = 2,
                        lineasPedido = new List<LineaPedido>
                        {
                            new LineaPedido
                            {
                                lineaPedidoId = 3,
                                idPedido=2,
                                producto=new Producto{
                                    productoId = 3,
                                    nombre="Papel higienico",
                                    precio=1.26m,
                                    tax=3
                                },
                                cantidadProductos=4,
                                precioUnitario=1.26m,
                                taxUnitario=3,
                                precioTotalLinea=5.19m
                            }
                        },
                        precioTotal=5.19m
                    }
                };

                context.Pedido.AddRange(pedidos);
                context.SaveChangesAsync();
            }                
        }
    }
}
