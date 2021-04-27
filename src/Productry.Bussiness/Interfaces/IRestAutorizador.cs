using Productry.Bussiness.Models;
using Productry.Bussiness.Services.Reponses;
using Refit;
using System.Threading.Tasks;

namespace Productry.Bussiness.Interfaces
{
    public interface IRestAutorizador
    {
        [Post("/compras")]
        Task <AutorizarCompraResponse> AutorizarCompra(Pagamento pagamento); 
    }
}
