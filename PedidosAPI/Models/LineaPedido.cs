using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PedidosAPI.Models
{
    public class LineaPedido
    {
        public int lineaPedidoId { get; set; }
        public int? idPedido { get; set; }
        public Producto? producto{ get; set; } = new Producto();
        public int cantidadProductos { get; set; } = 0;
        public decimal precioUnitario { get; set; } = 0m;
        public decimal? taxUnitario { get; set; } = 0;
        public decimal? precioTotalLinea { get; set; } = 0m;
    }

    public class LineaPedidoConfiguration : IEntityTypeConfiguration<LineaPedido>
    {
        public void Configure(EntityTypeBuilder<LineaPedido> entity)
        {
            entity.HasKey(e => e.lineaPedidoId);
            entity.Property(e => e.precioUnitario)
                .HasPrecision(10, 2);
            entity.Property(e => e.precioTotalLinea)
                .HasPrecision(10, 2);
        }
    }
}
