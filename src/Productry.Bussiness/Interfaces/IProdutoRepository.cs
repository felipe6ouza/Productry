using Productry.Bussiness.Models;
using System.Threading.Tasks;

namespace Productry.Bussiness.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Compra> ObterUltimaCompra(int ProdutoId);
    }
}
