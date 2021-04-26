using System.Threading.Tasks;

namespace Productry.Bussiness.Interfaces
{
    public interface IEstoqueService
    {
        Task<bool> AlterarEstoque(int produtoId, int quantidade);
     
    }
}
