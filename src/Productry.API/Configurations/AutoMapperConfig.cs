using AutoMapper;
using Productry.API.ViewModels;
using Productry.Bussiness.Models;

namespace Productry.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            
        }
    }
}
