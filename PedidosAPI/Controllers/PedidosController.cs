using Microsoft.EntityFrameworkCore;
using PedidosAPI.Data;
using PedidosAPI.Models;

namespace PedidosAPI.Controllers
{
    public class PedidosController
    {
        private readonly ProductContext _context;
        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _context.Pedido.ToListAsync();
        }
    }
}
