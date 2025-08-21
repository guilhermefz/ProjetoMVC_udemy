using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public long QuantidadeEstoque { get; set; }
    }
}
