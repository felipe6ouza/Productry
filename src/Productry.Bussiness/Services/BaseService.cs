using Productry.Bussiness.Handlers;
using Productry.Bussiness.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Productry.Bussiness.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

    }
}
