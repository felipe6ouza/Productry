using Productry.Bussiness.Models;
using System.Threading.Tasks;

namespace Productry.Services.Interfaces
{
    public interface IAutorizarCompraService
    {
        Task<bool> AutorizarCompra(Pagamento pagamento);
    }
}
