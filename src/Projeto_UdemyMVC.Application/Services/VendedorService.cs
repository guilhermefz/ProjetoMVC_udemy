using Microsoft.EntityFrameworkCore;
using Projeto_UdemyMVC.Application.Interfaces;
using ProjetoMVC.Data;

namespace ProjetoMVC.Models.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly ProjetoMVCContext _context;

        public VendedorService(ProjetoMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> ListarVendedoresAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }
        public async Task CriarVendedores(Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscarVendedorPorId(long id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task Excluir(long id)
        {
            var vendedor = await BuscarVendedorPorId(id);
            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();
        }

        public void Atualizar(Vendedor obj)
        {
            if (!_context.Vendedor.Any(x => x.Id == obj.Id))
            {
                throw new KeyNotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

    }
}
