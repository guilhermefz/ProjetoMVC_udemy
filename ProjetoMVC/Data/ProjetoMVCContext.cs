using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Models;

namespace ProjetoMVC.Data
{
    public class ProjetoMVCContext : DbContext
    {
        public ProjetoMVCContext (DbContextOptions<ProjetoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Vendedor> Vendedor { get; set; }

        public DbSet<RegistroVendas> RegistroVendas { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<RegistroVendasItens> PedidoItens {  get; set; }

    }
}
