using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Data;
using ProjetoMVC.Models.Interfaces;

namespace ProjetoMVC.Models.Services
{
    public class RegistroVendasService : IRegistroVendasService
    {
        private readonly ProjetoMVCContext _context;

        public RegistroVendasService(ProjetoMVCContext context)
        {
            context = _context;
        }

        [HttpGet]
        public void CriarRegistro (RegistroVendas registroVendas)
        {
            _context.Add(registroVendas);
            _context.SaveChanges();
        }

        public List<RegistroVendas> BuscarRegistros()
        {
            return _context.RegistroVendas.ToList();
        }
    }
}
