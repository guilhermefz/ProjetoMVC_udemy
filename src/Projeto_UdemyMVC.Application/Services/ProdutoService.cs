using Microsoft.EntityFrameworkCore;
using Projeto_UdemyMVC.Application.Interfaces;
using ProjetoMVC.Data;

namespace ProjetoMVC.Models.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProjetoMVCContext _context;

        public ProdutoService(ProjetoMVCContext context)
        {
            _context = context;
        }

        public async Task CriarProduto(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> ListarProdutosAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Produto> BuscarProdutoPorId(long id)
        {
            var produto = await _context.Produto.FirstOrDefaultAsync(c => c.Id ==id);
            return produto;
        }
        public async Task DeletarProdutoPOrId(long id)
        {
            var produto = await BuscarProdutoPorId(id);
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
