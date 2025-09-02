
using Microsoft.EntityFrameworkCore;
using Projeto_UdemyMVC.Infra.InterfacesRepositories;
using ProjetoMVC.Data;
using ProjetoMVC.Models;


namespace Projeto_UdemyMVC.Data.Repositories
{
    public class RegistroVendasRepository : IRegistroVendasRepository
    {
        private readonly ProjetoMVCContext _context;

        public RegistroVendasRepository(ProjetoMVCContext context)
        {
            _context = context;
        }
        public async Task CriarRegistroVendaAsync(RegistroVendas registro)
        {
            await _context.AddAsync(registro);
            await _context.SaveChangesAsync();
        }

        public async Task CriarPedidoItensAsync(RegistroVendasItens itens)
        {
            await _context.AddAsync(itens);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RegistroVendas>> ListarAsync()
        {
            return await _context.RegistroVendas.ToListAsync();
        }
    }
}
