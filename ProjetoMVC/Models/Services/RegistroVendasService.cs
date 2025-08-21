using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models.Dtos;
using ProjetoMVC.Models.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    }
}
