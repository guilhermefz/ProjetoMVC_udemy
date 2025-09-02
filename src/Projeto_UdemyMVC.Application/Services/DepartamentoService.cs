using Microsoft.EntityFrameworkCore;
using Projeto_UdemyMVC.Application.Interfaces;
using ProjetoMVC.Data;

namespace ProjetoMVC.Models.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly ProjetoMVCContext _context;

        public DepartamentoService(ProjetoMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> ListarDepartamentos()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Departamento> BuscarDepartamentoPorIdAsync(long id)
        {
            return await _context.Departamento.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task DeletarPorIdAsync(long id)
        {
            var departamento = await BuscarDepartamentoPorIdAsync(id);
            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();

        }
    }
}
