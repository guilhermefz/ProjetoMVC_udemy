namespace ProjetoMVC.Models.Interfaces
{
    public interface IProdutoService
    {
        Task CriarProduto(Produto produto);
        Task<List<Produto>> ListarProdutosAsync();
        Task DeletarProdutoPOrId(long id);
        Task<Produto> BuscarProdutoPorId(long id);
    }
}
