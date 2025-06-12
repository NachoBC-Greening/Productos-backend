using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NuGet.Protocol;
using System.Text.Json.Serialization;

namespace PedidosAPI.Models
{
    public class Pedido
    {
        public int pedidoId { get; set; }
        public decimal precioTotal { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<LineaPedido>? lineasPedido { get; set; } = new List<LineaPedido>();     
    }

    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entity)
        {
            entity.HasKey(e => e.pedidoId);
            entity.Property(e => e.precioTotal)
                .HasPrecision(10, 2);
        }
    }
}
