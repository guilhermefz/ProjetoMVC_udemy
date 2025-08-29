namespace ProjetoMVC.Models.Interfaces
{
    public interface IRegistroVendasService
    {
        Task CriarRegistro(RegistroVendas registroVendas);
        Task<List<RegistroVendas>> BuscarRegistros();
        Task<RegistroVendas> BuscarRegistroPoridAsync(long id);
        Task DeletarRegistroPorIdAsync(long id);
    }
}
