namespace ProjetoMVC.Models
{
    public class Departamento : BaseEntity
    {
        public string Nome{ get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendas(DateOnly inicio, DateOnly fim)
        {
            return Vendedores.Sum(v => v.TotalVendas(inicio, fim));
        }

    }
}
