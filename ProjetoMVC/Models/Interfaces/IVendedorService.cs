namespace ProjetoMVC.Models.Interfaces
{
    public interface IVendedorService
    {
        Task<List<Vendedor>> ListarVendedoresAsync();

        Task CriarVendedores(Vendedor vendedor);
        Task Excluir(int id);
        Task<Vendedor> BuscarVendedorPorId(int id);
    }
}
