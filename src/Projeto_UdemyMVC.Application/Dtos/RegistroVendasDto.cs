using ProjetoMVC.Models.Enuns;

namespace ProjetoMVC.Models.Dtos
{
    public class RegistroVendasDto
    {
        public long Id { get; set; }
        public DateOnly Data { get; set; }
        public double Quantidade { get; set; }
        public StatusVenda Status { get; set; }
        public long VendedorId { get; set; }
        public long ProdutoId { get; set; }
        public long ItensPedidoId { get; set; }
        public List<Vendedor> Vendedores { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<ItemVendaDto> Itens { get; set; }

    }
    }
