using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models.Dtos
{
    public class VendedorDtos
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public double? SalarioBase { get; set; }
        public int DepartamentoId { get; set; }
    }
}
