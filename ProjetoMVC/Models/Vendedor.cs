namespace ProjetoMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroVendas> RegistroVendas { get; set; } = new List<RegistroVendas>();


        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime nascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
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
