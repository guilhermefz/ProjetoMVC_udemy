namespace ProjetoMVC.Models.Interfaces
{
    public interface IProdutoService
    {
        Task CriarProduto(Produto produto);
        Task<List<Produto>> ListarProdutos();
    }
}
