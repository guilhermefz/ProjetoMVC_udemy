using ProjetoMVC.Models.Enuns;
using System.ComponentModel;

namespace ProjetoMVC.Models.ViewModels
{
    public class RegistroVendasViewModel
    {
        public long Id { get; set; }
        public DateOnly Data { get; set; }
        public StatusVenda Status { get; set; }
        public double Quantidade { get; set; }
        [DisplayName("ID Do Vendedor")]
        public long VendedorId { get; set; }
        public long ProdutoId { get; set; }
        [DisplayName("ID Do Pedido")]
        public long PedidoId { get; set; }
        public List<Vendedor> Vendedores { get; set; }
        public List<Produto> Produtos { get; set; }
        [DisplayName("Produtos")]
        public ICollection<RegistroVendasItens>? RegistroVendasItens { get; set; }

    }
    }
