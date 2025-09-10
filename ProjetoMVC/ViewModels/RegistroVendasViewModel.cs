using Projeto_UdemyMVC.Application.Dtos;
using ProjetoMVC.Models.Enuns;
using System.ComponentModel;

namespace ProjetoMVC.Models.ViewModels
{
    public class RegistroVendasViewModel
    {
        public long Id { get; set; }
        public DateOnly Data { get; set; }
        public StatusVenda Status { get; set; }
        [DisplayName("Quantidade")]
        public double Quantidade { get; set; }
        [DisplayName("Vendedor")]
        public long VendedorId { get; set; }
        [DisplayName("Produto")]
        public long ProdutoId { get; set; }
        public long PedidoId { get; set; }
        public List<Vendedor> Vendedores { get; set; }
        public List<Produto> Produtos { get; set; }

    }
    }
