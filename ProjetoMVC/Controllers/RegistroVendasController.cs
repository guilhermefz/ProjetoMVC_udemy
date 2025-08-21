using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Dtos;
using ProjetoMVC.Models.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRegistroVendasService _registroVendasService;
        private readonly IVendedorService _vendedorService;

        public RegistroVendasController(IRegistroVendasService registroVendasService, IVendedorService vendedorService, IMapper mapper)
        {
            _registroVendasService = registroVendasService;
            _vendedorService = vendedorService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var listaDeVendas = await _registroVendasService.BuscarRegistros();
            return View(listaDeVendas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var regitro = new RegistroVendasDto();
            var vendedores = await _vendedorService.ListarVendedoresAsync();
            regitro.Vendedores = vendedores;
            regitro.Data = DateOnly.FromDateTime(DateTime.Now);
            return View(regitro);
        }

        [HttpPost]
        public IActionResult Create(RegistroVendasDto registro)
        {
            var registroMapper = _mapper.Map<RegistroVendas>(registro);
            _registroVendasService.CriarRegistro(registroMapper);
            return RedirectToAction(nameof(Index));
        }
    }
}
