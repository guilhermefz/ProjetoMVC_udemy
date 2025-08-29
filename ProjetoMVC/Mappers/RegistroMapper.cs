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
                Quantidade = request.Quantidade,
                Status = request.Status,
                VendedorId = request.VendedorId
            };
        }
    }
}
