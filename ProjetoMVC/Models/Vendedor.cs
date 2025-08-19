using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateOnly Nascimento { get; set; }
        public double SalarioBase { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroVendas> RegistroVendas { get; set; } = new List<RegistroVendas>();


        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateOnly nascimento, double salarioBase, Departamento departamento)
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

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return RegistroVendas.Where(rv => rv.Data >= inicio && rv.Data <= fim)
                                 .Sum(rv => rv.Quantidade);
        }
    }
}
