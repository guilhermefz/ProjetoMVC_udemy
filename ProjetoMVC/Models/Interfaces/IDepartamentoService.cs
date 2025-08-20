namespace ProjetoMVC.Models.Interfaces
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> ListarDepartamentos();
        Task<Departamento> BuscarDepartamentoPorIdAsync(int id);

    }
}
