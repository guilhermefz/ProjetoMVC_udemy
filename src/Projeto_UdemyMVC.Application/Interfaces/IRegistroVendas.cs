using ProjetoMVC.Models;

namespace Projeto_UdemyMVC.Domain.Interfaces
{
    public interface IRegistroVendasRepository
    {
        Task CriarRegistroVendaAsync(RegistroVendas registro);
        Task CriarPedidoItensAsync(RegistroVendasItens itens);
    }
}
