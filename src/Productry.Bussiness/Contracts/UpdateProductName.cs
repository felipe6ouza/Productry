using Flunt.Validations;
using Productry.Bussiness.Models;

namespace Productry.Bussiness.Contracts
{
    public class UpdateProductName : Contract<Produto>
    {
        public UpdateProductName(Produto produto)
        {
            Requires()
                .IsNotNullOrWhiteSpace(produto.Nome, "Nome", "Nome Inválido.");
        }
    }
}
