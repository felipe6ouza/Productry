using Microsoft.Extensions.Options;
using Productry.Bussiness.Configurations;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Refit;
using System.Threading.Tasks;

namespace Productry.Bussiness.Services
{
    public class CompraService : ICompraService
    {
        private readonly IComprasRepository _comprasRepository;
        private readonly IProdutoRepository _produtoRepository;

        private readonly string _autorizadorBaseHostUrl;
        public CompraService(IComprasRepository comprasRepository, IProdutoRepository produtoRepository,
            IOptions<ConexaoGateway> autorizadorBaseHostUrl)
        {
            _comprasRepository = comprasRepository;
            _autorizadorBaseHostUrl = autorizadorBaseHostUrl.Value.BaseUrlHost;
            _produtoRepository = produtoRepository;
        }
        public async Task<bool> RealizarCompra(Compra compra)
        {
            var produto = await _produtoRepository.ObterPorId(compra.ProdutoId);

            if (produto == null)
                return false;

            var valor = produto.ValorUnitario * compra.QtdeComprada;
            var pagamento = new Pagamento(valor, compra.Cartao);

            if (!pagamento.IsValid)
                return false;

            var client = RestService.For<IRestAutorizador>(_autorizadorBaseHostUrl);

            var response = await client.AutorizarCompra(pagamento);

            if (!response.Success)
                return false;

            return await _comprasRepository.Adicionar(compra);
            
        }
    }
}
