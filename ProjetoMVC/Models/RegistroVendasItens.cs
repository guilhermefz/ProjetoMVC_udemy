namespace ProjetoMVC.Models
{
    public class RegistroVendasItens : BaseEntity
    {
        public long ProdutoId { get; set; }
        public long RegistroVendaId { get; set; }
    }
}
