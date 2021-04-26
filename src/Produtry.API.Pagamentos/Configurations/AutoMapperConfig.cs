using AutoMapper;
using Productry.Bussiness.Models;
using Produtry.API.Pagamentos.ViewModels;

namespace Produtry.API.Pagamentos.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
          
            CreateMap<CartaoViewModel, Cartao>()
                   .ConstructUsing(c => new Cartao(c.Titular, c.Numero, c.DataExpiracao, c.Bandeira, c.Cvv));
            
            CreateMap<PagamentoViewModel, Pagamento>()
                  .ConstructUsing(c => new Pagamento(c.Valor, 
                  new Cartao(c.Cartao.Titular, c.Cartao.Numero, c.Cartao.DataExpiracao, c.Cartao.Bandeira, c.Cartao.Cvv)));


            CreateMap<Cartao, CartaoViewModel>();

            CreateMap<Pagamento, PagamentoViewModel>();

        }
    }
}
