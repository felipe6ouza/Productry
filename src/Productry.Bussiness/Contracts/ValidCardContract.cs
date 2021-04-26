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
            var data = DateTime.ParseExact(cartao.DataExpiracao,
                        "dd-MM-yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));

            Requires()
                .IsCreditCard(cartao.Numero, "Numero", "Cartão de Crédito Inválido.")
                .IsNotNullOrEmpty(cartao.Titular, "Titular", "Nome do Titular Inválido.")
                .IsGreaterThan(data,
                         DateTime.Today,
                        "DataExpiracao",
                        "Cartão expirado.");
        }
    }
}
