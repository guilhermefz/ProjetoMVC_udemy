using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models.Interfaces;

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
    }
}
