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
        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.ListarDepartamentos();
            var viewModel = new VendedorFormularioDto { Departamentos = departamentos };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if(vendedor.Id == 0 || vendedor.Email == null || vendedor.SalarioBase == 0)
            {
                return BadRequest("Vendedor não pode ser nulo.");
            }
            var departamento = await _departamentoService.BuscarDepartamentoPorIdAsync(vendedor.DepartamentoId);
            vendedor.Departamento = departamento;

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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vendedor = _vendedorService.BuscarVendedorPorId(id.Value).Result;
            if (vendedor == null)
            {
                return NotFound();
            }
            var departamentos = await _departamentoService.ListarDepartamentos();
            var viewModel = new VendedorFormularioDto
            {
                Vendedor = vendedor,
                Departamentos = departamentos
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return NotFound();
            }
            try
            {
                _vendedorService.Atualizar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            ;
        }

    }
}
