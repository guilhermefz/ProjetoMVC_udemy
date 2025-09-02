using ProjetoMVC.Models;

namespace Projeto_UdemyMVC.Application.Interfaces
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> ListarDepartamentos();
        Task<Departamento> BuscarDepartamentoPorIdAsync(long id);

    }
}
