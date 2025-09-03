using ProjetoMVC.Models;
using ProjetoMVC.Models.Dtos;

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
                Quantidade = request.Quantidade,
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
