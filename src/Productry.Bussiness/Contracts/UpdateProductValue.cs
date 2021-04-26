using Flunt.Validations;
using Productry.Bussiness.Models;

namespace Productry.Bussiness.Contracts
{
    public class UpdateProductValue : Contract<Produto>
    {
        public UpdateProductValue(Produto produto)
        {
            Requires()
                .IsGreaterOrEqualsThan(produto.ValorUnitario, 0, "ValorUnitario", "O valor do produto não pode ser menor do que zero.");
        }
    }
}
