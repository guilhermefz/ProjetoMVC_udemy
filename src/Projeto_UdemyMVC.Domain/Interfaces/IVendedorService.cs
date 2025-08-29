namespace ProjetoMVC.Models.Interfaces
{
    public interface IVendedorService
    {
        Task<List<Vendedor>> ListarVendedoresAsync();

        Task CriarVendedores(Vendedor vendedor);
        Task Excluir(long id);
        Task<Vendedor> BuscarVendedorPorId(long id);

        void Atualizar(Vendedor obj);
    }
}
