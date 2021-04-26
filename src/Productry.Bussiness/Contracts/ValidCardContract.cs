using Flunt.Validations;
using Productry.Bussiness.Models;
using System;
using System.Globalization;

namespace Productry.Bussiness.Contracts
{
    public class ValidCardContract : Contract<Cartao>
    {
        public ValidCardContract(Cartao cartao)
        {
            Requires()
                .IsCreditCard(cartao.Numero, "Numero", "Cartão de Crédito Inválido.")
                .IsNotNullOrEmpty(cartao.Titular, "Titular", "Nome do Titular Inválido.")
                .IsGreaterThan(DateTime.ParseExact(cartao.DataExpiracao,
                        "dd-MM-yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
                         DateTime.Now,
                        "DataExpiracao",
                        "Cartão expirado.");
        }
    }
}
