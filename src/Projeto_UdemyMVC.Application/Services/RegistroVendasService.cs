using Microsoft.EntityFrameworkCore;
using Projeto_UdemyMVC.Application.Interfaces;
using Projeto_UdemyMVC.Infra.InterfacesRepositories;
using ProjetoMVC.Data;
using ProjetoMVC.Mappers;
using ProjetoMVC.Models.Dtos;

namespace ProjetoMVC.Models.Services
{
    public class RegistroVendasService : IRegistroVendasService
    {
        private readonly ProjetoMVCContext _context;
        private readonly IVendedorService _vendedorService;
        private readonly IRegistroVendasRepository _registroVendasRepository;

        public RegistroVendasService(ProjetoMVCContext context, IVendedorService vendedorService, IRegistroVendasRepository registroVendasRepository)
        {
            _context = context;
            _vendedorService = vendedorService;
            _registroVendasRepository = registroVendasRepository;
        }

        
        public async Task CriarRegistro(RegistroVendasDto registroVendas)
        {
            var registroEntity = registroVendas.MapToRegistro();
            registroEntity.RegistroPedidoItens = new List<RegistroVendasItens>();

            //foreach (var item in registroVendas.Itens)
            //{
            //    registroVendas.Quantidade = item.Quantidade;
            //    registroVendas.ProdutoId = item.ProdutoId;
            //}


            foreach (var item in registroVendas.Itens)
            {
                var registroVendasItem = new RegistroVendasItens
                {
                    Quantidade = item.Quantidade,
                    ProdutoId = item.ProdutoId,

                };
                registroEntity.RegistroPedidoItens.Add(registroVendasItem);
            }

            //var registroVenda = registroVendas.MapToRegistro();
            await _registroVendasRepository.CriarRegistroVendaAsync(registroEntity);
        }

        public async  Task<List<RegistroVendas>> BuscarRegistros()
        {
            var lista = await _registroVendasRepository.ListarAsync();
            return lista;
        }

        public async Task<RegistroVendas> BuscarRegistroPoridAsync(long id)
        {
            var registro = await _context.RegistroVendas.FirstOrDefaultAsync(c => c.Id == id);
            return registro;
        }

        public async Task DeletarRegistroPorIdAsync(long id)
        {
            var registro = await BuscarRegistroPoridAsync(id);
            _context.Remove(registro);
            await _context.SaveChangesAsync();
        }
    }
}
