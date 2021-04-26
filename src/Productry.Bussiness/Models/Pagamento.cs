using Productry.Bussiness.Contracts;

namespace Productry.Bussiness.Models
{
    public class Pagamento : Entity
    {
        public Pagamento(double valor, Cartao cartao)
        {
            Valor = valor;
            Cartao = cartao;

            AddNotifications(new ValidCardContract(this.Cartao), new PaymentContract(this));
        }

        public int CartaoId { get; set; }

        public double Valor { get; set; }
        public Cartao Cartao { get; set; }
        protected bool Aprovado => IsValid;


    }
}
