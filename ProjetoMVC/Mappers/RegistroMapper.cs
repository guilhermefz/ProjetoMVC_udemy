using AutoMapper;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Dtos;

namespace ProjetoMVC.Mappers
{
    public class RegistroMapper : Profile
    {
        public RegistroMapper()
        {
            CreateMap<RegistroVendas, RegistroVendasDto>().ReverseMap();
        }
    }
}
