using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Dtos;
using ProjetoMVC.Models.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class RegistroVendasController : Controller
    {

        private readonly IRegistroVendasService _registroVendasService;
        private readonly IVendedorService _vendedorService;

        public RegistroVendasController(IRegistroVendasService registroVendasService, IVendedorService vendedorService)
        {
            _registroVendasService = registroVendasService;
            _vendedorService = vendedorService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var regitro = new RegistroVendasDto();
            var vendedores = await _vendedorService.ListarVendedoresAsync();
            regitro.Vendedores = vendedores;

            return View(regitro);
        }

        [HttpPost]
        public IActionResult Create(RegistroVendas registro)
        {
            _registroVendasService.CriarRegistro(registro);
            return RedirectToAction(nameof(Index));
        }
    }
}
