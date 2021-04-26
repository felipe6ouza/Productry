using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Services.Interfaces;
using System.Threading.Tasks;

namespace Productry.Bussiness.Services
{
    public class AutorizarCompraService : BaseService, IAutorizarCompraService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public AutorizarCompraService(IPagamentoRepository pagamentoRepository, INotificador notificador) : base(notificador)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<bool> AutorizarCompra(Pagamento pagamento)
        {
            if (!pagamento.IsValid)
            {
                foreach(var item in  pagamento.Notifications)
                {
                    Notificar(item.Message);
                }

                return false;
            }

            return await _pagamentoRepository.Adicionar(pagamento);
        }
    }
}
