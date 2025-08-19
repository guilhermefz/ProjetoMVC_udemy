namespace ProjetoMVC.Models.Dtos
{
    public class VendedorFormularioDto
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
