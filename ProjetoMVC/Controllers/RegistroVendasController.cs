using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class RegistroVendasController : Controller
    {

        private readonly IRegistroVendasService _registroVendasService;

        public RegistroVendasController(IRegistroVendasService registroVendasService)
        {
            _registroVendasService = registroVendasService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegistroVendas registro)
        {
            _registroVendasService.CriarRegistro(registro);
            return RedirectToAction(nameof(Index));
        }
    }
}
