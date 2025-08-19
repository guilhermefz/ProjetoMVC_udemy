namespace ProjetoMVC.Models.Interfaces
{
    public interface IDepartamentoService
    {
        List<Departamento> ListarDepartamentos();
        Task<Departamento> BuscarDepartamentoPorIdAsync(int id);

    }
}
