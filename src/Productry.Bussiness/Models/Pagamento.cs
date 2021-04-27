using Productry.Bussiness.Contracts;

namespace Productry.Bussiness.Models
{
    public class Pagamento : Entity
    {
        public Pagamento(decimal valor, Cartao cartao)
        {
            Valor = valor;
            Cartao = cartao;

            AddNotifications(new ValidCardContract(this.Cartao), new PaymentContract(this));
        }

        private Pagamento (decimal valor)
        {
            Valor = valor;
        }
        public int CartaoId { get; set; }

        public decimal Valor { get; set; }
        public Cartao Cartao { get; set; }
        protected bool Aprovado => IsValid;


    }
}
