using ProjetoMVC.Models.Dtos;

namespace ProjetoMVC.Models.Interfaces
{
    public interface IRegistroVendasService
    {
        Task CriarRegistro(RegistroVendas registroVendas);
        Task<List<RegistroVendas>> BuscarRegistros();
    }
}
