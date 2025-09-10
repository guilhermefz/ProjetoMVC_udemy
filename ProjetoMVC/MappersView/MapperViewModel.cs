using ProjetoMVC.Models;
using ProjetoMVC.Models.ViewModels;

namespace ProjetoMVC.MappersView
{
    public static class MapperViewModel
    {
        public static List<RegistroVendasViewModel> MapToView(this List<RegistroVendas> request)
        {
            return request.Select(request => new RegistroVendasViewModel
            {
                Id = request.Id,
                Data = request.Data,
                Status = request.Status,
                VendedorId = request.VendedorId
            }).ToList();
        }
    }
}

