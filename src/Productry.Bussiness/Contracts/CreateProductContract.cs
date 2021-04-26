using Flunt.Validations;
using Productry.Bussiness.Models;

namespace Productry.Bussiness.Contracts
{
    public class CreateProductContract : Contract<Produto>
    {
        public CreateProductContract(Produto produto)
        {
            Requires()
                .IsLowerThan(produto.QtdeEstoque, 0, "QtdeEstoque", "O estoque não pode ser menor do que zero.")
                .IsLowerThan(produto.ValorUnitario, 0, "ValorUnitario", "O valor do produto não pode ser menor do que zero.")
                .IsNotNullOrWhiteSpace(produto.Nome, "Nome", "Nome Inválido.");
        }
    }
}
