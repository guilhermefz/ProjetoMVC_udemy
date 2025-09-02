using ProjetoMVC.Models;
using ProjetoMVC.Models.Dtos;

namespace Projeto_UdemyMVC.Application.Interfaces
{
    public interface IRegistroVendasService
    {
        Task CriarRegistro(RegistroVendasDto registroVendas);
        Task<List<RegistroVendas>> BuscarRegistros();
        Task<RegistroVendas> BuscarRegistroPoridAsync(long id);
        Task DeletarRegistroPorIdAsync(long id);
    }
}
