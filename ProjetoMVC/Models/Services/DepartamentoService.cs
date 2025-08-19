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

        public List<Departamento> ListarDepartamentos()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }

        public async Task<Departamento> BuscarDepartamentoPorIdAsync(int id)
        {
            return await _context.Departamento.FirstOrDefaultAsync(c => c.Id == id);
            
        }
    }
}
