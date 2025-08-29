using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class Vendedor : BaseEntity
    {

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 60 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email deve ser um endereço de email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Ta errado")]
        public DateOnly? Nascimento { get; set; }
        [Range(100.0, 100000.0, ErrorMessage = "O salário deve estar entre R$ 100,00 e R$ 100.000,00")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "O salário é obrigatório")]
        public double? SalarioBase { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Ta errado")]
        public long DepartamentoId { get; set; }
        public Departamento Departamento { get; set; } 
        public ICollection<RegistroVendas> RegistroVendas { get; set; } = new List<RegistroVendas>();


        public Vendedor()
        {
        }

        public Vendedor(long id, string nome, string email, DateOnly nascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }
        public Vendedor(string nome, string email, DateOnly nascimento, double salarioBase)
        {
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            SalarioBase = salarioBase;
        }

        public void AddRegistroVendas(RegistroVendas registroVendas)
        {
            RegistroVendas.Add(registroVendas);
        }

        public void RemoveRegistroVendas(RegistroVendas registroVendas)
        {
            RegistroVendas.Remove(registroVendas);
        }

        public double TotalVendas(DateOnly inicio, DateOnly fim)
        {
            return RegistroVendas.Where(rv => rv.Data >= inicio && rv.Data <= fim)
                                 .Sum(rv => rv.Quantidade);
        }
    }
}
