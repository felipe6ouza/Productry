using Productry.Bussiness.Handlers;
using System.Collections.Generic;

namespace Productry.Bussiness.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
