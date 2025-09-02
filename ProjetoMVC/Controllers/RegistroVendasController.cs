using Microsoft.AspNetCore.Mvc;
using Projeto_UdemyMVC.Application.Interfaces;
using ProjetoMVC.MappersView;
using ProjetoMVC.Models.Dtos;
using ProjetoMVC.Models.ViewModels;
using System.Threading.Tasks;

namespace ProjetoMVC.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly IRegistroVendasService _registroVendasService;
        private readonly IVendedorService _vendedorService;
        private readonly IProdutoService _produtoService;

        public RegistroVendasController(IRegistroVendasService registroVendasService, IVendedorService vendedorService, IProdutoService produtoService)
        {
            _registroVendasService = registroVendasService;
            _vendedorService = vendedorService;
            _produtoService = produtoService;
        }


        public async Task<IActionResult> Index()
        {
            var listaDeVendas = await _registroVendasService.BuscarRegistros();
            var listView = new List<RegistroVendasViewModel>();
            listView = listaDeVendas.MapToView();
            return View(listView);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var regitro = new RegistroVendasViewModel();
            var vendedores = await _vendedorService.ListarVendedoresAsync();
            regitro.Vendedores = vendedores;
            var produtos = await _produtoService.ListarProdutosAsync();
            regitro.Produtos = produtos;
            regitro.Data = DateOnly.FromDateTime(DateTime.Now);
            return View(regitro);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegistroVendasDto registro)
        {
            if (ModelState.IsValid)
            {
                await _registroVendasService.CriarRegistro(registro);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            await _registroVendasService.DeletarRegistroPorIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
