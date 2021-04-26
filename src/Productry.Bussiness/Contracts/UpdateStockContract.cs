using Flunt.Validations;
using Productry.Bussiness.Models;

namespace Productry.Bussiness.Contracts
{
    public class UpdateStockContract : Contract<Produto>
    {
        public UpdateStockContract(Produto produto)
        {
            Requires()
                .IsGreaterOrEqualsThan(produto.QtdeEstoque, 0, "QtdeEstoque", "O estoque não pode ser menor do que zero.");
        }
    }
}
