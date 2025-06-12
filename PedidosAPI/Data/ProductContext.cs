using Microsoft.EntityFrameworkCore;
using PedidosAPI.Models;

namespace PedidosAPI.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; } = default!;
        public DbSet<LineaPedido> LineaPedido { get; set; } = default!;
        public DbSet<Pedido> Pedido { get; set; } = default!;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new LineaPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
        }
    }
}
