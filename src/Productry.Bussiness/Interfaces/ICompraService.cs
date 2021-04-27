using Productry.Bussiness.Models;
using System.Threading.Tasks;

namespace Productry.Bussiness.Interfaces
{
    public interface ICompraService
    {
        Task<bool> RealizarCompra(Compra compra);
    }
}
