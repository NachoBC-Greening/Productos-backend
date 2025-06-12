using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PedidosAPI.Models
{
    public class Producto
    {
        public int productoId { get; set; }
        public string nombre { get; set; } = String.Empty;
        public decimal? precio { get; set; } = 0m;
        public decimal? tax { get; set; } = 0;
    }

    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.productoId);
            entity.Property(e => e.nombre)
                .IsRequired(false)
                .HasMaxLength(200);
            entity.Property(e => e.precio)
                .IsRequired(false)
                .HasPrecision(10, 8);
            entity.Property(e => e.tax)
                .IsRequired(false)
                .HasPrecision(10, 8);
        }
    }
}
