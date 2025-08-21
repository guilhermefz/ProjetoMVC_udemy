using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _produtoService.ListarProdutos();
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            await _produtoService.CriarProduto(produto);
            return RedirectToAction("Index");
        }
    }
}
