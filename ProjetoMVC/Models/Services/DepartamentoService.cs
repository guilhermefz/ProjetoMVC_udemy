using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models.Interfaces;

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
    }
}
