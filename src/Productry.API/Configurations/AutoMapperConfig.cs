using AutoMapper;
using Productry.API.ViewModels;
using Productry.Bussiness.Models;

namespace Productry.API.Configurations
{
    public class BusinessEntityToViewModel : Profile
    {
        public BusinessEntityToViewModel()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Cartao, CartaoViewModel>();
            CreateMap<Compra, CompraViewModel>();
        }

    public class ViewModelToBusinessEntity : Profile
    {
        public ViewModelToBusinessEntity()
        {
            CreateMap<ProdutoViewModel, Produto>()
                    .ConstructUsing(p=> new Produto(p.Nome, p.ValorUnitario, p.QtdeEstoque));

            CreateMap<CartaoViewModel, Cartao>()
                   .ConstructUsing(c => new Cartao(c.Titular, c.Numero, c.DataExpiracao, c.Bandeira,c.Cvv));

            CreateMap<CompraViewModel, Compra>()
                   .ConstructUsing(c => new Compra(c.ProdutoId, c.QtdeComprada, c.Cartao));
        }
    }
}
