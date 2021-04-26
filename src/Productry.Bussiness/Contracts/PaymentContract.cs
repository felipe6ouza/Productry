using Flunt.Validations;
using Productry.Bussiness.Models;

namespace Productry.Bussiness.Contracts
{
    public class PaymentContract : Contract<Pagamento>
    {
        public PaymentContract(Pagamento pagamento)
        {
            Requires()
                .IsGreaterThan(pagamento.Valor, 100, "Valor", "Pagamento Recusado.");
        }
    }
}
