using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models.Interfaces;

namespace ProjetoMVC.Models.Services
{
    public class RegistroVendasService : IRegistroVendasService
    {
        private readonly ProjetoMVCContext _context;
        private readonly IVendedorService _vendedorService;

        public RegistroVendasService(ProjetoMVCContext context, IVendedorService vendedorService)
        {
            _context = context;
            _vendedorService = vendedorService;
        }

        
        public async Task CriarRegistro (RegistroVendas registroVendas)
        {
            _context.Add(registroVendas);
            _context.SaveChanges();
        }

        public async  Task<List<RegistroVendas>> BuscarRegistros()
        {
            return await _context.RegistroVendas.ToListAsync();
        }

        public async Task<RegistroVendas> BuscarRegistroPoridAsync(long id)
        {
            var registro = await _context.RegistroVendas.FirstOrDefaultAsync(c => c.Id == id);
            return registro;
        }

        public async Task DeletarRegistroPorIdAsync(long id)
        {
            var registro = await BuscarRegistroPoridAsync(id);
            _context.Remove(registro);
            await _context.SaveChangesAsync();
        }
    }
}
