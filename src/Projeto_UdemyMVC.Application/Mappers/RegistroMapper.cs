using ProjetoMVC.Models;
using ProjetoMVC.Models.Dtos;
using ProjetoMVC.Models.Enuns;

namespace ProjetoMVC.Mappers
{
    public static class RegistroMapper
    {
        public static RegistroVendas MapToRegistro(this RegistroVendasDto request)
        {
            return new RegistroVendas
            {
                Data = request.Data,
                Status = request.Status,
                VendedorId = request.VendedorId,
                PedidoItensId = request.PedidoItensId,
                RegistroPedidoItens = request.Itens,
            };
        }

        public static RegistroVendasItens MapToItens(this RegistroVendasDto request)
        {
            return new RegistroVendasItens
            {
                ProdutoId = request.ProdutoId,
                Quantidade = request.Quantidade,
                RegistroVendasId = request.RegistroVendaId,
            };
        }

    }
}
