using ProjetoMVC.Models.Enuns;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly Data { get; set; }
        public double Quantidade { get; set; }
        public StatusVenda Status { get; set; }
        public int VendedorId { get; set; }

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
