using Projeto_UdemyMVC.Application.Dtos;
using ProjetoMVC.Models.Enuns;

namespace ProjetoMVC.Models.Dtos
{
    public class RegistroVendasDto
    {
        #region Criar Registro
        public DateOnly Data { get; set; }
        public StatusVenda Status { get; set; }
        public long VendedorId { get; set; }
        public long PedidoItensId { get; set; }
        public ICollection<ItensDto>? Itens { get; set; }
        #endregion

        #region Criar Pedido Itens
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public long RegistroVendaId { get; set; }
        #endregion
    }
}
