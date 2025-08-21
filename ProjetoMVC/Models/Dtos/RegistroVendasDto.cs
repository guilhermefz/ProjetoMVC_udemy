using ProjetoMVC.Models.Enuns;

namespace ProjetoMVC.Models.Dtos
{
    public class RegistroVendasDto
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public double Quantidade { get; set; }
        public StatusVenda Status { get; set; }
        public int VendedorId { get; set; }
        public List<Vendedor> Vendedores { get; set; }
    }
}
