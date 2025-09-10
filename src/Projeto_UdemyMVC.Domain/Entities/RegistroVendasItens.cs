using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    public class RegistroVendasItens : BaseEntity
    {
        public long ProdutoId { get; set; }
        public long RegistroVendasId { get; set; }
        public int Quantidade { get; set; }
        public RegistroVendas? RegistroVendas { get; set; }
    }
}
