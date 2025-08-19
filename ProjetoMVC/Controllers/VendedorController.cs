using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Dtos;
using ProjetoMVC.Models.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class VendedorController : Controller
    {
        private readonly IVendedorService _vendedorService;
        private readonly IDepartamentoService _departamentoService;

        public VendedorController(IVendedorService vendedorService, IDepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _vendedorService.ListarVendedoresAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departamentos = _departamentoService.ListarDepartamentos();
            var viewModel = new VendedorFormularioDto { Departamentos = departamentos };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            await _vendedorService.CriarVendedores(vendedor);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendedorService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Detalhes(int? id)
        {
            if(id == null){
                NotFound(); }

            var vend = await _vendedorService.BuscarVendedorPorId(id.Value);
            if(vend == null)
            {
                return NotFound();
            }
            return View(vend);
        }

    }
}
