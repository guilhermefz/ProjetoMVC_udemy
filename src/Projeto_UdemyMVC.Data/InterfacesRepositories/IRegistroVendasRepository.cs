using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_UdemyMVC.Infra.InterfacesRepositories
{
    public interface IRegistroVendasRepository
    {
        Task CriarRegistroVendaAsync(RegistroVendas registro);
        Task CriarPedidoItensAsync(RegistroVendasItens itens);
        Task<List<RegistroVendas>> ListarAsync();

    }
}
