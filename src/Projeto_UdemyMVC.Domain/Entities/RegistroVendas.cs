using ProjetoMVC.Models.Enuns;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class RegistroVendas : BaseEntity
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly Data { get; set; }
        public StatusVenda Status { get; set; }
        public long VendedorId { get; set; }
        public long PedidoItensId { get; set; }
        public ICollection<RegistroVendasItens>? RegistroPedidoItens { get; set; }

        public RegistroVendas()
        {
        }

        public RegistroVendas(long id, DateOnly data, StatusVenda status, long vendedor)
        {
            Id = id;
            Data = data;
            Status = status;
            VendedorId = vendedor;
        }
        public RegistroVendas( DateOnly data, StatusVenda status, long vendedor)
        {
            Data = data;
            Status = status;
            VendedorId = vendedor;
        }
    }
}
