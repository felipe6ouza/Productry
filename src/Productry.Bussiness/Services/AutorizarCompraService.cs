using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Services.Interfaces;
using System.Threading.Tasks;

namespace Productry.Bussiness.Services
{
    public class AutorizarCompraService : IAutorizarCompraService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public AutorizarCompraService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<bool> AutorizarCompra(Pagamento pagamento)
        {
            if (!pagamento.IsValid)
            { 
                return false;
            }

            return await _pagamentoRepository.Adicionar(pagamento);
        }
    }
}
