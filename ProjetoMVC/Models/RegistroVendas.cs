using ProjetoMVC.Models.Enuns;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class RegistroVendas : BaseEntity
    {
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly Data { get; set; }
        public double Quantidade { get; set; }
        public StatusVenda Status { get; set; }
        public long VendedorId { get; set; }
        public List<Produto> Produtos { get; set; } 

        public RegistroVendas()
        {
        }

        public RegistroVendas(int id, DateOnly data, double quantidade, StatusVenda status, int vendedor)
        {
            Id = id;
            Data = data;
            Quantidade = quantidade;
            Status = status;
            VendedorId = vendedor;
        }
    }
}
